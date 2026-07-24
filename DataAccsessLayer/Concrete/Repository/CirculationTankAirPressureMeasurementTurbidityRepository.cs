using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccsessLayer.Concrete.Repository
{
    public class CirculationTankAirPressureMeasurementTurbidityRepository : GenericRepository<DB_CirculationTankAirPressureMeasurementTurbidity>, ICirculationTankAirPressureMeasurementTurbidityRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public CirculationTankAirPressureMeasurementTurbidityRepository(AquaBusinessTrackingContext context, ILogger<GenericRepository<DB_CirculationTankAirPressureMeasurementTurbidity>> logger) : base(context, logger)
        {
            _context = context;
        }

        public async Task<List<DB_CirculationTankAirPressureMeasurementTurbidity>> GetWithDetails()
        {
            return await _context.Db_CirculationTankAirPressureMeasurementTurbidity
            .Include(x => x.Shift)
            .Include(x => x.AppUser)
            .ToListAsync();
        }
    }
}
