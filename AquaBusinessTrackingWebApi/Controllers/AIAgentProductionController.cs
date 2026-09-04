using AIAgent.Tools.Production;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AIAgentProductionController : ControllerBase
    {
        private readonly GetLast7DaysProductionTool _productionTool;

        public AIAgentProductionController(GetLast7DaysProductionTool productionTool)
        {
            _productionTool = productionTool;
        }

        [HttpGet("last-7-days")]
        public async Task<IActionResult> GetLast7Days()
        {
            try
            {
                var result = await _productionTool.ExecuteAsync();

                return Ok(new
                {
                    success = true,
                    tool = _productionTool.Name,
                    data = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = ex.Message,
                    innerException = ex.InnerException?.Message
                });
            }
        }
    }
}

