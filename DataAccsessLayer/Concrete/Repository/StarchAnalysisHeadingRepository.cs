using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccsessLayer.Concrete.Repository
{
    public class StarchAnalysisHeadingRepository : GenericRepository<DB_StarchAnalysisHeading>, IStarchAnalysisHeadingRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public StarchAnalysisHeadingRepository(AquaBusinessTrackingContext context, ILogger<GenericRepository<DB_StarchAnalysisHeading>> logger) : base(context, logger)
        {
            _context = context;
        }

        public async Task<List<DB_StarchAnalysisHeading>> GetWithDetails()
        {
            return await _context.Db_StarchAnalysisHeading
                .Include(x => x.Department)
                .Include(x => x.AppUser)
                .ToListAsync();
        }
    }
}
