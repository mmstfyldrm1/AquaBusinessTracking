using BusinessLayer.Abstract;
using BusinessLayer.Abstract.Integrations;

public class MachineRandomanJob : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly ILogger<MachineRandomanJob> _logger;

    private static readonly TimeSpan RunMinute = TimeSpan.FromMinutes(45);
    private static readonly TimeSpan RetryWindow = TimeSpan.FromMinutes(15);
    private static readonly TimeSpan RetryInterval = TimeSpan.FromMinutes(1);


    private DateTime? _lastSuccessSlot = null;

    public MachineRandomanJob(IServiceScopeFactory scopeFactory, ILogger<MachineRandomanJob> logger)
    {
        _scopeFactory = scopeFactory;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var now = DateTime.Now;
            var currentHourSlot = now.Date.AddHours(now.Hour).Add(RunMinute);
            var currentDeadline = currentHourSlot.Add(RetryWindow);

            bool alreadyDoneThisSlot = _lastSuccessSlot.HasValue && _lastSuccessSlot.Value == currentHourSlot;

            DateTime targetRun;

            if (!alreadyDoneThisSlot && now <= currentDeadline)
            {
                targetRun = currentHourSlot;
            }
            else
            {
                targetRun = currentHourSlot.AddHours(1);
            }

            var delay = targetRun > now ? targetRun - now : TimeSpan.Zero;

            _logger.LogInformation(
                "MachineRandomanJob hedef çalışma zamanı: {TargetRun}, bekleme: {Delay}",
                targetRun.ToString("dd.MM.yyyy HH:mm:ss"), delay);

            try
            {
                if (delay > TimeSpan.Zero)
                    await Task.Delay(delay, stoppingToken);
            }
            catch (OperationCanceledException)
            {
                break;
            }

            var success = await TryInsertWithRetryAsync(targetRun, stoppingToken);
            if (success)
                _lastSuccessSlot = targetRun;
        }
    }

    private async Task<bool> TryInsertWithRetryAsync(DateTime scheduledRun, CancellationToken stoppingToken)
    {
        var deadline = scheduledRun.Add(RetryWindow);

        while (!stoppingToken.IsCancellationRequested && DateTime.Now <= deadline)
        {
            try
            {
                using var scope = _scopeFactory.CreateScope();
                var plcService = scope.ServiceProvider.GetRequiredService<IPlcService>();
                var sentezService = scope.ServiceProvider.GetRequiredService<ISentezQueryService>();

                var resultWorkHours = await plcService.GetLastReadingsAsync(6, 3);
                var dto = resultWorkHours?.FirstOrDefault(x => x.DisplayName == "Bağlı Süre");

                if (dto == null)
                {
                    _logger.LogWarning(
                        "MachineRandomanJob: 'Bağlı Süre' değeri boş geldi, {Deadline} saatine kadar tekrar denenecek. Şu an: {Now}",
                        deadline.ToString("HH:mm:ss"), DateTime.Now.ToString("HH:mm:ss"));

                    await Task.Delay(RetryInterval, stoppingToken);
                    continue;
                }

                var result = await sentezService.InsertMachineRandoman(dto.Value);
                if (result.IsOk)
                {
                    _logger.LogInformation("MachineRandomanJob çalıştı: {Now}, değer: {Value}",
                        DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"), dto.Value);
                    return true;
                }
                else
                {
                    _logger.LogWarning(
                        "MachineRandomanJob: InsertMachineRandoman başarısız döndü (IsOk=false), {Interval} sonra tekrar denenecek",
                        RetryInterval);

                    await Task.Delay(RetryInterval, stoppingToken);
                    continue;
                }
            }
            catch (OperationCanceledException)
            {
                return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "MachineRandomanJob hata aldı, {Interval} sonra tekrar denenecek", RetryInterval);
                try
                {
                    await Task.Delay(RetryInterval, stoppingToken);
                }
                catch (OperationCanceledException)
                {
                    return false;
                }
            }
        }

        _logger.LogError(
            "MachineRandomanJob: {Deadline} saatine kadar geçerli değer alınamadı, bu saat dilimi için kayıt atılamadı.",
            deadline.ToString("dd.MM.yyyy HH:mm:ss"));
        return false; // pencere doldu, başarısız
    }
}