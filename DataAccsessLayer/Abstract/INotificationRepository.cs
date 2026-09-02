using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface INotificationRepository
    {
        Task<DB_Notification> AddAsync(DB_Notification entity);
        Task<List<DB_Notification>> GetUnreadAsync(int appUserId);
        Task<DB_Notification?> GetByIdAsync(int id);
        Task MarkAsReadAsync(int id);
    }
}
