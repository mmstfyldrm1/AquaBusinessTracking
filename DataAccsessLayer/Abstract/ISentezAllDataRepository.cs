using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface ISentezAllDataRepository : IGenericRepository<DB_SentezAllData>
    {
        public Task<List<DB_SentezAllData>> GetWithDetails();
    }
}
