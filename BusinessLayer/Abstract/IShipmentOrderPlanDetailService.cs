using DTOLayer.Dtos.ShipmentOrderPlanDtos.ShipmentOrderPlanDetailDtos;

namespace BusinessLayer.Abstract
{
    public interface IShipmentOrderPlanDetailService : IGenericService<ShipmentOrderPlanDetailDto, CreateShipmentOrderPlanDetailDto, UpdateShipmentOrderPlanDetailDto>
    {
        public Task<List<ShipmentOrderPlanDetailDto>> GetByShipmentOrderPlanId(int shipmentOrderPlanId);
    }
}
