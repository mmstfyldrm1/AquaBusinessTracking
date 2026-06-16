using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccsessLayer.Concrete.Repository
{
    public class OilAnalysisReportRepository : GenericRepository<DB_OilAnalysisReport>, IOilAnalysisReportRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public OilAnalysisReportRepository(AquaBusinessTrackingContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<DB_OilAnalysisReport>> GetWithDetails()
        {
            return await _context.Db_OilAnalysisReport
                .Include(x => x.Shift)
                .Include(x => x.AppUser)
                .ToListAsync();
        }
    }
}
