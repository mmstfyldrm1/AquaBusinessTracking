using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccsessLayer.Concrete.Repository
{
    public class MassWasteBalanceRepository : GenericRepository<DB_MassWasteBalance>, IMassWasteBalanceRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public MassWasteBalanceRepository(AquaBusinessTrackingContext context, ILogger<GenericRepository<DB_MassWasteBalance>> logger) : base(context, logger)
        {
            _context = context;
        }

        public async Task<List<DB_MassWasteBalance>> GetWithDetails()
        {
            return await _context.Db_MassWasteBalance
                 .Include(x => x.Shift)
                 .Include(x => x.AppUser)
                 .ToListAsync();
        }
    }
}
