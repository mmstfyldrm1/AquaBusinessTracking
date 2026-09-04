using DTOLayer.Dtos.SentezProductionDtos;

namespace AIAgent.Models.Production
{
    public class ProductionApiResponseGetbyDateRange
    {
        public bool IsOk { get; set; }
        public int ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }
        public object? ServerMessages { get; set; }
        public List<SentezProductionDto> Data { get; set; } = new();
    }
}
