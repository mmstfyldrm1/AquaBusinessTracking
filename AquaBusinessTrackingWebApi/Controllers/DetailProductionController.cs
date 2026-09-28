using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DetailProductionController : ControllerBase
    {
        private readonly ISentezProductionQueryService _sentezProductionQueryService;

        public DetailProductionController(ISentezProductionQueryService sentezProductionQueryService)
        {
            _sentezProductionQueryService = sentezProductionQueryService;
        }

        [HttpGet("GetCombinationDetails")]
        public async Task<IActionResult> GetCombinationDetails()
        {
            var result = await _sentezProductionQueryService.GetProductionCombination();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("GetProductionDetails")]
        public async Task<IActionResult> GetProductionDetails()
        {
            var result = await _sentezProductionQueryService.GetProductionDetails();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
