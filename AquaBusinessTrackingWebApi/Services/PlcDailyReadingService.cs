
using BusinessLayer.Abstract.Integrations;
using DataAccsessLayer.Abstract.Integrations;

namespace AquaBusinessTrackingWebApi.Services
{
    public class PlcDailyReadingService : BackgroundService
    {
        private readonly IPlcReader _plcReader;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IConfiguration _config;

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

                // 08:00 geçtiyse yarın çalıştır
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
                        Console.WriteLine($"{machine.Name} okundu: {DateTime.Now:HH:mm:ss}");
                    }

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
