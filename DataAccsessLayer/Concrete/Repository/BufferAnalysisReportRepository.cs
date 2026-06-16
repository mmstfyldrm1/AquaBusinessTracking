using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccsessLayer.Concrete.Repository
{
    public class BufferAnalysisReportRepository : GenericRepository<DB_BufferAnalysisReport>, IBufferAnalysisReportRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public BufferAnalysisReportRepository(AquaBusinessTrackingContext context) : base(context)
        {
            _context = context;
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
