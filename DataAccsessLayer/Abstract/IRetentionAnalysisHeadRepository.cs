using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface IRetentionAnalysisHeadRepository : IGenericRepository<DB_RetentionAnalysisHead>
    {
        public Task<List<DB_RetentionAnalysisHead>> GetWithDetails();
    }
}
