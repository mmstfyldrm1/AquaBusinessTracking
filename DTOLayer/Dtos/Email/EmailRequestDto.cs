namespace DTOLayer.Dtos.Email
{
    public class EmailRequestDto
    {
        public List<string> To { get; set; } = new();

        public List<string> Cc { get; set; } = new();

        public string Subject { get; set; } = string.Empty;

        public string HtmlBody { get; set; } = string.Empty;

        public List<EmailAttachmentDto> Attachments { get; set; } = new();
    }
}
