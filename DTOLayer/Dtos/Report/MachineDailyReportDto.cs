
namespace DTOLayer.DTOs.Reports
{
    public class MachineDailyReportDto
    {
        public int MachineId { get; set; }
        public string MachineName { get; set; } = string.Empty;
        public DateTime ReportDate { get; set; }

        public List<MachineDailyReportItemDto> Items { get; set; } = new();

        public bool HasMissingData => Items.Any(x => x.Value == null);
    }

    public class MachineDailyReportItemDto
    {
        public int TagId { get; set; }
        public string TagName { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string Unit { get; set; } = string.Empty;

        public double? Value { get; set; }
        public DateTime? ReadingTime { get; set; }

        public bool HasData => Value.HasValue;
    }
}
