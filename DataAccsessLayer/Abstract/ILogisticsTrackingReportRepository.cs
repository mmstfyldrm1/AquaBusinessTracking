using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface ILogisticsTrackingReportRepository : IGenericRepository<DB_LogisticsTrackingReport>
    {
        public Task<List<DB_LogisticsTrackingReport>> GetWithDetails();
    }
}
