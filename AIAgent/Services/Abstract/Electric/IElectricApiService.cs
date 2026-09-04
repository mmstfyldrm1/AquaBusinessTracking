using DTOLayer.Dtos.ElectricDtos.CumulativeElectricityConsumptionDtos;

namespace AIAgent.Services.Abstract.Electric
{
    public interface IElectricApiService
    {
        Task<List<CumulativeElectricityConsumptionDto>> GetWithBySearch(DateTime StartDate, DateTime EndDate);
    }
}
