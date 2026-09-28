
using AIAgent.Services.Abstract.Production;

namespace AIAgent.Tools.Production
{
    public class GetWithProductionByDateTool : IAiTool
    {
        private readonly IProductionApiService _productionApiService;

        public GetWithProductionByDateTool(IProductionApiService productionApiService)
        {
            _productionApiService = productionApiService;
        }

        public string Name => "get_with_production_by_date_tool";

        public string Description => "Retrieves finished product production data for the start date and end date provided by the user. " +
        "The result may contain multiple production records within the specified date range. " +
        "Evaluate each record separately and do not automatically aggregate or combine the records unless the user explicitly asks for a total, summary, or aggregation. " +
        "If the result is empty, clearly state that no finished product production records were found for the specified date range. " +
        "Always respond to the user in Turkish.";

        public object ParametersSchema => new
        {
            type = "object",
            properties = new
            {
                StartDate = new { type = "string", format = "date", description = "Rapor başlangıç tarihi" },
                EndDate = new { type = "string", format = "date", description = "Rapor bitiş tarihi" }
            },
            required = new[] { "StartDate", "EndDate" }
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
