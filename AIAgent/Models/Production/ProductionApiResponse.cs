namespace AIAgent.Models.Production
{
    public class ProductionApiResponse
    {
        public bool IsOk { get; set; }
        public int ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }
        public object? ServerMessages { get; set; }
        public List<DailyProductionDto> Data { get; set; } = new();
    }
}
