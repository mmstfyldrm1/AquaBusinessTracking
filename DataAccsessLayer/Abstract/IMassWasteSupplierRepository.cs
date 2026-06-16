using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface IMassWasteSupplierRepository : IGenericRepository<DB_MassWasteSupplier>
    {
        public Task<List<DB_MassWasteSupplier>> GetWithDetails();
    }
}
