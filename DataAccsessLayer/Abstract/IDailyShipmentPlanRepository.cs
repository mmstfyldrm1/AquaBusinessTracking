using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface IDailyShipmentPlanRepository : IGenericRepository<DB_DailyShipmentPlan>
    {
        public Task<List<DB_DailyShipmentPlan>> GetWithDetails();
        public Task<List<DB_DailyShipmentPlan>> GetActivePlan();

        public Task<bool> UpdateIsActiveStatus(int id);
        public Task<bool> UpdateIsStatus(int id);

    }
}
