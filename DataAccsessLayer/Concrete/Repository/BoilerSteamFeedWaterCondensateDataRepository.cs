using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccsessLayer.Concrete.Repository
{
    public class BoilerSteamFeedWaterCondensateDataRepository : GenericRepository<DB_BoilerSteamFeedWaterCondensateData>, IBoilerSteamFeedWaterCondensateDataRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public BoilerSteamFeedWaterCondensateDataRepository(AquaBusinessTrackingContext context, ILogger<GenericRepository<DB_BoilerSteamFeedWaterCondensateData>> logger) : base(context, logger)
        {
            _context = context;
        }

        public async Task<List<DB_BoilerSteamFeedWaterCondensateData>> GetPreviousDay()
        {
            DateTime? startDate = DateTime.Today.AddDays(-1);
            DateTime? endDate = DateTime.Today;

            return await _context.Db_BoilerSteamFeedWaterCondensateData
              .Include(x => x.Shift)
              .Include(x => x.AppUser)
              .Where(x => x.ReceiptDate >= startDate && x.ReceiptDate < endDate)
              .ToListAsync();
        }

        public async Task<List<DB_BoilerSteamFeedWaterCondensateData>> GetWithDetails()
        {
            return await _context.Db_BoilerSteamFeedWaterCondensateData
           .Include(x => x.Shift)
           .Include(x => x.AppUser)
           .ToListAsync();
        }
    }
}
