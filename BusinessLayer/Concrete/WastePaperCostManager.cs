using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.WastePaperCost;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class WastePaperCostManager : GenericManager<DB_WastePaperCost, WastePaperCostDto, CreateWastePaperCostDto, UpdateWastePaperCostDto>, IWastePaperCostService
    {
        private readonly IWastePaperCostRepository _repo;
        public WastePaperCostManager(IUnitOfWork uow, IMapper mapper, IWastePaperCostRepository repo) : base(uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<WastePaperCostDto>> GetWithDetails()
        {
            var entities = await _repo.GetWithDetails();
            var dtos = _mapper.Map<List<WastePaperCostDto>>(entities);
            return dtos;
        }
    }
}
