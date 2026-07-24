using BusinessLayer.Abstract;
using DTOLayer.Dtos.PurificationChemicalsConsumptionDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PurificationChemicalsConsumptionController : ControllerBase
    {
        private readonly IPurificationChemicalsConsumptionService _service;
        private readonly ILogger<PurificationChemicalsConsumptionController> _logger;

        public PurificationChemicalsConsumptionController(
            IPurificationChemicalsConsumptionService service,
            ILogger<PurificationChemicalsConsumptionController> logger)
        {
            _service = service;
            _logger = logger;
        }


        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation(
                "Purification Chemicals Consumption listesi istendi. User={User}",
                User?.Identity?.Name);

            var result = await _service.GetList();

            _logger.LogInformation(
                "{Count} adet Purification Chemicals Consumption kaydı getirildi.",
                result.Count());

            return Ok(result);
        }


        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            _logger.LogInformation(
                "Purification Chemicals Consumption detayları istendi. User={User}",
                User?.Identity?.Name);

            var result = await _service.GetWithDetails();

            return Ok(result);
        }


        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation(
                "Purification Chemicals Consumption kaydı getiriliyor. Id={Id}",
                id);

            var result = await _service.GetById(id);

            if (result == null)
            {
                _logger.LogWarning(
                    "Purification Chemicals Consumption kaydı bulunamadı. Id={Id}",
                    id);

                return NotFound();
            }

            _logger.LogInformation(
                "Purification Chemicals Consumption kaydı bulundu. Id={Id}",
                id);

            return Ok(result);
        }


        [HttpPost("add")]
        public async Task<IActionResult> Add(
            [FromBody] CreatePurificationChemicalsConsumptionDto dto)
        {
            _logger.LogInformation(
                "Yeni Purification Chemicals Consumption kaydı ekleniyor. User={User}",
                User?.Identity?.Name);

            dto.InsertDate = DateTime.Now;

            var result = await _service.Add(dto);

            _logger.LogInformation(
                "Purification Chemicals Consumption kaydı başarıyla eklendi.");

            return Ok(result);
        }


        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] UpdatePurificationChemicalsConsumptionDto dto)
        {
            _logger.LogInformation(
                "Purification Chemicals Consumption kaydı güncelleniyor. Id={Id}",
                id);

            dto.RecId = id;
            dto.UpdateDate = DateTime.Now;

            await _service.Update(dto);

            _logger.LogInformation(
                "Purification Chemicals Consumption kaydı güncellendi. Id={Id}",
                id);

            return Ok();
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogWarning(
                "Purification Chemicals Consumption kaydı siliniyor. Id={Id}, User={User}",
                id,
                User?.Identity?.Name);

            await _service.Delete(id);

            _logger.LogWarning(
                "Purification Chemicals Consumption kaydı silindi. Id={Id}",
                id);

            return Ok();
        }
    }
}