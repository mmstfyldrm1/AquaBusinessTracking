using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract.Integrations
{
    internal interface IMachineRepository : IGenericRepository<DB_PlcMachine>
    {
        Task<DB_PlcMachine?> GetWithTagsAsync(int machineId);
        Task<IEnumerable<DB_PlcMachine>> GetAllActiveAsync();
    }
}
