using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccsessLayer.Concrete.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly AquaBusinessTrackingContext _context;

        public NotificationRepository(AquaBusinessTrackingContext context)
        {
            _context = context;
        }

        public async Task<DB_Notification> AddAsync(DB_Notification entity)
        {
            await _context.Db_Notification.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<DB_Notification?> GetByIdAsync(int id)
            => await _context.Db_Notification.FindAsync(id);

        public async Task<List<DB_Notification>> GetUnreadAsync(int appUserId)
        {
            return await _context.Db_Notification
            .Where(n => n.UserId == appUserId && !n.IsRead)
            .OrderByDescending(n => n.InsertDate)
            .ToListAsync();
        }

        public async Task MarkAsReadAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity == null) return;

            entity.IsRead = true;
            await _context.SaveChangesAsync();
        }
    }
}
