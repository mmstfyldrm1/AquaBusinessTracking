using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccsessLayer.Concrete.Repository
{
    public class LogisticsTrackingReportRepository : GenericRepository<DB_LogisticsTrackingReport>, ILogisticsTrackingReportRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public LogisticsTrackingReportRepository(AquaBusinessTrackingContext context, ILogger<GenericRepository<DB_LogisticsTrackingReport>> logger) : base(context, logger)
        {
            _context = context;
        }

        public async Task<List<DB_LogisticsTrackingReport>> GetWithDetails()
        {
            return await _context.Db_LogisticsTrackingReport
            .Include(x => x.Shift)
            .Include(x => x.AppUser)
            .ToListAsync();
        }
    }
}
