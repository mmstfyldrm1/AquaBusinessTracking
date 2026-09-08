using DTOLayer.Dtos.SentezIntegrationsDtos;

namespace AIAgent.Models.Production
{
    public class GetStockByInventoryCodeIntegrationsResponse
    {
        public bool IsOk { get; set; }
        public int ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }
        public object? ServerMessages { get; set; }
        public List<SentezIntegrationsGetStockByInventoryCode> Data { get; set; } = new();
    }
}
