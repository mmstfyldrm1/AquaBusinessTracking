using BusinessLayer.Abstract;
using DTOLayer.Dtos.MessageDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _service;

        public MessageController(IMessageService service)
        {
            _service = service;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetList();
            return Ok(result);
        }

        //[HttpGet("details")]
        //public async Task<IActionResult> GetWithDetails()
        //{
        //    var result = await _service.GetWithDetails();
        //    return Ok(result);
        //}

        [HttpGet("unreadcount/{userId}")]
        public async Task<IActionResult> GetUnreadCount(int userId)
        {
            var count = await _service.GetUnreadCountAsync(userId);
            return Ok(count);
        }

        [HttpPost("markasread")]
        public async Task<IActionResult> MarkAsRead([FromBody] MarkAsReadDto dto)
        {
            await _service.MarkAsReadAsync(dto.SenderId, dto.ReceiverId);
            return Ok();
        }

        [HttpGet("getbyId/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetById(id);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateMessageDto dto)
        {
            // doughPreparationDto.InsertDate = DateTime.Now;
            var result = await _service.Add(dto);
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update([FromBody] UpdateMessageDto dto)
        {
            await _service.Update(dto);
            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}
