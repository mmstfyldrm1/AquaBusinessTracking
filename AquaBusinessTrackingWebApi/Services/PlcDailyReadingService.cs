
using BusinessLayer.Abstract.Integrations;
using DataAccsessLayer.Abstract.Integrations;

namespace AquaBusinessTrackingWebApi.Services
{
    public class PlcDailyReadingService : BackgroundService
    {
        private readonly IPlcReader _plcReader;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IConfiguration _config;
        private const int MaxHeartbeatValue = 10000;
        private readonly TimeSpan _interval = TimeSpan.FromSeconds(5);

        public PlcDailyReadingService(
            IPlcReader plcReader,
            IServiceScopeFactory scopeFactory,
            IConfiguration config)
        {
            _plcReader = plcReader;
            _scopeFactory = scopeFactory;
            _config = config;
        }
        protected override async Task ExecuteAsync(CancellationToken ct)
        {
            while (!ct.IsCancellationRequested)
            {
                var hour = _config.GetValue<int>("PlcSettings:DailyReadHour");
                var minute = _config.GetValue<int>("PlcSettings:DailyReadMinute");

                var now = DateTime.Now;
                var nextRun = DateTime.Today.AddHours(hour).AddMinutes(minute);


                if (now >= nextRun)
                    nextRun = nextRun.AddDays(1);

                var delay = nextRun - now;
                Console.WriteLine($"Sonraki PLC okuma: {nextRun:dd.MM.yyyy HH:mm}");

                await Task.Delay(delay, ct);

                try
                {
                    using var scope = _scopeFactory.CreateScope();
                    var plcService = scope.ServiceProvider.GetRequiredService<IPlcService>();
                    var machines = await plcService.GetActiveMachinesAsync();

                    foreach (var machine in machines)
                    {
                        await _plcReader.ReadAndSaveAsync(machine.RecId, ct);
                        try
                        {
                            await _plcReader.WriteHeartbeatAsync(machine.RecId, MaxHeartbeatValue, ct);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Heartbeat loop hatası [{machine.Name}]: {ex.Message}");

                        }
                        Console.WriteLine($"{machine.Name} okundu: {DateTime.Now:HH:mm:ss}");
                    }

                    await Task.Delay(_interval, ct);

                    Console.WriteLine($"Günlük PLC okuma tamamlandı: {DateTime.Now:dd.MM.yyyy HH:mm}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"PLC okuma hatası: {ex.Message}");
                }
            }

        }
    }
}
