using AIAgent.Services.Abstract.Shipment;

namespace AIAgent.Tools.Shipment
{
    public class GetLast30DaysShipmentTool : IAiTool
    {
        private readonly IShipmentApiService _shipmentApiService;
        public GetLast30DaysShipmentTool(IShipmentApiService shipmentApiService)
        {
            _shipmentApiService = shipmentApiService;
        }
        public string Name => "get_last_30_days_shipment_tool";

        public string Description => "Retrieves detailed shipment data from the Shipment API for the last 30 days. " +
        "The result may contain multiple shipment records within this 30-day period. " +
        "Evaluate each record separately and do not automatically aggregate or combine the records unless the user explicitly asks for a total, summary, or aggregation. " +
        "If the result is empty, clearly state that no shipment records were found for the last 30 days. " +
        "Always respond to the user in Turkish.";

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
