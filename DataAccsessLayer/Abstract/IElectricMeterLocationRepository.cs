using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface IElectricMeterLocationRepository : IGenericRepository<DB_ElectricMeterLocation>
    {
        public Task<List<DB_ElectricMeterLocation>> GetWithDetails();
    }
}
