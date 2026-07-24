using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccsessLayer.Concrete.Repository
{
    public class SentezNotOrdersRepository : GenericRepository<DB_SentezNotOrder>, ISentezNotOrdersRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public SentezNotOrdersRepository(AquaBusinessTrackingContext context, ILogger<GenericRepository<DB_SentezNotOrder>> logger) : base(context, logger)
        {
            _context = context;
        }

        public async Task<List<DB_SentezNotOrder>> GetWithDetails()
        {
            return await _context.Db_SentezNotOrder
                .Include(x => x.Department)
                .Include(x => x.AppUser)
                .ToListAsync();
        }
    }
}
