using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccsessLayer.Concrete.Repository
{
    public class WastePaperCostRepository : GenericRepository<DB_WastePaperCost>, IWastePaperCostRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public WastePaperCostRepository(AquaBusinessTrackingContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<DB_WastePaperCost>> GetWithDetails()
        {
            return await _context.Db_WastePaperCost
                .Include(x => x.Shift)
                .Include(x => x.AppUser)
                .ToListAsync();
        }
    }
}
