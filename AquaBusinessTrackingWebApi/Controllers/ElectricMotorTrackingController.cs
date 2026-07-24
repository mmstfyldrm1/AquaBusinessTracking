using BusinessLayer.Abstract;
using DTOLayer.Dtos.ElectricDtos.ElectricMotorTrackingDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ElectricMotorTrackingController : ControllerBase
    {
        private readonly IElectricMotorTrackingService _electricMotorTrackingService;
        private readonly ILogger<ElectricMotorTrackingController> _logger;

        public ElectricMotorTrackingController(
            IElectricMotorTrackingService electricMotorTrackingService,
            ILogger<ElectricMotorTrackingController> logger)
        {
            _electricMotorTrackingService = electricMotorTrackingService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            _logger.LogInformation(
                "Elektrik Motor Takip listesi istendi. User={User}",
                User?.Identity?.Name);

            var result = await _electricMotorTrackingService.GetList();

            _logger.LogInformation(
                "{Count} adet Elektrik Motor Takip kaydı getirildi.",
                result.Count());

            return Ok(result);
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            _logger.LogInformation(
                "Elektrik Motor Takip detayları istendi. User={User}",
                User?.Identity?.Name);

            var result = await _electricMotorTrackingService.GetWithDetails();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation(
                "Elektrik Motor Takip kaydı getiriliyor. Id={Id}",
                id);

            var result = await _electricMotorTrackingService.GetById(id);

            if (result == null)
            {
                _logger.LogWarning(
                    "Elektrik Motor Takip kaydı bulunamadı. Id={Id}",
                    id);

                return NotFound();
            }

            _logger.LogInformation(
                "Elektrik Motor Takip kaydı bulundu. Id={Id}",
                id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateElectricMotorDto dto)
        {
            _logger.LogInformation(
                "Yeni Elektrik Motor Takip kaydı ekleniyor. User={User}",
                User?.Identity?.Name);

            dto.InsertDate = DateTime.Now;

            await _electricMotorTrackingService.Add(dto);

            _logger.LogInformation(
                "Elektrik Motor Takip kaydı başarıyla eklendi.");

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateElectricMotorDto dto)
        {
            _logger.LogInformation(
                "Elektrik Motor Takip kaydı güncelleniyor. Id={Id}",
                id);

            dto.RecId = id;
            dto.UpdateDate = DateTime.Now;

            await _electricMotorTrackingService.Update(dto);

            _logger.LogInformation(
                "Elektrik Motor Takip kaydı güncellendi. Id={Id}",
                id);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogWarning(
                "Elektrik Motor Takip kaydı siliniyor. Id={Id}, User={User}",
                id,
                User?.Identity?.Name);

            await _electricMotorTrackingService.Delete(id);

            _logger.LogWarning(
                "Elektrik Motor Takip kaydı silindi. Id={Id}",
                id);

            return Ok();
        }
    }
}