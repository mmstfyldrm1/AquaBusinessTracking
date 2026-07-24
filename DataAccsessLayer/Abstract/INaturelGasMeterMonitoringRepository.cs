using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface INaturelGasMeterMonitoringRepository : IGenericRepository<DB_NaturelGasMeterMonitoring>
    {
        public Task<List<DB_NaturelGasMeterMonitoring>> GetWithDetails();

        public Task<List<DB_NaturelGasMeterMonitoring>> GetPreviousDay();

        public Task<List<DB_NaturelGasMeterMonitoring>> GetLast30DaysNaturelGas();
    }
}
