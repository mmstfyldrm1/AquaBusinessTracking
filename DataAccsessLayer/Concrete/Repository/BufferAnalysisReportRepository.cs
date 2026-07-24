using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccsessLayer.Concrete.Repository
{
    public class BufferAnalysisReportRepository : GenericRepository<DB_BufferAnalysisReport>, IBufferAnalysisReportRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public BufferAnalysisReportRepository(AquaBusinessTrackingContext context, ILogger<GenericRepository<DB_BufferAnalysisReport>> logger) : base(context, logger)
        {
            _context = context;
        }

        public async Task<List<DB_BufferAnalysisReport>> GetPreviousDay()
        {
            DateTime? startDate = DateTime.Today.AddDays(-1);
            DateTime? endDate = DateTime.Today;

            return await _context.Db_BufferAnalysisReport
              .Include(x => x.Shift)
              .Include(x => x.AppUser)
              .Where(x => x.ReceiptDate >= startDate && x.ReceiptDate < endDate)
              .ToListAsync();
        }

        public async Task<List<DB_BufferAnalysisReport>> GetWithDetails()
        {
            return await _context.Db_BufferAnalysisReport
          .Include(x => x.Shift)
          .Include(x => x.AppUser)
          .ToListAsync();
        }
    }
}
