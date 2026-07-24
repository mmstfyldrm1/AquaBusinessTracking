using BusinessLayer.Abstract;
using BusinessLayer.Abstract.Integrations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SentezIntegrationsController : ControllerBase
    {
        private readonly ISentezQueryService _service;
        private readonly IPlcService _plcService;
        private readonly ILogger<SentezIntegrationsController> _logger;


        public SentezIntegrationsController(
            ISentezQueryService service,
            IPlcService plcService,
            ILogger<SentezIntegrationsController> logger)
        {
            _service = service;
            _plcService = plcService;
            _logger = logger;
        }


        [HttpGet("getpreviousdaystock")]
        public async Task<IActionResult> GetPreviousDay()
        {
            _logger.LogInformation(
                "Önceki gün stok bilgileri isteniyor. Kullanıcı={User}",
                User?.Identity?.Name);


            var result = await _service.GetPreviousDayStockAsync();


            _logger.LogInformation(
                "Önceki gün stok bilgileri başarıyla getirildi.");


            return Ok(result);
        }


        [HttpGet("getStock")]
        public async Task<IActionResult> GetStock()
        {
            _logger.LogInformation(
                "Stok bilgileri isteniyor. Kullanıcı={User}",
                User?.Identity?.Name);


            var result = await _service.GetStockAsync();


            _logger.LogInformation(
                "Stok bilgileri başarıyla getirildi.");


            return Ok(result);
        }


        [HttpGet("getpreviousdaySales")]
        public async Task<IActionResult> GetSalesPreviousDay()
        {
            _logger.LogInformation(
                "Önceki gün satış bilgileri isteniyor.");


            var result = await _service.GetPreviousDaySalesAsync();


            _logger.LogInformation(
                "Önceki gün satış bilgileri başarıyla getirildi.");


            return Ok(result);
        }


        [HttpGet("getSales")]
        public async Task<IActionResult> GetSales()
        {
            _logger.LogInformation(
                "Satış bilgileri isteniyor.");


            var result = await _service.GetSalesAsync();


            _logger.LogInformation(
                "Satış bilgileri başarıyla getirildi.");


            return Ok(result);
        }


        [HttpGet("getLas7DaysProductionAsync")]
        public async Task<IActionResult> GetLas7DaysProductionAsync()
        {
            _logger.LogInformation(
                "Son 7 günlük üretim bilgileri isteniyor.");


            var result = await _service.GetLas7DaysProductionAsync();


            _logger.LogInformation(
                "Son 7 günlük üretim bilgileri getirildi.");


            return Ok(result);
        }


        [HttpGet("getLas30DaysProductionAsync")]
        public async Task<IActionResult> GetLas30DaysProductionAsync()
        {
            _logger.LogInformation(
                "Son 30 günlük üretim bilgileri isteniyor.");


            var result = await _service.GetLas30DaysProductionAsync();


            _logger.LogInformation(
                "Son 30 günlük üretim bilgileri getirildi.");


            return Ok(result);
        }


        [HttpGet("getRawMaterielsPreviousDayStockAsync")]
        public async Task<IActionResult> GetRawMaterielsPreviousDayStockAsync()
        {
            _logger.LogInformation(
                "Önceki gün hammadde stok bilgileri isteniyor.");


            var result = await _service.GetRawMaterielsPreviousDayStockAsync();


            _logger.LogInformation(
                "Önceki gün hammadde stok bilgileri getirildi.");


            return Ok(result);
        }


        [HttpGet("getRawMaterielsStockAsync")]
        public async Task<IActionResult> GetRawMaterielsStockAsync()
        {
            _logger.LogInformation(
                "Hammadde stok bilgileri isteniyor.");


            var result = await _service.GetRawMaterielsStockAsync();


            _logger.LogInformation(
                "Hammadde stok bilgileri başarıyla getirildi.");


            return Ok(result);
        }


        [HttpGet("updateMachineRandoman/{workhours}")]
        public async Task<IActionResult> UpdateMachineRandoman(double workhours)
        {
            _logger.LogInformation(
                "Makine Randoman çalışma saati güncelleniyor. ÇalışmaSaati={WorkHours}",
                workhours);


            var result = await _service.InsertMachineRandoman(workhours);


            _logger.LogInformation(
                "Makine Randoman güncelleme işlemi tamamlandı.");


            return Ok(result);
        }
    }
}