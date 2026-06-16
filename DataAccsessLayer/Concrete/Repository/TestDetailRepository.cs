using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;

namespace DataAccsessLayer.Concrete.Repository
{
    public class TestDetailRepository : GenericRepository<DB_TestDetail>, ITestDetailRepository
    {
        public TestDetailRepository(AquaBusinessTrackingContext context) : base(context)
        {
        }
    }
}
