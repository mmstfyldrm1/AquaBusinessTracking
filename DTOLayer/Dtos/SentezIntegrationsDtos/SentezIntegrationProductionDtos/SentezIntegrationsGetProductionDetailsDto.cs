namespace DTOLayer.Dtos.SentezIntegrationsDtos.SentezIntegrationProductionDtos
{
    public class SentezIntegrationsGetProductionDetailsDto
    {
        public decimal? RecId { get; set; }

        public decimal? ParentId { get; set; }
        public DateTime? ReceiptDate { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public string? SerialCode { get; set; }

        public decimal? Quantity { get; set; }

        public string? InventoryCode { get; set; }

        public string? InventoryName { get; set; }

        public decimal? WidthCM { get; set; }

        public string? CombinationNo { get; set; }

        public string? Explanation { get; set; }

        public string? EmployeeName { get; set; }

        public decimal? ResourceSpeed { get; set; }

        // public decimal? UD_Vardiya { get; set; }

        public string? WorkOrderNo { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public Int16? IsStrapping { get; set; }

        public Int16? IsWrapping { get; set; }

        public DateTime? StopperAt { get; set; }

        public DateTime? LabelAt { get; set; }

        public DateTime? WarehouseAt { get; set; }

        public decimal? ManufactureReceiptId { get; set; }

        public decimal? ConsumptionReceiptId { get; set; }
        public int? SetNumber { get; set; }

        public int? SetPosition { get; set; }
    }
}
