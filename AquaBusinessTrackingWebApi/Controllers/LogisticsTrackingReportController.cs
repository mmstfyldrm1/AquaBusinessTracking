using BusinessLayer.Abstract;
using DTOLayer.Dtos.LogisticsTrackingReportDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LogisticsTrackingReportController : ControllerBase
    {
        private readonly ILogisticsTrackingReportService _logisticsTrackingReportService;

        public LogisticsTrackingReportController(ILogisticsTrackingReportService logisticsTrackingReportService)
        {
            _logisticsTrackingReportService = logisticsTrackingReportService;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _logisticsTrackingReportService.GetList();
            return Ok(result);
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            var result = await _logisticsTrackingReportService.GetWithDetails();
            return Ok(result);
        }


        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _logisticsTrackingReportService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateLogisticsTrackingReportDto dto)
        {
            dto.InsertDate = DateTime.Now;
            await _logisticsTrackingReportService.Add(dto);
            return Ok(dto);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateLogisticsTrackingReportDto dto)
        {
            dto.UpdateDate = DateTime.Now;
            await _logisticsTrackingReportService.Update(dto);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _logisticsTrackingReportService.Delete(id);
            return Ok();
        }
    }
}
