using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface IShipmentOrderPlanRepository : IGenericRepository<DB_ShipmentOrderPlan>
    {
        public Task<List<DB_ShipmentOrderPlan>> GetWithDetails();
    }
}
