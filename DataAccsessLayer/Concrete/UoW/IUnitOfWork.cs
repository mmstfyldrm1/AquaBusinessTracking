using DataAccsessLayer.Abstract;

namespace DataAccsessLayer.Concrete.UoW
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> Repository<T>() where T : class;
        Task SaveChangesAsync();
    }
}
