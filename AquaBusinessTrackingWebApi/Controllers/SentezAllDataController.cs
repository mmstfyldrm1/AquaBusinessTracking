using BusinessLayer.Abstract;
using DTOLayer.Dtos.SentezAllDataDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SentezAllDataController : ControllerBase
    {
        private readonly ISentezAllDataService _service;
        private readonly ILogger<SentezAllDataController> _logger;


        public SentezAllDataController(
            ISentezAllDataService service,
            ILogger<SentezAllDataController> logger)
        {
            _service = service;
            _logger = logger;
        }


        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation(
                "Sentez All Data listesi istendi. Kullanıcı={User}",
                User?.Identity?.Name);


            var result = await _service.GetList();


            _logger.LogInformation(
                "{Count} adet Sentez All Data kaydı getirildi.",
                result.Count());


            return Ok(result);
        }


        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            _logger.LogInformation(
                "Sentez All Data detayları istendi.");


            var result = await _service.GetWithDetails();


            _logger.LogInformation(
                "Sentez All Data detayları başarıyla getirildi.");


            return Ok(result);
        }


        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation(
                "Sentez All Data kaydı getiriliyor. Id={Id}",
                id);


            var result = await _service.GetById(id);


            if (result == null)
            {
                _logger.LogWarning(
                    "Sentez All Data kaydı bulunamadı. Id={Id}",
                    id);

                return NotFound();
            }


            _logger.LogInformation(
                "Sentez All Data kaydı bulundu. Id={Id}",
                id);


            return Ok(result);
        }


        [HttpPost("add")]
        public async Task<IActionResult> Add(
            [FromBody] CreateSentezAllDataDto dto)
        {
            _logger.LogInformation(
                "Yeni Sentez All Data kaydı ekleniyor. Kullanıcı={User}",
                User?.Identity?.Name);


            dto.InsertDate = DateTime.Now;


            var result = await _service.Add(dto);


            _logger.LogInformation(
                "Sentez All Data kaydı başarıyla eklendi.");


            return Ok(result);
        }


        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(
            [FromBody] UpdateSentezAllDataDto dto)
        {
            _logger.LogInformation(
                "Sentez All Data kaydı güncelleniyor.");


            dto.UpdateDate = DateTime.Now;


            await _service.Update(dto);


            _logger.LogInformation(
                "Sentez All Data kaydı başarıyla güncellendi.");


            return Ok();
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogWarning(
                "Sentez All Data kaydı siliniyor. Id={Id}, Kullanıcı={User}",
                id,
                User?.Identity?.Name);


            await _service.Delete(id);


            _logger.LogWarning(
                "Sentez All Data kaydı silindi. Id={Id}",
                id);


            return Ok();
        }
    }
}