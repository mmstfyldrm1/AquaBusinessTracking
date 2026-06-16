using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface ICirculationTankAirPressureMeasurementTurbidityRepository : IGenericRepository<DB_CirculationTankAirPressureMeasurementTurbidity>
    {
        public Task<List<DB_CirculationTankAirPressureMeasurementTurbidity>> GetWithDetails();
    }
}
