using BusinessLayer.Abstract;
using DTOLayer.Dtos.DepartmentDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private readonly ILogger<DepartmentController> _logger;

        public DepartmentController(
            IDepartmentService departmentService,
            ILogger<DepartmentController> logger)
        {
            _departmentService = departmentService;
            _logger = logger;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetList()
        {
            _logger.LogInformation("Departman listesi istendi.");

            var result = await _departmentService.GetList();

            _logger.LogInformation(
                "{Count} adet departman getirildi.",
                result.Count());

            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation(
                "Departman getiriliyor. Id={Id}, User={User}",
                id,
                User?.Identity?.Name);

            var result = await _departmentService.GetById(id);

            if (result == null)
            {
                _logger.LogWarning(
                    "Departman bulunamadı. Id={Id}",
                    id);

                return NotFound();
            }

            _logger.LogInformation(
                "Departman bulundu. Id={Id}",
                id);

            return Ok(result);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add([FromBody] CreateDepartmentDto dto)
        {
            _logger.LogInformation(
                "Yeni departman ekleniyor. User={User}",
                User?.Identity?.Name);

            dto.InsertDate = DateTime.Now;

            await _departmentService.Add(dto);

            _logger.LogInformation(
                "Departman başarıyla eklendi.");

            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateDepartmentDto dto)
        {
            _logger.LogInformation(
                "Departman güncelleniyor. Id={Id}, User={User}",
                id,
                User?.Identity?.Name);

            dto.Id = id;
            dto.UpdateDate = DateTime.Now;

            await _departmentService.Update(dto);

            _logger.LogInformation(
                "Departman güncellendi. Id={Id}",
                id);

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogWarning(
                "Departman siliniyor. Id={Id}, User={User}",
                id,
                User?.Identity?.Name);

            await _departmentService.Delete(id);

            _logger.LogWarning(
                "Departman silindi. Id={Id}",
                id);

            return Ok();
        }
    }
}