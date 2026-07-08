using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccsessLayer.Concrete.Repository
{
    public class BoilerRoomDailyShiftMonitoringRepository : GenericRepository<DB_BoilerRoomDailyShiftMonitoring>, IBoilerRoomDailyShiftMonitoringRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public BoilerRoomDailyShiftMonitoringRepository(AquaBusinessTrackingContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<DB_BoilerRoomDailyShiftMonitoring>> GetWithDetails()
        {
            return await _context.Db_BoilerRoomDailyShiftMonitoring
           .Include(x => x.Shift)
           .Include(x => x.AppUser)
           .ToListAsync();
        }
    }
}
