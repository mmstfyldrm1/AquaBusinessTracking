using BusinessLayer.Abstract;
using DTOLayer.Dtos.NaturelGasMeterMonitoringDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NaturelGasMeterMonitoringController : ControllerBase
    {
        private readonly INaturelGasMeterMonitoringService _naturelGasMeterMonitoringService;
        private readonly ILogger<NaturelGasMeterMonitoringController> _logger;

        public NaturelGasMeterMonitoringController(
            INaturelGasMeterMonitoringService naturelGasMeterMonitoringService,
            ILogger<NaturelGasMeterMonitoringController> logger)
        {
            _naturelGasMeterMonitoringService = naturelGasMeterMonitoringService;
            _logger = logger;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation(
                "Doğalgaz Sayaç İzleme listesi istendi. User={User}",
                User?.Identity?.Name);

            var result = await _naturelGasMeterMonitoringService.GetList();

            _logger.LogInformation(
                "{Count} adet Doğalgaz Sayaç İzleme kaydı getirildi.",
                result.Count());

            return Ok(result);
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            _logger.LogInformation(
                "Doğalgaz Sayaç İzleme detayları istendi. User={User}",
                User?.Identity?.Name);

            var result = await _naturelGasMeterMonitoringService.GetWithDetails();

            return Ok(result);
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation(
                "Doğalgaz Sayaç İzleme kaydı getiriliyor. Id={Id}",
                id);

            var result = await _naturelGasMeterMonitoringService.GetById(id);

            if (result == null)
            {
                _logger.LogWarning(
                    "Doğalgaz Sayaç İzleme kaydı bulunamadı. Id={Id}",
                    id);

                return NotFound();
            }

            _logger.LogInformation(
                "Doğalgaz Sayaç İzleme kaydı bulundu. Id={Id}",
                id);

            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateNaturelGasMeterMonitoringDto dto)
        {
            _logger.LogInformation(
                "Yeni Doğalgaz Sayaç İzleme kaydı ekleniyor. User={User}",
                User?.Identity?.Name);

            dto.InsertDate = DateTime.Now;

            var result = await _naturelGasMeterMonitoringService.Add(dto);

            _logger.LogInformation(
                "Doğalgaz Sayaç İzleme kaydı başarıyla eklendi.");

            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] UpdateNaturelGasMeterMonitoringDto dto)
        {
            _logger.LogInformation(
                "Doğalgaz Sayaç İzleme kaydı güncelleniyor. Id={Id}",
                id);

            dto.RecId = id;
            dto.UpdateDate = DateTime.Now;

            await _naturelGasMeterMonitoringService.Update(dto);

            _logger.LogInformation(
                "Doğalgaz Sayaç İzleme kaydı güncellendi. Id={Id}",
                id);

            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogWarning(
                "Doğalgaz Sayaç İzleme kaydı siliniyor. Id={Id}, User={User}",
                id,
                User?.Identity?.Name);

            await _naturelGasMeterMonitoringService.Delete(id);

            _logger.LogWarning(
                "Doğalgaz Sayaç İzleme kaydı silindi. Id={Id}",
                id);

            return Ok();
        }
    }
}