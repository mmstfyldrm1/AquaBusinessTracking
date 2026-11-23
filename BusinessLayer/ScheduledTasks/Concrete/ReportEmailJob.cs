using BusinessLayer.Abstract;
using BusinessLayer.Abstract.MailService.@abstract;
using BusinessLayer.ScheduledTasks.Abstract;
using Microsoft.Extensions.Logging;

namespace BusinessLayer.ScheduledTasks.Concrete
{
    public class ReportEmailJob : IReportEmailJob
    {
        private readonly IReportEmailService _reportEmailService;
        private readonly ILogger<ReportEmailJob> _logger;

        private readonly IEmailReportRecipientService _recipientService;

        public ReportEmailJob(IReportEmailService reportEmailService, ILogger<ReportEmailJob> logger, IEmailReportRecipientService recipientService)
        {
            _reportEmailService = reportEmailService;
            _logger = logger;
            _recipientService = recipientService;
        }

        public async Task SendDailyMachineReportAsync()
        {
            var reportDate = DateTime.Today.AddDays(-1);

            var recipients = await _recipientService
                .GetActiveEmailsByReportCode("DAILY_MACHINE");

            if (recipients == null || recipients.Count == 0)
            {
                _logger.LogWarning(
                    "DAILY_MACHINE raporu için aktif alıcı bulunamadı.");

                return;
            }

            foreach (var recipient in recipients)
            {
                try
                {
                    await _reportEmailService.SendMachineDailyReportAsync(
                        recipient,
                        reportDate);

                    _logger.LogInformation(
                        "Makine raporu gönderildi. Recipient={Recipient}, Date={Date}",
                        recipient,
                        reportDate);
                }
                catch (Exception ex)
                {
                    _logger.LogError(
                        ex,
                        "Makine raporu gönderilemedi. Recipient={Recipient}",
                        recipient);
                }
            }
        }

        public async Task SendDailyTestReportAsync(List<string> email)
        {
            foreach (var recipientEmail in email)
            {
                try
                {
                    await _reportEmailService.SendTestReportAsync(recipientEmail);

                    _logger.LogInformation(
                        "Test raporu gönderildi. Recipient={Recipient}",
                        recipientEmail);
                }
                catch (Exception ex)
                {
                    _logger.LogError(
                        ex,
                        "Test raporu gönderilemedi. Recipient={Recipient}",
                        recipientEmail);
                }
            }
        }
    }
}