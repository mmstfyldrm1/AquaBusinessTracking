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

        public StarchAnalysisController(IStarchAnalysisHeadingService headService, IStarchAnalysisHeadingDetailService detailService)
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
        public async Task<IActionResult> Add([FromBody] CreateStarchAnalysisHeadingDto dto)
        {
            dto.InsertDate = DateTime.Now;
            await _headService.Add(dto);

            var all = await _headService.GetList();
            var last = all.OrderByDescending(x => x.RecId).FirstOrDefault();

            return Ok(last);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateStarchAnalysisHeadingDto dto)
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


        [HttpGet("{starchAnalysisHeadId}/starchAnalysisDetail")]
        public async Task<IActionResult> GetStarchAnalysisDetails(int starchAnalysisHeadId)
        {
            var all = await _detailService.GetList();
            var result = all.Where(x => x.StarchAnalysisHeadingId == starchAnalysisHeadId).ToList();
            return Ok(result);
        }

        [HttpPost("{starchAnalysisHeadId}/starchAnalysisDetail")]
        public async Task<IActionResult> AddStarchAnalysisDetail(int starchAnalysisHeadId, [FromBody] CreateStarchAnalysisHeadingDetailDto dto)
        {
            dto.StarchAnalysisHeadingId = starchAnalysisHeadId;
            var value = await _detailService.Add(dto);
            return Ok(value);
        }

        [HttpPut("{starchAnalysisHeadId}/starchAnalysisDetail")]
        public async Task<IActionResult> UpdateStarchAnalysisDetail(int starchAnalysisHeadId, [FromBody] UpdateStarchAnalysisHeadingDetailDto dto)
        {
            dto.StarchAnalysisHeadingId = starchAnalysisHeadId;
            await _detailService.Update(dto);
            return Ok();
        }

        [HttpDelete("{starchAnalysisHeadId}/starchAnalysisDetail/{starchAnalysisHeadDetailId}")]
        public async Task<IActionResult> DeleteStarchAnalysisDetail(int starchAnalysisHeadId, int starchAnalysisHeadDetailId)
        {
            await _detailService.Delete(starchAnalysisHeadDetailId);
            return Ok();
        }


    }
}
