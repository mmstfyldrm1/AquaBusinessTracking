using DTOLayer.Dtos.RetentionAnalysis.RetentionAnalysisHeadDtos;

namespace BusinessLayer.Abstract
{
    public interface IRetentionAnalysisHeadService : IGenericService<RetentionAnalysisHeadDto, CreateRetentionAnalysisHeadDto, UpdateRetentionAnalysisHeadDto>
    {
        public Task<List<RetentionAnalysisHeadDto>> GetWithDetails();
    }
}
