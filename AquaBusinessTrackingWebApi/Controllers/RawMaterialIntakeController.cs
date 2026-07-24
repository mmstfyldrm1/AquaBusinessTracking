using BusinessLayer.Abstract;
using DTOLayer.Dtos.RawMaterialIntakesDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RawMaterialIntakeController : ControllerBase
    {
        private readonly IRawMaterialIntakeService _service;
        private readonly ILogger<RawMaterialIntakeController> _logger;

        public RawMaterialIntakeController(
            IRawMaterialIntakeService rawMaterialIntakeService,
            ILogger<RawMaterialIntakeController> logger)
        {
            _service = rawMaterialIntakeService;
            _logger = logger;
        }


        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation(
                "Hammadde giriş listesi istendi. Kullanıcı={User}",
                User?.Identity?.Name);

            var result = await _service.GetList();

            _logger.LogInformation(
                "{Count} adet hammadde giriş kaydı getirildi.",
                result.Count());

            return Ok(result);
        }


        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            _logger.LogInformation(
                "Hammadde giriş detayları istendi. Kullanıcı={User}",
                User?.Identity?.Name);

            var result = await _service.GetWithDetails();

            _logger.LogInformation(
                "Hammadde giriş detayları başarıyla getirildi.");

            return Ok(result);
        }


        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation(
                "Hammadde giriş kaydı getiriliyor. Id={Id}",
                id);

            var result = await _service.GetById(id);

            if (result == null)
            {
                _logger.LogWarning(
                    "Hammadde giriş kaydı bulunamadı. Id={Id}",
                    id);

                return NotFound();
            }

            _logger.LogInformation(
                "Hammadde giriş kaydı bulundu. Id={Id}",
                id);

            return Ok(result);
        }


        [HttpPost("add")]
        public async Task<IActionResult> Add(
            [FromBody] CreateRawMaterialIntakesDto dto)
        {
            _logger.LogInformation(
                "Yeni hammadde giriş kaydı ekleniyor. Kullanıcı={User}",
                User?.Identity?.Name);

            dto.InsertDate = DateTime.Now;

            var result = await _service.Add(dto);

            _logger.LogInformation(
                "Hammadde giriş kaydı başarıyla eklendi.");

            return Ok(result);
        }


        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(
            int id,
            [FromBody] UpdateRawMaterialIntakesDto dto)
        {
            _logger.LogInformation(
                "Hammadde giriş kaydı güncelleniyor. Id={Id}",
                id);

            dto.RecId = id;
            dto.UpdateDate = DateTime.Now;

            await _service.Update(dto);

            _logger.LogInformation(
                "Hammadde giriş kaydı başarıyla güncellendi. Id={Id}",
                id);

            return Ok();
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogWarning(
                "Hammadde giriş kaydı siliniyor. Id={Id}, Kullanıcı={User}",
                id,
                User?.Identity?.Name);

            await _service.Delete(id);

            _logger.LogWarning(
                "Hammadde giriş kaydı silindi. Id={Id}",
                id);

            return Ok();
        }
    }
}