using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.RawMaterialIntakesDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class RawMaterialIntakeManager : GenericManager<DB_RawMaterialIntake, RawMaterialIntakesDto, CreateRawMaterialIntakesDto, UpdateRawMaterialIntakesDto>, IRawMaterialIntakeService
    {
        private readonly IRawMaterialIntakeRepository _repo;
        public RawMaterialIntakeManager(IUnitOfWork uow, IMapper mapper, IRawMaterialIntakeRepository repo) : base(uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<RawMaterialIntakesDto>> GetWithDetails()
        {
            var entities = await _repo.GetWithDetails();
            var dtos = _mapper.Map<List<RawMaterialIntakesDto>>(entities);
            return dtos;
        }

        public async Task<List<RawMaterialIntakesDto>> GetWithSearchDetails(DateTime StartDate, DateTime EndDate)
        {
            var entities = await _repo.GetWithSearchDetails(StartDate, EndDate);
            var dtos = _mapper.Map<List<RawMaterialIntakesDto>>(entities);
            return dtos;
        }
    }
}
