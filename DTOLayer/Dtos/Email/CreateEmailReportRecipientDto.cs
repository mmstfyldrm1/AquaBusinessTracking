namespace DTOLayer.Dtos.Email
{
    public class CreateEmailReportRecipientDto
    {
        public string ReportCode { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;

    }
}
