using DTOLayer.Dtos.Integrations;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract.Integrations
{
    public interface IPlcService
    {
        Task<List<PlcReadingDto>> GetLastReadingsAsync(int machineId, int count = 50);
        public Task<List<PlcReadingDto>> GetMachineAndTagsByDate(int machineId, DateTime startDate, DateTime endDate);

        Task<List<DB_PlcMachine>> GetActiveMachinesAsync();
    }
}
