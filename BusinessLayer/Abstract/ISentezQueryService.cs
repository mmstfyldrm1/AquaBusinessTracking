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

        Task<SentezIntegrationsResponsoDto<AdminDahboardLast7DaysStock>?> GetLas30DaysProductionAsync();

        Task<SentezIntegrationsResponsoDto<SentezProductionDto>?> GetRawMaterielsStockAsync();

        Task<SentezIntegrationsResponsoDto<SentezProductionDto>?> GetRawMaterielsPreviousDayStockAsync();
    }
}
