using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccsessLayer.Concrete.Repository
{
    public class MassWasteSupplierRepository : GenericRepository<DB_MassWasteSupplier>, IMassWasteSupplierRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public MassWasteSupplierRepository(AquaBusinessTrackingContext context, ILogger<GenericRepository<DB_MassWasteSupplier>> logger) : base(context, logger)
        {
            _context = context;
        }

        public async Task<List<DB_MassWasteSupplier>> GetWithDetails()
        {
            return await _context.Db_MassWasteSupplier
             .Include(x => x.Shift)
             .Include(x => x.AppUser)
             .ToListAsync();
        }
    }
}
