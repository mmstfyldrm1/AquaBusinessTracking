using BusinessLayer.Abstract;
using DTOLayer.Dtos.RolePermission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionService _service;
        private readonly ILogger<PermissionController> _logger;

        public PermissionController(
            IPermissionService service,
            ILogger<PermissionController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation(
                "Yetki listesi istendi. User={User}",
                User?.Identity?.Name);

            var result = await _service.GetAll();

            _logger.LogInformation(
                "{Count} adet yetki getirildi.",
                result.Count());

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            _logger.LogInformation(
                "Yetki getiriliyor. Id={Id}",
                id);

            var result = await _service.GetById(id);

            if (result == null)
            {
                _logger.LogWarning(
                    "Yetki bulunamadı. Id={Id}",
                    id);

                return NotFound();
            }

            _logger.LogInformation(
                "Yetki bulundu. Id={Id}",
                id);

            return Ok(result);
        }

        [HttpGet("getPermisionsName")]
        public async Task<IActionResult> GetByName(string permisionsName)
        {
            _logger.LogInformation(
                "Yetki isimleri istendi. User={User}",
                User?.Identity?.Name);

            var result = await _service.GetByName();

            _logger.LogInformation(
                "{Count} adet yetki adı getirildi.",
                result.Count());

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddPermissionsDto dto)
        {
            _logger.LogInformation(
                "Yeni yetki oluşturuluyor. User={User}",
                User?.Identity?.Name);

            await _service.Add(dto);

            _logger.LogInformation(
                "Yeni yetki başarıyla oluşturuldu.");

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdatePermissionsDto dto)
        {
            _logger.LogInformation(
                "Yetki güncelleniyor. Id={Id}",
                id);

            dto.RecId = id;

            await _service.Update(dto);

            _logger.LogInformation(
                "Yetki güncellendi. Id={Id}",
                id);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogWarning(
                "Yetki siliniyor. Id={Id}, User={User}",
                id,
                User?.Identity?.Name);

            await _service.Delete(id);

            _logger.LogWarning(
                "Yetki silindi. Id={Id}",
                id);

            return Ok();
        }
    }
}