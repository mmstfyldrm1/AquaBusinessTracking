using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccsessLayer.Concrete.Repository
{
    public class WinderCoilTrackingRepository : GenericRepository<DB_WinderCoilTracking>, IWinderCoilTrackingRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public WinderCoilTrackingRepository(AquaBusinessTrackingContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<DB_WinderCoilTracking>> GetWithDetails()
        {
            return await _context.Db_WinderCoilTracking
                .Include(x => x.Shift)
                .Include(x => x.AppUser)
                .ToListAsync();
        }
    }
}
