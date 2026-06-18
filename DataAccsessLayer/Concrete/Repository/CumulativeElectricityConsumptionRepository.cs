using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccsessLayer.Concrete.Repository
{
    public class CumulativeElectricityConsumptionRepository : GenericRepository<DB_CumulativeElectricityConsumption>, ICumulativeElectricityConsumptionRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public CumulativeElectricityConsumptionRepository(AquaBusinessTrackingContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<DB_ElectricMeterLocation>> GetLocationName()
        {
            return await _context.Db_ElectricMeterLocation
               .AsNoTracking()
                .ToListAsync();
        }

        public async Task<List<DB_CumulativeElectricityConsumption>> GetPreviousDay()
        {
            DateTime startdate = DateTime.Today.AddDays(-1);
            DateTime endDate = DateTime.Today;


            return await _context.Db_CumulativeElectricityConsumption
                .Include(x => x.Shift)
                .Include(x => x.AppUser)
                .Include(x => x.ElectricMeterLocation)
                .Where(x => x.InsertedDate > startdate && x.InsertedDate < endDate)
                .ToListAsync();
        }

        public async Task<List<DB_CumulativeElectricityConsumption>> GetWithDetails()
        {
            return await _context.Db_CumulativeElectricityConsumption
                 .Include(x => x.Shift)
                 .Include(x => x.AppUser)
                 .Include(x => x.ElectricMeterLocation)
                .AsNoTracking()
                 .ToListAsync();
        }

    }
}
