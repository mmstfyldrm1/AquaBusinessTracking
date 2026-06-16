using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface IOilAnalysisReportRepository : IGenericRepository<DB_OilAnalysisReport>
    {
        public Task<List<DB_OilAnalysisReport>> GetWithDetails();
    }
}
