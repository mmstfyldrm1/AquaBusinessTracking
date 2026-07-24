using BusinessLayer.Abstract;
using DTOLayer.Dtos.WastePaperCost;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WastePaperCostController : ControllerBase
    {
        private readonly IWastePaperCostService _wastePaperCostService;
        private readonly ILogger<WastePaperCostController> _logger;


        public WastePaperCostController(
            IWastePaperCostService wastePaperCostService,
            ILogger<WastePaperCostController> logger)
        {
            _wastePaperCostService = wastePaperCostService;
            _logger = logger;
        }


        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation(
                "Atık kağıt maliyet listesi istendi. Kullanıcı={User}",
                User?.Identity?.Name);


            var result = await _wastePaperCostService.GetList();


            _logger.LogInformation(
                "{Count} adet atık kağıt maliyet kaydı getirildi.",
                result.Count());


            return Ok(result);
        }


        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            _logger.LogInformation(
                "Atık kağıt maliyet detayları istendi.");


            var result = await _wastePaperCostService.GetWithDetails();


            _logger.LogInformation(
                "Atık kağıt maliyet detayları başarıyla getirildi.");


            return Ok(result);
        }


        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation(
                "Atık kağıt maliyet kaydı getiriliyor. Id={Id}",
                id);


            var result = await _wastePaperCostService.GetById(id);


            if (result == null)
            {
                _logger.LogWarning(
                    "Atık kağıt maliyet kaydı bulunamadı. Id={Id}",
                    id);

                return NotFound();
            }


            _logger.LogInformation(
                "Atık kağıt maliyet kaydı bulundu. Id={Id}",
                id);


            return Ok(result);
        }


        [HttpPost("add")]
        public async Task<IActionResult> Add(
            [FromBody] CreateWastePaperCostDto wastePaperCost)
        {
            _logger.LogInformation(
                "Yeni atık kağıt maliyet kaydı ekleniyor. Kullanıcı={User}",
                User?.Identity?.Name);


            wastePaperCost.InsertDate = DateTime.Now;


            var result = await _wastePaperCostService.Add(wastePaperCost);


            _logger.LogInformation(
                "Atık kağıt maliyet kaydı başarıyla eklendi.");


            return Ok(result);
        }


        [HttpPut("update")]
        public async Task<IActionResult> Update(
            [FromBody] UpdateWastePaperCostDto wastePaperCost)
        {
            _logger.LogInformation(
                "Atık kağıt maliyet kaydı güncelleniyor.");


            wastePaperCost.UpdateDate = DateTime.Now;


            await _wastePaperCostService.Update(wastePaperCost);


            _logger.LogInformation(
                "Atık kağıt maliyet kaydı başarıyla güncellendi.");


            return Ok();
        }


        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogWarning(
                "Atık kağıt maliyet kaydı siliniyor. Id={Id}, Kullanıcı={User}",
                id,
                User?.Identity?.Name);


            await _wastePaperCostService.Delete(id);


            _logger.LogWarning(
                "Atık kağıt maliyet kaydı silindi. Id={Id}",
                id);


            return Ok();
        }
    }
}