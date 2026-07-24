using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccsessLayer.Concrete.Repository
{

    public class WaterTreatmentAnalysisResultsRepository : GenericRepository<DB_WaterTreatmentAnalysisResults>, IWaterTreatmentAnalysisResultsRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public WaterTreatmentAnalysisResultsRepository(AquaBusinessTrackingContext context, ILogger<GenericRepository<DB_WaterTreatmentAnalysisResults>> logger) : base(context, logger)
        {
            _context = context;
        }

        public async Task<List<DB_WaterTreatmentAnalysisResults>> GetWithDetails()
        {
            return await _context.Db_WaterTreatmentAnalysisResults
                .Include(x => x.Shift)
                .Include(x => x.AppUser)
                .ToListAsync();
        }
    }
}
