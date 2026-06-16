using BusinessLayer.Abstract;
using DTOLayer.Dtos.LabWorkDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LabWorkController : ControllerBase
    {
        private readonly ILabWorkService _labWorkService;

        public LabWorkController(ILabWorkService labWorkService)
        {
            _labWorkService = labWorkService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _labWorkService.GetList();
            return Ok(result);
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            var result = await _labWorkService.GetWithDetails();
            return Ok(result);
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _labWorkService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateLabWorkDto dto)
        {
            dto.InsertDate = DateTime.Now;
            await _labWorkService.Add(dto);
            return Ok(dto);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateLabWorkDto dto)
        {
            dto.UpdateDate = DateTime.Now;
            await _labWorkService.Update(dto);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _labWorkService.Delete(id);
            return Ok();
        }
    }
}
