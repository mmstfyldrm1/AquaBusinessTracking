using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface IWaterTreatmentAnalysisResultsRepository : IGenericRepository<DB_WaterTreatmentAnalysisResults>
    {
        public Task<List<DB_WaterTreatmentAnalysisResults>> GetWithDetails();
    }
}
