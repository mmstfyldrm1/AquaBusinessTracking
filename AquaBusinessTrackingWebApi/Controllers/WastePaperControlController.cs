using BusinessLayer.Abstract;
using DTOLayer.Dtos.WastePaperControlDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WastePaperControlController : ControllerBase
    {
        private readonly IWastePaperControlService _wastePaperControlService;

        public WastePaperControlController(IWastePaperControlService wastePaperControlService)
        {
            _wastePaperControlService = wastePaperControlService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _wastePaperControlService.GetList();
            return Ok(result);
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            var result = await _wastePaperControlService.GetWithDetails();
            return Ok(result);
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _wastePaperControlService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateWastePaperControlDto wastePaperControl)
        {
            wastePaperControl.InsertDate = DateTime.Now;
            await _wastePaperControlService.Add(wastePaperControl);
            return Ok(wastePaperControl);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateWastePaperControlDto wastePaperControl)
        {
            wastePaperControl.UpdateDate = DateTime.Now;
            await _wastePaperControlService.Update(wastePaperControl);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _wastePaperControlService.Delete(id);
            return Ok();
        }


    }
}
