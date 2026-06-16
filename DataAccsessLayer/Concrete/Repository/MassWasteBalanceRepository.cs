using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccsessLayer.Concrete.Repository
{
    public class MassWasteBalanceRepository : GenericRepository<DB_MassWasteBalance>, IMassWasteBalanceRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public MassWasteBalanceRepository(AquaBusinessTrackingContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<DB_MassWasteBalance>> GetWithDetails()
        {
            return await _context.DB_MassWasteBalance
                 .Include(x => x.Shift)
                 .Include(x => x.AppUser)
                 .ToListAsync();
        }
    }
}
