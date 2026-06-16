using DTOLayer.Dtos.OilAnalysisReportDtos;

namespace BusinessLayer.Abstract
{
    public interface IOilAnalysisReportService : IGenericService<OilAnalysisReportDto, CreateOilAnalysisReportDto, UpdateOilAnalysisReportDto>
    {
        public Task<List<OilAnalysisReportDto>> GetWithDetails();
    }
}
