using BusinessLayer.Abstract;
using DTOLayer.Dtos.VechileFuelLogsDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VechileFuelLogsController : ControllerBase
    {
        private readonly IVechileFuelLogsService _service;
        private readonly ILogger<VechileFuelLogsController> _logger;


        public VechileFuelLogsController(
            IVechileFuelLogsService service,
            ILogger<VechileFuelLogsController> logger)
        {
            _service = service;
            _logger = logger;
        }


        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation(
                "Araç yakıt kayıtları listesi istendi. Kullanıcı={User}",
                User?.Identity?.Name);


            var result = await _service.GetList();


            _logger.LogInformation(
                "{Count} adet araç yakıt kaydı getirildi.",
                result.Count());


            return Ok(result);
        }


        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            _logger.LogInformation(
                "Araç yakıt kayıt detayları istendi.");


            var result = await _service.GetWithDetails();


            _logger.LogInformation(
                "Araç yakıt kayıt detayları başarıyla getirildi.");


            return Ok(result);
        }


        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation(
                "Araç yakıt kaydı getiriliyor. Id={Id}",
                id);


            var result = await _service.GetById(id);


            if (result == null)
            {
                _logger.LogWarning(
                    "Araç yakıt kaydı bulunamadı. Id={Id}",
                    id);

                return NotFound();
            }


            _logger.LogInformation(
                "Araç yakıt kaydı bulundu. Id={Id}",
                id);


            return Ok(result);
        }


        [HttpPost("add")]
        public async Task<IActionResult> Add(
            [FromBody] CreateVechileFuelLogsDto dto)
        {
            _logger.LogInformation(
                "Yeni araç yakıt kaydı ekleniyor. Kullanıcı={User}",
                User?.Identity?.Name);


            dto.InsertDate = DateTime.Now;


            var result = await _service.Add(dto);


            _logger.LogInformation(
                "Araç yakıt kaydı başarıyla eklendi.");


            return Ok(result);
        }


        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(
            [FromBody] UpdateVechileFuelLogsDto dto)
        {
            _logger.LogInformation(
                "Araç yakıt kaydı güncelleniyor.");


            dto.UpdateDate = DateTime.Now;


            await _service.Update(dto);


            _logger.LogInformation(
                "Araç yakıt kaydı başarıyla güncellendi.");


            return Ok();
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogWarning(
                "Araç yakıt kaydı siliniyor. Id={Id}, Kullanıcı={User}",
                id,
                User?.Identity?.Name);


            await _service.Delete(id);


            _logger.LogWarning(
                "Araç yakıt kaydı silindi. Id={Id}",
                id);


            return Ok();
        }
    }
}