using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.LabWork;
using DTOLayer.Dtos.LabWorkDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class LabWorkManager : GenericManager<DB_LabWork, LabWorkDto, CreateLabWorkDto, UpdateLabWorkDto>, ILabWorkService
    {
        private readonly ILabWorkRepository _repo;
        public LabWorkManager(IUnitOfWork uow, IMapper mapper, ILabWorkRepository repo) : base(uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<LabWorkDto>> GetWithDetails()
        {
            var entities = await _repo.GetWithDetails();
            var dtos = _mapper.Map<List<LabWorkDto>>(entities);
            return dtos;
        }
    }
}
