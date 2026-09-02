using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.KazanEnergyConsumptionDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class KazanEnergyConsumptionManager : GenericManager<DB_KazanEnergyConsumption, KazanEnergyConsumptionDto, CreateKazanEnergyConsumptionDto, UpdateKazanEnergyConsumptionDto>, IKazanEnergyConsumptionService
    {
        private readonly IKazanEnergyConsumptionRepository _repo;
        public KazanEnergyConsumptionManager(IUnitOfWork uow, IMapper mapper, IKazanEnergyConsumptionRepository repo) : base(uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<KazanEnergyConsumptionDto>> GetWithDetails()
        {
            var entities = await _repo.GetWithDetails();
            return _mapper.Map<List<KazanEnergyConsumptionDto>>(entities);
        }
    }
}
