using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccsessLayer.Concrete.Repository
{
    public class WaterPreparationAndConsumptionRepository : GenericRepository<DB_WaterPreparationAndConsumption>, IWaterPreparationAndConsumptionRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public WaterPreparationAndConsumptionRepository(AquaBusinessTrackingContext context, ILogger<GenericRepository<DB_WaterPreparationAndConsumption>> logger) : base(context, logger)
        {
            _context = context;
        }

        public async Task<List<DB_WaterPreparationAndConsumption>> GetPreviousDay()
        {
            DateTime? startDate = DateTime.Today.AddDays(-1);
            DateTime? endDate = DateTime.Today;

            return await _context.Db_WaterPreparationAndConsumption
              .Include(x => x.Shift)
              .Include(x => x.AppUser)
              .Where(x => x.ReceiptDate >= startDate && x.ReceiptDate < endDate)
              .ToListAsync();
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
