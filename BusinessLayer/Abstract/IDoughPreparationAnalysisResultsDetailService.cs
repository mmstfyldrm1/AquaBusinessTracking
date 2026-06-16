using DTOLayer.Dtos.DoughPreparationDtos.DoughPreparationDetailDtos;

namespace BusinessLayer.Abstract
{
    public interface IDoughPreparationAnalysisResultsDetailService : IGenericService<DoughPreparationAnalysisResultsDto, CreateDoughPreparationAnalysisResultsDto, UpdateDoughPreparationAnalysisResultsDto>
    {
        public Task<List<DoughPreparationAnalysisResultsDto>> GetWithDetails();
    }
}
