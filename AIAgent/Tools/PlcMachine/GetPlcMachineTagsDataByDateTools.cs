using AIAgent.Services.Abstract.PlcMachine;

namespace AIAgent.Tools.PlcMachine
{
    public class GetPlcMachineTagsDataByDateTools : IAiTool
    {
        private readonly IPlcMachineApiService _plcMachineApiService;

        public GetPlcMachineTagsDataByDateTools(IPlcMachineApiService plcMachineApiService)
        {
            _plcMachineApiService = plcMachineApiService;
        }

        public string Name => "get_plc_machine_tags_data_by_date";

        public string Description => "Retrieves historical PLC machine tag data for a specified date range. " +
                "Use this tool to answer questions about machine measurements, PLC tag values, " +
                "machine operating data, machine status, production-related machine data, " +
                "or other PLC readings recorded during a specific time period. " +
                "The user must provide a start date and an end date. " +
                "Use the returned data as the sole source for answering the user's question " +
                "and do not fabricate, estimate, or assume values that are not present in the tool result.";

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

            return await _plcMachineApiService.GetReadingsAsync(6, startDate, endDate);
        }
    }
}
