using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccsessLayer.Concrete.Repository
{
    public class RetentionAnalysisHeadRepository : GenericRepository<DB_RetentionAnalysisHead>, IRetentionAnalysisHeadRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public RetentionAnalysisHeadRepository(AquaBusinessTrackingContext context, ILogger<GenericRepository<DB_RetentionAnalysisHead>> logger) : base(context, logger)
        {
            _context = context;
        }

        public async Task<List<DB_RetentionAnalysisHead>> GetWithDetails()
        {
            return await _context.Db_RetentionAnalysisHead
                .Include(x => x.Shift)
                .Include(x => x.AppUser)
                .ToListAsync();
        }
    }
}
