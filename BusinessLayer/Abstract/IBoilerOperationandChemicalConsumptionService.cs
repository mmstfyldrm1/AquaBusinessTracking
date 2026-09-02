using DTOLayer.Dtos.BoilerOperationandChemicalConsumptionDtos;
using DTOLayer.Dtos.BoilerRoomDailyShiftMonitoringDtos;

namespace BusinessLayer.Abstract
{
    public interface IBoilerOperationandChemicalConsumptionService : IGenericService<BoilerOperationandChemicalConsumptionDto, CreateBoilerOperationandChemicalConsumptionDto, UpdateBoilerOperationandChemicalConsumptionDto>
    {
        public Task<List<BoilerOperationandChemicalConsumptionDto>> GetWithDetails();

        public Task<List<BoilerOperationandChemicalConsumptionDto>> GetWithSearchDetails(DateTime StartDate, DateTime EndDate);

        public Task<List<EnergyConsumptionStatusDto>> GetActiveShiftEnergyStatus();

    }
}
