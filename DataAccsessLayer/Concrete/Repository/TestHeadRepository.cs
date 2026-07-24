using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccsessLayer.Concrete.Repository
{
    public class TestHeadRepository : GenericRepository<DB_TestHeader>, ITestHeadRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public TestHeadRepository(AquaBusinessTrackingContext context, ILogger<GenericRepository<DB_TestHeader>> logger) : base(context, logger)
        {
            _context = context;
        }

        public async Task<List<DB_TestHeader>> GetWithDetails()
        {
            return await _context.Db_TestHeader
                .Include(x => x.Department)
                .Include(x => x.AppUser)
                .Include(x => x.Shift)
                .ToListAsync();
        }
    }
}
