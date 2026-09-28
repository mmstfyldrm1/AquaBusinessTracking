using DTOLayer.Dtos.Integrations;

namespace AIAgent.Services.Abstract.PlcMachine
{
    public interface IPlcMachineApiService
    {
        Task<List<PlcReadingDto>> GetReadingsAsync(int machineId, DateTime startTime, DateTime endTime);
    }
}
