using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccsessLayer.Concrete.Repository
{
    public class PlcTagsRepository : GenericRepository<DB_PlcTags>, IPlcTagsRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public PlcTagsRepository(AquaBusinessTrackingContext context, ILogger<GenericRepository<DB_PlcTags>> logger) : base(context, logger)
        {
            _context = context;
        }

        public async Task<List<DB_PlcTags>> GetByMachineName()
        {
            return await _context.Db_PlcTags
                .Include(x => x.Machine)
                .AsNoTracking()
                .ToListAsync();


        }
    }
}
