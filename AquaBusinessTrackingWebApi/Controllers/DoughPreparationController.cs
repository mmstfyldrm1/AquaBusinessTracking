using BusinessLayer.Abstract;
using DTOLayer.Dtos.DoughPreparationDtos.DoughPreparationHeadDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DoughPreparationController : ControllerBase
    {
        private readonly IDoughPreparationHeadService _doughPreparationHeadService;
        private readonly ILogger<DoughPreparationController> _logger;

        public DoughPreparationController(
            IDoughPreparationHeadService doughPreparationHeadService,
            ILogger<DoughPreparationController> logger)
        {
            _doughPreparationHeadService = doughPreparationHeadService;
            _logger = logger;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation(
                "Hamur Hazırlama listesi istendi. User={User}",
                User?.Identity?.Name);

            var result = await _doughPreparationHeadService.GetList();

            _logger.LogInformation(
                "{Count} adet Hamur Hazırlama kaydı getirildi.",
                result.Count());

            return Ok(result);
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            _logger.LogInformation(
                "Hamur Hazırlama detayları istendi. User={User}",
                User?.Identity?.Name);

            var result = await _doughPreparationHeadService.GetWithDetails();

            return Ok(result);
        }

        [HttpGet("getbyId/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation(
                "Hamur Hazırlama kaydı getiriliyor. Id={Id}",
                id);

            var result = await _doughPreparationHeadService.GetById(id);

            if (result == null)
            {
                _logger.LogWarning(
                    "Hamur Hazırlama kaydı bulunamadı. Id={Id}",
                    id);

                return NotFound();
            }

            _logger.LogInformation(
                "Hamur Hazırlama kaydı bulundu. Id={Id}",
                id);

            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateDoughPreparationDto doughPreparationDto)
        {
            _logger.LogInformation(
                "Yeni Hamur Hazırlama kaydı ekleniyor. User={User}",
                User?.Identity?.Name);

            doughPreparationDto.InsertDate = DateTime.Now;

            var result = await _doughPreparationHeadService.Add(doughPreparationDto);

            _logger.LogInformation(
                "Hamur Hazırlama kaydı başarıyla eklendi.");

            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateDoughPreparationDto updateDoughPreparationDto)
        {
            _logger.LogInformation(
                "Hamur Hazırlama kaydı güncelleniyor. Id={Id}",
                updateDoughPreparationDto.RecId);

            updateDoughPreparationDto.UpdateDate = DateTime.Now;

            await _doughPreparationHeadService.Update(updateDoughPreparationDto);

            _logger.LogInformation(
                "Hamur Hazırlama kaydı güncellendi. Id={Id}",
                updateDoughPreparationDto.RecId);

            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogWarning(
                "Hamur Hazırlama kaydı siliniyor. Id={Id}, User={User}",
                id,
                User?.Identity?.Name);

            await _doughPreparationHeadService.Delete(id);

            _logger.LogWarning(
                "Hamur Hazırlama kaydı silindi. Id={Id}",
                id);

            return Ok();
        }
    }
}