using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccsessLayer.Concrete.Repository
{
    public class PlcTagsRepository : GenericRepository<DB_PlcTags>, IPlcTagsRepository
    {
        private AquaBusinessTrackingContext _context;
        public PlcTagsRepository(AquaBusinessTrackingContext context) : base(context)
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
