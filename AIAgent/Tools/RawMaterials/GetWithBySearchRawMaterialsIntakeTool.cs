using AIAgent.Services.Abstract.RawMaterials;

namespace AIAgent.Tools.RawMaterials
{
    public class GetWithBySearchRawMaterialsIntakeTool : IAiTool
    {
        private readonly IRawMaterialsApiService _rawMaterialsApiService;

        public GetWithBySearchRawMaterialsIntakeTool(IRawMaterialsApiService rawMaterialsApiService)
        {
            _rawMaterialsApiService = rawMaterialsApiService;
        }

        public string Name => "get_with_by_search_raw_materials_intake_tool";

        public string Description => "Retrieves waste paper raw material purchase and stock intake records between the start date and end date provided by the user. " +
        "The results specifically refer to waste paper raw materials and should not include finished products or other types of raw materials. " +
        "The result may contain multiple records within the specified date range. " +
        "Evaluate each record separately and do not automatically aggregate or combine the records unless the user explicitly asks for a total, summary, or aggregation. " +
        "If the result is empty, clearly state that no waste paper raw material purchase records were found for the specified date range. " +
        "Always respond to the user in Turkish.";

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

            return await _rawMaterialsApiService.GetWithSearchDetails(startDate, endDate);
        }
    }
}
