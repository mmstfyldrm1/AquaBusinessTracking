using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccsessLayer.Concrete.Repository
{
    public class WastePaperControlRepository : GenericRepository<DB_WastePaperControl>, IWastePaperControlRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public WastePaperControlRepository(AquaBusinessTrackingContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<DB_WastePaperControl>> GetPreviousDay()
        {
            var start = DateTime.Today.AddDays(-1);
            var end = DateTime.Today;

            return await _context.Db_WastePaperControl
                .Include(x => x.Shift)
                .Include(x => x.AppUser)
                .Where(x => x.ReceiptDate >= start && x.ReceiptDate < end)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<DB_WastePaperControl>> GetWithDetails()
        {
            return await _context.Db_WastePaperControl
                .Include(x => x.Shift)
                .Include(x => x.AppUser)
                .ToListAsync();
        }
    }
}
