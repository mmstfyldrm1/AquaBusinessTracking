using BusinessLayer.Abstract.MailService.@abstract;
using BusinessLayer.Abstract.Reports;
using BusinessLayer.Reports.@abstract;
using DTOLayer.Dtos.Email;


namespace BusinessLayer.Abstract.MailService.concrete
{
    public class ReportEmailService : IReportEmailService
    {
        private readonly IPdfReportService _pdfReportService;
        private readonly IEmailService _emailService;
        private readonly IEmailTemplateService _emailTemplateService;
        private readonly IReportFileService _reportFileService;
        private readonly IMachineDailyReportService _machineDailyReportService;

        public ReportEmailService(IPdfReportService pdfReportService, IEmailService emailService, IEmailTemplateService emailTemplateService, IReportFileService reportFileService, IMachineDailyReportService machineDailyReportService)
        {
            _pdfReportService = pdfReportService;
            _emailService = emailService;
            _emailTemplateService = emailTemplateService;
            _reportFileService = reportFileService;
            _machineDailyReportService = machineDailyReportService;
        }

        public async Task SendTestReportAsync(string recipientEmail)
        {
            var pdfBytes = _pdfReportService.GenerateTestPdf();

            var attachment = new EmailAttachmentDto
            {
                FileName = "AquaMES-Test-Raporu.pdf",
                ContentType = "application/pdf",
                Content = pdfBytes
            };

            await SendAttachmentAsync(recipientEmail, attachment);
        }

        public async Task SendAttachmentAsync(string recipientEmail, EmailAttachmentDto attachment)
        {
            var parameters = new Dictionary<string, string>
            {
                ["Title"] = "Aqua MES Raporu",
                ["Message"] = "Raporunuz e-posta ekinde gönderilmiştir.",
                ["Date"] = DateTime.Now.ToString("dd.MM.yyyy HH:mm")
            };

            var htmlBody = _emailTemplateService.Render(
                "DefaultNotification",
                parameters);

            var request = new EmailRequestDto
            {
                To = new List<string> { recipientEmail },
                Subject = "Aqua MES - Rapor Bildirimi",
                HtmlBody = htmlBody,
                Attachments = new List<EmailAttachmentDto>
                {
                    attachment
                }
            };

            var result = await _emailService.SendEmailAsync(request);

            if (!result.Success)
            {
                throw new Exception(
                    $"E-posta gönderilemedi: {result.ErrorMessage}");
            }
        }

        public async Task SendExistingFileAsync(string recipientEmail, string fileName)
        {
            var fileBytes = await _reportFileService.ReadFileAsync(fileName);

            var extension = Path.GetExtension(fileName).ToLowerInvariant();

            var contentType = extension switch
            {
                ".pdf" => "application/pdf",
                ".xlsx" => "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                _ => "application/octet-stream"
            };

            var attachment = new DTOLayer.Dtos.Email.EmailAttachmentDto
            {
                FileName = fileName,
                ContentType = contentType,
                Content = fileBytes
            };

            await SendAttachmentAsync(recipientEmail, attachment);
        }

        public async Task SendMachineDailyReportAsync(string recipientEmail, DateTime reportDate)
        {
            // Günlük makine verilerini getir
            var report = await _machineDailyReportService
                .GetDailyReportAsync(reportDate);

            if (report == null)
                throw new InvalidOperationException(
                    "Günlük makine raporu oluşturulamadı. Makine bulunamadı.");

            // PDF oluştur
            var pdfBytes = _pdfReportService
                .GenerateMachineDailyReportPdf(report);

            var attachment = new EmailAttachmentDto
            {
                FileName = $"MakineGunlukRapor_{reportDate:yyyyMMdd}.pdf",
                ContentType = "application/pdf",
                Content = pdfBytes
            };

            // E-posta içeriği
            var htmlBody = _emailTemplateService.Render(
                "DefaultNotification",
                new Dictionary<string, string>
                {
                    ["Title"] = "Günlük Makine Üretim Raporu",
                    ["Message"] = $"{report.MachineName} için " +
                                  $"{reportDate:dd.MM.yyyy} tarihli günlük rapor ektedir.",
                    ["Date"] = DateTime.Now.ToString("dd.MM.yyyy HH:mm")
                });

            var result = await _emailService.SendEmailAsync(new EmailRequestDto
            {
                To = new List<string> { recipientEmail },
                Subject = $"{report.MachineName} - Günlük Makine Raporu ({reportDate:dd.MM.yyyy})",
                HtmlBody = htmlBody,
                Attachments = new List<EmailAttachmentDto> { attachment }
            });

            if (!result.Success)
            {
                throw new InvalidOperationException(
                    $"Makine raporu e-postası gönderilemedi: {result.ErrorMessage}");
            }
        }
    }
}