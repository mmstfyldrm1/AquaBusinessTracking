using DTOLayer.Dtos.DailyShipmentPlanDtos;

namespace BusinessLayer.Abstract
{
    public interface IDailyShipmentPlanService : IGenericService<DailyShipmentPlanDto, CreateDailyShipmentPlanDto, UpdateDailyShipmentPlanDto>
    {
        public Task<List<DailyShipmentPlanDto>> GetWithDetails();

        public Task<List<DailyShipmentPlanDto>> GetActivePlan();

        public Task<bool> UpdateIsActiveStatus(int id);

        public Task<bool> UpdateIsStatus(int id);
    }
}
