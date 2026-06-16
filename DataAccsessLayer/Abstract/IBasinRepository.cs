using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface IBasinRepository : IGenericRepository<DB_Basin>
    {
        Task<List<DB_Basin>> GetBasinsWithDetails();

    }
}
