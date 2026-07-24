using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccsessLayer.Concrete.Repository
{
    public class WinderCoilLengthControlRepository : GenericRepository<DB_WinderCoilLengthControl>, IWinderCoilLengthControlRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public WinderCoilLengthControlRepository(AquaBusinessTrackingContext context, ILogger<GenericRepository<DB_WinderCoilLengthControl>> logger) : base(context, logger)
        {
            _context = context;

        }

        public async Task<List<DB_WinderCoilLengthControl>> GetWithDetails()
        {
            return await _context.Db_WinderCoilLengthControl
                .Include(x => x.Shift)
                .Include(x => x.AppUser)
                .ToListAsync();
        }
    }
}
