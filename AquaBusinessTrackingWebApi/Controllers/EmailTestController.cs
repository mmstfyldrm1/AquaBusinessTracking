using BusinessLayer.Abstract.MailService.@abstract;
using DTOLayer.Dtos.Email;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmailTestController : ControllerBase
    {
        private readonly IReportEmailService _reportEmailService;

        public EmailTestController(
            IReportEmailService reportEmailService)
        {
            _reportEmailService = reportEmailService;
        }

        [HttpPost("send-test-report")]
        public async Task<IActionResult> SendTestReport([FromBody] EmailTestRequestDto request)

        {
            if (string.IsNullOrWhiteSpace(request.RecipientEmail))
            {
                return BadRequest("Alıcı e-posta adresi zorunludur.");
            }

            try
            {
                await _reportEmailService.SendTestReportAsync(
                    request.RecipientEmail);

                return Ok(new
                {
                    Success = true,
                    Message = "PDF raporu e-posta ile gönderildi."
                });
            }
            catch (Exception ex)
            {
                // Ayrıntıyı sunucu loglarında tut.
                return StatusCode(500, new
                {
                    Success = false,
                    Message = "E-posta gönderimi başarısız oldu."
                });
            }
        }
    }
}