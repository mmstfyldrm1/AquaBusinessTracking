using DTOLayer.Dtos.AdminDashboardDtos;
using DTOLayer.Dtos.SentezProductionDtos;

namespace AquaBusinessTrackingWebUI.Models
{
    public class AdminDashboardSummaryViewModel
    {
        public List<StopChartDto> DurusDagilim { get; set; }

        public SentezIntegrationsResponsoDto<AdminDahboardLast7DaysStock> GetLast7Days { get; set; }
    }
}
