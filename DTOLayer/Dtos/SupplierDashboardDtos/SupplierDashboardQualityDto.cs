namespace DTOLayer.Dtos.SupplierDashboardDtos
{
    public class SupplierDashboardQualityDto
    {
        public string SupplierName { get; set; }

        public decimal AverageMoisture { get; set; }

        public decimal AverageForeignMaterial { get; set; }

        public decimal TotalDeduction { get; set; }

        public decimal DeductionRate { get; set; }

        public decimal ApprovedQuantity { get; set; }

        public decimal RejectedQuantity { get; set; }

        public decimal RejectionRate { get; set; }
    }
}
