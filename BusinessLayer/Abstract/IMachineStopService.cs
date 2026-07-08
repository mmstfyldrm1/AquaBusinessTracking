using DTOLayer.Dtos.AdminDashboardDtos;
using DTOLayer.Dtos.MachineStopDtos;

namespace BusinessLayer.Abstract
{
    public interface IMachineStopService : IGenericService<MachineStopDto, CreateMachineStopDto, UpdateMachineStopDto>
    {
        public Task<List<MachineStopDto>> GetWithDetails();

        public Task<List<StopChartDto>> GetStopChart();
    }
}
