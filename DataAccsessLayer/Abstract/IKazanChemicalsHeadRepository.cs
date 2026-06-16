using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface IKazanChemicalsHeadRepository : IGenericRepository<DB_KazanChemicalsHead>
    {
        public Task<List<DB_KazanChemicalsHead>> GetWithDetails();
    }
}
