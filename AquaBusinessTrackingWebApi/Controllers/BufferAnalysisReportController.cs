using BusinessLayer.Abstract;
using DTOLayer.Dtos.BufferAnalysisReportDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BufferAnalysisReportController : ControllerBase
    {
        private readonly IBufferAnalysisReportService _bufferAnalysisReportService;
        private readonly ILogger<BufferAnalysisReportController> _logger;

        public BufferAnalysisReportController(
            IBufferAnalysisReportService bufferAnalysisReportService,
            ILogger<BufferAnalysisReportController> logger)
        {
            _bufferAnalysisReportService = bufferAnalysisReportService;
            _logger = logger;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation(
                "Buffer Analysis Report listesi istendi. User={User}",
                User?.Identity?.Name);

            var result = await _bufferAnalysisReportService.GetList();

            _logger.LogInformation(
                "{Count} adet Buffer Analysis Report kaydı getirildi.",
                result.Count());

            return Ok(result);
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            _logger.LogInformation(
                "Buffer Analysis Report detayları istendi. User={User}",
                User?.Identity?.Name);

            var result = await _bufferAnalysisReportService.GetWithDetails();

            return Ok(result);
        }

        [HttpGet("getbyId/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation(
                "Buffer Analysis Report getiriliyor. Id={Id}",
                id);

            var result = await _bufferAnalysisReportService.GetById(id);

            if (result == null)
            {
                _logger.LogWarning(
                    "Buffer Analysis Report bulunamadı. Id={Id}",
                    id);

                return NotFound();
            }

            _logger.LogInformation(
                "Buffer Analysis Report bulundu. Id={Id}",
                id);

            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateBufferAnalysisReportDto createBufferAnalysisReportDto)
        {
            _logger.LogInformation(
                "Yeni Buffer Analysis Report ekleniyor. User={User}",
                User?.Identity?.Name);

            createBufferAnalysisReportDto.InsertDate = DateTime.Now;

            var result = await _bufferAnalysisReportService.Add(createBufferAnalysisReportDto);

            _logger.LogInformation(
                "Buffer Analysis Report başarıyla eklendi.");

            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(UpdateBufferAnalysisReportDto updateBufferAnalysisReportDto)
        {
            _logger.LogInformation(
                "Buffer Analysis Report güncelleniyor. Id={Id}",
                updateBufferAnalysisReportDto.RecId);

            updateBufferAnalysisReportDto.UpdateDate = DateTime.Now;

            await _bufferAnalysisReportService.Update(updateBufferAnalysisReportDto);

            _logger.LogInformation(
                "Buffer Analysis Report güncellendi. Id={Id}",
                updateBufferAnalysisReportDto.RecId);

            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogWarning(
                "Buffer Analysis Report siliniyor. Id={Id}, User={User}",
                id,
                User?.Identity?.Name);

            await _bufferAnalysisReportService.Delete(id);

            _logger.LogWarning(
                "Buffer Analysis Report silindi. Id={Id}",
                id);

            return Ok();
        }
    }
}