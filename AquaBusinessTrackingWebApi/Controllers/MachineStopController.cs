using BusinessLayer.Abstract;
using DTOLayer.Dtos.MachineStopDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MachineStopController : ControllerBase
    {
        private readonly IMachineStopService _service;
        private readonly ILogger<MachineStopController> _logger;

        public MachineStopController(
            IMachineStopService service,
            ILogger<MachineStopController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation(
                "Makine Duruş listesi istendi. User={User}",
                User?.Identity?.Name);

            var result = await _service.GetList();

            _logger.LogInformation(
                "{Count} adet Makine Duruş kaydı getirildi.",
                result.Count());

            return Ok(result);
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            _logger.LogInformation(
                "Makine Duruş detayları istendi. User={User}",
                User?.Identity?.Name);

            var result = await _service.GetWithDetails();

            return Ok(result);
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation(
                "Makine Duruş kaydı getiriliyor. Id={Id}",
                id);

            var result = await _service.GetById(id);

            if (result == null)
            {
                _logger.LogWarning(
                    "Makine Duruş kaydı bulunamadı. Id={Id}",
                    id);

                return NotFound();
            }

            _logger.LogInformation(
                "Makine Duruş kaydı bulundu. Id={Id}",
                id);

            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateMachineStopDto dto)
        {
            _logger.LogInformation(
                "Yeni Makine Duruş kaydı ekleniyor. User={User}",
                User?.Identity?.Name);

            dto.InsertDate = DateTime.Now;

            var result = await _service.Add(dto);

            _logger.LogInformation(
                "Makine Duruş kaydı başarıyla eklendi.");

            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateMachineStopDto dto)
        {
            _logger.LogInformation(
                "Makine Duruş kaydı güncelleniyor. Id={Id}",
                id);

            dto.RecId = id;
            dto.UpdateDate = DateTime.Now;

            await _service.Update(dto);

            _logger.LogInformation(
                "Makine Duruş kaydı güncellendi. Id={Id}",
                id);

            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogWarning(
                "Makine Duruş kaydı siliniyor. Id={Id}, User={User}",
                id,
                User?.Identity?.Name);

            await _service.Delete(id);

            _logger.LogWarning(
                "Makine Duruş kaydı silindi. Id={Id}",
                id);

            return Ok();
        }
    }
}