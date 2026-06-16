using BusinessLayer.Abstract;
using DTOLayer.Dtos.WastePaperCost;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WastePaperCostController : ControllerBase
    {
        private readonly IWastePaperCostService _wastePaperCostService;

        public WastePaperCostController(IWastePaperCostService wastePaperCostService)
        {
            _wastePaperCostService = wastePaperCostService;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _wastePaperCostService.GetList();
            return Ok(result);

        }

        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            var result = await _wastePaperCostService.GetWithDetails();
            return Ok(result);
        }
        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _wastePaperCostService.GetById(id);
            return Ok(result);
        }


        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateWastePaperCostDto wastePaperCost)
        {
            wastePaperCost.InsertDate = DateTime.Now;
            var result = await _wastePaperCostService.Add(wastePaperCost);
            return Ok(result);

        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromBody] UpdateWastePaperCostDto wastePaperCost)
        {
            wastePaperCost.UpdateDate = DateTime.Now;
            await _wastePaperCostService.Update(wastePaperCost);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _wastePaperCostService.Delete(id);
            return Ok();
        }


    }
}
