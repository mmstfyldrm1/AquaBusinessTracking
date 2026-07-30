using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface IChemicalSupplierProductsRepository : IGenericRepository<DB_ChemicalSupplierProducts>
    {
        public Task<List<DB_ChemicalSupplierProducts>> GetWithDetails();
    }
}
