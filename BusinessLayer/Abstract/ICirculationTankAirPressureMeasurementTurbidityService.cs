using DTOLayer.Dtos.CirculationTankAirPressureMeasurementTurbidity;
using DTOLayer.Dtos.CirculationTankAirPressureMeasurementTurbidityDtos;

namespace BusinessLayer.Abstract
{
    public interface ICirculationTankAirPressureMeasurementTurbidityService : IGenericService<CirculationTankAirPressureMeasurementTurbidityDto, CreateCirculationTankAirPressureMeasurementTurbidityDto, UpdateCirculationTankAirPressureMeasurementTurbidityDto>
    {
        public Task<List<CirculationTankAirPressureMeasurementTurbidityDto>> GetWithDetails();
    }
}
