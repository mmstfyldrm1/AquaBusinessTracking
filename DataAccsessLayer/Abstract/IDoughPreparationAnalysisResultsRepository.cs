using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface IDoughPreparationAnalysisResultsRepository : IGenericRepository<DB_DoughPreparationAnalysisResults>
    {
        public Task<List<DB_DoughPreparationAnalysisResults>> GetWithDetails();
    }
}
