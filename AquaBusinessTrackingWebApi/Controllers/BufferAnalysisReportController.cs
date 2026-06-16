using BusinessLayer.Abstract;
using DTOLayer.Dtos.BufferAnalysisReportDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BufferAnalysisReportController : ControllerBase
    {
        private readonly IBufferAnalysisReportService _bufferAnalysisReportService;

        public BufferAnalysisReportController(IBufferAnalysisReportService bufferAnalysisReportService)
        {
            _bufferAnalysisReportService = bufferAnalysisReportService;
        }


        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _bufferAnalysisReportService.GetList();
            return Ok(result);
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            var result = await _bufferAnalysisReportService.GetWithDetails();
            return Ok(result);
        }

        [HttpGet("getbyId/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _bufferAnalysisReportService.GetById(id);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateBufferAnalysisReportDto createBufferAnalysisReportDto)
        {
            createBufferAnalysisReportDto.InsertDate = DateTime.Now;
            var result = await _bufferAnalysisReportService.Add(createBufferAnalysisReportDto);
            return Ok(result);

        }
        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(UpdateBufferAnalysisReportDto updateBufferAnalysisReportDto)
        {
            updateBufferAnalysisReportDto.UpdateDate = DateTime.Now;
            await _bufferAnalysisReportService.Update(updateBufferAnalysisReportDto);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _bufferAnalysisReportService.Delete(id);
            return Ok();
        }

    }

}
