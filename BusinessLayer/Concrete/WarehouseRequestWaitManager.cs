using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.WarehouseRequestWaitDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class WarehouseRequestWaitManager : GenericManager<DB_WarehouseRequestWait, WarehouseRequestWaitDto, CreateWarehouseRequestWaitDto, UpdateWarehouseRequestWaitDto>, IWarehouseRequestWaitService
    {
        private readonly IWarehouseRequestWaitRepository _repo;
        public WarehouseRequestWaitManager(IUnitOfWork uow, IMapper mapper, IWarehouseRequestWaitRepository repo) : base(uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<WarehouseRequestWaitDto>> GetWithDetails()
        {
            var entities = await _repo.GetWithDetails();
            var dtos = _mapper.Map<List<WarehouseRequestWaitDto>>(entities);
            return dtos;
        }
    }
}
