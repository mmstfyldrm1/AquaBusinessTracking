using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccsessLayer.Concrete.Repository
{
    public class DailyShipmentPlanRepository : GenericRepository<DB_DailyShipmentPlan>, IDailyShipmentPlanRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public DailyShipmentPlanRepository(AquaBusinessTrackingContext context, ILogger<GenericRepository<DB_DailyShipmentPlan>> logger) : base(context, logger)
        {
            _context = context;
        }

        public async Task<List<DB_DailyShipmentPlan>> GetWithDetails()
        {
            return await _context.Db_DailyShipmentPlan
                 .Include(x => x.Shift)
                 .Include(x => x.AppUser)
                  .OrderByDescending(x => x.RecId)
                 .ToListAsync();
        }

        public async Task<List<DB_DailyShipmentPlan>> GetActivePlan()
        {
            return await _context.Db_DailyShipmentPlan
                 .Include(x => x.Shift)
                 .Include(x => x.AppUser)
                 .Where(x => x.InUse == 1)
                 .ToListAsync();
        }

        public async Task<bool> UpdateIsStatus(int id)
        {
            var plan = await _context.Db_DailyShipmentPlan.FindAsync(id);

            if (plan == null)
                return false;

            plan.InUse = 0;

            var value = await _context.SaveChangesAsync();
            if (value == 0)
            {
                return false;
            }
            return true;

        }
    }
}
