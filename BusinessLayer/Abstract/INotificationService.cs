using DTOLayer.Dtos.NotificationDtos;

namespace BusinessLayer.Abstract
{
    public interface INotificationService
    {
        Task<NotificationDto> SendAsync(CreateNotificationDto dto);
        Task<List<NotificationDto>> GetUnreadAsync(int appUserId);
        Task MarkAsReadAsync(int id);
    }
}
