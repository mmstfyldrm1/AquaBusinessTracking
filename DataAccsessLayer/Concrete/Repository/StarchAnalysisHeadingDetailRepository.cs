using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.Extensions.Logging;

namespace DataAccsessLayer.Concrete.Repository
{
    public class StarchAnalysisHeadingDetailRepository : GenericRepository<DB_StarchAnalysisHeadingDetail>, IStarchAnalysisHeadingDetailRepository
    {
        public StarchAnalysisHeadingDetailRepository(AquaBusinessTrackingContext context, ILogger<GenericRepository<DB_StarchAnalysisHeadingDetail>> logger) : base(context, logger)
        {
        }
    }
}
