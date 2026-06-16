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

        public BufferGramajProfileController(IBufferGramajProfileService bufferGramajProfileService)
        {
            _bufferGramajProfileService = bufferGramajProfileService;
        }
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _bufferGramajProfileService.GetList();
            return Ok(result);
        }

        [HttpGet("details")]
        public async Task<IActionResult> GetWithDetails()
        {
            var result = await _bufferGramajProfileService.GetWithDetails();
            return Ok(result);
        }

        [HttpGet("getbyId/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _bufferGramajProfileService.GetById(id);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateBufferGramajProfileDto createBufferGramajProfileDto)
        {
            createBufferGramajProfileDto.InsertDate = DateTime.Now;
            var result = await _bufferGramajProfileService.Add(createBufferGramajProfileDto);
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateBufferGramajProfileDto updateBufferGramajProfileDto)
        {
            updateBufferGramajProfileDto.UpdateDate = DateTime.Now;
            await _bufferGramajProfileService.Update(updateBufferGramajProfileDto);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _bufferGramajProfileService.Delete(id);
            return Ok();
        }


    }
}
