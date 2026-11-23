using DTOLayer.Dtos.Email;

namespace BusinessLayer.Abstract.MailService.@abstract
{
    public interface IReportEmailService
    {
        Task SendTestReportAsync(string recipientEmail);

        Task SendAttachmentAsync(string recipientEmail, EmailAttachmentDto attachment);

        Task SendExistingFileAsync(string recipientEmail, string fileName);


        Task SendMachineDailyReportAsync(string recipientEmail, DateTime reportDate);

    }
}
