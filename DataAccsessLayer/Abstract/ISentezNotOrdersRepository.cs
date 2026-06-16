using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface ISentezNotOrdersRepository : IGenericRepository<DB_SentezNotOrder>
    {
        public Task<List<DB_SentezNotOrder>> GetWithDetails();
    }
}
