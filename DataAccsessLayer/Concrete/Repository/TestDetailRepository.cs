using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.Extensions.Logging;

namespace DataAccsessLayer.Concrete.Repository
{
    public class TestDetailRepository : GenericRepository<DB_TestDetail>, ITestDetailRepository
    {
        public TestDetailRepository(AquaBusinessTrackingContext context, ILogger<GenericRepository<DB_TestDetail>> logger) : base(context, logger)
        {
        }
    }
}
