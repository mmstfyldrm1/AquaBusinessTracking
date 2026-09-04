
using AIAgent.Services.Abstract.Production;

namespace AIAgent.Tools.Production
{
    public class GetWithProductionByDate : IAiTool
    {
        private readonly IProductionApiService _productionApiService;

        public GetWithProductionByDate(IProductionApiService productionApiService)
        {
            _productionApiService = productionApiService;
        }

        public string Name => "get_with_production_by_date";

        public string Description => "Kullanıcıdan alınan tarih aralığına göre üretim verilerini getirir.";

        public object ParametersSchema => new
        {
            type = "object",
            properties = new { }
        };

        public async Task<object> ExecuteAsync(string? argumentsJson = null)
        {
            var rawArgs = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string>>(argumentsJson);

            if (rawArgs is null)
                return new { error = "Argümanlar okunamadı." };

            var args = new Dictionary<string, string>(rawArgs, StringComparer.OrdinalIgnoreCase);

            if (!args.TryGetValue("StartDate", out var startDateStr) ||
                !args.TryGetValue("EndDate", out var endDateStr))
            {
                return new { error = "startDate ve endDate parametreleri zorunludur." };
            }

            if (!DateTime.TryParse(startDateStr, out var startDate) ||
                !DateTime.TryParse(endDateStr, out var endDate))
            {
                return new { error = "Tarih formatı geçersiz." };
            }

            return await _productionApiService.GetDailyWithByDateRangeProduction(startDate, endDate);
        }
    }
}
