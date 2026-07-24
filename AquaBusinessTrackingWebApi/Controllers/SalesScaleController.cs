using BusinessLayer.Abstract;
using DTOLayer.Dtos.SalesScale;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SalesScaleController : ControllerBase
    {
        private readonly ISalesScaleService _salesScaleService;
        private readonly ILogger<SalesScaleController> _logger;


        public SalesScaleController(
            ISalesScaleService salesScaleService,
            ILogger<SalesScaleController> logger)
        {
            _salesScaleService = salesScaleService;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            _logger.LogInformation(
                "Satış kantar listesi istendi. Kullanıcı={User}",
                User?.Identity?.Name);


            var result = await _salesScaleService.GetList();


            _logger.LogInformation(
                "{Count} adet satış kantar kaydı getirildi.",
                result.Count());


            return Ok(result);
        }


        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            _logger.LogInformation(
                "Satış kantar detayları istendi.");


            var result = await _salesScaleService.GetWithDetails();


            _logger.LogInformation(
                "Satış kantar detayları başarıyla getirildi.");


            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation(
                "Satış kantar kaydı getiriliyor. Id={Id}",
                id);


            var result = await _salesScaleService.GetById(id);


            if (result == null)
            {
                _logger.LogWarning(
                    "Satış kantar kaydı bulunamadı. Id={Id}",
                    id);

                return NotFound();
            }


            _logger.LogInformation(
                "Satış kantar kaydı bulundu. Id={Id}",
                id);


            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Add(CreateSalesScaleDto dto)
        {
            _logger.LogInformation(
                "Yeni satış kantar kaydı ekleniyor. Kullanıcı={User}",
                User?.Identity?.Name);


            dto.InsertDate = DateTime.Now;
            dto.ScaleDate = DateTime.Now;


            await _salesScaleService.Add(dto);


            _logger.LogInformation(
                "Satış kantar kaydı başarıyla eklendi.");


            return Ok();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateSalesScaleDto dto)
        {
            _logger.LogInformation(
                "Satış kantar kaydı güncelleniyor.");


            dto.UpdateDate = DateTime.Now;


            await _salesScaleService.Update(dto);


            _logger.LogInformation(
                "Satış kantar kaydı başarıyla güncellendi.");


            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogWarning(
                "Satış kantar kaydı siliniyor. Id={Id}, Kullanıcı={User}",
                id,
                User?.Identity?.Name);


            await _salesScaleService.Delete(id);


            _logger.LogWarning(
                "Satış kantar kaydı silindi. Id={Id}",
                id);


            return Ok();
        }
    }
}