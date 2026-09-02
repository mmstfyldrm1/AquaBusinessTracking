using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccsessLayer.Concrete.Repository
{
    public class ShipmentOrderPlanDetailRepository : GenericRepository<DB_ShipmentOrderPlanDetail>, IShipmentOrderPlanDetailRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public ShipmentOrderPlanDetailRepository(AquaBusinessTrackingContext context, ILogger<GenericRepository<DB_ShipmentOrderPlanDetail>> logger) : base(context, logger)
        {
            _context = context;
        }

        public async Task<List<DB_ShipmentOrderPlanDetail>> GetByShipmentOrderPlanId(int shipmentOrderPlanId)
        {
            return await _context.Db_ShipmentOrderPlanDetail
                .Where(detail => detail.ShipmentPlanId == shipmentOrderPlanId)
                .ToListAsync();
        }
    }
}
