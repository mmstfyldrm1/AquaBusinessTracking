using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccsessLayer.Concrete.Repository
{
    public class BoilerRoomDailyShiftMonitoringRepository : GenericRepository<DB_BoilerRoomDailyShiftMonitoring>, IBoilerRoomDailyShiftMonitoringRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public BoilerRoomDailyShiftMonitoringRepository(AquaBusinessTrackingContext context, ILogger<GenericRepository<DB_BoilerRoomDailyShiftMonitoring>> logger) : base(context, logger)
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
