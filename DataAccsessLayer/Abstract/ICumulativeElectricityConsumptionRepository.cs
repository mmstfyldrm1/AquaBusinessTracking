using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface ICumulativeElectricityConsumptionRepository : IGenericRepository<DB_CumulativeElectricityConsumption>
    {
        Task<List<DB_CumulativeElectricityConsumption>> GetWithDetails();

        Task<List<DB_ElectricMeterLocation>> GetLocationName();
    }
}
