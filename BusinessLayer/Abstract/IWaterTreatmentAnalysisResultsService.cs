using DTOLayer.Dtos.WaterTreatmentAnalysisResultsDtos;

namespace BusinessLayer.Abstract
{
    public interface IWaterTreatmentAnalysisResultsService : IGenericService<WaterTreatmentAnalysisResultsDto, CreateWaterTreatmentAnalysisResultsDto, UpdateWaterTreatmentAnalysisResultsDto>
    {
        public Task<List<WaterTreatmentAnalysisResultsDto>> GetWithDetails();
    }
}
