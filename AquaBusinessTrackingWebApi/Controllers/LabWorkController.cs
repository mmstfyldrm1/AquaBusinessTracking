using BusinessLayer.Abstract;
using DTOLayer.Dtos.LabWorkDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LabWorkController : ControllerBase
    {
        private readonly ILabWorkService _labWorkService;
        private readonly ILogger<LabWorkController> _logger;

        public LabWorkController(
            ILabWorkService labWorkService,
            ILogger<LabWorkController> logger)
        {
            _labWorkService = labWorkService;
            _logger = logger;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation(
                "Laboratuvar Çalışmaları listesi istendi. User={User}",
                User?.Identity?.Name);

            var result = await _labWorkService.GetList();

            _logger.LogInformation(
                "{Count} adet Laboratuvar Çalışması getirildi.",
                result.Count());

            return Ok(result);
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            _logger.LogInformation(
                "Laboratuvar Çalışmaları detayları istendi. User={User}",
                User?.Identity?.Name);

            var result = await _labWorkService.GetWithDetails();

            return Ok(result);
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation(
                "Laboratuvar Çalışması getiriliyor. Id={Id}",
                id);

            var result = await _labWorkService.GetById(id);

            if (result == null)
            {
                _logger.LogWarning(
                    "Laboratuvar Çalışması bulunamadı. Id={Id}",
                    id);

                return NotFound();
            }

            _logger.LogInformation(
                "Laboratuvar Çalışması bulundu. Id={Id}",
                id);

            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateLabWorkDto dto)
        {
            _logger.LogInformation(
                "Yeni Laboratuvar Çalışması ekleniyor. User={User}",
                User?.Identity?.Name);

            dto.InsertDate = DateTime.Now;

            await _labWorkService.Add(dto);

            _logger.LogInformation(
                "Laboratuvar Çalışması başarıyla eklendi.");

            return Ok(dto);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateLabWorkDto dto)
        {
            _logger.LogInformation(
                "Laboratuvar Çalışması güncelleniyor. Id={Id}",
                id);

            dto.RecId = id;
            dto.UpdateDate = DateTime.Now;

            await _labWorkService.Update(dto);

            _logger.LogInformation(
                "Laboratuvar Çalışması güncellendi. Id={Id}",
                id);

            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogWarning(
                "Laboratuvar Çalışması siliniyor. Id={Id}, User={User}",
                id,
                User?.Identity?.Name);

            await _labWorkService.Delete(id);

            _logger.LogWarning(
                "Laboratuvar Çalışması silindi. Id={Id}",
                id);

            return Ok();
        }
    }
}