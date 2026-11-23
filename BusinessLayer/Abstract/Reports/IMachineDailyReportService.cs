using DTOLayer.DTOs.Reports;

namespace BusinessLayer.Abstract.Reports
{
    public interface IMachineDailyReportService
    {
        Task<MachineDailyReportDto?> GetDailyReportAsync(DateTime reportDate);
    }
}
