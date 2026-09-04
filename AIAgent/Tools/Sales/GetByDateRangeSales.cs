using AIAgent.Services.Abstract.Sales;

namespace AIAgent.Tools.Sales
{
    public class GetByDateRangeSales : IAiTool
    {
        private readonly ISalesApiService _salesApiService;

        public GetByDateRangeSales(ISalesApiService salesApiService)
        {
            _salesApiService = salesApiService;
        }

        public string Name => "get_by_date_range_sales";

        public string Description => "Kullanıcı tarafından belirtilen tarih aralığındaki satış bilgilerini getirir.";

        public object ParametersSchema => new
        {
            type = "object",
            properties = new
            {
                StartDate = new { type = "string", format = "date" },
                EndDate = new { type = "string", format = "date" }
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

            return await _salesApiService.GetSalesGetbyDateAsync(startDate, endDate);
        }
    }
}
