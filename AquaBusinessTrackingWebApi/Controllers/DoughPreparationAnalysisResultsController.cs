using BusinessLayer.Abstract;
using DTOLayer.Dtos.DoughPreparationDtos.DoughPreparationDetailDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DoughPreparationAnalysisResultsController : ControllerBase
    {
        private readonly IDoughPreparationAnalysisResultsDetailService _service;
        private readonly ILogger<DoughPreparationAnalysisResultsController> _logger;

        public DoughPreparationAnalysisResultsController(
            IDoughPreparationAnalysisResultsDetailService service,
            ILogger<DoughPreparationAnalysisResultsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation(
                "Hamur Hazırlama Analiz Sonuçları listesi istendi. User={User}",
                User?.Identity?.Name);

            var result = await _service.GetList();

            _logger.LogInformation(
                "{Count} adet Hamur Hazırlama Analiz Sonuçları kaydı getirildi.",
                result.Count());

            return Ok(result);
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            _logger.LogInformation(
                "Hamur Hazırlama Analiz Sonuçları detayları istendi. User={User}",
                User?.Identity?.Name);

            var result = await _service.GetWithDetails();

            return Ok(result);
        }

        [HttpGet("getbyId/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation(
                "Hamur Hazırlama Analiz Sonucu getiriliyor. Id={Id}",
                id);

            var result = await _service.GetById(id);

            if (result == null)
            {
                _logger.LogWarning(
                    "Hamur Hazırlama Analiz Sonucu bulunamadı. Id={Id}",
                    id);

                return NotFound();
            }

            _logger.LogInformation(
                "Hamur Hazırlama Analiz Sonucu bulundu. Id={Id}",
                id);

            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateDoughPreparationAnalysisResultsDto doughPreparationDto)
        {
            _logger.LogInformation(
                "Yeni Hamur Hazırlama Analiz Sonucu ekleniyor. User={User}",
                User?.Identity?.Name);

            doughPreparationDto.InsertDate = DateTime.Now;

            var result = await _service.Add(doughPreparationDto);

            _logger.LogInformation(
                "Hamur Hazırlama Analiz Sonucu başarıyla eklendi.");

            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateDoughPreparationAnalysisResultsDto updateDoughPreparationDto)
        {
            _logger.LogInformation(
                "Hamur Hazırlama Analiz Sonucu güncelleniyor. Id={Id}",
                updateDoughPreparationDto.RecId);

            updateDoughPreparationDto.UpdateDate = DateTime.Now;

            await _service.Update(updateDoughPreparationDto);

            _logger.LogInformation(
                "Hamur Hazırlama Analiz Sonucu güncellendi. Id={Id}",
                updateDoughPreparationDto.RecId);

            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogWarning(
                "Hamur Hazırlama Analiz Sonucu siliniyor. Id={Id}, User={User}",
                id,
                User?.Identity?.Name);

            await _service.Delete(id);

            _logger.LogWarning(
                "Hamur Hazırlama Analiz Sonucu silindi. Id={Id}",
                id);

            return Ok();
        }
    }
}