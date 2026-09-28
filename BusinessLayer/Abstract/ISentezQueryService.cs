using DTOLayer.Dtos.AdminDashboardDtos;
using DTOLayer.Dtos.SentezIntegrationsDtos;
using DTOLayer.Dtos.SentezProductionDtos;

namespace BusinessLayer.Abstract
{
    public interface ISentezQueryService
    {
        Task<SentezIntegrationsResponsoDto<SentezProductionDto>?> GetPreviousDayStockAsync();
        Task<SentezIntegrationsResponsoDto<SentezProductionDto>?> GetStockAsync();

        Task<SentezUpdateResponseDto?> InsertMachineRandoman(double workhours);

        Task<SentezIntegrationsResponsoDto<SentezSalesResponseDto>?> GetPreviousDaySalesAsync();
        Task<SentezIntegrationsResponsoDto<SentezSalesResponseDto>?> GetSalesAsync();

        Task<SentezIntegrationsResponsoDto<AdminDahboardDaysStock>?> GetLas7DaysProductionAsync(DateTime? startDate, DateTime? endDate);

        Task<SentezIntegrationsResponsoDto<AdminDashboardSales>?> GetLas7DaysSalesAsync(DateTime? startDate, DateTime? endDate);

        Task<SentezIntegrationsResponsoDto<AdminDahboardDaysStock>?> GetLas7DaysRawMaterilsAsync(DateTime? startDate, DateTime? endDate);
        Task<SentezIntegrationsResponsoDto<AdminDahboardDaysStock>?> GetLas30DaysProductionAsync();

        Task<SentezIntegrationsResponsoDto<SentezProductionDto>?> GetRawMaterielsStockAsync();

        Task<SentezIntegrationsResponsoDto<SentezProductionDto>?> GetRawMaterielsPreviousDayStockAsync();

        public Task<SentezIntegrationsResponsoDto<SentezSalesResponseDto>?> GetSalesGetbyDateAsync(DateTime startDate, DateTime endDate);

        public Task<SentezIntegrationsResponsoDto<SentezProductionDto>?> GetStockWithByDateRange(DateTime startDate, DateTime endDate);
        public Task<SentezIntegrationsResponsoDto<SentezIntegrationsGetStockByInventoryCode>?> GetStockByInventoryCode(string inventoryCode);

        public Task<SentezIntegrationsResponsoDto<SentezIntegrationsGetStockByInventoryCode>?> GetStockByInventoryCodeAndWidthCM(string inventoryCode, double WidthCM);

    }
}
