using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.ElectricDtos.CumulativeElectricityConsumptionDtos;
using DTOLayer.Dtos.ElectricDtos.ElectricMeterLocationDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class CumulativeElectricityConsumptionManager : GenericManager<DB_CumulativeElectricityConsumption, CumulativeElectricityConsumptionDto, CreateCumulativeElectricityConsumptionDto, UpdateCumulativeElectricityConsumptionDto>, ICumulativeElectricityConsumptionService
    {
        private readonly ICumulativeElectricityConsumptionRepository _repo;
        public CumulativeElectricityConsumptionManager(IUnitOfWork uow, IMapper mapper, ICumulativeElectricityConsumptionRepository repo) : base(uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<ElectricMeterLocationDto>> GetLocationName()
        {
            var data = await _repo.GetLocationName();
            return _mapper.Map<List<ElectricMeterLocationDto>>(data);
        }

        public async Task<List<CumulativeElectricityConsumptionDto>> GetWithDetails()
        {
            var data = await _repo.GetWithDetails();
            return _mapper.Map<List<CumulativeElectricityConsumptionDto>>(data);
        }
    }
}
