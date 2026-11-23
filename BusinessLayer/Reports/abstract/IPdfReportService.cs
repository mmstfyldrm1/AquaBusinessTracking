using DTOLayer.DTOs.Reports;

namespace BusinessLayer.Reports.@abstract
{
    public interface IPdfReportService
    {
        byte[] GenerateTestPdf();

        byte[] GenerateMachineDailyReportPdf(MachineDailyReportDto report);
    }
}
