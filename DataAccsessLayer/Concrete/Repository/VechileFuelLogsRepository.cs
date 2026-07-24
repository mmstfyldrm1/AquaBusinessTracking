using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccsessLayer.Concrete.Repository
{
    public class VechileFuelLogsRepository : GenericRepository<DB_VechileFuelLogs>, IVechileFuelLogsRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public VechileFuelLogsRepository(AquaBusinessTrackingContext context, ILogger<GenericRepository<DB_VechileFuelLogs>> logger) : base(context, logger)
        {
            _context = context;
        }

        public async Task<List<DB_VechileFuelLogs>> GetWithDetails()
        {
            return await _context.Db_VechileFuelLogs
                .Include(x => x.Department)
                .Include(x => x.AppUser)
                .ToListAsync();
        }
    }
}
