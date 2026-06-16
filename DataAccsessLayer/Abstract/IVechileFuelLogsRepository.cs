using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface IVechileFuelLogsRepository : IGenericRepository<DB_VechileFuelLogs>
    {
        public Task<List<DB_VechileFuelLogs>> GetWithDetails();
    }
}
