namespace DTOLayer.Dtos.SupplierDashboardDtos
{
    public class SupplierDashboardMaterialDistributionDto
    {
        public string SupplierName { get; set; }

        public string InventoryCode { get; set; }

        public string InventoryName { get; set; }

        public decimal TotalQuantity { get; set; }

        public decimal NetQuantity { get; set; }

        public decimal ApprovedQuantity { get; set; }

        public decimal RejectedQuantity { get; set; }

        public decimal Percentage { get; set; }
    }
}
