using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.PlanningScorBoardViewDto;
using DTOLayer.Dtos.PlanningScorBoardViewDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class PlanningScorBoardViewManager : GenericManager<DB_PlanningScorBoardView, PlanningScorBoardViewDto, CreatePlanningScorBoardViewDto, UpdatePlanningScorBoardViewDto>, IPlanningScorBoardViewService
    {
        private readonly IPlanningScorBoardViewRepository _repo;
        public PlanningScorBoardViewManager(IUnitOfWork uow, IMapper mapper, IPlanningScorBoardViewRepository repo) : base(uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<PlanningScorBoardViewDto>> GetWithDetails()
        {
            var result = await _repo.GetWithDetails();
            var mappedList = _mapper.Map<List<PlanningScorBoardViewDto>>(result);
            return mappedList;
        }
    }
}
