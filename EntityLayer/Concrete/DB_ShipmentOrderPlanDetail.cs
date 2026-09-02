using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class DB_ShipmentOrderPlanDetail
    {
        [Key]
        public int RecId { get; set; }

        public int ShipmentPlanId { get; set; }

        public string OrderNo { get; set; }

        public string PaperType { get; set; }

        public decimal Grammage { get; set; }

        public decimal Width { get; set; }

        public decimal Tonnage { get; set; }

        public bool Checklist { get; set; }

        public string? DeliveryNoteNo { get; set; }

        public bool Shipped { get; set; }

        public DB_ShipmentOrderPlan ShipmentOrderPlan { get; set; }
    }
}
