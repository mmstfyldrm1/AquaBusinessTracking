using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;

namespace DataAccsessLayer.Concrete.Repository
{
    public class RetentionAnalysisDetailRepository : GenericRepository<DB_RetantionAnalysisDetail>, IRetentionAnalysisDetailRepository
    {
        public RetentionAnalysisDetailRepository(AquaBusinessTrackingContext context) : base(context)
        {
        }
    }
}
