using DataAccsessLayer.Abstract.Integrations;
using DataAccsessLayer.Concrete.UoW;
using EntityLayer.Concrete;
using Microsoft.Extensions.DependencyInjection;
using Opc.Ua;
using Opc.Ua.Client;


namespace DataAccsessLayer.Concrete.Repository.Integrations
{
    public class OpcUaPlcReader : IPlcReader, IAsyncDisposable
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly Dictionary<int, Session> _sessions = new();

        public OpcUaPlcReader(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;

        }

        private async Task<Session> EnsureConnectedAsync(DB_PlcMachine machine)
        {
            try
            {
                if (_sessions.TryGetValue(machine.RecId, out var existing) && existing.Connected)
                    return existing;

                if (existing == null) return null;
                try
                {
                    if (existing.Connected) existing.Close();
                }
                catch { /* zaten kopmuşsa Close de hata verebilir, yok say */ }
                finally
                {
                    existing.Dispose();
                    _sessions.Remove(machine.RecId);
                }

                var appConfig = new ApplicationConfiguration
                {
                    ApplicationName = "AquaBusinessTracking",
                    ApplicationType = ApplicationType.Client,
                    SecurityConfiguration = new SecurityConfiguration
                    {
                        ApplicationCertificate = new CertificateIdentifier
                        {
                            StoreType = "Directory",
                            StorePath = "CertificateStores/MachineDefault",
                            SubjectName = "CN=AquaBusinessTracking"
                        },
                        AutoAcceptUntrustedCertificates = true,
                        AddAppCertToTrustedStore = true
                    },
                    TransportConfigurations = new TransportConfigurationCollection(),
                    TransportQuotas = new TransportQuotas
                    {
                        OperationTimeout = 10000
                    },
                    ClientConfiguration = new ClientConfiguration
                    {
                        DefaultSessionTimeout = 60000
                    }
                };

                await appConfig.Validate(ApplicationType.Client);

                var endpoint = machine.IpAddress.StartsWith("opc.tcp://")
                    ? machine.IpAddress
                    : $"opc.tcp://{machine.IpAddress}:4863";

                var selectedEndpoint = CoreClientUtils.SelectEndpoint(endpoint, false);

                var endpointConfig = EndpointConfiguration.Create(appConfig);
                var configuredEndpoint = new ConfiguredEndpoint(null, selectedEndpoint, endpointConfig);

                var session = await Session.Create(
                    appConfig,
                    configuredEndpoint,
                    false,
                    $"AquaSession_{machine.RecId}",
                    60000,
                    new UserIdentity(new AnonymousIdentityToken()),
                    null);


                session.KeepAlive += (s, e) =>
                {
                    if (e.Status != null && ServiceResult.IsNotGood(e.Status))
                    {
                        Console.WriteLine($"[KeepAlive] Session koptu [MachineId={machine.RecId}]: {e.Status}");
                    }
                };

                _sessions[machine.RecId] = session;

                return session;
            }
            catch (Exception ex)
            {
                // Debug için
                Console.WriteLine(ex.ToString());

                // Logger kullanıyorsan
                //_logger.LogError(ex, "PLC bağlantı hatası. IP: {Ip}", machine?.IpAddress);

                throw new Exception(
                    $"PLC bağlantısı kurulamadı.\n" +
                    $"IP: {machine?.IpAddress}\n\n" +
                    ex.ToString(), ex);
            }
        }

        public async Task ReadAndSaveAsync(int machineId, CancellationToken ct = default)
        {
            using var scope = _scopeFactory.CreateScope();
            var uow = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

            var machine = await uow.Repository<DB_PlcMachine>().TGetById(machineId);
            if (machine is null) return;

            // session makine tablosundaki endpoint ile kurulur
            var session = await EnsureConnectedAsync(machine);

            var tags = (await uow.Repository<DB_PlcTags>().TGetAll())
                .Where(t => t.MachineId == machineId && t.IsActive)
                .ToList();

            var now = DateTime.UtcNow;

            foreach (var tag in tags)
            {
                try
                {
                    var nodeId = new NodeId(tag.DataAddress);
                    var dataValue = session.ReadValue(nodeId);
                    var value = Convert.ToDouble(dataValue.Value);

                    await uow.Repository<DB_PlcReading>().TAdd(new DB_PlcReading
                    {
                        PlcTagId = tag.RecId,
                        Value = value,
                        ReadingTime = now
                    });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Tag okuma hatası [{tag.TagName}]: {ex.Message}");
                }
            }

            await uow.SaveChangesAsync();
            Console.WriteLine($"OPC-UA okuma tamamlandı [{machine.Name}]: {now:HH:mm:ss}");
        }

        public async ValueTask DisposeAsync()
        {
            foreach (var session in _sessions.Values)
            {
                if (session.Connected) session.Close();
                session.Dispose();
            }
            _sessions.Clear();
            await ValueTask.CompletedTask;
        }

        private readonly Dictionary<int, int> _heartbeatCounters = new();
        public async Task WriteHeartbeatAsync(int machineId, int maxValue = 10000, CancellationToken ct = default)
        {
            using var scope = _scopeFactory.CreateScope();
            var uow = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

            var machine = await uow.Repository<DB_PlcMachine>().TGetById(machineId);
            if (machine is null) return;

            // Heartbeat tag'ini bul (TagName sabit bir konvansiyon olarak "Heartbeat" kabul edildi)
            var heartbeatTag = (await uow.Repository<DB_PlcTags>().TGetAll())
                .FirstOrDefault(t => t.MachineId == machineId
                                   && t.IsActive
                                   && t.TagName.Equals("Heartbeat", StringComparison.OrdinalIgnoreCase));

            if (heartbeatTag is null)
            {
                Console.WriteLine($"Heartbeat tag'i bulunamadı [MachineId={machineId}]");
                return;
            }

            var session = await EnsureConnectedAsync(machine);

            try
            {
                var nodeId = new NodeId(heartbeatTag.DataAddress);

                if (!_heartbeatCounters.TryGetValue(machineId, out int counter))
                    counter = 0;


                counter = (counter >= maxValue) ? 0 : counter + 1;
                _heartbeatCounters[machineId] = counter;

                var currentValue = session.ReadValue(nodeId);
                bool toggled = currentValue.Value is bool b ? !b : true;

                var writeValue = new WriteValue
                {
                    NodeId = nodeId,
                    AttributeId = Attributes.Value,
                    // PLC tarafındaki tag tipine göre Int16/Int32 seçin
                    Value = new DataValue(new Variant(counter))
                };

                var writeValues = new WriteValueCollection { writeValue };

                var responseHeader = session.Write(
                    null,
                    writeValues,
                    out StatusCodeCollection results,
                    out DiagnosticInfoCollection diagnosticInfos
                );

                if (StatusCode.IsGood(results[0]))
                {
                    Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] Heartbeat gönderildi [{machine.Name}]: {toggled}");
                }
                else
                {
                    Console.WriteLine($"Heartbeat yazma hatası [{machine.Name}]: {results[0]}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Heartbeat exception [{machine.Name}]: {ex.Message}");
            }
        }
    }
}
