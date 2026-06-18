using BusinessLayer.Abstract;
using DTOLayer.Dtos.ShiftDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ShiftController : ControllerBase
    {
        private readonly IShiftService _shiftService;

        public ShiftController(IShiftService shiftService)
        {
            _shiftService = shiftService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetList()
        {
            var result = await _shiftService.GetList();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _shiftService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Add(CreateShiftDto dto)
        {
            dto.InsertDate = DateTime.Now;
            await _shiftService.Add(dto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(UpdateShiftDto dto)
        {
            dto.UpdateDate = DateTime.Now;
            await _shiftService.Update(dto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _shiftService.Delete(id);
            return Ok();
        }
    }
}
