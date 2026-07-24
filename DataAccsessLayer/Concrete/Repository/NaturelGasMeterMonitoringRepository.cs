using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccsessLayer.Concrete.Repository
{
    public class NaturelGasMeterMonitoringRepository : GenericRepository<DB_NaturelGasMeterMonitoring>, INaturelGasMeterMonitoringRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public NaturelGasMeterMonitoringRepository(AquaBusinessTrackingContext context, ILogger<GenericRepository<DB_NaturelGasMeterMonitoring>> logger) : base(context, logger)
        {
            _context = context;
        }

        public async Task<List<DB_NaturelGasMeterMonitoring>> GetPreviousDay()
        {
            DateTime? startDate = DateTime.Today.AddDays(-1);
            DateTime? endDate = DateTime.Today;

            return await _context.Db_NaturelGasMeterMonitoring
              .Include(x => x.Shift)
              .Include(x => x.AppUser)
              .Where(x => x.ReceiptDate >= startDate && x.ReceiptDate < endDate)
              .ToListAsync();
        }

        public async Task<List<DB_NaturelGasMeterMonitoring>> GetWithDetails()
        {
            return await _context.Db_NaturelGasMeterMonitoring
                .Include(x => x.Shift)
                .Include(x => x.AppUser)
                .ToListAsync();
        }

        public async Task<List<DB_NaturelGasMeterMonitoring>> GetLast30DaysNaturelGas()
        {
            DateTime startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime endDate = DateTime.Today;
            return await _context.Db_NaturelGasMeterMonitoring
                .AsNoTracking()
                .Where(x => x.ReceiptDate >= startDate && x.ReceiptDate < endDate)
                .GroupBy(x => x.ReceiptDate!.Value.Date)
                .Select(g => new DB_NaturelGasMeterMonitoring
                {
                    ReceiptDate = g.Key,
                    DailyConsumption = g.Sum(x => x.DailyConsumption),
                    kW = g.Sum(x => x.kW)
                })
                .OrderBy(x => x.ReceiptDate)
                .ToListAsync();
        }
    }
}
