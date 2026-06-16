using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccsessLayer.Concrete.Repository
{
    public class BasinRepository : GenericRepository<DB_Basin>, IBasinRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public BasinRepository(AquaBusinessTrackingContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<DB_Basin>> GetBasinsWithDetails()
        {
            return await _context.Db_Basin
            .Include(x => x.Shift)
            .Include(x => x.AppUser)
            .ToListAsync();
        }
    }
}
