namespace EntityLayer.Concrete
{
    public class DB_EmailReportRecipient : BaseEntity
    {
        public string ReportCode { get; set; } = string.Empty;

        public string EmailAddress { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;
    }
}
