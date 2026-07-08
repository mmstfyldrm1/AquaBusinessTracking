using DTOLayer.Dtos.ChartDtos;
using DTOLayer.Dtos.SalesScale;
using DTOLayer.Dtos.SentezProductionDtos;

namespace AquaBusinessTrackingWebUI.Models
{
    public class AdminDashboardSalesShippingViewModel
    {
        public SentezIntegrationsResponsoDto<SentezProductionDto> PreviousDay { get; set; }
        public SentezIntegrationsResponsoDto<SentezProductionDto> Sales { get; set; }
        public decimal TotalShipment { get; set; }
        public decimal TotalSales { get; set; }
        public decimal TotalInvoice { get; set; }
        public decimal PendingShipment { get; set; }

        public List<SalesScaleDto> Last10 { get; set; }
        public List<ChartPointDto> Trend { get; set; }

        public decimal PreviousTotal { get; set; }

        public decimal AllTotal { get; set; }

    }
}
