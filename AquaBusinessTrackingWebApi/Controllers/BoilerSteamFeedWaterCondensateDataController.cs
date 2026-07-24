using BusinessLayer.Abstract;
using DTOLayer.Dtos.BoilerSteamFeedWaterCondensateDataDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BoilerSteamFeedWaterCondensateDataController : ControllerBase
    {
        private readonly IBoilerSteamFeedWaterCondensateDataService _boilerSteamFeedWaterCondensateDataService;
        private readonly ILogger<BoilerSteamFeedWaterCondensateDataController> _logger;

        public BoilerSteamFeedWaterCondensateDataController(
            IBoilerSteamFeedWaterCondensateDataService boilerSteamFeedWaterCondensateDataService,
            ILogger<BoilerSteamFeedWaterCondensateDataController> logger)
        {
            _boilerSteamFeedWaterCondensateDataService = boilerSteamFeedWaterCondensateDataService;
            _logger = logger;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation(
                "Kazan Buhar/Besleme Suyu/Kondens verileri listelendi. User={User}",
                User?.Identity?.Name);

            var result = await _boilerSteamFeedWaterCondensateDataService.GetList();

            _logger.LogInformation(
                "{Count} adet kayıt getirildi.",
                result.Count());

            return Ok(result);
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            _logger.LogInformation(
                "Kazan Buhar/Besleme Suyu/Kondens detayları istendi. User={User}",
                User?.Identity?.Name);

            var result = await _boilerSteamFeedWaterCondensateDataService.GetWithDetails();

            return Ok(result);
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation(
                "Kayıt getiriliyor. Id={Id}",
                id);

            var result = await _boilerSteamFeedWaterCondensateDataService.GetById(id);

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
        public async Task<IActionResult> Add([FromBody] CreateBoilerSteamFeedWaterCondensateDataDto dto)
        {
            _logger.LogInformation(
                "Yeni kayıt ekleniyor. User={User}",
                User?.Identity?.Name);

            dto.InsertDate = DateTime.Now;

            var result = await _boilerSteamFeedWaterCondensateDataService.Add(dto);

            _logger.LogInformation(
                "Kayıt başarıyla eklendi.");

            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateBoilerSteamFeedWaterCondensateDataDto dto)
        {
            _logger.LogInformation(
                "Kayıt güncelleniyor. Id={Id}",
                dto.RecId);

            dto.UpdateDate = DateTime.Now;

            await _boilerSteamFeedWaterCondensateDataService.Update(dto);

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

            await _boilerSteamFeedWaterCondensateDataService.Delete(id);

            _logger.LogWarning(
                "Kayıt silindi. Id={Id}",
                id);

            return Ok();
        }
    }
}