using BusinessLayer.Abstract;
using DTOLayer.Dtos.Email;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EmailReportRecipientController : ControllerBase
    {
        private readonly IEmailReportRecipientService _service;

        public EmailReportRecipientController(
            IEmailReportRecipientService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            var result = await _service.GetList();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _service.GetById(id);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add(
            [FromBody] CreateEmailReportRecipientDto dto)
        {
            try
            {
                var result = await _service.Add(dto);

                return CreatedAtAction(
                    nameof(GetById),
                    new { id = result.RecId },
                    result);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { Message = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update(
            [FromBody] UpdateEmailReportRecipientDto dto)
        {
            try
            {
                await _service.Update(dto);
                return Ok(new { Message = "E-posta alıcısı güncellendi." });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { Message = ex.Message });
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _service.Delete(id);
                return Ok(new { Message = "E-posta alıcısı silindi." });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
    }
}