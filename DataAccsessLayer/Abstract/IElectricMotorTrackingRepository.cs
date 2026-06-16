using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface IElectricMotorTrackingRepository : IGenericRepository<DB_ElectricMotorTracking>
    {
        public Task<List<DB_ElectricMotorTracking>> GetWithDetails();
    }
}
