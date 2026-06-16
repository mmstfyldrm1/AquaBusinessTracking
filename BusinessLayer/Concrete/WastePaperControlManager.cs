using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.WastePaperControlDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class WastePaperControlManager : GenericManager<DB_WastePaperControl, WastePaperControlDto, CreateWastePaperControlDto, UpdateWastePaperControlDto>, IWastePaperControlService
    {
        private readonly IWastePaperControlRepository _repo;
        public WastePaperControlManager(IUnitOfWork uow, IMapper mapper, IWastePaperControlRepository repo) : base(uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<WastePaperControlDto>> GetPreviousDay()
        {
            var entities = await _repo.GetPreviousDay();
            var dtos = _mapper.Map<List<WastePaperControlDto>>(entities);
            return dtos;
        }

        public async Task<List<WastePaperControlDto>> GetWithDetails()
        {
            var entities = await _repo.GetWithDetails();
            var dtos = _mapper.Map<List<WastePaperControlDto>>(entities);
            return dtos;
        }
    }
}
