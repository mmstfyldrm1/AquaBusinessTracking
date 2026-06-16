using BusinessLayer.Abstract;
using DTOLayer.Dtos.NaturelGasMeterMonitoringDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NaturelGasMeterMonitoringController : ControllerBase
    {
        private readonly INaturelGasMeterMonitoringService _naturelGasMeterMonitoringService;

        public NaturelGasMeterMonitoringController(INaturelGasMeterMonitoringService naturelGasMeterMonitoringService)
        {
            _naturelGasMeterMonitoringService = naturelGasMeterMonitoringService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _naturelGasMeterMonitoringService.GetList();
            return Ok(result);

        }
        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            var result = await _naturelGasMeterMonitoringService.GetWithDetails();
            return Ok(result);
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _naturelGasMeterMonitoringService.GetById(id);
            return Ok(result);
        }


        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateNaturelGasMeterMonitoringDto dto)
        {
            dto.InsertDate = DateTime.Now;
            var result = await _naturelGasMeterMonitoringService.Add(dto);
            return Ok(result);

        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateNaturelGasMeterMonitoringDto dto)
        {
            dto.UpdateDate = DateTime.Now;
            await _naturelGasMeterMonitoringService.Update(dto);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _naturelGasMeterMonitoringService.Delete(id);
            return Ok();
        }
    }
}
