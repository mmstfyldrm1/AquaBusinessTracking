using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccsessLayer.Concrete.Repository
{
    public class MessageRepository : GenericRepository<DB_Message>, IMessageRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public MessageRepository(AquaBusinessTrackingContext context) : base(context)
        {
            _context = context;
        }

        public async Task<int> GetUnreadCountAsync(int userId)
        {
            return await _context.Db_Message
                 .CountAsync(m => m.ReceiverId == userId && !m.IsRead);
        }

        public async Task MarkAsReadAsync(int senderId, int receiverId)
        {
            var unreadMessages = await _context.Db_Message
                .Where(m => m.SenderId == senderId && m.ReceiverId == receiverId && !m.IsRead)
                .ToListAsync();

            foreach (var msg in unreadMessages)
            {
                msg.IsRead = true;
            }

            await _context.SaveChangesAsync();
        }
    }
}
