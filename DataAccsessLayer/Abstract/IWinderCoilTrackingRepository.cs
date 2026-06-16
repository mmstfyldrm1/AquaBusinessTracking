using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface IWinderCoilTrackingRepository : IGenericRepository<DB_WinderCoilTracking>
    {
        public Task<List<DB_WinderCoilTracking>> GetWithDetails();
    }
}
