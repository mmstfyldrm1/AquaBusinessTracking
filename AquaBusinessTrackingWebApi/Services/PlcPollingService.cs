
using BusinessLayer.Abstract.Integrations;
using DataAccsessLayer.Abstract.Integrations;
using Microsoft.AspNetCore.SignalR;

namespace AquaBusinessTrackingWebApi.Services
{
    public class PlcPollingService : BackgroundService
    {
        private readonly IPlcReader _plcReader;
        private readonly IHubContext<PlcHub> _hub;
        private readonly IServiceScopeFactory _scopeFactory;

        public PlcPollingService(
            IPlcReader plcReader,
            IHubContext<PlcHub> hub,
            IServiceScopeFactory scopeFactory)
        {
            _plcReader = plcReader;
            _hub = hub;
            _scopeFactory = scopeFactory;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    using var scope = _scopeFactory.CreateScope();
                    var plcService = scope.ServiceProvider.GetRequiredService<IPlcService>();
                    var machines = await plcService.GetActiveMachinesAsync();

                    foreach (var machine in machines)
                    {
                        await _plcReader.ReadAndSaveAsync(machine.RecId, stoppingToken);

                        var readings = await plcService.GetLastReadingsAsync(machine.RecId);

                        await _hub.Clients.All.SendAsync("PlcUpdated", readings, stoppingToken);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Polling hatası: {ex.Message}");
                    await Task.Delay(5_000, stoppingToken);
                    continue;
                }

                await Task.Delay(2_000, stoppingToken);
            }
        }

    }
}
