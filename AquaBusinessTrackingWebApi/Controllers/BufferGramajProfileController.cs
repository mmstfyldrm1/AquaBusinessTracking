using BusinessLayer.Abstract;
using DTOLayer.Dtos.BufferGramajProfileDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BufferGramajProfileController : ControllerBase
    {
        private readonly IBufferGramajProfileService _bufferGramajProfileService;
        private readonly ILogger<BufferGramajProfileController> _logger;

        public BufferGramajProfileController(
            IBufferGramajProfileService bufferGramajProfileService,
            ILogger<BufferGramajProfileController> logger)
        {
            _bufferGramajProfileService = bufferGramajProfileService;
            _logger = logger;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation(
                "Buffer Gramaj Profile listesi istendi. User={User}",
                User?.Identity?.Name);

            var result = await _bufferGramajProfileService.GetList();

            _logger.LogInformation(
                "{Count} adet Buffer Gramaj Profile kaydı getirildi.",
                result.Count());

            return Ok(result);
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            _logger.LogInformation(
                "Buffer Gramaj Profile detayları istendi. User={User}",
                User?.Identity?.Name);

            var result = await _bufferGramajProfileService.GetWithDetails();

            return Ok(result);
        }

        [HttpGet("getbyId/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation(
                "Buffer Gramaj Profile getiriliyor. Id={Id}",
                id);

            var result = await _bufferGramajProfileService.GetById(id);

            if (result == null)
            {
                _logger.LogWarning(
                    "Buffer Gramaj Profile bulunamadı. Id={Id}",
                    id);

                return NotFound();
            }

            _logger.LogInformation(
                "Buffer Gramaj Profile bulundu. Id={Id}",
                id);

            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateBufferGramajProfileDto createBufferGramajProfileDto)
        {
            _logger.LogInformation(
                "Yeni Buffer Gramaj Profile ekleniyor. User={User}",
                User?.Identity?.Name);

            createBufferGramajProfileDto.InsertDate = DateTime.Now;

            var result = await _bufferGramajProfileService.Add(createBufferGramajProfileDto);

            _logger.LogInformation(
                "Buffer Gramaj Profile başarıyla eklendi.");

            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateBufferGramajProfileDto updateBufferGramajProfileDto)
        {
            _logger.LogInformation(
                "Buffer Gramaj Profile güncelleniyor. Id={Id}",
                updateBufferGramajProfileDto.RecId);

            updateBufferGramajProfileDto.UpdateDate = DateTime.Now;

            await _bufferGramajProfileService.Update(updateBufferGramajProfileDto);

            _logger.LogInformation(
                "Buffer Gramaj Profile güncellendi. Id={Id}",
                updateBufferGramajProfileDto.RecId);

            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogWarning(
                "Buffer Gramaj Profile siliniyor. Id={Id}, User={User}",
                id,
                User?.Identity?.Name);

            await _bufferGramajProfileService.Delete(id);

            _logger.LogWarning(
                "Buffer Gramaj Profile silindi. Id={Id}",
                id);

            return Ok();
        }
    }
}