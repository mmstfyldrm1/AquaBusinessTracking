using AquaBusinessTrackingWebApi.Services;
using BusinessLayer.Abstract;
using DTOLayer.Dtos.NotificationDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly IHubContext<NotificationHub> _hub;

        public NotificationController(INotificationService notificationService, IHubContext<NotificationHub> hub)
        {
            _notificationService = notificationService;
            _hub = hub;
        }

        [HttpGet("unread/{appUserId}")]
        public async Task<IActionResult> GetUnread(int appUserId)
            => Ok(await _notificationService.GetUnreadAsync(appUserId));

        [HttpPost("mark-as-read/{id}")]
        public async Task<IActionResult> MarkAsRead(int id)
        {
            await _notificationService.MarkAsReadAsync(id);
            return Ok();
        }

        [HttpPost("send")]
        public async Task<IActionResult> Send(CreateNotificationDto dto)
        {
            var created = await _notificationService.SendAsync(dto);
            await _hub.Clients.Group($"user-{dto.UserId}").SendAsync("ReceiveNotification", created);
            return Ok(created);
        }
    }
}
