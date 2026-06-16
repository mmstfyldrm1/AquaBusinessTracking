using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;

namespace DataAccsessLayer.Concrete.Repository
{
    public class StarchAnalysisHeadingDetailRepository : GenericRepository<DB_StarchAnalysisHeadingDetail>, IStarchAnalysisHeadingDetailRepository
    {
        public StarchAnalysisHeadingDetailRepository(AquaBusinessTrackingContext context) : base(context)
        {
        }
    }
}
