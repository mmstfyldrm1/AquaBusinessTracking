using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.PurificationChemicalsConsumptionDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class PurificationChemicalsConsumptionManager : GenericManager<DB_PurificationChemicalsConsumption, PurificationChemicalsConsumptionDto, CreatePurificationChemicalsConsumptionDto, UpdatePurificationChemicalsConsumptionDto>, IPurificationChemicalsConsumptionService
    {
        private readonly IPurificationChemicalsConsumptionRepository _repo;
        public PurificationChemicalsConsumptionManager(IUnitOfWork uow, IMapper mapper, IPurificationChemicalsConsumptionRepository repo) : base(uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<PurificationChemicalsConsumptionDto>> GetWithDetails()
        {
            var entities = await _repo.GetWithDetails();
            var dtos = _mapper.Map<List<PurificationChemicalsConsumptionDto>>(entities);
            return dtos;
        }
    }
}
