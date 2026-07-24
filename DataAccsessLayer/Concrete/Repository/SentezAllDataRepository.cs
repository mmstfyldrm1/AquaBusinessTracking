using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccsessLayer.Concrete.Repository
{
    public class SentezAllDataRepository : GenericRepository<DB_SentezAllData>, ISentezAllDataRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public SentezAllDataRepository(AquaBusinessTrackingContext context, ILogger<GenericRepository<DB_SentezAllData>> logger) : base(context, logger)
        {
            _context = context;
        }

        public async Task<List<DB_SentezAllData>> GetWithDetails()
        {
            return await _context.Db_SentezAllData
                .Include(x => x.Department)
                .Include(x => x.AppUser)
                .ToListAsync();
        }
    }
}
