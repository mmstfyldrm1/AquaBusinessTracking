using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.SentezNotOrdersDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class SentezNotOrdersManager : GenericManager<DB_SentezNotOrder, SentezNotOrderDto, CreateSentezNotOrdersDto, UpdateSentezNotOrdersDto>, ISentezNotOrdersService
    {
        private readonly ISentezNotOrdersRepository _repo;
        public SentezNotOrdersManager(IUnitOfWork uow, IMapper mapper, ISentezNotOrdersRepository repo) : base(uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<SentezNotOrderDto>> GetWithDetails()
        {
            var entities = await _repo.GetWithDetails();
            var dtos = _mapper.Map<List<SentezNotOrderDto>>(entities);
            return dtos;
        }
    }
}
