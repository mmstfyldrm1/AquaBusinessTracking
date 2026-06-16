using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface IStarchAnalysisHeadingRepository : IGenericRepository<DB_StarchAnalysisHeading>
    {
        public Task<List<DB_StarchAnalysisHeading>> GetWithDetails();
    }
}
