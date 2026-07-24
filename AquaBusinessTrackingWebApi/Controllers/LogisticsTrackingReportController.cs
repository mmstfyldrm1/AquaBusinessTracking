using BusinessLayer.Abstract;
using DTOLayer.Dtos.LogisticsTrackingReportDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LogisticsTrackingReportController : ControllerBase
    {
        private readonly ILogisticsTrackingReportService _logisticsTrackingReportService;
        private readonly ILogger<LogisticsTrackingReportController> _logger;

        public LogisticsTrackingReportController(
            ILogisticsTrackingReportService logisticsTrackingReportService,
            ILogger<LogisticsTrackingReportController> logger)
        {
            _logisticsTrackingReportService = logisticsTrackingReportService;
            _logger = logger;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation(
                "Lojistik Takip Raporu listesi istendi. User={User}",
                User?.Identity?.Name);

            var result = await _logisticsTrackingReportService.GetList();

            _logger.LogInformation(
                "{Count} adet Lojistik Takip Raporu kaydı getirildi.",
                result.Count());

            return Ok(result);
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            _logger.LogInformation(
                "Lojistik Takip Raporu detayları istendi. User={User}",
                User?.Identity?.Name);

            var result = await _logisticsTrackingReportService.GetWithDetails();

            return Ok(result);
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation(
                "Lojistik Takip Raporu getiriliyor. Id={Id}",
                id);

            var result = await _logisticsTrackingReportService.GetById(id);

            if (result == null)
            {
                _logger.LogWarning(
                    "Lojistik Takip Raporu bulunamadı. Id={Id}",
                    id);

                return NotFound();
            }

            _logger.LogInformation(
                "Lojistik Takip Raporu bulundu. Id={Id}",
                id);

            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateLogisticsTrackingReportDto dto)
        {
            _logger.LogInformation(
                "Yeni Lojistik Takip Raporu ekleniyor. User={User}",
                User?.Identity?.Name);

            dto.InsertDate = DateTime.Now;

            await _logisticsTrackingReportService.Add(dto);

            _logger.LogInformation(
                "Lojistik Takip Raporu başarıyla eklendi.");

            return Ok(dto);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateLogisticsTrackingReportDto dto)
        {
            _logger.LogInformation(
                "Lojistik Takip Raporu güncelleniyor. Id={Id}",
                id);

            dto.RecId = id;
            dto.UpdateDate = DateTime.Now;

            await _logisticsTrackingReportService.Update(dto);

            _logger.LogInformation(
                "Lojistik Takip Raporu güncellendi. Id={Id}",
                id);

            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogWarning(
                "Lojistik Takip Raporu siliniyor. Id={Id}, User={User}",
                id,
                User?.Identity?.Name);

            await _logisticsTrackingReportService.Delete(id);

            _logger.LogWarning(
                "Lojistik Takip Raporu silindi. Id={Id}",
                id);

            return Ok();
        }
    }
}