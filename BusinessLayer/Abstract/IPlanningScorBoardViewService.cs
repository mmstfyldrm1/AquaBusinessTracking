using DTOLayer.Dtos.PlanningScorBoardViewDto;
using DTOLayer.Dtos.PlanningScorBoardViewDtos;

namespace BusinessLayer.Abstract
{
    public interface IPlanningScorBoardViewService : IGenericService<PlanningScorBoardViewDto, CreatePlanningScorBoardViewDto, UpdatePlanningScorBoardViewDto>
    {
        public Task<List<PlanningScorBoardViewDto>> GetWithDetails();
    }
}
