using DataAccsessLayer.Abstract.Integrations;
using DataAccsessLayer.Concrete.UoW;
using EntityLayer.Concrete;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Opc.Ua;
using Opc.Ua.Client;

namespace DataAccsessLayer.Concrete.Repository.Integrations
{
    public class OpcUaPlcReader : IPlcReader, IAsyncDisposable
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly Dictionary<int, Session> _sessions = new();
        private readonly ILogger<OpcUaPlcReader> _logger;

        public OpcUaPlcReader(IServiceScopeFactory scopeFactory, ILogger<OpcUaPlcReader> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        private async Task<Session> EnsureConnectedAsync(DB_PlcMachine machine)
        {
            try
            {
                if (_sessions.TryGetValue(machine.RecId, out var existing) && existing.Connected)
                    return existing;
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
                _logger.LogInformation("PLC bağlantısı kuruldu. Machine={MachineName}, Ip={Ip}", machine.Name, machine.IpAddress);
                return session;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "PLC bağlantısı kurulamadı. Machine={MachineName}, Ip={Ip}", machine?.Name, machine?.IpAddress);

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
            _logger.LogInformation("PLC okuma başladı. Machine={MachineName}", machine.Name);
            // session makine tablosundaki endpoint ile kurulur
            var session = await EnsureConnectedAsync(machine);

            var tags = (await uow.Repository<DB_PlcTags>().TGetAll())
                .Where(t => t.MachineId == machineId && t.IsActive)
                .ToList();

            var now = DateTime.Now;

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
                    _logger.LogError(ex, "Tag okunamadı. Machine={MachineName}, Tag={TagName}, NodeId={NodeId}", machine.Name, tag.TagName, tag.DataAddress);
                }
            }

            await uow.SaveChangesAsync();
            _logger.LogInformation("PLC okuma tamamlandı. Machine={MachineName}, TagCount={TagCount}, Time={Time}", machine.Name, tags.Count, now);




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
                _logger.LogWarning("Heartbeat tag bulunamadı. Machine={MachineName}", machine.Name);
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
                    _logger.LogInformation("Heartbeat gönderildi. Machine={MachineName}, Counter={Counter}", machine.Name, counter);
                }
                else
                {
                    _logger.LogError("Heartbeat yazma hatası. Machine={MachineName}, StatusCode={StatusCode}", machine.Name, results[0]);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Heartbeat exception. Machine={MachineName}", machine.Name);
            }
        }
    }
}
