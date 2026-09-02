namespace DTOLayer.Dtos.ShipmentOrderPlanDtos.ShipmentOrderPlanDetailDtos
{
    public class CreateShipmentOrderPlanDetailDto
    {

        public int ShipmentPlanId { get; set; }

        public string OrderNo { get; set; }

        public string PaperType { get; set; }

        public decimal Grammage { get; set; }

        public decimal Width { get; set; }

        public decimal Tonnage { get; set; }

        public bool Checklist { get; set; }

        public string? DeliveryNoteNo { get; set; }

        public bool Shipped { get; set; }
    }
}
