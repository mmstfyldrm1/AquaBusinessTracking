using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface IBufferAnalysisReportRepository : IGenericRepository<DB_BufferAnalysisReport>
    {
        public Task<List<DB_BufferAnalysisReport>> GetWithDetails();
    }
}
