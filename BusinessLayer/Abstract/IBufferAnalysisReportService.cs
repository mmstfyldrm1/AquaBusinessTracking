using DTOLayer.Dtos.BufferAnalysisReportDtos;

namespace BusinessLayer.Abstract
{
    public interface IBufferAnalysisReportService : IGenericService<BufferAnalysisReportDto, CreateBufferAnalysisReportDto, UpdateBufferAnalysisReportDto>
    {
        public Task<BufferAnalysisReportDto> GetWithDetails();
    }
}
