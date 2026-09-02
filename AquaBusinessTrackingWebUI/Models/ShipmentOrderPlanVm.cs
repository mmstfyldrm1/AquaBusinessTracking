using DTOLayer.Dtos.ShipmentOrderPlan;
using DTOLayer.Dtos.ShipmentOrderPlanDtos.ShipmentOrderPlanDetailDtos;

namespace AquaBusinessTrackingWebUI.Models
{
    public class ShipmentOrderPlanVm
    {
        public ShipmentOrderPlanDto Plan { get; set; } = new ShipmentOrderPlanDto();
        public List<ShipmentOrderPlanDetailDto> Details { get; set; } = new List<ShipmentOrderPlanDetailDto>();

        public List<int> DeletedDetailIds { get; set; } = new List<int>();


    }
}
