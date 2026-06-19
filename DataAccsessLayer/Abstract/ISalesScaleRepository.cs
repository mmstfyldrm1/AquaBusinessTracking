using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface ISalesScaleRepository : IGenericRepository<DB_SalesScale>
    {
        public Task<List<DB_SalesScale>> GetWithDetails();

        public Task<decimal> GetPreviousTodaySales();



    }
}
