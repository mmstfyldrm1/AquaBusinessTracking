using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccsessLayer.Concrete.Repository
{
    public class SalesScaleRepository : GenericRepository<DB_SalesScale>, ISalesScaleRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public SalesScaleRepository(AquaBusinessTrackingContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<DB_SalesScale>> GetWithDetails()
        {
            return await _context.Db_SalesScale
                .Include(x => x.Shift)
                .Include(x => x.AppUser)
                .ToListAsync();
        }
    }
}
