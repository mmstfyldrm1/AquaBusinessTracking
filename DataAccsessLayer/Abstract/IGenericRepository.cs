namespace DataAccsessLayer.Abstract
{
    public interface IGenericRepository<T>
    {
        Task<List<T>> TGetAll();
        Task<T> TGetById(int id);
        Task TAdd(T entity);
        Task TUpdate(T entity);
        Task TDelete(T entity);
    }
}
