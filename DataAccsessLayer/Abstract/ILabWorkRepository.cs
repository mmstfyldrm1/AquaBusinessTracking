using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface ILabWorkRepository : IGenericRepository<DB_LabWork>
    {
        public Task<List<DB_LabWork>> GetWithDetails();
    }
}
