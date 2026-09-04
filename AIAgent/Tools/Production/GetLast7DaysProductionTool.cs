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

        public string Name => "get_last_7_days_production";

        public string Description => "Üretim API'sinden günlük üretim verilerini getirir.";

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
