using DTOLayer.Dtos.SentezProductionDtos;
using DTOLayer.Dtos.SupplierDashboardDtos;

namespace BusinessLayer.Abstract
{
    public interface ISentezSupplierQueryService
    {
        public Task<SentezIntegrationsResponsoDto<SupplierDashboardSummaryDto>> GetSupplierDashboardSummary(DateTime startDate, DateTime endDate);

        public Task<SentezIntegrationsResponsoDto<SupplierDashboardBySupplierDto>> GetSupplierDashboardBySupplier(DateTime startDate, DateTime endDate);

        public Task<SentezIntegrationsResponsoDto<SupplierDashboardByDateDto>> GetSupplierDashboardByDate(DateTime startDate, DateTime endDate);

        public Task<SentezIntegrationsResponsoDto<SupplierDashboardQualityDto>> GetSupplierQuality(DateTime startDate, DateTime endDate);

        public Task<SentezIntegrationsResponsoDto<SupplierDashboardMaterialDistributionDto>> GetSupplierMaterialDistribution(DateTime startDate, DateTime endDate);

        public Task<SentezIntegrationsResponsoDto<SupplierDashboardTrendDto>> GetSupplierTrend(DateTime startDate, DateTime endDate);


    }
}
