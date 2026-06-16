using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.SentezAllDataDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class SentezAllDataManager : GenericManager<DB_SentezAllData, SentezAllDataDto, CreateSentezAllDataDto, UpdateSentezAllDataDto>, ISentezAllDataService
    {
        private readonly ISentezAllDataRepository _repo;
        public SentezAllDataManager(IUnitOfWork uow, IMapper mapper, ISentezAllDataRepository repo) : base(uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<SentezAllDataDto>> GetWithDetails()
        {
            var entities = await _repo.GetWithDetails();
            var dtos = _mapper.Map<List<SentezAllDataDto>>(entities);
            return dtos;
        }
    }
}
