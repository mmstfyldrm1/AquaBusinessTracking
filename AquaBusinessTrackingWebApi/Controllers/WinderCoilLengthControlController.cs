using BusinessLayer.Abstract;
using DTOLayer.Dtos.WinderCoilLengthControlDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WinderCoilLengthControlController : ControllerBase
    {
        private readonly IWinderCoilLengthControlService _winderCoilLengthControlService;

        public WinderCoilLengthControlController(IWinderCoilLengthControlService winderCoilLengthControlService)
        {
            _winderCoilLengthControlService = winderCoilLengthControlService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _winderCoilLengthControlService.GetList();
            return Ok(result);
        }
        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            var result = await _winderCoilLengthControlService.GetWithDetails();
            return Ok(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _winderCoilLengthControlService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateWinderLengthControlDto winderCoilLengthControl)
        {
            winderCoilLengthControl.InsertDate = DateTime.Now;
            await _winderCoilLengthControlService.Add(winderCoilLengthControl);
            return Ok(winderCoilLengthControl);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateWinderCoilLengthControlDto winderCoilLengthControl)
        {
            winderCoilLengthControl.UpdateDate = DateTime.Now;
            await _winderCoilLengthControlService.Update(winderCoilLengthControl);
            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete(int id)
        {
            await _winderCoilLengthControlService.Delete(id);
            return Ok();
        }
    }
}