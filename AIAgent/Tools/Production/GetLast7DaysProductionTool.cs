using AIAgent.Services.Abstract.Production;

namespace AIAgent.Tools.Production
{
    public class GetLast7DaysProductionTool : IAiTool
    {
        private readonly IProductionApiService _productionApiService;

        public GetLast7DaysProductionTool(IProductionApiService productionApiService)
        {
            _productionApiService = productionApiService;
        }

        public string Name => "get_last_7_days_production_tool";

        public string Description => "Retrieves daily production data from the Production API for the last 7 days. Always respond to the user in Turkish.";

        public object ParametersSchema => new
        {
            type = "object",
            properties = new { }
        };


        public async Task<object> ExecuteAsync(string? argumentsJson = null)
        {
            return await _productionApiService.GetDailyProductionAsync();
        }
    }
}
