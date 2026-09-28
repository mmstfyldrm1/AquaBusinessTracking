using DTOLayer.Dtos.NotificationDtos;

namespace AquaBusinessTrackingWebApi.Models.NotificationModels.Concrete
{
    public interface ISendNotificationService
    {
        public Task<CreateNotificationDto> SendNotificationAsync(string title, string message, string[]? userId, string? roleName, string? url, string? icon, string? color);
    }
}
