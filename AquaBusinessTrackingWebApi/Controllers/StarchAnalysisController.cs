using BusinessLayer.Abstract;
using DTOLayer.Dtos.StarchAnalysis.StarchAnalysisHeadingDetail;
using DTOLayer.Dtos.StarchAnalysis.StarchAnalysisHeadingDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StarchAnalysisController : ControllerBase
    {
        private readonly IStarchAnalysisHeadingService _headService;
        private readonly IStarchAnalysisHeadingDetailService _detailService;
        private readonly ILogger<StarchAnalysisController> _logger;


        public StarchAnalysisController(
            IStarchAnalysisHeadingService headService,
            IStarchAnalysisHeadingDetailService detailService,
            ILogger<StarchAnalysisController> logger)
        {
            _headService = headService;
            _detailService = detailService;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation(
                "Nişasta analiz listesi istendi. Kullanıcı={User}",
                User?.Identity?.Name);

            var result = await _headService.GetList();

            _logger.LogInformation(
                "{Count} adet nişasta analiz kaydı getirildi.",
                result.Count());

            return Ok(result);
        }


        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            _logger.LogInformation(
                "Nişasta analiz detayları istendi.");

            var result = await _headService.GetWithDetails();

            _logger.LogInformation(
                "Nişasta analiz detayları başarıyla getirildi.");

            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation(
                "Nişasta analiz kaydı getiriliyor. Id={Id}",
                id);

            var result = await _headService.GetById(id);

            _logger.LogInformation(
                "Nişasta analiz kaydı getirildi. Id={Id}",
                id);

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Add(
            [FromBody] CreateStarchAnalysisHeadingDto dto)
        {
            _logger.LogInformation(
                "Yeni nişasta analiz kaydı ekleniyor. Kullanıcı={User}",
                User?.Identity?.Name);

            dto.InsertDate = DateTime.Now;

            await _headService.Add(dto);


            var all = await _headService.GetList();
            var last = all.OrderByDescending(x => x.RecId).FirstOrDefault();


            _logger.LogInformation(
                "Nişasta analiz kaydı başarıyla eklendi. Id={Id}",
                last?.RecId);


            return Ok(last);
        }


        [HttpPut]
        public async Task<IActionResult> Update(
            [FromBody] UpdateStarchAnalysisHeadingDto dto)
        {
            _logger.LogInformation(
                "Nişasta analiz kaydı güncelleniyor.");

            dto.UpdateDate = DateTime.Now;

            await _headService.Update(dto);


            _logger.LogInformation(
                "Nişasta analiz kaydı güncellendi.");


            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogWarning(
                "Nişasta analiz kaydı siliniyor. Id={Id}, Kullanıcı={User}",
                id,
                User?.Identity?.Name);

            await _headService.Delete(id);

            _logger.LogWarning(
                "Nişasta analiz kaydı silindi. Id={Id}",
                id);

            return Ok();
        }



        [HttpGet("{starchAnalysisHeadId}/starchAnalysisDetail")]
        public async Task<IActionResult> GetStarchAnalysisDetails(int starchAnalysisHeadId)
        {
            _logger.LogInformation(
                "Nişasta analiz detayları getiriliyor. HeadId={Id}",
                starchAnalysisHeadId);


            var all = await _detailService.GetList();

            var result = all
                .Where(x => x.StarchAnalysisHeadingId == starchAnalysisHeadId)
                .ToList();


            _logger.LogInformation(
                "{Count} adet nişasta analiz detay kaydı getirildi.",
                result.Count);


            return Ok(result);
        }


        [HttpPost("{starchAnalysisHeadId}/starchAnalysisDetail")]
        public async Task<IActionResult> AddStarchAnalysisDetail(
            int starchAnalysisHeadId,
            [FromBody] CreateStarchAnalysisHeadingDetailDto dto)
        {
            _logger.LogInformation(
                "Nişasta analiz detay kaydı ekleniyor. HeadId={Id}",
                starchAnalysisHeadId);


            dto.StarchAnalysisHeadingId = starchAnalysisHeadId;

            var value = await _detailService.Add(dto);


            _logger.LogInformation(
                "Nişasta analiz detay kaydı eklendi.");


            return Ok(value);
        }


        [HttpPut("{starchAnalysisHeadId}/starchAnalysisDetail")]
        public async Task<IActionResult> UpdateStarchAnalysisDetail(
            int starchAnalysisHeadId,
            [FromBody] UpdateStarchAnalysisHeadingDetailDto dto)
        {
            _logger.LogInformation(
                "Nişasta analiz detay kaydı güncelleniyor. HeadId={Id}",
                starchAnalysisHeadId);


            dto.StarchAnalysisHeadingId = starchAnalysisHeadId;

            await _detailService.Update(dto);


            _logger.LogInformation(
                "Nişasta analiz detay kaydı güncellendi.");


            return Ok();
        }


        [HttpDelete("{starchAnalysisHeadId}/starchAnalysisDetail/{starchAnalysisHeadDetailId}")]
        public async Task<IActionResult> DeleteStarchAnalysisDetail(
            int starchAnalysisHeadId,
            int starchAnalysisHeadDetailId)
        {
            _logger.LogWarning(
                "Nişasta analiz detay kaydı siliniyor. DetailId={Id}",
                starchAnalysisHeadDetailId);


            await _detailService.Delete(starchAnalysisHeadDetailId);


            _logger.LogWarning(
                "Nişasta analiz detay kaydı silindi. DetailId={Id}",
                starchAnalysisHeadDetailId);


            return Ok();
        }
    }
}