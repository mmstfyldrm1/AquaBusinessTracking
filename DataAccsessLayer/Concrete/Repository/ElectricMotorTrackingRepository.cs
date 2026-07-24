using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccsessLayer.Concrete.Repository
{
    public class ElectricMotorTrackingRepository : GenericRepository<DB_ElectricMotorTracking>, IElectricMotorTrackingRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public ElectricMotorTrackingRepository(AquaBusinessTrackingContext context, ILogger<GenericRepository<DB_ElectricMotorTracking>> logger) : base(context, logger)
        {
            _context = context;
        }

        public async Task<List<DB_ElectricMotorTracking>> GetWithDetails()
        {
            return await _context.Db_ElectricMotorTracking
                .Include(x => x.Shift)
                .Include(x => x.AppUser)
                .ToListAsync();
        }
    }
}
