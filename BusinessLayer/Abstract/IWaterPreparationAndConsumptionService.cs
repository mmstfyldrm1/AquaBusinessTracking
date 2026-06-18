using DTOLayer.Dtos.WaterPreparationAndConsumptionDtos;

namespace BusinessLayer.Abstract
{
    public interface IWaterPreparationAndConsumptionService : IGenericService<WaterPreparationAndConsumptionDto, CreateWaterPreparationAndConsumptionDto, UpdateWaterPreparationAndConsumptionDto>
    {
        public Task<List<WaterPreparationAndConsumptionDto>> GetWithDetails();

        public Task<List<WaterPreparationAndConsumptionDto>> GetPreviousDay();
    }
}
