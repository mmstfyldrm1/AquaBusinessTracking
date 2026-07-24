using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.Extensions.Logging;

namespace DataAccsessLayer.Concrete.Repository
{
    public class RetentionAnalysisDetailRepository : GenericRepository<DB_RetantionAnalysisDetail>, IRetentionAnalysisDetailRepository
    {
        public RetentionAnalysisDetailRepository(AquaBusinessTrackingContext context, ILogger<GenericRepository<DB_RetantionAnalysisDetail>> logger) : base(context, logger)
        {
        }
    }
}
