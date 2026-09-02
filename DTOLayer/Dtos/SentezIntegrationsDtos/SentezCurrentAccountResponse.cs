namespace DTOLayer.Dtos.SentezIntegrationsDtos
{
    public class SentezCurrentAccountResponse
    {
        public int CurrentAccountId { get; set; }
        public string CurrentAccountCode { get; set; }
        public string CurrentAccountName { get; set; }
        public List<string> CityName { get; set; }
        public List<string> District { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string Line3 { get; set; }

    }
}
