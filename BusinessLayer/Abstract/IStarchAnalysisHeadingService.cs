using DTOLayer.Dtos.StarchAnalysis.StarchAnalysisHeadingDtos;

namespace BusinessLayer.Abstract
{
    public interface IStarchAnalysisHeadingService : IGenericService<StarchAnalysisHeadingDto, CreateStarchAnalysisHeadingDto, UpdateStarchAnalysisHeadingDto>
    {
        public Task<List<StarchAnalysisHeadingDto>> GetWithDetails();
    }
}
