using BusinessLayer.Abstract;
using DTOLayer.Dtos.DailyShipmentPlanDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DailyShipmentPlanController : ControllerBase
    {
        private readonly IDailyShipmentPlanService _service;
        private readonly ILogger<DailyShipmentPlanController> _logger;
        private readonly ISentezCurrentAccountQueryService _sentezCurrentAccountQueryService;

        public DailyShipmentPlanController(IDailyShipmentPlanService service, ILogger<DailyShipmentPlanController> logger, ISentezCurrentAccountQueryService sentezCurrentAccountQueryService)
        {
            _service = service;
            _logger = logger;
            _sentezCurrentAccountQueryService = sentezCurrentAccountQueryService;
        }
        [HttpGet("currentaccount")]
        public async Task<IActionResult> GetCurrentAccount()
        {
            _logger.LogInformation("Günlük  Sevkiyat Sipariş Plan Sentez Cari Hesap  detayları istendi.");
            var result = await _sentezCurrentAccountQueryService.GetCurrentAccountCodeAndName();
            _logger.LogInformation("Günlük  Sevkiyat Sipariş Plan Sentez Cari Hesap  detayları başarıyla getirildi.");
            return Ok(result);
        }

        [HttpGet("cities/{recId}")]
        public async Task<IActionResult> GetCurrentAccountCities(int recId)
        {
            _logger.LogInformation("Günlük  Sevkiyat Sipariş Plan Sentez Cari Hesap  Şehir detayları istendi.");
            var result = await _sentezCurrentAccountQueryService.GetCurrentAccountCity(recId);
            _logger.LogInformation("Günlük  Sevkiyat Sipariş Plan Sentez Cari Hesap  Şehir detayları başarıyla getirildi.");
            return Ok(result);
        }

        [HttpGet("districts/{recId}")]
        public async Task<IActionResult> GetCurrentAccountDistricts(int recId)
        {
            _logger.LogInformation("Günlük  Sevkiyat Sipariş Plan Sentez Cari Hesap  İlçe detayları istendi.");
            var result = await _sentezCurrentAccountQueryService.GetCurrentAccountDistrict(recId);
            _logger.LogInformation("Günlük  Sevkiyat Sipariş Plan Sentez Cari Hesap  İlçe detayları başarıyla getirildi.");
            return Ok(result);
        }

        [HttpGet("neighborhoods/{recId}")]
        public async Task<IActionResult> GetCurrentAccountAddress(int recId)
        {
            _logger.LogInformation("Günlük  Sevkiyat Sipariş Plan Sentez Cari Hesap  Mahalle detayları istendi.");
            var result = await _sentezCurrentAccountQueryService.GetCurrentAccountAddress(recId);
            _logger.LogInformation("Günlük  Sevkiyat Sipariş Plan Sentez Cari Hesap  Mahalle detayları başarıyla getirildi.");
            return Ok(result);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Günlük  Sevkiyat Sipariş Plan ler listesi istendi. Kullanıcı={User}", User?.Identity?.Name);
            var result = await _service.GetList();
            _logger.LogInformation("{Count} adet Günlük  Sevkiyat Sipariş Plan  kaydı getirildi.", result.Count());
            return Ok(result);
        }


        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            _logger.LogInformation("Günlük  Sevkiyat Sipariş Plan  detayları istendi.");
            var result = await _service.GetWithDetails();
            _logger.LogInformation("Günlük  Sevkiyat Sipariş Plan  detayları başarıyla getirildi.");
            return Ok(result);
        }

        [HttpGet("getActivePlan")]
        public async Task<IActionResult> GetActivePlan()
        {
            _logger.LogInformation("Günlük  Sevkiyat Sipariş Plan  detayları istendi.");
            var result = await _service.GetActivePlan();
            _logger.LogInformation("Günlük  Sevkiyat Sipariş Plan  detayları başarıyla getirildi.");
            return Ok(result);
        }


        [HttpPut("updateIsStatus/{id}")]
        public async Task<IActionResult> UpdateIsStatus(int id)
        {
            _logger.LogInformation("Update Is Status istendi.");
            var result = await _service.UpdateIsStatus(id);
            _logger.LogInformation("güncellendi");
            return Ok(result);
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation("Günlük  Sevkiyat Sipariş Plan  kaydı getiriliyor. Id={Id}", id);
            var result = await _service.GetById(id);
            if (result == null)
            {
                _logger.LogWarning("Günlük  Sevkiyat Sipariş Plan  kaydı bulunamadı. Id={Id}", id);
                return NotFound();
            }
            _logger.LogInformation("Günlük  Sevkiyat Sipariş Plan  kaydı bulundu. Id={Id}", id);
            return Ok(result);
        }


        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateDailyShipmentPlanDto dto)

        {
            _logger.LogInformation("Yeni Günlük  Sevkiyat Sipariş Plan  kaydı ekleniyor. Kullanıcı={User}", User?.Identity?.Name);
            dto.InsertDate = DateTime.Now;
            var result = await _service.Add(dto);
            _logger.LogInformation("Günlük  Sevkiyat Sipariş Plan  kaydı başarıyla eklendi.");
            return Ok(result);
        }


        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateDailyShipmentPlanDto dto)

        {
            _logger.LogInformation("Günlük  Sevkiyat Sipariş Plan  kaydı güncelleniyor.");
            dto.UpdateDate = DateTime.Now;
            await _service.Update(dto);
            _logger.LogInformation("Günlük  Sevkiyat Sipariş Plan  kaydı başarıyla güncellendi.");
            return Ok();
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogWarning("Günlük  Sevkiyat Sipariş Plan  kaydı siliniyor. Id={Id}, Kullanıcı={User}", id, User?.Identity?.Name);
            await _service.Delete(id);
            _logger.LogWarning("Günlük  Sevkiyat Sipariş Plan  kaydı silindi. Id={Id}", id);
            return Ok();
        }
    }
}