using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.ElectricDtos.ElectricMeterLocationDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class ElectricMeterLocationManager : GenericManager<DB_ElectricMeterLocation, ElectricMeterLocationDto, CreateElectricMeterLocationDto, UpdateElectricMeterLocationDto>, IElectricMeterLocationService
    {
        private readonly IElectricMeterLocationRepository _repo;
        public ElectricMeterLocationManager(IUnitOfWork uow, IMapper mapper, IElectricMeterLocationRepository repo) : base(uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<ElectricMeterLocationDto>> GetWithDetails()
        {
            var data = await _repo.GetWithDetails();
            return _mapper.Map<List<ElectricMeterLocationDto>>(data);
        }
    }
}
