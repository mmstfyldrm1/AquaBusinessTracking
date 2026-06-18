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
        // makine bazlı session dictionary — birden fazla makine olabilir
        private readonly Dictionary<int, Session> _sessions = new();

        public OpcUaPlcReader(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
            // config inject edilmiyor — endpoint DB'den geliyor
        }

        private async Task<Session> EnsureConnectedAsync(DB_PlcMachine machine)
        {
            if (_sessions.TryGetValue(machine.RecId, out var existing) && existing.Connected)
                return existing;

            var appConfig = new ApplicationConfiguration
            {
                ApplicationName = "AquaBusinessTracking",
                ApplicationType = ApplicationType.Client,
                SecurityConfiguration = new SecurityConfiguration
                {
                    AutoAcceptUntrustedCertificates = true,
                    AddAppCertToTrustedStore = true
                },
                TransportConfigurations = new TransportConfigurationCollection(),
                TransportQuotas = new TransportQuotas { OperationTimeout = 10000 },
                ClientConfiguration = new ClientConfiguration { DefaultSessionTimeout = 60000 }
            };

            await appConfig.Validate(ApplicationType.Client);

            // IpAddress'i endpoint olarak kullan
            // Kullanıcı "opc.tcp://192.168.0.10:4840" yazarsa direkt kullan
            // "192.168.0.10" yazarsa otomatik formatla
            var endpoint = machine.IpAddress.StartsWith("opc.tcp://")
                ? machine.IpAddress
                : $"opc.tcp://{machine.IpAddress}:4863";

            var selectedEndpoint = CoreClientUtils.SelectEndpoint(endpoint, useSecurity: false);
            var endpointConfig = EndpointConfiguration.Create(appConfig);
            var configuredEndpoint = new ConfiguredEndpoint(null, selectedEndpoint, endpointConfig);

            var session = await Session.Create(
                appConfig,
                configuredEndpoint,
                updateBeforeConnect: false,
                sessionName: $"AquaSession_{machine.RecId}",
                sessionTimeout: 60000,
                identity: new UserIdentity(new AnonymousIdentityToken()),
                preferredLocales: null
            );

            _sessions[machine.RecId] = session;
            return session;
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
    }
}
