using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccsessLayer.Concrete.Repository
{
    public class ElectricMeterLocationRepository : GenericRepository<DB_ElectricMeterLocation>, IElectricMeterLocationRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public ElectricMeterLocationRepository(AquaBusinessTrackingContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<DB_ElectricMeterLocation>> GetWithDetails()
        {
            return await _context.Db_ElectricMeterLocation
            .Include(x => x.Shift)
            .Include(x => x.AppUser)
            .ToListAsync();
        }
    }
}
