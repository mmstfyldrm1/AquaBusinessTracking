using DTOLayer.Dtos.NaturelGasMeterMonitoringDtos;

namespace BusinessLayer.Abstract
{
    public interface INaturelGasMeterMonitoringService : IGenericService<NaturelGasMeterMonitoringDto, CreateNaturelGasMeterMonitoringDto, UpdateNaturelGasMeterMonitoringDto>
    {
        public Task<List<NaturelGasMeterMonitoringDto>> GetWithDetails();

        public Task<List<NaturelGasMeterMonitoringDto>> GetPreviousDay();
        public Task<List<NaturelGasMeterMonitoringDto>> GetLast30DaysNaturelGas();
    }
}
