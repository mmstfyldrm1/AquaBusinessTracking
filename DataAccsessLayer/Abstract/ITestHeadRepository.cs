using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface ITestHeadRepository : IGenericRepository<DB_TestHeader>
    {
        public Task<List<DB_TestHeader>> GetWithDetails();
    }
}
