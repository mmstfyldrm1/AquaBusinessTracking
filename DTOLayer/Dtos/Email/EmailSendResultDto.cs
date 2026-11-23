namespace DTOLayer.Dtos.Email
{
    public class EmailSendResultDto
    {
        public bool Success { get; set; }

        public string Message { get; set; } = string.Empty;

        public string? ErrorMessage { get; set; }
    }
}
