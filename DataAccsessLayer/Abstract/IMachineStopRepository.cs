using DTOLayer.Dtos.AdminDashboardDtos;
using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface IMachineStopRepository : IGenericRepository<DB_MachineStop>
    {
        public Task<List<DB_MachineStop>> GetWithDetails();

        public Task<List<StopChartDto>> GetStopChart();
    }
}
