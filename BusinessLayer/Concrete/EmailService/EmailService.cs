using BusinessLayer.Abstract.MailService.@abstract;
using BusinessLayer.Abstract.MailService.settings;
using DTOLayer.Dtos.Email;
using MailKit;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;

namespace BusinessLayer.Email
{
    public class EmailService : IEmailService
    {
        private readonly EmailSettings _settings;
        private readonly ILogger<EmailService> _logger;

        public EmailService(IOptions<EmailSettings> settings, ILogger<EmailService> logger)
        {
            _settings = settings.Value;
            _logger = logger;
        }

        public async Task<EmailSendResultDto> SendEmailAsync(EmailRequestDto request)
        {
            try
            {
                if (request == null)
                    throw new ArgumentNullException(nameof(request));

                if (request.To == null || !request.To.Any())
                    throw new ArgumentException("En az bir alıcı belirtilmelidir.");

                if (string.IsNullOrWhiteSpace(request.Subject))
                    throw new ArgumentException("Mail konusu boş olamaz.");

                var message = new MimeMessage();

                message.From.Add(new MailboxAddress(_settings.SenderName, _settings.SenderEmail));
                foreach (var address in request.To)
                {
                    message.To.Add(MailboxAddress.Parse(address));
                }

                foreach (var address in request.Cc ?? new List<string>())
                {
                    message.Cc.Add(MailboxAddress.Parse(address));
                }

                message.Subject = request.Subject;

                var bodyBuilder = new BodyBuilder
                {
                    HtmlBody = request.HtmlBody
                };

                // Dosya ekleri
                foreach (var attachment in request.Attachments ?? new List<EmailAttachmentDto>())
                {
                    if (attachment.Content == null ||
                        attachment.Content.Length == 0)
                        continue;

                    bodyBuilder.Attachments.Add(
                        attachment.FileName,
                        attachment.Content,
                        ContentType.Parse(attachment.ContentType));
                }

                message.Body = bodyBuilder.ToMessageBody();

                using var smtpClient = new SmtpClient();

                var secureSocketOptions = _settings.UseSsl
                    ? SecureSocketOptions.SslOnConnect
                    : _settings.UseStartTls
                        ? SecureSocketOptions.StartTls
                        : SecureSocketOptions.None;

                await smtpClient.ConnectAsync(
                    _settings.Host,
                    _settings.Port,
                    secureSocketOptions);

                if (!string.IsNullOrWhiteSpace(_settings.Username))
                {
                    await smtpClient.AuthenticateAsync(
                        _settings.Username,
                        _settings.Password);
                }

                await smtpClient.SendAsync(message);

                await smtpClient.DisconnectAsync(true);

                _logger.LogInformation(
                    "Mail başarıyla gönderildi. Konu: {Subject}",
                    request.Subject);

                return new EmailSendResultDto
                {
                    Success = true,
                    Message = "Mail başarıyla gönderildi."
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Mail gönderim hatası. Konu: {Subject}",
                    request?.Subject);

                return new EmailSendResultDto
                {
                    Success = false,
                    Message = "Mail gönderilemedi.",
                    ErrorMessage = ex.Message
                };
            }
        }
    }
}