using BusinessLayer.Abstract;
using DTOLayer.Dtos.RetentionAnalysis.RetentionAnalysisDetailDtos;
using DTOLayer.Dtos.RetentionAnalysis.RetentionAnalysisHeadDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RetentionAnalysisController : ControllerBase
    {
        private readonly IRetentionAnalysisHeadService _headService;
        private readonly IRetentionAnalysisDetailService _detailService;
        private readonly ILogger<RetentionAnalysisController> _logger;

        public RetentionAnalysisController(
            IRetentionAnalysisHeadService headService,
            IRetentionAnalysisDetailService detailService,
            ILogger<RetentionAnalysisController> logger)
        {
            _headService = headService;
            _detailService = detailService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("Retention Analysis listesi istendi. Kullanıcı={User}", User?.Identity?.Name);

            var result = await _headService.GetList();

            _logger.LogInformation("{Count} adet Retention Analysis kaydı getirildi.", result.Count());

            return Ok(result);
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            _logger.LogInformation("Retention Analysis detayları istendi.");

            var result = await _headService.GetWithDetails();

            _logger.LogInformation("Retention Analysis detayları getirildi.");

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation("Retention Analysis kaydı getiriliyor. Id={Id}", id);

            var result = await _headService.GetById(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateRetentionAnalysisHeadDto dto)
        {
            _logger.LogInformation("Yeni Retention Analysis kaydı ekleniyor.");

            dto.InsertDate = DateTime.Now;
            await _headService.Add(dto);

            _logger.LogInformation("Retention Analysis kaydı başarıyla eklendi.");

            var all = await _headService.GetList();
            var last = all.OrderByDescending(x => x.RecId).FirstOrDefault();

            return Ok(last);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateRetentionAnalysisHeadDto dto)
        {
            _logger.LogInformation("Retention Analysis kaydı güncelleniyor.");

            dto.UpdateDate = DateTime.Now;
            await _headService.Update(dto);

            _logger.LogInformation("Retention Analysis kaydı güncellendi.");

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogWarning("Retention Analysis kaydı siliniyor. Id={Id}", id);

            await _headService.Delete(id);

            _logger.LogWarning("Retention Analysis kaydı silindi. Id={Id}", id);

            return Ok();
        }


        [HttpGet("{retentionAnalysisHeadId}/retentionAnalysisDetail")]
        public async Task<IActionResult> GetRetentionAnalysisDetails(int retentionAnalysisHeadId)
        {
            _logger.LogInformation(
                "Retention Analysis detayları getiriliyor. HeadId={Id}",
                retentionAnalysisHeadId);

            var all = await _detailService.GetList();
            var result = all.Where(x => x.RetentionAnalysisHeadId == retentionAnalysisHeadId).ToList();

            _logger.LogInformation(
                "{Count} adet detay kaydı getirildi.",
                result.Count);

            return Ok(result);
        }


        [HttpPost("{retentionAnalysisHeadId}/retentionAnalysisDetail")]
        public async Task<IActionResult> AddRetentionAnalysisDetail(
            int retentionAnalysisHeadId,
            [FromBody] CreateRetentionAnalysisDetailDto dto)
        {
            _logger.LogInformation(
                "Retention Analysis detay kaydı ekleniyor. HeadId={Id}",
                retentionAnalysisHeadId);

            dto.RetentionAnalysisHeadId = retentionAnalysisHeadId;

            var value = await _detailService.Add(dto);

            _logger.LogInformation(
                "Retention Analysis detay kaydı eklendi.");

            return Ok(value);
        }


        [HttpPut("{retentionAnalysisHeadId}/retentionAnalysisDetail")]
        public async Task<IActionResult> UpdateRetentionAnalysisDetail(
            int testHeadId,
            [FromBody] UpdateRetentionAnalysisDetailDto dto)
        {
            _logger.LogInformation(
                "Retention Analysis detay kaydı güncelleniyor.");

            await _detailService.Update(dto);

            _logger.LogInformation(
                "Retention Analysis detay kaydı güncellendi.");

            return Ok();
        }


        [HttpDelete("{retentionAnalysisDetail}/retentionAnalysisDetail/{retentionAnalysisDetailId}")]
        public async Task<IActionResult> DeleteRetentionAnalysisDetail(
            int retentionAnalysisDetail,
            int retentionAnalysisDetailId)
        {
            _logger.LogWarning(
                "Retention Analysis detay kaydı siliniyor. Id={Id}",
                retentionAnalysisDetailId);

            await _detailService.Delete(retentionAnalysisDetailId);

            _logger.LogWarning(
                "Retention Analysis detay kaydı silindi. Id={Id}",
                retentionAnalysisDetailId);

            return Ok();
        }
    }
}