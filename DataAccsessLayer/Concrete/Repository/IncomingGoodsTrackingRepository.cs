using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccsessLayer.Concrete.Repository
{
    public class IncomingGoodsTrackingRepository : GenericRepository<DB_IncomingGoodsTracking>, IIncomingGoodsTrackingRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public IncomingGoodsTrackingRepository(AquaBusinessTrackingContext context, ILogger<GenericRepository<DB_IncomingGoodsTracking>> logger) : base(context, logger)
        {
            _context = context;
        }

        public async Task<List<DB_IncomingGoodsTracking>> GetWithDetails()
        {
            return await _context.Db_IncomingGoodsTracking
                .Include(x => x.Shift)
                .Include(x => x.AppUser)
                .ToListAsync();
        }
    }
}
