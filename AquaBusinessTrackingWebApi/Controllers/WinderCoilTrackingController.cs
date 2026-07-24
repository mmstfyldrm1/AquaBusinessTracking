using BusinessLayer.Abstract;
using DTOLayer.Dtos.WinderCoilTrackingDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WinderCoilTrackingController : ControllerBase
    {
        private readonly IWinderCoilTrackingService _service;
        private readonly ILogger<WinderCoilTrackingController> _logger;


        public WinderCoilTrackingController(
            IWinderCoilTrackingService service,
            ILogger<WinderCoilTrackingController> logger)
        {
            _service = service;
            _logger = logger;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation(
                "Winder bobin takip listesi istendi. Kullanıcı={User}",
                User?.Identity?.Name);


            var result = await _service.GetList();


            _logger.LogInformation(
                "{Count} adet Winder bobin takip kaydı getirildi.",
                result.Count());


            return Ok(result);
        }


        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            _logger.LogInformation(
                "Winder bobin takip detayları istendi.");


            var result = await _service.GetWithDetails();


            _logger.LogInformation(
                "Winder bobin takip detayları başarıyla getirildi.");


            return Ok(result);
        }


        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation(
                "Winder bobin takip kaydı getiriliyor. Id={Id}",
                id);


            var result = await _service.GetById(id);


            if (result == null)
            {
                _logger.LogWarning(
                    "Winder bobin takip kaydı bulunamadı. Id={Id}",
                    id);

                return NotFound();
            }


            _logger.LogInformation(
                "Winder bobin takip kaydı bulundu. Id={Id}",
                id);


            return Ok(result);
        }


        [HttpPost("Add")]
        public async Task<IActionResult> Add(CreateWinderCoilTrackingDto dto)
        {
            _logger.LogInformation(
                "Yeni Winder bobin takip kaydı ekleniyor. Kullanıcı={User}",
                User?.Identity?.Name);


            dto.InsertDate = DateTime.Now;


            await _service.Add(dto);


            _logger.LogInformation(
                "Winder bobin takip kaydı başarıyla eklendi.");


            return Ok(dto);
        }


        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(UpdateWinderCoilTrackingDto dto)
        {
            _logger.LogInformation(
                "Winder bobin takip kaydı güncelleniyor.");


            dto.UpdateDate = DateTime.Now;


            await _service.Update(dto);


            _logger.LogInformation(
                "Winder bobin takip kaydı başarıyla güncellendi.");


            return Ok(dto);
        }


        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogWarning(
                "Winder bobin takip kaydı siliniyor. Id={Id}, Kullanıcı={User}",
                id,
                User?.Identity?.Name);


            await _service.Delete(id);


            _logger.LogWarning(
                "Winder bobin takip kaydı silindi. Id={Id}",
                id);


            return Ok();
        }
    }
}