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

        public RetentionAnalysisController(IRetentionAnalysisHeadService headService, IRetentionAnalysisDetailService detailService)
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
        public async Task<IActionResult> Add([FromBody] CreateRetentionAnalysisHeadDto dto)
        {
            dto.InsertDate = DateTime.Now;
            await _headService.Add(dto);

            var all = await _headService.GetList();
            var last = all.OrderByDescending(x => x.RecId).FirstOrDefault();

            return Ok(last);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateRetentionAnalysisHeadDto dto)
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


        [HttpGet("{retentionAnalysisHeadId}/retentionAnalysisDetail")]
        public async Task<IActionResult> GetRetentionAnalysisDetails(int retentionAnalysisHeadId)
        {
            var all = await _detailService.GetList();
            var result = all.Where(x => x.RetentionAnalysisHeadId == retentionAnalysisHeadId).ToList();
            return Ok(result);
        }

        [HttpPost("{retentionAnalysisHeadId}/retentionAnalysisDetail")]
        public async Task<IActionResult> AddRetentionAnalysisDetail(int retentionAnalysisHeadId, [FromBody] CreateRetentionAnalysisDetailDto dto)
        {
            dto.RetentionAnalysisHeadId = retentionAnalysisHeadId;
            var value = await _detailService.Add(dto);
            return Ok(value);
        }

        [HttpPut("{retentionAnalysisHeadId}/retentionAnalysisDetail")]
        public async Task<IActionResult> UpdateRetentionAnalysisDetail(int testHeadId, [FromBody] UpdateRetentionAnalysisDetailDto dto)
        {
            await _detailService.Update(dto);
            return Ok();
        }

        [HttpDelete("{retentionAnalysisDetail}/retentionAnalysisDetail/{retentionAnalysisDetailId}")]
        public async Task<IActionResult> DeleteRetentionAnalysisDetail(int retentionAnalysisDetail, int retentionAnalysisDetailId)
        {
            await _detailService.Delete(retentionAnalysisDetailId);
            return Ok();
        }
    }
}

