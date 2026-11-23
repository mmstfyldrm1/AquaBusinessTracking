using AIAgent.Services.Abstract.NaturelGas;

namespace AIAgent.Tools.NaturelGas
{
    public class GetWithBySearchNaturelGasTool : IAiTool
    {
        private readonly INaturelGasApiService _apiService;

        public GetWithBySearchNaturelGasTool(INaturelGasApiService apiService)
        {
            _apiService = apiService;
        }

        public string Name => "get_with_by_search_naturel_gas_tool";

        public string Description => "Retrieves Naturel Gas  consumption details for the date range specified by the user. Always respond to the user in Turkish";

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

            return await _apiService.GetWithBySearch(startDate, endDate);
        }
    }
}
