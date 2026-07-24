using BusinessLayer.Abstract;
using DTOLayer.Dtos.BasinDtos.BasinDto;
using DTOLayer.Dtos.BasinDtos.BasinMeasurement;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BasinController : ControllerBase
    {
        private readonly IBasinService _basinService;
        private readonly IBasinMeasurementService _measurementService;
        private readonly ILogger<BasinController> _logger;

        public BasinController(
            IBasinService basinService,
            IBasinMeasurementService measurementService,
            ILogger<BasinController> logger)
        {
            _basinService = basinService;
            _measurementService = measurementService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation(
                "Havuz listesi istendi. User={User}",
                User?.Identity?.Name);

            var result = await _basinService.GetList();

            _logger.LogInformation(
                "{Count} adet havuz döndürüldü.",
                result.Count());

            return Ok(result);
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetDetails()
        {
            _logger.LogInformation(
                "Havuz detayları istendi. User={User}",
                User?.Identity?.Name);

            var result = await _basinService.GetWithDetails();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation(
                "Havuz getiriliyor. Id={Id}",
                id);

            var result = await _basinService.GetById(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBasinDto dto)
        {
            _logger.LogInformation(
                "Yeni havuz ekleniyor. User={User}",
                User?.Identity?.Name);

            dto.InsertDate = DateTime.Now;

            await _basinService.Add(dto);

            var all = await _basinService.GetList();
            var last = all.OrderByDescending(x => x.RecId).FirstOrDefault();

            _logger.LogInformation(
                "Havuz eklendi. BasinId={Id}",
                last?.RecId);

            return Ok(last);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateBasinDto dto)
        {
            _logger.LogInformation(
                "Havuz güncelleniyor. Id={Id}",
                dto.RecId);

            dto.UpdateDate = DateTime.Now;

            await _basinService.Update(dto);

            _logger.LogInformation(
                "Havuz güncellendi. Id={Id}",
                dto.RecId);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogWarning(
                "Havuz siliniyor. Id={Id}, User={User}",
                id,
                User?.Identity?.Name);

            await _basinService.Delete(id);

            _logger.LogWarning(
                "Havuz silindi. Id={Id}",
                id);

            return Ok();
        }

        [HttpGet("{basinId}/measurements")]
        public async Task<IActionResult> GetMeasurements(int basinId)
        {
            _logger.LogInformation(
                "Havuz ölçümleri istendi. BasinId={BasinId}",
                basinId);

            var all = await _measurementService.GetList();
            var result = all.Where(x => x.BasinId == basinId).ToList();

            _logger.LogInformation(
                "{Count} adet ölçüm döndürüldü. BasinId={BasinId}",
                result.Count,
                basinId);

            return Ok(result);
        }

        [HttpPost("{basinId}/measurement")]
        public async Task<IActionResult> AddMeasurement(
            int basinId,
            [FromBody] CreateBasinMeasurementDto dto)
        {
            _logger.LogInformation(
                "Yeni havuz ölçümü ekleniyor. BasinId={BasinId}",
                basinId);

            dto.BasinId = basinId;

            await _measurementService.Add(dto);

            _logger.LogInformation(
                "Havuz ölçümü eklendi. BasinId={BasinId}",
                basinId);

            return Ok();
        }

        [HttpPut("{basinId}/measurement")]
        public async Task<IActionResult> UpdateMeasurement(
            int basinId,
            [FromBody] UpdateBasinMeasurementDto dto)
        {
            _logger.LogInformation(
                "Havuz ölçümü güncelleniyor. MeasurementId={MeasurementId}",
                dto.Id);

            await _measurementService.Update(dto);

            _logger.LogInformation(
                "Havuz ölçümü güncellendi. MeasurementId={MeasurementId}",
                dto.Id);

            return Ok();
        }

        [HttpDelete("{basinId}/measurement/{measurementId}")]
        public async Task<IActionResult> DeleteMeasurement(
            int basinId,
            int measurementId)
        {
            _logger.LogWarning(
                "Havuz ölçümü siliniyor. BasinId={BasinId}, MeasurementId={MeasurementId}",
                basinId,
                measurementId);

            await _measurementService.Delete(measurementId);

            _logger.LogWarning(
                "Havuz ölçümü silindi. MeasurementId={MeasurementId}",
                measurementId);

            return Ok();
        }
    }
}