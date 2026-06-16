using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.CirculationTankAirPressureMeasurementTurbidity;
using DTOLayer.Dtos.CirculationTankAirPressureMeasurementTurbidityDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CirculationTankAirPressureMeasurementTurbidityManager : GenericManager<DB_CirculationTankAirPressureMeasurementTurbidity, CirculationTankAirPressureMeasurementTurbidityDto, CreateCirculationTankAirPressureMeasurementTurbidityDto, UpdateCirculationTankAirPressureMeasurementTurbidityDto>, ICirculationTankAirPressureMeasurementTurbidityService
    {
        private readonly ICirculationTankAirPressureMeasurementTurbidityRepository _repo;
        public CirculationTankAirPressureMeasurementTurbidityManager(IUnitOfWork uow, IMapper mapper, ICirculationTankAirPressureMeasurementTurbidityRepository repo) : base(uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<CirculationTankAirPressureMeasurementTurbidityDto>> GetWithDetails()
        {
            var entities = await _repo.GetWithDetails();
            return _mapper.Map<List<CirculationTankAirPressureMeasurementTurbidityDto>>(entities);
        }
    }
}
