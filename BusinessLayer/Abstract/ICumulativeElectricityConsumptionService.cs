using DTOLayer.Dtos.ElectricDtos.CumulativeElectricityConsumptionDtos;
using DTOLayer.Dtos.ElectricDtos.ElectricMeterLocationDtos;

namespace BusinessLayer.Abstract
{
    public interface ICumulativeElectricityConsumptionService : IGenericService<CumulativeElectricityConsumptionDto, CreateCumulativeElectricityConsumptionDto, UpdateCumulativeElectricityConsumptionDto>
    {
        public Task<List<CumulativeElectricityConsumptionDto>> GetWithDetails();

        public Task<List<CumulativeElectricityConsumptionDto>> GetPreviousDay();


        public Task<List<ElectricMeterLocationDto>> GetLocationName();

        public Task<List<CumulativeElectricityConsumptionDto>> GetLast7Days();
    }
}
