using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccsessLayer.Concrete.Repository
{
    public class TestHeadRepository : GenericRepository<DB_TestHeader>, ITestHeadRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public TestHeadRepository(AquaBusinessTrackingContext context) : base(context)
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
