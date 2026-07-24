using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class DB_IncomingGoodsTracking : BaseEntity
    {

        [Key]
        public int RecId { get; set; }

        public string WaybillNo { get; set; }

        public TimeSpan ScaleHours { get; set; } = DateTime.Now.TimeOfDay;

        public string ReceiptNo { get; set; }

        public string CurrentAccountName { get; set; }

        public string InventoryName { get; set; }

        public string Plate { get; set; }

        public string Operator { get; set; }

        public string Unit { get; set; }

        public decimal? WaybillQuantity { get; set; }

        public decimal? FilledQuantity { get; set; }

        public decimal? EmptyQuantity { get; set; }

        public decimal? NetQuantity { get; set; }

        public string Description { get; set; }
    }
}
