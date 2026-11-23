using DTOLayer.Dtos.Email;

namespace BusinessLayer.Abstract.MailService.@abstract
{
    public interface IEmailService
    {
        Task<EmailSendResultDto> SendEmailAsync(EmailRequestDto request);

    }
}
