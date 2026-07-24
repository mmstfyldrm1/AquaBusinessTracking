using BusinessLayer.Abstract;
using DTOLayer.Dtos.ElectricDtos.ElectricShiftDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ElectiricShiftWorkController : ControllerBase
    {
        private readonly IElectiricShiftWorkService _electricShiftWorkService;
        private readonly ILogger<ElectiricShiftWorkController> _logger;

        public ElectiricShiftWorkController(
            IElectiricShiftWorkService electricShiftWorkService,
            ILogger<ElectiricShiftWorkController> logger)
        {
            _electricShiftWorkService = electricShiftWorkService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            _logger.LogInformation(
                "Elektrik Vardiya Çalışması listesi istendi. User={User}",
                User?.Identity?.Name);

            var result = await _electricShiftWorkService.GetList();

            _logger.LogInformation(
                "{Count} adet Elektrik Vardiya Çalışması kaydı getirildi.",
                result.Count());

            return Ok(result);
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            _logger.LogInformation(
                "Elektrik Vardiya Çalışması detayları istendi. User={User}",
                User?.Identity?.Name);

            var result = await _electricShiftWorkService.GetWithDetails();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation(
                "Elektrik Vardiya Çalışması getiriliyor. Id={Id}",
                id);

            var result = await _electricShiftWorkService.GetById(id);

            if (result == null)
            {
                _logger.LogWarning(
                    "Elektrik Vardiya Çalışması bulunamadı. Id={Id}",
                    id);

                return NotFound();
            }

            _logger.LogInformation(
                "Elektrik Vardiya Çalışması bulundu. Id={Id}",
                id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateElectricShiftWorkDto dto)
        {
            _logger.LogInformation(
                "Yeni Elektrik Vardiya Çalışması ekleniyor. User={User}",
                User?.Identity?.Name);

            dto.InsertDate = DateTime.Now;

            await _electricShiftWorkService.Add(dto);

            _logger.LogInformation(
                "Elektrik Vardiya Çalışması başarıyla eklendi.");

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateElectiricShiftWorkDto dto)
        {
            _logger.LogInformation(
                "Elektrik Vardiya Çalışması güncelleniyor. Id={Id}",
                id);

            dto.RecId = id;
            dto.UpdateDate = DateTime.Now;

            await _electricShiftWorkService.Update(dto);

            _logger.LogInformation(
                "Elektrik Vardiya Çalışması güncellendi. Id={Id}",
                id);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogWarning(
                "Elektrik Vardiya Çalışması siliniyor. Id={Id}, User={User}",
                id,
                User?.Identity?.Name);

            await _electricShiftWorkService.Delete(id);

            _logger.LogWarning(
                "Elektrik Vardiya Çalışması silindi. Id={Id}",
                id);

            return Ok();
        }
    }
}