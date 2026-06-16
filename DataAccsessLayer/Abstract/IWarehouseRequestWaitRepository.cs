using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface IWarehouseRequestWaitRepository : IGenericRepository<DB_WarehouseRequestWait>
    {
        public Task<List<DB_WarehouseRequestWait>> GetWithDetails();
    }
}
