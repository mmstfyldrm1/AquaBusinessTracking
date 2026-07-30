using BusinessLayer.Abstract;
using DTOLayer.Dtos.ChemicalSupplierProductsDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ChemicalSupplierProductsController : ControllerBase
    {
        private readonly IChemicalSupplierProductsService _service;
        private readonly ILogger<ChemicalSupplierProductsController> _logger;

        public ChemicalSupplierProductsController(IChemicalSupplierProductsService service, ILogger<ChemicalSupplierProductsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation(
                "Tedarikçi Kimyasal Ürünleri listesi istendi. User={User}",
                User?.Identity?.Name);

            var result = await _service.GetList();

            _logger.LogInformation(
                "{Count} adet Tedarikçi Kimyasal Ürünleri kaydı getirildi.",
                result.Count());

            return Ok(result);
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            _logger.LogInformation(
                "Tedarikçi Kimyasal Ürünleri detayları istendi. User={User}",
                User?.Identity?.Name);

            var result = await _service.GetWithDetails();

            return Ok(result);
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation(
                "Tedarikçi Kimyasal Ürünleri kaydı getiriliyor. Id={Id}",
                id);

            var result = await _service.GetById(id);

            if (result == null)
            {
                _logger.LogWarning(
                    "Tedarikçi Kimyasal Ürünleri kaydı bulunamadı. Id={Id}",
                    id);

                return NotFound();
            }

            _logger.LogInformation(
                "Tedarikçi Kimyasal Ürünleri kaydı bulundu. Id={Id}",
                id);

            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateChemicalSupplierProductsDto dto)
        {
            _logger.LogInformation(
                "Yeni Tedarikçi Kimyasal Ürünleri kaydı ekleniyor. User={User}",
                User?.Identity?.Name);

            dto.InsertDate = DateTime.Now;

            var result = await _service.Add(dto);

            _logger.LogInformation(
                "Tedarikçi Kimyasal Ürünleri kaydı başarıyla eklendi.");

            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateChemicalSupplierProductsDto dto)
        {
            _logger.LogInformation(
                "Tedarikçi Kimyasal Ürünleri kaydı güncelleniyor. Id={Id}",
                id);

            dto.RecId = id;
            dto.UpdateDate = DateTime.Now;

            await _service.Update(dto);

            _logger.LogInformation(
                "Tedarikçi Kimyasal Ürünleri kaydı güncellendi. Id={Id}",
                id);

            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogWarning(
                "Tedarikçi Kimyasal Ürünleri kaydı siliniyor. Id={Id}, User={User}",
                id,
                User?.Identity?.Name);

            await _service.Delete(id);

            _logger.LogWarning(
                "Tedarikçi Kimyasal Ürünleri kaydı silindi. Id={Id}",
                id);

            return Ok();
        }
    }
}
