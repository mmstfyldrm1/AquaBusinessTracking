using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccsessLayer.Concrete.Repository
{
    public class BufferGramajProfileRepository : GenericRepository<DB_BufferGramajProfile>, IBufferGramajProfileRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public BufferGramajProfileRepository(AquaBusinessTrackingContext context, ILogger<GenericRepository<DB_BufferGramajProfile>> logger) : base(context, logger)
        {
            _context = context;
        }

        public async Task<List<DB_BufferGramajProfile>> GetWithDetails()
        {
            return await _context.Db_BufferGramajProfile
            .Include(x => x.Shift)
            .Include(x => x.AppUser)
            .ToListAsync();
        }
    }
}
