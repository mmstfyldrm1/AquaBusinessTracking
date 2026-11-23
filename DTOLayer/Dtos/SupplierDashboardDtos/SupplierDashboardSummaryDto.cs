namespace DTOLayer.Dtos.SupplierDashboardDtos
{
    public class SupplierDashboardSummaryDto
    {
        public decimal TotalQuantity { get; set; }
        public decimal NetQuantity { get; set; }
        public decimal ApprovedQuantity { get; set; }
        public decimal RejectedQuantity { get; set; }
        public decimal ReturnedQuantity { get; set; }
        public decimal TotalDeduction { get; set; }
        public decimal DeductionRate { get; set; }
    }
}
