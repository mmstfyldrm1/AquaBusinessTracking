using BusinessLayer.Abstract;
using DTOLayer.Dtos.ElectricDtos.ElectricMeterLocationDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ElectricMeterLocationController : ControllerBase
    {
        private readonly IElectricMeterLocationService _service;
        private readonly ILogger<ElectricMeterLocationController> _logger;

        public ElectricMeterLocationController(
            IElectricMeterLocationService service,
            ILogger<ElectricMeterLocationController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            _logger.LogInformation(
                "Elektrik Sayaç Lokasyonları listesi istendi. User={User}",
                User?.Identity?.Name);

            var result = await _service.GetList();

            _logger.LogInformation(
                "{Count} adet Elektrik Sayaç Lokasyonu getirildi.",
                result.Count());

            return Ok(result);
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            _logger.LogInformation(
                "Elektrik Sayaç Lokasyonu detayları istendi. User={User}",
                User?.Identity?.Name);

            var result = await _service.GetWithDetails();

            return Ok(result);
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation(
                "Elektrik Sayaç Lokasyonu getiriliyor. Id={Id}",
                id);

            var result = await _service.GetById(id);

            if (result == null)
            {
                _logger.LogWarning(
                    "Elektrik Sayaç Lokasyonu bulunamadı. Id={Id}",
                    id);

                return NotFound();
            }

            _logger.LogInformation(
                "Elektrik Sayaç Lokasyonu bulundu. Id={Id}",
                id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateElectricMeterLocationDto dto)
        {
            _logger.LogInformation(
                "Yeni Elektrik Sayaç Lokasyonu ekleniyor. User={User}",
                User?.Identity?.Name);

            dto.InsertDate = DateTime.Now;

            await _service.Add(dto);

            _logger.LogInformation(
                "Elektrik Sayaç Lokasyonu başarıyla eklendi.");

            return Ok();
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateElectricMeterLocationDto dto)
        {
            _logger.LogInformation(
                "Elektrik Sayaç Lokasyonu güncelleniyor. Id={Id}",
                id);

            dto.RecId = id;
            dto.UpdateDate = DateTime.Now;

            await _service.Update(dto);

            _logger.LogInformation(
                "Elektrik Sayaç Lokasyonu güncellendi. Id={Id}",
                id);

            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogWarning(
                "Elektrik Sayaç Lokasyonu siliniyor. Id={Id}, User={User}",
                id,
                User?.Identity?.Name);

            await _service.Delete(id);

            _logger.LogWarning(
                "Elektrik Sayaç Lokasyonu silindi. Id={Id}",
                id);

            return Ok();
        }
    }
}