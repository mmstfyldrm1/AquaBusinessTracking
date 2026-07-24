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
        private readonly ILogger<MessageController> _logger;

        public MessageController(
            IMessageService service,
            ILogger<MessageController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation(
                "Mesaj listesi istendi. User={User}",
                User?.Identity?.Name);

            var result = await _service.GetList();

            _logger.LogInformation(
                "{Count} adet mesaj getirildi.",
                result.Count());

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
            _logger.LogInformation(
                "Okunmamış mesaj sayısı isteniyor. UserId={UserId}",
                userId);

            var count = await _service.GetUnreadCountAsync(userId);

            _logger.LogInformation(
                "Okunmamış mesaj sayısı: {Count}. UserId={UserId}",
                count,
                userId);

            return Ok(count);
        }

        [HttpPost("markasread")]
        public async Task<IActionResult> MarkAsRead([FromBody] MarkAsReadDto dto)
        {
            _logger.LogInformation(
                "Mesajlar okundu olarak işaretleniyor. Sender={SenderId}, Receiver={ReceiverId}",
                dto.SenderId,
                dto.ReceiverId);

            await _service.MarkAsReadAsync(dto.SenderId, dto.ReceiverId);

            _logger.LogInformation(
                "Mesajlar okundu olarak işaretlendi. Sender={SenderId}, Receiver={ReceiverId}",
                dto.SenderId,
                dto.ReceiverId);

            return Ok();
        }

        [HttpGet("getbyId/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _logger.LogInformation(
                "Mesaj getiriliyor. Id={Id}",
                id);

            var result = await _service.GetById(id);

            if (result == null)
            {
                _logger.LogWarning(
                    "Mesaj bulunamadı. Id={Id}",
                    id);

                return NotFound();
            }

            _logger.LogInformation(
                "Mesaj bulundu. Id={Id}",
                id);

            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateMessageDto dto)
        {
            _logger.LogInformation(
                "Yeni mesaj gönderiliyor. Sender={SenderId}, Receiver={ReceiverId}",
                dto.SenderId,
                dto.ReceiverId);

            var result = await _service.Add(dto);

            _logger.LogInformation(
                "Mesaj başarıyla gönderildi.");

            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateMessageDto dto)
        {
            _logger.LogInformation(
                "Mesaj güncelleniyor. Id={Id}",
                id);

            dto.RecId = id;

            await _service.Update(dto);

            _logger.LogInformation(
                "Mesaj güncellendi. Id={Id}",
                id);

            return Ok();
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogWarning(
                "Mesaj siliniyor. Id={Id}, User={User}",
                id,
                User?.Identity?.Name);

            await _service.Delete(id);

            _logger.LogWarning(
                "Mesaj silindi. Id={Id}",
                id);

            return Ok();
        }
    }
}