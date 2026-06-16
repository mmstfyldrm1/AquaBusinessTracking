using DTOLayer.Dtos.Integrations;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract.Integrations
{
    public interface IPlcService
    {
        Task<List<PlcReadingDto>> GetLastReadingsAsync(int machineId, int count = 50);
        Task<List<DB_PlcMachine>> GetActiveMachinesAsync();
    }
}
