using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccsessLayer.Concrete.Repository
{
    public class BufferProductionRepository : GenericRepository<DB_BufferProduction>, IBufferProductionRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public BufferProductionRepository(AquaBusinessTrackingContext context, ILogger<GenericRepository<DB_BufferProduction>> logger) : base(context, logger)
        {
            _context = context;
        }

        public async Task<List<DB_BufferProduction>> GetWithDetails()
        {
            return await _context.Db_BufferProduction
                .Include(x => x.Shift)
                .Include(x => x.AppUser)
                .Include(x => x.ShiftSupervisorUser)
                .ToListAsync();
        }
    }
}
