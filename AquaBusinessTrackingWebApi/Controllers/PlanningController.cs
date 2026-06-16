
using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanningController : ControllerBase
    {
        private readonly IWastePaperControlService _wastepPaperService;

        public PlanningController(IWastePaperControlService wastepPaperService)
        {
            _wastepPaperService = wastepPaperService;
        }

        [HttpGet("Planning")]
        public async Task<IActionResult> GetPreviosDay()
        {
            var wastePaperControl = await _wastepPaperService.GetPreviousDay();



            return Ok();
        }
    }
}
