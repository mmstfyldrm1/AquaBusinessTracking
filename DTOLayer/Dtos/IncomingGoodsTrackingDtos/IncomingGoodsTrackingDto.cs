namespace DTOLayer.Dtos.IncomingGoodsTrackingDtos
{
    public class IncomingGoodsTrackingDto
    {
        public int RecId { get; set; }

        public string WaybillNo { get; set; }

        public DateTime ReceiptDate { get; set; } = DateTime.Now;

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

        public int DepartmentId { get; set; }

        public DateTime? InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        public int AppUserId { get; set; }

        public int ShiftId { get; set; }

        public string ShiftName { get; set; }

        public string CreatedByName { get; set; }

        public Int16? InUse { get; set; }

        public int? DeletedBy { get; set; }

        public int? UpdatedBy { get; set; }
    }


}
