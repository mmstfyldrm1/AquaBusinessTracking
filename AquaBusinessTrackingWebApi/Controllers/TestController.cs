using BusinessLayer.Abstract;
using DTOLayer.Dtos.TestDtos.TestDetailDtos;
using DTOLayer.Dtos.TestDtos.TestHeadDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TestController : ControllerBase
    {
        private readonly ITestHeadService _headService;
        private readonly ITestDetailService _detailService;
        private readonly ILogger<TestController> _logger;


        public TestController(
            ITestHeadService headService,
            ITestDetailService detailService,
            ILogger<TestController> logger)
        {
            _headService = headService;
            _detailService = detailService;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation(
                "Test listesi istendi. Kullanıcı={User}",
                User?.Identity?.Name);

            var result = await _headService.GetList();

            _logger.LogInformation(
                "{Count} adet test kaydı getirildi.",
                result.Count());

            return Ok(result);
        }


        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            _logger.LogInformation(
                "Test detayları istendi.");

            var result = await _headService.GetWithDetails();

            _logger.LogInformation(
                "Test detayları başarıyla getirildi.");

            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation(
                "Test kaydı getiriliyor. Id={Id}",
                id);

            var result = await _headService.GetById(id);

            _logger.LogInformation(
                "Test kaydı getirildi. Id={Id}",
                id);

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Add(
            [FromBody] CreateTestHeadDto dto)
        {
            _logger.LogInformation(
                "Yeni test kaydı ekleniyor. Kullanıcı={User}",
                User?.Identity?.Name);

            dto.InsertDate = DateTime.Now;

            await _headService.Add(dto);


            var all = await _headService.GetList();

            var last = all
                .OrderByDescending(x => x.RecId)
                .FirstOrDefault();


            _logger.LogInformation(
                "Test kaydı başarıyla eklendi. Id={Id}",
                last?.RecId);


            return Ok(last);
        }


        [HttpPut]
        public async Task<IActionResult> Update(
            [FromBody] UpdateTestHeadDto dto)
        {
            _logger.LogInformation(
                "Test kaydı güncelleniyor.");

            dto.UpdateDate = DateTime.Now;

            await _headService.Update(dto);


            _logger.LogInformation(
                "Test kaydı başarıyla güncellendi.");


            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogWarning(
                "Test kaydı siliniyor. Id={Id}, Kullanıcı={User}",
                id,
                User?.Identity?.Name);


            await _headService.Delete(id);


            _logger.LogWarning(
                "Test kaydı silindi. Id={Id}",
                id);


            return Ok();
        }



        [HttpGet("{testHeadId}/testDetail")]
        public async Task<IActionResult> GetTestDetails(int testHeadId)
        {
            _logger.LogInformation(
                "Test detayları getiriliyor. TestHeadId={Id}",
                testHeadId);


            var all = await _detailService.GetList();

            var result = all
                .Where(x => x.TestHeaderId == testHeadId)
                .ToList();


            _logger.LogInformation(
                "{Count} adet test detay kaydı getirildi.",
                result.Count);


            return Ok(result);
        }



        [HttpPost("{testHeadId}/testDetail")]
        public async Task<IActionResult> AddTestDetail(
            int testHeadId,
            [FromBody] CreateTestDetailDto dto)
        {
            _logger.LogInformation(
                "Test detay kaydı ekleniyor. TestHeadId={Id}",
                testHeadId);


            dto.TestHeaderId = testHeadId;

            var value = await _detailService.Add(dto);


            _logger.LogInformation(
                "Test detay kaydı başarıyla eklendi.");


            return Ok(value);
        }



        [HttpPut("{testHeadId}/testDetail")]
        public async Task<IActionResult> UpdateTestDetail(
            int testHeadId,
            [FromBody] UpdateTestDetailDto dto)
        {
            _logger.LogInformation(
                "Test detay kaydı güncelleniyor. TestHeadId={Id}",
                testHeadId);


            await _detailService.Update(dto);


            _logger.LogInformation(
                "Test detay kaydı başarıyla güncellendi.");


            return Ok();
        }



        [HttpDelete("{testHeadId}/testDetail/{testDetailId}")]
        public async Task<IActionResult> DeleteTestDetail(
            int testHeadId,
            int testDetailId)
        {
            _logger.LogWarning(
                "Test detay kaydı siliniyor. DetailId={Id}",
                testDetailId);


            await _detailService.Delete(testDetailId);


            _logger.LogWarning(
                "Test detay kaydı silindi. DetailId={Id}",
                testDetailId);


            return Ok();
        }
    }
}