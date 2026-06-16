using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccsessLayer.Concrete.Repository
{
    public class RetentionAnalysisHeadRepository : GenericRepository<DB_RetentionAnalysisHead>, IRetentionAnalysisHeadRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public RetentionAnalysisHeadRepository(AquaBusinessTrackingContext context) : base(context)
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
