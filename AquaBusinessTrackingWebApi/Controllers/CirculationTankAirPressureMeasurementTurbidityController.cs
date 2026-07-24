using BusinessLayer.Abstract;
using DTOLayer.Dtos.CirculationTankAirPressureMeasurementTurbidityDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CirculationTankAirPressureMeasurementTurbidityController : ControllerBase
    {
        private readonly ICirculationTankAirPressureMeasurementTurbidityService _circulationTurbidityService;
        private readonly ILogger<CirculationTankAirPressureMeasurementTurbidityController> _logger;

        public CirculationTankAirPressureMeasurementTurbidityController(
            ICirculationTankAirPressureMeasurementTurbidityService circulationTurbidityService,
            ILogger<CirculationTankAirPressureMeasurementTurbidityController> logger)
        {
            _circulationTurbidityService = circulationTurbidityService;
            _logger = logger;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation(
                "Circulation Tank Air Pressure Measurement Turbidity listesi istendi. User={User}",
                User?.Identity?.Name);

            var result = await _circulationTurbidityService.GetList();

            _logger.LogInformation(
                "{Count} adet kayıt getirildi.",
                result.Count());

            return Ok(result);
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            _logger.LogInformation(
                "Circulation Tank Air Pressure Measurement Turbidity detayları istendi. User={User}",
                User?.Identity?.Name);

            var result = await _circulationTurbidityService.GetWithDetails();

            return Ok(result);
        }

        [HttpGet("getbyId/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation(
                "Kayıt getiriliyor. Id={Id}",
                id);

            var result = await _circulationTurbidityService.GetById(id);

            if (result == null)
            {
                _logger.LogWarning(
                    "Kayıt bulunamadı. Id={Id}",
                    id);

                return NotFound();
            }

            _logger.LogInformation(
                "Kayıt bulundu. Id={Id}",
                id);

            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateCirculationTankAirPressureMeasurementTurbidityDto dto)
        {
            _logger.LogInformation(
                "Yeni kayıt ekleniyor. User={User}",
                User?.Identity?.Name);

            dto.InsertDate = DateTime.Now;

            var result = await _circulationTurbidityService.Add(dto);

            _logger.LogInformation(
                "Kayıt başarıyla eklendi.");

            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateCirculationTankAirPressureMeasurementTurbidityDto dto)
        {
            _logger.LogInformation(
                "Kayıt güncelleniyor. Id={Id}",
                dto.RecId);

            dto.UpdateDate = DateTime.Now;

            await _circulationTurbidityService.Update(dto);

            _logger.LogInformation(
                "Kayıt güncellendi. Id={Id}",
                dto.RecId);

            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogWarning(
                "Kayıt siliniyor. Id={Id}, User={User}",
                id,
                User?.Identity?.Name);

            await _circulationTurbidityService.Delete(id);

            _logger.LogWarning(
                "Kayıt silindi. Id={Id}",
                id);

            return Ok();
        }
    }
}