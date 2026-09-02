using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface IShipmentOrderPlanDetailRepository : IGenericRepository<DB_ShipmentOrderPlanDetail>
    {
        Task<List<DB_ShipmentOrderPlanDetail>> GetByShipmentOrderPlanId(int shipmentOrderPlanId);
    }
}
