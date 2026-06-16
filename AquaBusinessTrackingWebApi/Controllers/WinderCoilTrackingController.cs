using BusinessLayer.Abstract;
using DTOLayer.Dtos.WinderCoilTrackingDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WinderCoilTrackingController : ControllerBase
    {
        private readonly IWinderCoilTrackingService _service;

        public WinderCoilTrackingController(IWinderCoilTrackingService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetList();
            return Ok(result);
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            var result = await _service.GetWithDetails();
            return Ok(result);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(CreateWinderCoilTrackingDto dto)
        {
            dto.InsertDate = DateTime.Now;
            await _service.Add(dto);
            return Ok(dto);
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> Update(UpdateWinderCoilTrackingDto dto)
        {
            dto.UpdateDate = DateTime.Now;
            await _service.Update(dto);
            return Ok(dto);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}
