using BusinessLayer.Abstract;
using DTOLayer.Dtos.WarehouseRequestWaitDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WarehouseRequestWaitController : ControllerBase
    {
        private readonly IWarehouseRequestWaitService _service;
        private readonly ILogger<WarehouseRequestWaitController> _logger;


        public WarehouseRequestWaitController(
            IWarehouseRequestWaitService service,
            ILogger<WarehouseRequestWaitController> logger)
        {
            _service = service;
            _logger = logger;
        }


        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation(
                "Depo bekleyen talepler listesi istendi. Kullanıcı={User}",
                User?.Identity?.Name);


            var result = await _service.GetList();


            _logger.LogInformation(
                "{Count} adet depo bekleyen talep kaydı getirildi.",
                result.Count());


            return Ok(result);
        }


        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            _logger.LogInformation(
                "Depo bekleyen talep detayları istendi.");


            var result = await _service.GetWithDetails();


            _logger.LogInformation(
                "Depo bekleyen talep detayları başarıyla getirildi.");


            return Ok(result);
        }


        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation(
                "Depo bekleyen talep kaydı getiriliyor. Id={Id}",
                id);


            var result = await _service.GetById(id);


            if (result == null)
            {
                _logger.LogWarning(
                    "Depo bekleyen talep kaydı bulunamadı. Id={Id}",
                    id);

                return NotFound();
            }


            _logger.LogInformation(
                "Depo bekleyen talep kaydı bulundu. Id={Id}",
                id);


            return Ok(result);
        }


        [HttpPost("add")]
        public async Task<IActionResult> Add(
            [FromBody] CreateWarehouseRequestWaitDto dto)
        {
            _logger.LogInformation(
                "Yeni depo bekleyen talep kaydı ekleniyor. Kullanıcı={User}",
                User?.Identity?.Name);


            dto.InsertDate = DateTime.Now;


            var result = await _service.Add(dto);


            _logger.LogInformation(
                "Depo bekleyen talep kaydı başarıyla eklendi.");


            return Ok(result);
        }


        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(
            [FromBody] UpdateWarehouseRequestWaitDto dto)
        {
            _logger.LogInformation(
                "Depo bekleyen talep kaydı güncelleniyor.");


            dto.UpdateDate = DateTime.Now;


            await _service.Update(dto);


            _logger.LogInformation(
                "Depo bekleyen talep kaydı başarıyla güncellendi.");


            return Ok();
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogWarning(
                "Depo bekleyen talep kaydı siliniyor. Id={Id}, Kullanıcı={User}",
                id,
                User?.Identity?.Name);


            await _service.Delete(id);


            _logger.LogWarning(
                "Depo bekleyen talep kaydı silindi. Id={Id}",
                id);


            return Ok();
        }
    }
}