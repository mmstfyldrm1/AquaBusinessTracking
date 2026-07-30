using DTOLayer.Dtos.AdminDashboardDtos;
using DTOLayer.Dtos.SentezProductionDtos;

namespace AquaBusinessTrackingWebUI.Models
{
    public class AdminDashboardSummaryViewModel
    {
        public SentezIntegrationsResponsoDto<AdminDahboardLast7DaysStock> GetLast7Sales { get; set; }

        public SentezIntegrationsResponsoDto<AdminDahboardLast7DaysStock> GetLast7RawMateriels { get; set; }

        public SentezIntegrationsResponsoDto<AdminDahboardLast7DaysStock> GetLast7Days { get; set; }
    }
}
