using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccsessLayer.Concrete.Repository
{
    public class ShipmentOrderPlanRepository : GenericRepository<DB_ShipmentOrderPlan>, IShipmentOrderPlanRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public ShipmentOrderPlanRepository(AquaBusinessTrackingContext context, ILogger<GenericRepository<DB_ShipmentOrderPlan>> logger) : base(context, logger)
        {
            _context = context;
        }

        public async Task<List<DB_ShipmentOrderPlan>> GetWithDetails()
        {
            return await _context.Db_ShipmentOrderPlan
                .Include(x => x.Department)
                .Include(x => x.AppUser)
                 .OrderByDescending(x => x.RecId)
                .ToListAsync();
        }
    }
}
