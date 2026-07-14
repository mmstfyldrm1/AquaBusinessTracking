using BusinessLayer.Abstract.Integrations;
using DataAccsessLayer.Abstract.Integrations;

namespace AquaBusinessTrackingWebApi.Services
{
    public class PlcHoursReadingService : BackgroundService
    {
        private readonly IPlcReader _plcReader;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IConfiguration _config;
        private readonly IHostEnvironment _env;
        private const int MaxHeartbeatValue = 10000;

        public PlcHoursReadingService(
            IPlcReader plcReader,
            IServiceScopeFactory scopeFactory,
            IConfiguration config,
            IHostEnvironment env)
        {
            _plcReader = plcReader;
            _scopeFactory = scopeFactory;
            _config = config;
            _env = env;
        }

        protected override async Task ExecuteAsync(CancellationToken ct)
        {
            // Debug modda: hemen başla ve kısa aralıklarla çalış (görmek için)
            // Production'da: saatte bir çalış
            var isDebug = _env.IsDevelopment();

            if (isDebug)
            {
                Console.WriteLine("[DEBUG MOD] PLC okuma servisi debug modunda çalışıyor - her 1 dakikada bir okuyacak.");
            }

            while (!ct.IsCancellationRequested)
            {
                if (!isDebug)
                {
                    // --- PRODUCTION: bir sonraki tam saate kadar bekle ---
                    var now = DateTime.Now;
                    var nextRun = now.Date
                        .AddHours(now.Hour)
                        .AddHours(1); // bir sonraki tam saat, örn. 14:32 -> 15:00

                    var delay = nextRun - now;
                    Console.WriteLine($"Sonraki PLC okuma: {nextRun:dd.MM.yyyy HH:mm}");
                    await Task.Delay(delay, ct);
                }
                else
                {
                    // --- DEBUG: hemen çalış, sonraki turda 1 dakika bekle ---
                    Console.WriteLine($"[DEBUG] PLC okuma tetiklendi: {DateTime.Now:HH:mm:ss}");
                }

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

                    Console.WriteLine($"PLC okuma turu tamamlandı: {DateTime.Now:dd.MM.yyyy HH:mm}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"PLC okuma hatası: {ex.Message}");
                }

                if (isDebug)
                {

                    await Task.Delay(TimeSpan.FromMinutes(0.25), ct);
                }
            }
        }
    }
}