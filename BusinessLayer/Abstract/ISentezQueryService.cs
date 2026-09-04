using DTOLayer.Dtos.AdminDashboardDtos;
using DTOLayer.Dtos.SentezProductionDtos;

namespace BusinessLayer.Abstract
{
    public interface ISentezQueryService
    {
        Task<SentezIntegrationsResponsoDto<SentezProductionDto>?> GetPreviousDayStockAsync();
        Task<SentezIntegrationsResponsoDto<SentezProductionDto>?> GetStockAsync();

        Task<SentezUpdateResponseDto?> InsertMachineRandoman(double workhours);

        Task<SentezIntegrationsResponsoDto<SentezProductionDto>?> GetPreviousDaySalesAsync();
        Task<SentezIntegrationsResponsoDto<SentezProductionDto>?> GetSalesAsync();

        Task<SentezIntegrationsResponsoDto<AdminDahboardLast7DaysStock>?> GetLas7DaysProductionAsync();

        Task<SentezIntegrationsResponsoDto<AdminDahboardLast7DaysStock>?> GetLas7DaysSalesAsync();

        Task<SentezIntegrationsResponsoDto<AdminDahboardLast7DaysStock>?> GetLas7DaysRawMaterilsAsync();

        Task<SentezIntegrationsResponsoDto<AdminDahboardLast7DaysStock>?> GetLas30DaysProductionAsync();

        Task<SentezIntegrationsResponsoDto<SentezProductionDto>?> GetRawMaterielsStockAsync();

        Task<SentezIntegrationsResponsoDto<SentezProductionDto>?> GetRawMaterielsPreviousDayStockAsync();

        public Task<SentezIntegrationsResponsoDto<SentezProductionDto>?> GetSalesGetbyDateAsync(DateTime startDate, DateTime endDate);

        public Task<SentezIntegrationsResponsoDto<SentezProductionDto>?> GetStockWithByDateRange(DateTime startDate, DateTime endDate);
    }
}
