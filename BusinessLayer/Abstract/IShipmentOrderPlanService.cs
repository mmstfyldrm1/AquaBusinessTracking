using DTOLayer.Dtos.ShipmentOrderPlan;

namespace BusinessLayer.Abstract
{
    public interface IShipmentOrderPlanService : IGenericService<ShipmentOrderPlanDto, CreateShipmentOrderPlanDto, UpdateShipmentOrderPlanDto>
    {
        public Task<List<ShipmentOrderPlanDto>> GetWithDetails();
        public Task<List<ShipmentOrderPlanDto>> GetTodayPlan();
    }
}
