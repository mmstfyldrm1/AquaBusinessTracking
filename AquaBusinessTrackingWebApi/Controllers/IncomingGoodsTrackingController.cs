using BusinessLayer.Abstract;
using DTOLayer.Dtos.IncomingGoodsTrackingDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IncomingGoodsTrackingController : ControllerBase
    {
        private readonly IIncomingGoodsTrackingService _service;
        private readonly ILogger<IncomingGoodsTrackingController> _logger;

        public IncomingGoodsTrackingController(
            IIncomingGoodsTrackingService service,
            ILogger<IncomingGoodsTrackingController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation(
                "Gelen Mal Takip listesi istendi. User={User}",
                User?.Identity?.Name);

            var result = await _service.GetList();

            _logger.LogInformation(
                "{Count} adet Gelen Mal Takip kaydı getirildi.",
                result.Count());

            return Ok(result);
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            _logger.LogInformation(
                "Gelen Mal Takip detayları istendi. User={User}",
                User?.Identity?.Name);

            var result = await _service.GetWithDetails();

            return Ok(result);
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation(
                "Gelen Mal Takip kaydı getiriliyor. Id={Id}",
                id);

            var result = await _service.GetById(id);

            if (result == null)
            {
                _logger.LogWarning(
                    "Gelen Mal Takip kaydı bulunamadı. Id={Id}",
                    id);

                return NotFound();
            }

            _logger.LogInformation(
                "Gelen Mal Takip kaydı bulundu. Id={Id}",
                id);

            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateIncomingGoodsTrackingDto dto)
        {
            _logger.LogInformation(
                "Yeni Gelen Mal Takip kaydı ekleniyor. User={User}",
                User?.Identity?.Name);

            dto.InsertDate = DateTime.Now;

            var result = await _service.Add(dto);

            _logger.LogInformation(
                "Gelen Mal Takip kaydı başarıyla eklendi.");

            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateIncomingGoodsTrackingDto dto)
        {
            _logger.LogInformation(
                "Gelen Mal Takip kaydı güncelleniyor. Id={Id}",
                id);

            dto.RecId = id;
            dto.UpdateDate = DateTime.Now;

            await _service.Update(dto);

            _logger.LogInformation(
                "Gelen Mal Takip kaydı güncellendi. Id={Id}",
                id);

            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogWarning(
                "Gelen Mal Takip kaydı siliniyor. Id={Id}, User={User}",
                id,
                User?.Identity?.Name);

            await _service.Delete(id);

            _logger.LogWarning(
                "Gelen Mal Takip kaydı silindi. Id={Id}",
                id);

            return Ok();
        }
    }
}