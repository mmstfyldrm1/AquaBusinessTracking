using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccsessLayer.Concrete.Repository
{
    public class WaterPreparationAndConsumptionRepository : GenericRepository<DB_WaterPreparationAndConsumption>, IWaterPreparationAndConsumptionRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public WaterPreparationAndConsumptionRepository(AquaBusinessTrackingContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<DB_WaterPreparationAndConsumption>> GetWithDetails()
        {
            return await _context.Db_WaterPreparationAndConsumption
                .Include(x => x.Shift)
                .Include(x => x.AppUser)
                .ToListAsync();
        }
    }
}
