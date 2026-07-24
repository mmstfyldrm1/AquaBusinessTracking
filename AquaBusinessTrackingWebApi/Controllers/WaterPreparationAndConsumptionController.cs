using BusinessLayer.Abstract;
using DTOLayer.Dtos.WaterPreparationAndConsumptionDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WaterPreparationAndConsumptionController : ControllerBase
    {
        private readonly IWaterPreparationAndConsumptionService _service;
        private readonly ILogger<WaterPreparationAndConsumptionController> _logger;


        public WaterPreparationAndConsumptionController(
            IWaterPreparationAndConsumptionService service,
            ILogger<WaterPreparationAndConsumptionController> logger)
        {
            _service = service;
            _logger = logger;
        }


        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation(
                "Su hazırlama ve tüketim listesi istendi. Kullanıcı={User}",
                User?.Identity?.Name);


            var result = await _service.GetList();


            _logger.LogInformation(
                "{Count} adet su hazırlama ve tüketim kaydı getirildi.",
                result.Count());


            return Ok(result);
        }


        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            _logger.LogInformation(
                "Su hazırlama ve tüketim detayları istendi.");


            var result = await _service.GetWithDetails();


            _logger.LogInformation(
                "Su hazırlama ve tüketim detayları başarıyla getirildi.");


            return Ok(result);
        }


        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation(
                "Su hazırlama ve tüketim kaydı getiriliyor. Id={Id}",
                id);


            var result = await _service.GetById(id);


            if (result == null)
            {
                _logger.LogWarning(
                    "Su hazırlama ve tüketim kaydı bulunamadı. Id={Id}",
                    id);

                return NotFound();
            }


            _logger.LogInformation(
                "Su hazırlama ve tüketim kaydı bulundu. Id={Id}",
                id);


            return Ok(result);
        }


        [HttpPost("add")]
        public async Task<IActionResult> Add(
            [FromBody] CreateWaterPreparationAndConsumptionDto dto)
        {
            _logger.LogInformation(
                "Yeni su hazırlama ve tüketim kaydı ekleniyor. Kullanıcı={User}",
                User?.Identity?.Name);


            dto.InsertDate = DateTime.Now;


            var result = await _service.Add(dto);


            _logger.LogInformation(
                "Su hazırlama ve tüketim kaydı başarıyla eklendi.");


            return Ok(result);
        }


        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(
            [FromBody] UpdateWaterPreparationAndConsumptionDto dto)
        {
            _logger.LogInformation(
                "Su hazırlama ve tüketim kaydı güncelleniyor.");


            dto.UpdateDate = DateTime.Now;


            await _service.Update(dto);


            _logger.LogInformation(
                "Su hazırlama ve tüketim kaydı başarıyla güncellendi.");


            return Ok();
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogWarning(
                "Su hazırlama ve tüketim kaydı siliniyor. Id={Id}, Kullanıcı={User}",
                id,
                User?.Identity?.Name);


            await _service.Delete(id);


            _logger.LogWarning(
                "Su hazırlama ve tüketim kaydı silindi. Id={Id}",
                id);


            return Ok();
        }
    }
}