using DataAccsessLayer.Abstract;
using DTOLayer.Dtos.ElectricDtos.CumulativeElectricityConsumptionDtos;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccsessLayer.Concrete.Repository
{
    public class CumulativeElectricityConsumptionRepository : GenericRepository<DB_CumulativeElectricityConsumption>, ICumulativeElectricityConsumptionRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public CumulativeElectricityConsumptionRepository(AquaBusinessTrackingContext context, ILogger<GenericRepository<DB_CumulativeElectricityConsumption>> logger) : base(context, logger)
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
                .Where(x => x.ReceiptDate >= startdate && x.ReceiptDate < endDate)
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

        public async Task<List<CumulativeElectricityConsumptionDto>> GetLast30DaysElectricConsumable()
        {
            DateTime startDate = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            DateTime endDate = DateTime.Today;
            var data = await _context.Db_CumulativeElectricityConsumption
                .AsNoTracking()
                .Include(x => x.ElectricMeterLocation)
                .Where(x => x.ReceiptDate >= startDate && x.ReceiptDate < endDate)
                .GroupBy(x => new
                {
                    Date = x.ReceiptDate!.Value.Date,
                    LocationName = x.ElectricMeterLocation != null
                        ? x.ElectricMeterLocation.LocationName
                        : "Bilinmeyen"
                })
                .Select(g => new CumulativeElectricityConsumptionDto
                {
                    ReceiptDate = g.Key.Date,
                    LocationName = g.Key.LocationName,
                    Consumption = g.Sum(x => x.Consumption)
                })
                .ToListAsync();
            return data;
        }

    }
}
