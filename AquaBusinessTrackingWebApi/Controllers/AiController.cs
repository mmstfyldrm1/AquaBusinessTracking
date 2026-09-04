using AIAgent.Orchestration.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]


    public class AiController : ControllerBase
    {
        private readonly IAiService _aiService;

        public AiController(IAiService aiService)
        {
            _aiService = aiService;
        }

        [HttpPost("ask")]
        public async Task<IActionResult> Ask([FromBody] AiRequest request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.Message))
                {
                    return BadRequest(new
                    {
                        success = false,
                        message = "Mesaj boş olamaz."
                    });
                }

                var result = await _aiService.AskAsync(
                    request.Message);

                return Ok(new
                {
                    success = true,
                    response = result
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    success = false,
                    message = ex.Message,
                    innerException = ex.InnerException?.Message,
                    stackTrace = ex.StackTrace
                });
            }
        }


    }
    public class AiRequest
    {
        public string Message { get; set; } = string.Empty;
    }

}

