using AquaBusinessTrackingWebApi.Models.NotificationModels.Concrete;
using BusinessLayer.Abstract;
using DTOLayer.Dtos.NotificationDtos;

namespace AquaBusinessTrackingWebApi.Models.NotificationModels.Manager
{
    public class NotificationManager : ISendNotificationService
    {
        private readonly INotificationService _notificationService;

        public NotificationManager(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task<CreateNotificationDto> SendNotificationAsync(string title, string message, string[]? userId, string? roleName, string? url, string? icon, string? color)
        {
            return null;
        }
    }
}
