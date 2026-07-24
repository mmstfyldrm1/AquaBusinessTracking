using BusinessLayer.Abstract;
using DTOLayer.Dtos.WaterTreatmentAnalysisResultsDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WaterTreatmentAnalysisResultsController : ControllerBase
    {
        private readonly IWaterTreatmentAnalysisResultsService _service;
        private readonly ILogger<WaterTreatmentAnalysisResultsController> _logger;


        public WaterTreatmentAnalysisResultsController(
            IWaterTreatmentAnalysisResultsService service,
            ILogger<WaterTreatmentAnalysisResultsController> logger)
        {
            _service = service;
            _logger = logger;
        }


        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation(
                "Su arıtma analiz sonuçları listesi istendi. Kullanıcı={User}",
                User?.Identity?.Name);


            var result = await _service.GetList();


            _logger.LogInformation(
                "{Count} adet su arıtma analiz sonucu getirildi.",
                result.Count());


            return Ok(result);
        }


        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            _logger.LogInformation(
                "Su arıtma analiz sonuç detayları istendi.");


            var result = await _service.GetWithDetails();


            _logger.LogInformation(
                "Su arıtma analiz sonuç detayları başarıyla getirildi.");


            return Ok(result);
        }


        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation(
                "Su arıtma analiz sonucu getiriliyor. Id={Id}",
                id);


            var result = await _service.GetById(id);


            if (result == null)
            {
                _logger.LogWarning(
                    "Su arıtma analiz sonucu bulunamadı. Id={Id}",
                    id);

                return NotFound();
            }


            _logger.LogInformation(
                "Su arıtma analiz sonucu bulundu. Id={Id}",
                id);


            return Ok(result);
        }


        [HttpPost("add")]
        public async Task<IActionResult> Add(
            [FromBody] CreateWaterTreatmentAnalysisResultsDto dto)
        {
            _logger.LogInformation(
                "Yeni su arıtma analiz sonucu ekleniyor. Kullanıcı={User}",
                User?.Identity?.Name);


            dto.InsertDate = DateTime.Now;


            var result = await _service.Add(dto);


            _logger.LogInformation(
                "Su arıtma analiz sonucu başarıyla eklendi.");


            return Ok(result);
        }


        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(
            [FromBody] UpdateWaterTreatmentAnalysisResultsDto dto)
        {
            _logger.LogInformation(
                "Su arıtma analiz sonucu güncelleniyor.");


            dto.UpdateDate = DateTime.Now;


            await _service.Update(dto);


            _logger.LogInformation(
                "Su arıtma analiz sonucu başarıyla güncellendi.");


            return Ok();
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogWarning(
                "Su arıtma analiz sonucu siliniyor. Id={Id}, Kullanıcı={User}",
                id,
                User?.Identity?.Name);


            await _service.Delete(id);


            _logger.LogWarning(
                "Su arıtma analiz sonucu silindi. Id={Id}",
                id);


            return Ok();
        }
    }
}