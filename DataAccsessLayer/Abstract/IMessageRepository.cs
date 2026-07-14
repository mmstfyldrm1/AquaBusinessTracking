using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface IMessageRepository : IGenericRepository<DB_Message>
    {
        Task<int> GetUnreadCountAsync(int userId);
        Task MarkAsReadAsync(int senderId, int receiverId);
    }
}
