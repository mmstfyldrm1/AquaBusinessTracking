using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface INaturelGasMeterMonitoringRepository : IGenericRepository<DB_NaturelGasMeterMonitoring>
    {
        public Task<List<DB_NaturelGasMeterMonitoring>> GetWithDetails();
    }
}
