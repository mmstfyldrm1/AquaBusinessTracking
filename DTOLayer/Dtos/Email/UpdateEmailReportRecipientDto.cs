namespace DTOLayer.Dtos.Email
{
    public class UpdateEmailReportRecipientDto
    {
        public int RecId { get; set; }
        public string ReportCode { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}
