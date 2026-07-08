using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface IBoilerRoomDailyShiftMonitoringRepository : IGenericRepository<DB_BoilerRoomDailyShiftMonitoring>
    {
        public Task<List<DB_BoilerRoomDailyShiftMonitoring>> GetWithDetails();
    }
}
