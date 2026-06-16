using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.DoughPreparationDtos.DoughPreparationHeadDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class DoughPreparationHeadManager : GenericManager<DB_DoughPreparation, DoughPreparationDto, CreateDoughPreparationDto, UpdateDoughPreparationDto>, IDoughPreparationHeadService
    {
        private readonly IDoughPreparationHeadRepository _repo;
        public DoughPreparationHeadManager(IUnitOfWork uow, IMapper mapper, IDoughPreparationHeadRepository repo) : base(uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<DoughPreparationDto>> GetWithDetails()
        {
            var entities = await _repo.GetWithDetails();
            var dtos = _mapper.Map<List<DoughPreparationDto>>(entities);
            return dtos;
        }
    }
}
