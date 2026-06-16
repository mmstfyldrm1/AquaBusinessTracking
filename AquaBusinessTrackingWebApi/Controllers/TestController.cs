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

        public TestController(ITestHeadService headService, ITestDetailService detailService)
        {
            _headService = headService;
            _detailService = detailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _headService.GetList());

        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            var result = await _headService.GetWithDetails();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) =>
            Ok(await _headService.GetById(id));

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateTestHeadDto dto)
        {
            dto.InsertDate = DateTime.Now;
            await _headService.Add(dto);

            var all = await _headService.GetList();
            var last = all.OrderByDescending(x => x.RecId).FirstOrDefault();

            return Ok(last);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTestHeadDto dto)
        {
            dto.UpdateDate = DateTime.Now;
            await _headService.Update(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _headService.Delete(id);
            return Ok();
        }


        [HttpGet("{testHeadId}/testDetail")]
        public async Task<IActionResult> GetTestDetails(int testHeadId)
        {
            var all = await _detailService.GetList();
            var result = all.Where(x => x.TestHeaderId == testHeadId).ToList();
            return Ok(result);
        }

        [HttpPost("{testHeadId}/testDetail")]
        public async Task<IActionResult> AddTestDetail(int testHeadId, [FromBody] CreateTestDetailDto dto)
        {
            dto.TestHeaderId = testHeadId;
            var value = await _detailService.Add(dto);
            return Ok(value);
        }

        [HttpPut("{testHeadId}/testDetail")]
        public async Task<IActionResult> UpdateTestDetail(int testHeadId, [FromBody] UpdateTestDetailDto dto)
        {
            await _detailService.Update(dto);
            return Ok();
        }

        [HttpDelete("{testHeadId}/testDetail/{testDetailId}")]
        public async Task<IActionResult> DeleteTestDetail(int testHeadId, int testDetailId)
        {
            await _detailService.Delete(testDetailId);
            return Ok();
        }
    }

}

