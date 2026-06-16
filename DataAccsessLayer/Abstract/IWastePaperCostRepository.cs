using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface IWastePaperCostRepository : IGenericRepository<DB_WastePaperCost>
    {
        public Task<List<DB_WastePaperCost>> GetWithDetails();
    }
}
