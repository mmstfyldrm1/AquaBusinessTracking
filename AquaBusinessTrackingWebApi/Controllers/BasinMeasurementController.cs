using BusinessLayer.Abstract;
using DTOLayer.Dtos.BasinDtos.BasinMeasurement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BasinMeasurementController : ControllerBase
    {
        private readonly IBasinMeasurementService _measurementService;
        private readonly ILogger<BasinMeasurementController> _logger;

        public BasinMeasurementController(
            IBasinMeasurementService measurementService,
            ILogger<BasinMeasurementController> logger)
        {
            _measurementService = measurementService;
            _logger = logger;
        }

        [HttpGet("getbyid/{basinId}")]
        public async Task<IActionResult> GetByBasinId(int basinId)
        {
            _logger.LogInformation(
                "Havuz ölçümleri istendi. BasinId={BasinId}",
                basinId);

            var all = await _measurementService.GetById(basinId);


            _logger.LogInformation(
                "{Count} adet ölçüm döndürüldü. BasinId={BasinId}",
                basinId);

            return Ok(all);
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetDetails()
        {
            _logger.LogInformation(
                "Havuz tüketimleri Detay Sayfası istendi. User={User}",
                User?.Identity?.Name);

            var result = await _measurementService.GetWithDetails();

            return Ok(result);
        }

        [HttpGet("search")]
        public async Task<IActionResult> GetWithSearchDetails([FromQuery] DateTime StartDate, [FromQuery] DateTime EndDate)
        {
            _logger.LogInformation(
                "Havuz tüketimleri {StartDate} - {EndDate} istendi.",
                StartDate,
                EndDate);


            var result = await _measurementService.GetWithSearchDetails(StartDate, EndDate);

            _logger.LogInformation(
              "Havuz tüketimleri Detay Sayfası {StartDate} - {EndDate} başarıyla getirildi.",
              StartDate,
              EndDate);


            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateBasinMeasurementDto dto)
        {
            _logger.LogInformation(
                "Yeni havuz ölçümü ekleniyor. BasinId={BasinId}");


            await _measurementService.Add(dto);

            _logger.LogInformation(
                "Havuz ölçümü eklendi. BasinId={BasinId}");


            return Ok();
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateBasinMeasurementDto dto)
        {
            _logger.LogInformation(
                "Havuz ölçümü güncelleniyor. MeasurementId={MeasurementId}",
                dto.RecId);

            await _measurementService.Update(dto);

            _logger.LogInformation(
                "Havuz ölçümü güncellendi. MeasurementId={MeasurementId}",
                dto.RecId);

            return Ok();
        }

        [HttpDelete("delete/{measurementId}")]
        public async Task<IActionResult> Delete(int measurementId)
        {
            _logger.LogWarning(
                "Havuz ölçümü siliniyor. MeasurementId={MeasurementId}",
                measurementId);

            await _measurementService.Delete(measurementId);

            _logger.LogWarning(
                "Havuz ölçümü silindi. MeasurementId={MeasurementId}",
                measurementId);

            return Ok();
        }
    }
}