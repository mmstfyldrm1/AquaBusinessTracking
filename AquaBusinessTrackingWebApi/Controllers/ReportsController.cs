
using BusinessLayer.Abstract.MailService.@abstract;
using BusinessLayer.Abstract.Reports;
using BusinessLayer.Reports.@abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReportsController : ControllerBase
    {
        private readonly IMachineDailyReportService _machineReportService;
        private readonly IPdfReportService _pdfReportService;
        private readonly IReportEmailService _reportEmailService;

        public ReportsController(IMachineDailyReportService machineReportService, IPdfReportService pdfReportService, IReportEmailService reportEmailService)
        {
            _machineReportService = machineReportService;
            _pdfReportService = pdfReportService;
            _reportEmailService = reportEmailService;
        }

        [HttpGet("machine-daily")]
        public async Task<IActionResult> GetMachineDaily([FromQuery] DateTime? reportDate)
        {
            var selectedDate = reportDate?.Date ?? DateTime.Today.AddDays(-1);


            var report = await _machineReportService
                .GetDailyReportAsync(selectedDate);

            if (report == null)
            {
                return NotFound(new
                {
                    Success = false,
                    Message = "Makine bulunamadı."
                });
            }

            return Ok(new
            {
                Success = true,
                Data = report
            });
        }

        [HttpGet("machine-daily/pdf")]
        public async Task<IActionResult> GetMachineDailyPdf([FromQuery] DateTime? reportDate)
        {
            var selectedDate = reportDate?.Date
                               ?? DateTime.Today.AddDays(-1);

            var report = await _machineReportService
                .GetDailyReportAsync(selectedDate);

            if (report == null)
                return NotFound("Makine bulunamadı.");

            var pdfBytes = _pdfReportService
                .GenerateMachineDailyReportPdf(report);

            return File(
                pdfBytes,
                "application/pdf",
                $"MakineGunlukRapor_{selectedDate:yyyyMMdd}.pdf");
        }

        [HttpGet("test/machine-daily/pdf")]
        public async Task<IActionResult> SendMachineDailyReportTest([FromQuery] string recipientEmail, [FromQuery] DateTime? reportDate)
        {
            if (string.IsNullOrWhiteSpace(recipientEmail))
                return BadRequest("Alıcı e-posta adresi zorunludur.");

            var selectedDate = reportDate?.Date ?? DateTime.Today.AddDays(-1);

            await _reportEmailService.SendMachineDailyReportAsync(
                recipientEmail,
                selectedDate);

            return Ok(new
            {
                Success = true,
                Message = "Günlük makine raporu e-posta gönderimi tamamlandı.",
                Recipient = recipientEmail,
                ReportDate = selectedDate
            });
        }
    }
}
