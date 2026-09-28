using DTOLayer.Dtos.AdminDashboardDtos;
using DTOLayer.Dtos.SentezProductionDtos;

namespace AquaBusinessTrackingWebUI.Models
{
    public class AdminDashboardSummaryViewModel
    {
        public SentezIntegrationsResponsoDto<AdminDashboardSales> GetLast7Sales { get; set; }

        public SentezIntegrationsResponsoDto<AdminDahboardDaysStock> GetLast7RawMateriels { get; set; }
        public SentezIntegrationsResponsoDto<AdminDahboardDaysStock> GetLast7Days { get; set; }
    }
}
