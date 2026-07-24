using BusinessLayer.Abstract;
using DTOLayer.Dtos.ElectricDtos.CumulativeElectricityConsumptionDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CumulativeElectricityConsumptionController : ControllerBase
    {
        private readonly ICumulativeElectricityConsumptionService _service;
        private readonly ILogger<CumulativeElectricityConsumptionController> _logger;

        public CumulativeElectricityConsumptionController(
            ICumulativeElectricityConsumptionService service,
            ILogger<CumulativeElectricityConsumptionController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation(
                "Kümülatif elektrik tüketimi listesi istendi. User={User}",
                User?.Identity?.Name);

            var result = await _service.GetList();

            _logger.LogInformation(
                "{Count} adet kümülatif elektrik tüketimi kaydı getirildi.",
                result.Count());

            return Ok(result);
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            _logger.LogInformation(
                "Kümülatif elektrik tüketimi detayları istendi. User={User}",
                User?.Identity?.Name);

            var result = await _service.GetWithDetails();

            return Ok(result);
        }

        [HttpGet("location")]
        public async Task<IActionResult> GetLocationName()
        {
            _logger.LogInformation(
                "Elektrik lokasyon bilgileri istendi. User={User}",
                User?.Identity?.Name);

            var result = await _service.GetLocationName();

            _logger.LogInformation(
                "{Count} adet lokasyon getirildi.",
                result.Count());

            return Ok(result);
        }

        [HttpGet("getbyId/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation(
                "Kümülatif elektrik tüketimi kaydı getiriliyor. Id={Id}",
                id);

            var result = await _service.GetById(id);

            if (result == null)
            {
                _logger.LogWarning(
                    "Kümülatif elektrik tüketimi kaydı bulunamadı. Id={Id}",
                    id);

                return NotFound();
            }

            _logger.LogInformation(
                "Kümülatif elektrik tüketimi kaydı bulundu. Id={Id}",
                id);

            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateCumulativeElectricityConsumptionDto dto)
        {
            _logger.LogInformation(
                "Yeni kümülatif elektrik tüketimi kaydı ekleniyor. User={User}",
                User?.Identity?.Name);

            dto.InsertDate = DateTime.Now;

            var result = await _service.Add(dto);

            _logger.LogInformation(
                "Kümülatif elektrik tüketimi kaydı başarıyla eklendi.");

            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateCumulativeElectricityConsumptionDto dto)
        {
            _logger.LogInformation(
                "Kümülatif elektrik tüketimi kaydı güncelleniyor. Id={Id}",
                dto.RecId);

            dto.UpdateDate = DateTime.Now;

            await _service.Update(dto);

            _logger.LogInformation(
                "Kümülatif elektrik tüketimi kaydı güncellendi. Id={Id}",
                dto.RecId);

            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogWarning(
                "Kümülatif elektrik tüketimi kaydı siliniyor. Id={Id}, User={User}",
                id,
                User?.Identity?.Name);

            await _service.Delete(id);

            _logger.LogWarning(
                "Kümülatif elektrik tüketimi kaydı silindi. Id={Id}",
                id);

            return Ok();
        }
    }
}