using BusinessLayer.Abstract;
using DTOLayer.Dtos.ShiftDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ShiftController : ControllerBase
    {
        private readonly IShiftService _shiftService;
        private readonly ILogger<ShiftController> _logger;


        public ShiftController(
            IShiftService shiftService,
            ILogger<ShiftController> logger)
        {
            _shiftService = shiftService;
            _logger = logger;
        }


        [HttpGet("getall")]
        public async Task<IActionResult> GetList()
        {
            _logger.LogInformation(
                "Vardiya listesi istendi. Kullanıcı={User}",
                User?.Identity?.Name);


            var result = await _shiftService.GetList();


            _logger.LogInformation(
                "{Count} adet vardiya kaydı getirildi.",
                result.Count());


            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation(
                "Vardiya kaydı getiriliyor. Id={Id}",
                id);


            var result = await _shiftService.GetById(id);


            if (result == null)
            {
                _logger.LogWarning(
                    "Vardiya kaydı bulunamadı. Id={Id}",
                    id);

                return NotFound();
            }


            _logger.LogInformation(
                "Vardiya kaydı bulundu. Id={Id}",
                id);


            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Add(CreateShiftDto dto)
        {
            _logger.LogInformation(
                "Yeni vardiya kaydı ekleniyor. Kullanıcı={User}",
                User?.Identity?.Name);


            dto.InsertDate = DateTime.Now;


            await _shiftService.Add(dto);


            _logger.LogInformation(
                "Vardiya kaydı başarıyla eklendi.");


            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateShiftDto dto)
        {
            _logger.LogInformation(
                "Vardiya kaydı güncelleniyor.");


            dto.UpdateDate = DateTime.Now;


            await _shiftService.Update(dto);


            _logger.LogInformation(
                "Vardiya kaydı başarıyla güncellendi.");


            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogWarning(
                "Vardiya kaydı siliniyor. Id={Id}, Kullanıcı={User}",
                id,
                User?.Identity?.Name);


            await _shiftService.Delete(id);


            _logger.LogWarning(
                "Vardiya kaydı silindi. Id={Id}",
                id);


            return Ok();
        }
    }
}