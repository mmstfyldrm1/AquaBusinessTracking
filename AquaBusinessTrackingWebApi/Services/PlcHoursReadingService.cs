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
        private readonly ILogger<PlcHoursReadingService> _logger;
        private const int MaxHeartbeatValue = 10000;


        private DateTime? _lastSuccessHour = null;

        public PlcHoursReadingService(
            IPlcReader plcReader,
            IServiceScopeFactory scopeFactory,
            IConfiguration config,
            IHostEnvironment env,
            ILogger<PlcHoursReadingService> logger)
        {
            _plcReader = plcReader;
            _scopeFactory = scopeFactory;
            _config = config;
            _env = env;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken ct)
        {
            var isDebug = _env.IsDevelopment();
            if (isDebug)
            {
                _logger.LogInformation("[DEBUG MOD] PLC okuma servisi debug modunda çalışıyor - her 1 dakikada bir okuyacak.");
            }

            while (!ct.IsCancellationRequested)
            {
                if (!isDebug)
                {
                    var now = DateTime.Now;
                    var currentHourSlot = now.Date.AddHours(now.Hour);


                    bool alreadyDoneThisHour = _lastSuccessHour.HasValue && _lastSuccessHour.Value == currentHourSlot;

                    DateTime targetSlot;

                    if (alreadyDoneThisHour)
                    {
                        targetSlot = currentHourSlot.AddHours(1);
                    }
                    else if (_lastSuccessHour == null)
                    {

                        targetSlot = currentHourSlot.AddHours(1);
                    }
                    else
                    {
                        targetSlot = currentHourSlot;
                    }


                    var delay = targetSlot > now ? targetSlot - now : TimeSpan.Zero;

                    _logger.LogInformation("Sonraki PLC okuma hedefi: {TargetSlot}, bekleme: {Delay}",
                        targetSlot.ToString("dd.MM.yyyy HH:mm"), delay);

                    try
                    {
                        if (delay > TimeSpan.Zero)
                            await Task.Delay(delay, ct);
                    }
                    catch (OperationCanceledException)
                    {
                        break;
                    }
                }
                else
                {
                    _logger.LogInformation("[DEBUG] PLC okuma tetiklendi: {Now}", DateTime.Now.ToString("HH:mm:ss"));
                }

                var runHourSlot = DateTime.Now.Date.AddHours(DateTime.Now.Hour);
                bool anyFailure = false;

                try
                {
                    using var scope = _scopeFactory.CreateScope();
                    var plcService = scope.ServiceProvider.GetRequiredService<IPlcService>();
                    var machines = await plcService.GetActiveMachinesAsync();

                    foreach (var machine in machines)
                    {
                        try
                        {
                            await _plcReader.ReadAndSaveAsync(machine.RecId, ct);
                            _logger.LogInformation("{Machine} okundu: {Now}", machine.Name, DateTime.Now.ToString("HH:mm:ss"));
                        }
                        catch (Exception ex)
                        {
                            anyFailure = true;
                            _logger.LogError(ex, "Okuma hatası [{Machine}]", machine.Name);

                        }

                        try
                        {
                            await _plcReader.WriteHeartbeatAsync(machine.RecId, MaxHeartbeatValue, ct);
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex, "Heartbeat hatası [{Machine}]", machine.Name);
                        }
                    }

                    _logger.LogInformation("PLC okuma turu tamamlandı: {Now}", DateTime.Now.ToString("dd.MM.yyyy HH:mm"));
                }
                catch (Exception ex)
                {
                    anyFailure = true;
                    _logger.LogError(ex, "PLC okuma turu genel hata");
                }


                if (!anyFailure && !isDebug)
                {
                    _lastSuccessHour = runHourSlot;
                }
                else if (anyFailure && !isDebug)
                {

                    _logger.LogWarning("Bu turda hata oluştu, 2 dakika sonra tekrar denenecek.");
                    try
                    {
                        await Task.Delay(TimeSpan.FromMinutes(2), ct);
                    }
                    catch (OperationCanceledException)
                    {
                        break;
                    }
                }

                if (isDebug)
                {
                    try
                    {
                        await Task.Delay(TimeSpan.FromMinutes(0.25), ct);
                    }
                    catch (OperationCanceledException)
                    {
                        break;
                    }
                }
            }
        }
    }
}