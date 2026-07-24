using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccsessLayer.Concrete.Repository
{
    public class ElectricShiftWorkRepository : GenericRepository<DB_ElectricShiftWork>, IElectricShiftWorkRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public ElectricShiftWorkRepository(AquaBusinessTrackingContext context, ILogger<GenericRepository<DB_ElectricShiftWork>> logger) : base(context, logger)
        {
            _context = context;
        }

        public async Task<List<DB_ElectricShiftWork>> GetWithDetails()
        {
            return await _context.Db_ElectricShiftWork
            .Include(x => x.Shift)
            .Include(x => x.AppUser)
            .ToListAsync();
        }
    }
}
