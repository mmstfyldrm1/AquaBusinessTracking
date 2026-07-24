using BusinessLayer.Abstract;
using DTOLayer.Dtos.WastePaperControlDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WastePaperControlController : ControllerBase
    {
        private readonly IWastePaperControlService _wastePaperControlService;
        private readonly ILogger<WastePaperControlController> _logger;


        public WastePaperControlController(
            IWastePaperControlService wastePaperControlService,
            ILogger<WastePaperControlController> logger)
        {
            _wastePaperControlService = wastePaperControlService;
            _logger = logger;
        }


        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation(
                "Atık kağıt kontrol listesi istendi. Kullanıcı={User}",
                User?.Identity?.Name);


            var result = await _wastePaperControlService.GetList();


            _logger.LogInformation(
                "{Count} adet atık kağıt kontrol kaydı getirildi.",
                result.Count());


            return Ok(result);
        }


        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            _logger.LogInformation(
                "Atık kağıt kontrol detayları istendi.");


            var result = await _wastePaperControlService.GetWithDetails();


            _logger.LogInformation(
                "Atık kağıt kontrol detayları başarıyla getirildi.");


            return Ok(result);
        }


        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation(
                "Atık kağıt kontrol kaydı getiriliyor. Id={Id}",
                id);


            var result = await _wastePaperControlService.GetById(id);


            if (result != null)
            {
                _logger.LogInformation(
                    "Atık kağıt kontrol kaydı bulundu. Id={Id}",
                    id);

                return Ok(result);
            }


            _logger.LogWarning(
                "Atık kağıt kontrol kaydı bulunamadı. Id={Id}",
                id);


            return NotFound();
        }


        [HttpPost("add")]
        public async Task<IActionResult> Add(
            [FromBody] CreateWastePaperControlDto wastePaperControl)
        {
            _logger.LogInformation(
                "Yeni atık kağıt kontrol kaydı ekleniyor. Kullanıcı={User}",
                User?.Identity?.Name);


            wastePaperControl.InsertDate = DateTime.Now;


            await _wastePaperControlService.Add(wastePaperControl);


            _logger.LogInformation(
                "Atık kağıt kontrol kaydı başarıyla eklendi.");


            return Ok(wastePaperControl);
        }


        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(
            [FromBody] UpdateWastePaperControlDto wastePaperControl)
        {
            _logger.LogInformation(
                "Atık kağıt kontrol kaydı güncelleniyor.");


            wastePaperControl.UpdateDate = DateTime.Now;


            await _wastePaperControlService.Update(wastePaperControl);


            _logger.LogInformation(
                "Atık kağıt kontrol kaydı başarıyla güncellendi.");


            return Ok();
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogWarning(
                "Atık kağıt kontrol kaydı siliniyor. Id={Id}, Kullanıcı={User}",
                id,
                User?.Identity?.Name);


            await _wastePaperControlService.Delete(id);


            _logger.LogWarning(
                "Atık kağıt kontrol kaydı silindi. Id={Id}",
                id);


            return Ok();
        }
    }
}