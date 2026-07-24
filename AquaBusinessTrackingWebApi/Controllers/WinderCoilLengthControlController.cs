using BusinessLayer.Abstract;
using DTOLayer.Dtos.WinderCoilLengthControlDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WinderCoilLengthControlController : ControllerBase
    {
        private readonly IWinderCoilLengthControlService _winderCoilLengthControlService;
        private readonly ILogger<WinderCoilLengthControlController> _logger;


        public WinderCoilLengthControlController(
            IWinderCoilLengthControlService winderCoilLengthControlService,
            ILogger<WinderCoilLengthControlController> logger)
        {
            _winderCoilLengthControlService = winderCoilLengthControlService;
            _logger = logger;
        }


        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation(
                "Winder bobin uzunluk kontrol listesi istendi. Kullanıcı={User}",
                User?.Identity?.Name);


            var result = await _winderCoilLengthControlService.GetList();


            _logger.LogInformation(
                "{Count} adet Winder bobin uzunluk kontrol kaydı getirildi.",
                result.Count());


            return Ok(result);
        }


        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            _logger.LogInformation(
                "Winder bobin uzunluk kontrol detayları istendi.");


            var result = await _winderCoilLengthControlService.GetWithDetails();


            _logger.LogInformation(
                "Winder bobin uzunluk kontrol detayları başarıyla getirildi.");


            return Ok(result);
        }


        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation(
                "Winder bobin uzunluk kontrol kaydı getiriliyor. Id={Id}",
                id);


            var result = await _winderCoilLengthControlService.GetById(id);


            if (result != null)
            {
                _logger.LogInformation(
                    "Winder bobin uzunluk kontrol kaydı bulundu. Id={Id}",
                    id);

                return Ok(result);
            }


            _logger.LogWarning(
                "Winder bobin uzunluk kontrol kaydı bulunamadı. Id={Id}",
                id);


            return NotFound();
        }


        [HttpPost("add")]
        public async Task<IActionResult> Add(
            [FromBody] CreateWinderLengthControlDto winderCoilLengthControl)
        {
            _logger.LogInformation(
                "Yeni Winder bobin uzunluk kontrol kaydı ekleniyor. Kullanıcı={User}",
                User?.Identity?.Name);


            winderCoilLengthControl.InsertDate = DateTime.Now;


            await _winderCoilLengthControlService.Add(winderCoilLengthControl);


            _logger.LogInformation(
                "Winder bobin uzunluk kontrol kaydı başarıyla eklendi.");


            return Ok(winderCoilLengthControl);
        }


        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(
            [FromBody] UpdateWinderCoilLengthControlDto winderCoilLengthControl)
        {
            _logger.LogInformation(
                "Winder bobin uzunluk kontrol kaydı güncelleniyor.");


            winderCoilLengthControl.UpdateDate = DateTime.Now;


            await _winderCoilLengthControlService.Update(winderCoilLengthControl);


            _logger.LogInformation(
                "Winder bobin uzunluk kontrol kaydı başarıyla güncellendi.");


            return Ok();
        }


        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogWarning(
                "Winder bobin uzunluk kontrol kaydı siliniyor. Id={Id}, Kullanıcı={User}",
                id,
                User?.Identity?.Name);


            await _winderCoilLengthControlService.Delete(id);


            _logger.LogWarning(
                "Winder bobin uzunluk kontrol kaydı silindi. Id={Id}",
                id);


            return Ok();
        }
    }
}