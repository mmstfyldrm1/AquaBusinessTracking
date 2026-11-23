using DTOLayer.Dtos.NaturelGasMeterMonitoringDtos;

namespace AIAgent.Services.Abstract.NaturelGas
{
    public interface INaturelGasApiService
    {
        Task<List<NaturelGasMeterMonitoringDto>> GetWithBySearch(DateTime StartDate, DateTime EndDate);
    }
}
