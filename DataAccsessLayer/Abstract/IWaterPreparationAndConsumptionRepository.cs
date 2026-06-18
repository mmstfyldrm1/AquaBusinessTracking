using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface IWaterPreparationAndConsumptionRepository : IGenericRepository<DB_WaterPreparationAndConsumption>
    {
        public Task<List<DB_WaterPreparationAndConsumption>> GetWithDetails();

        public Task<List<DB_WaterPreparationAndConsumption>> GetPreviousDay();
    }
}
