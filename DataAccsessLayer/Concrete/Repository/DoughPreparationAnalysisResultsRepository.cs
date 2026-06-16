using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccsessLayer.Concrete.Repository
{
    public class DoughPreparationAnalysisResultsRepository : GenericRepository<DB_DoughPreparationAnalysisResults>, IDoughPreparationAnalysisResultsRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public DoughPreparationAnalysisResultsRepository(AquaBusinessTrackingContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<DB_DoughPreparationAnalysisResults>> GetWithDetails()
        {
            return await _context.Db_DoughPreparationAnalysisResults
            .Include(x => x.Shift)
            .Include(x => x.AppUser)
            .ToListAsync();
        }
    }
}
