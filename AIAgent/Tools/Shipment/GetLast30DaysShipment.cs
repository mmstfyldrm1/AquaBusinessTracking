using AIAgent.Services.Abstract.Shipment;

namespace AIAgent.Tools.Shipment
{
    public class GetLast30DaysShipment : IAiTool
    {
        private readonly IShipmentApiService _shipmentApiService;
        public GetLast30DaysShipment(IShipmentApiService shipmentApiService)
        {
            _shipmentApiService = shipmentApiService;
        }
        public string Name => "get_last_30_days_shipment";

        public string Description => "Sevkiyat Apisinden son 30 gündeki sevkiyat detaylarını alır.";

        public object ParametersSchema => new
        {
            type = "object",
            properties = new { }
        };
        public async Task<object> ExecuteAsync(string? argumentsJson = null)
        {
            return await _shipmentApiService.GetLast30daysShipment();
        }
    }
}
