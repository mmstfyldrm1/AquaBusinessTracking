using BusinessLayer.Abstract;
using DTOLayer.Dtos.KazanDtos.KazanHeadDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class KazanChemicalsController : ControllerBase
    {
        private readonly IKazanChemicalsHeadService _kazanHead;
        private readonly ILogger<KazanChemicalsController> _logger;

        public KazanChemicalsController(
            IKazanChemicalsHeadService kazanHead,
            ILogger<KazanChemicalsController> logger)
        {
            _kazanHead = kazanHead;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation(
                "Kazan Kimyasalları listesi istendi. User={User}",
                User?.Identity?.Name);

            var result = await _kazanHead.GetList();

            _logger.LogInformation(
                "{Count} adet Kazan Kimyasalları kaydı getirildi.",
                result.Count());

            return Ok(result);
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            _logger.LogInformation(
                "Kazan Kimyasalları detayları istendi. User={User}",
                User?.Identity?.Name);

            var result = await _kazanHead.GetWithDetails();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation(
                "Kazan Kimyasalları kaydı getiriliyor. Id={Id}",
                id);

            var result = await _kazanHead.GetById(id);

            if (result == null)
            {
                _logger.LogWarning(
                    "Kazan Kimyasalları kaydı bulunamadı. Id={Id}",
                    id);

                return NotFound();
            }

            _logger.LogInformation(
                "Kazan Kimyasalları kaydı bulundu. Id={Id}",
                id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateKazanChemicalsHeadDto dto)
        {
            _logger.LogInformation(
                "Yeni Kazan Kimyasalları kaydı ekleniyor. User={User}",
                User?.Identity?.Name);

            dto.InsertDate = DateTime.Now;

            await _kazanHead.Add(dto);

            var all = await _kazanHead.GetList();
            var last = all.OrderByDescending(x => x.RecId).FirstOrDefault();

            _logger.LogInformation(
                "Kazan Kimyasalları kaydı başarıyla eklendi. Id={Id}",
                last?.RecId);

            return Ok(last);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateKazanChemicalsHeadDto dto)
        {
            _logger.LogInformation(
                "Kazan Kimyasalları kaydı güncelleniyor. Id={Id}",
                dto.RecId);

            dto.UpdateDate = DateTime.Now;

            await _kazanHead.Update(dto);

            _logger.LogInformation(
                "Kazan Kimyasalları kaydı güncellendi. Id={Id}",
                dto.RecId);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogWarning(
                "Kazan Kimyasalları kaydı siliniyor. Id={Id}, User={User}",
                id,
                User?.Identity?.Name);

            await _kazanHead.Delete(id);

            _logger.LogWarning(
                "Kazan Kimyasalları kaydı silindi. Id={Id}",
                id);

            return Ok();
        }
    }
}