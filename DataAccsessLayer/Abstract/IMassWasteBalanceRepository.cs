using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface IMassWasteBalanceRepository : IGenericRepository<DB_MassWasteBalance>
    {
        public Task<List<DB_MassWasteBalance>> GetWithDetails();
    }
}
