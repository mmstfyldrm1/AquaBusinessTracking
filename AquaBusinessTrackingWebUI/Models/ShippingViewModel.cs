using DTOLayer.Dtos.ChartDtos;
using DTOLayer.Dtos.SalesScale;

namespace AquaBusinessTrackingWebUI.Models
{
    public class ShippingViewModel
    {
        public decimal TotalShipment { get; set; }
        public decimal TotalSales { get; set; }
        public decimal TotalInvoice { get; set; }
        public decimal PendingShipment { get; set; }

        public List<SalesScaleDto> Last10 { get; set; }
        public List<ChartPointDto> Trend { get; set; }
    }
}
