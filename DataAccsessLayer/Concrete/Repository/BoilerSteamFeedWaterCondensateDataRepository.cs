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
            .OrderByDescending(x => x.RecId)
           .ToListAsync();
        }

        public async Task<List<DB_BoilerSteamFeedWaterCondensateData>> GetLast30DaysBoilerConsumable()
        {
            DateTime startDate = DateTime.Now.AddDays(-30); //new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime endDate = DateTime.Today.AddDays(1);

            var data = await _context.Db_BoilerSteamFeedWaterCondensateData
                .AsNoTracking()

                .Where(x => x.ReceiptDate >= startDate && x.ReceiptDate < endDate)
                .GroupBy(x => new
                {
                    Date = x.ReceiptDate!.Value.Date,
                })
                .Select(g => new DB_BoilerSteamFeedWaterCondensateData
                {
                    ReceiptDate = g.Key.Date,
                    Boil = g.Sum(x => x.Boil)
                })
                .OrderBy(x => x.ReceiptDate)
                .ToListAsync();

            return data;
        }

        public async Task<List<DB_BoilerSteamFeedWaterCondensateData>> GetWithSearchDetails(DateTime StartDate, DateTime EndDate)
        {


            var query = _context.Db_BoilerSteamFeedWaterCondensateData
               .Include(x => x.Shift)
               .Include(x => x.AppUser)
               .Where(x => x.ReceiptDate >= StartDate && x.ReceiptDate < EndDate);

            return await query.ToListAsync();
        }


    }
}
