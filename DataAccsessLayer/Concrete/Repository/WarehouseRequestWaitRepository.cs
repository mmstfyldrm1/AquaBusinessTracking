using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccsessLayer.Concrete.Repository
{
    public class WarehouseRequestWaitRepository : GenericRepository<DB_WarehouseRequestWait>, IWarehouseRequestWaitRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public WarehouseRequestWaitRepository(AquaBusinessTrackingContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<DB_WarehouseRequestWait>> GetWithDetails()
        {
            return await _context.Db_WarehouseRequestWait
                 .Include(x => x.Shift)
                 .Include(x => x.AppUser)
                 .ToListAsync();
        }
    }
}
