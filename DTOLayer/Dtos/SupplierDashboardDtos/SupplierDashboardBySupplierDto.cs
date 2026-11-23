namespace DTOLayer.Dtos.SupplierDashboardDtos
{
    public class SupplierDashboardBySupplierDto
    {
        public string SupplierName { get; set; }

        public decimal TotalQuantity { get; set; }
        public decimal ApprovedQuantity { get; set; }
        public decimal RejectedQuantity { get; set; }

        public decimal TotalDeduction { get; set; }
        public decimal DeductionRate { get; set; }

        public decimal AverageMoisture { get; set; }
        public decimal AverageForeignMaterial { get; set; }
    }
}
