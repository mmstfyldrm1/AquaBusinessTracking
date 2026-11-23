using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierDashboardController : ControllerBase
    {
        private readonly ILogger<SupplierDashboardController> _logger;
        private readonly ISentezSupplierQueryService _service;

        public SupplierDashboardController(ILogger<SupplierDashboardController> logger, ISentezSupplierQueryService supplierDashboardService)
        {
            _logger = logger;
            _service = supplierDashboardService;
        }

        [HttpGet("summary")]
        public async Task<IActionResult> Summary(DateTime startDate, DateTime endDate)
        {
            _logger.LogInformation(
                "Supplier Dashboard Summary başladı. FirstDate: {FirstDate}, SecondDate: {SecondDate}",
                startDate,
                endDate);

            try
            {

                var result = await _service.GetSupplierDashboardSummary(
                    startDate,
                    endDate);

                _logger.LogInformation(
                    "Supplier Dashboard Summary başarıyla tamamlandı. FirstDate: {FirstDate}, SecondDate: {SecondDate}",
                    startDate,
                    endDate);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Supplier Dashboard Summary sırasında hata oluştu. FirstDate: {FirstDate}, SecondDate: {SecondDate}",
                    startDate,
                    endDate);

                return StatusCode(500, "Tedarikçi dashboard özet verileri alınırken hata oluştu.");
            }
        }


        [HttpGet("by-supplier")]
        public async Task<IActionResult> BySupplier(DateTime StartDate, DateTime EndDate)
        {
            _logger.LogInformation(
                "Supplier Dashboard BySupplier başladı. FirstDate: {FirstDate}, SecondDate: {SecondDate}",
                StartDate,
                EndDate);

            try
            {
                var result = await _service.GetSupplierDashboardBySupplier(
                    StartDate,
                    EndDate);

                _logger.LogInformation(
                    "Supplier Dashboard BySupplier başarıyla tamamlandı. Kayıt Sayısı: {Count}",
                    result?.Data.Count ?? 0);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Supplier Dashboard BySupplier sırasında hata oluştu. FirstDate: {FirstDate}, SecondDate: {SecondDate}",
                    StartDate,
                    EndDate);

                return StatusCode(500, "Tedarikçi bazlı dashboard verileri alınırken hata oluştu.");
            }
        }


        [HttpGet("by-date")]
        public async Task<IActionResult> ByDate(DateTime StartDate, DateTime EndDate)
        {
            _logger.LogInformation(
                "Supplier Dashboard ByDate başladı. FirstDate: {FirstDate}, SecondDate: {SecondDate}",
                StartDate,
                EndDate);

            try
            {
                var result = await _service.GetSupplierDashboardByDate(
                    StartDate,
                    EndDate);

                _logger.LogInformation(
                    "Supplier Dashboard ByDate başarıyla tamamlandı. Kayıt Sayısı: {Count}",
                    result?.Data.Count ?? 0);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Supplier Dashboard ByDate sırasında hata oluştu. FirstDate: {FirstDate}, SecondDate: {SecondDate}",
                    StartDate,
                    EndDate);

                return StatusCode(500, "Tarih bazlı dashboard verileri alınırken hata oluştu.");
            }
        }


        [HttpGet("quality")]
        public async Task<IActionResult> Quality(DateTime StartDate, DateTime EndDate)
        {
            _logger.LogInformation(
                "Supplier Dashboard Quality başladı. FirstDate: {FirstDate}, SecondDate: {SecondDate}",
                StartDate,
                EndDate);

            try
            {
                var result = await _service.GetSupplierQuality(
                    StartDate,
                    EndDate);

                _logger.LogInformation(
                    "Supplier Dashboard Quality başarıyla tamamlandı. Kayıt Sayısı: {Count}",
                    result?.Data.Count ?? 0);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Supplier Dashboard Quality sırasında hata oluştu. FirstDate: {FirstDate}, SecondDate: {SecondDate}",
                    StartDate,
                    EndDate);

                return StatusCode(500, "Tedarikçi kalite verileri alınırken hata oluştu.");
            }
        }


        [HttpGet("material-distribution")]
        public async Task<IActionResult> MaterialDistribution(DateTime StartDate, DateTime EndDate)
        {
            _logger.LogInformation(
                "Supplier Dashboard MaterialDistribution başladı. FirstDate: {FirstDate}, SecondDate: {SecondDate}",
                StartDate,
                EndDate);

            try
            {
                var result = await _service.GetSupplierMaterialDistribution(
                    StartDate,
                    EndDate);

                _logger.LogInformation(
                    "Supplier Dashboard MaterialDistribution başarıyla tamamlandı. Kayıt Sayısı: {Count}",
                    result?.Data.Count ?? 0);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Supplier Dashboard MaterialDistribution sırasında hata oluştu. FirstDate: {FirstDate}, SecondDate: {SecondDate}",
                    StartDate,
                    EndDate);

                return StatusCode(500, "Malzeme dağılım verileri alınırken hata oluştu.");
            }
        }


        [HttpGet("trend")]
        public async Task<IActionResult> Trend(DateTime StartDate, DateTime EndDate)
        {
            _logger.LogInformation(
                "Supplier Dashboard Trend başladı. FirstDate: {FirstDate}, SecondDate: {SecondDate}",
                StartDate,
                EndDate);

            try
            {
                var result = await _service.GetSupplierTrend(
                    StartDate,
                    EndDate);

                _logger.LogInformation(
                    "Supplier Dashboard Trend başarıyla tamamlandı. Kayıt Sayısı: {Count}",
                    result?.Data.Count ?? 0);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Supplier Dashboard Trend sırasında hata oluştu. FirstDate: {FirstDate}, SecondDate: {SecondDate}",
                    StartDate,
                    EndDate);

                return StatusCode(500, "Tedarikçi trend verileri alınırken hata oluştu.");
            }
        }

    }
}
