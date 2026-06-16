using DTOLayer.Dtos.LogisticsTrackingReportDtos;

namespace BusinessLayer.Abstract
{
    public interface ILogisticsTrackingReportService : IGenericService<LogisticsTrackingReportDto, CreateLogisticsTrackingReportDto, UpdateLogisticsTrackingReportDto>
    {
        public Task<List<LogisticsTrackingReportDto>> GetWithDetails();
    }
}
