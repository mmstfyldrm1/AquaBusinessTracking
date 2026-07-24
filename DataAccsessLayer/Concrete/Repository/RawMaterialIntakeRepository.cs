using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccsessLayer.Concrete.Repository
{
    public class RawMaterialIntakeRepository : GenericRepository<DB_RawMaterialIntake>, IRawMaterialIntakeRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public RawMaterialIntakeRepository(AquaBusinessTrackingContext context, ILogger<GenericRepository<DB_RawMaterialIntake>> logger) : base(context, logger)
        {
            _context = context;
        }

        public async Task<List<DB_RawMaterialIntake>> GetWithDetails()
        {
            return await _context.Db_RawMaterialIntake
               .Include(x => x.Shift)
               .Include(x => x.AppUser)
               .ToListAsync();
        }
    }
}
