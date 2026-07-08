using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface IBufferProductionRepository : IGenericRepository<DB_BufferProduction>
    {
        public Task<List<DB_BufferProduction>> GetWithDetails();
    }
}
