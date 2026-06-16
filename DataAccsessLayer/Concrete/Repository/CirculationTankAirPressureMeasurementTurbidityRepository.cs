using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccsessLayer.Concrete.Repository
{
    public class CirculationTankAirPressureMeasurementTurbidityRepository : GenericRepository<DB_CirculationTankAirPressureMeasurementTurbidity>, ICirculationTankAirPressureMeasurementTurbidityRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public CirculationTankAirPressureMeasurementTurbidityRepository(AquaBusinessTrackingContext context) : base(context)
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
