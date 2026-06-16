using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface IElectricShiftWorkRepository : IGenericRepository<DB_ElectricShiftWork>
    {
        public Task<List<DB_ElectricShiftWork>> GetWithDetails();
    }
}
