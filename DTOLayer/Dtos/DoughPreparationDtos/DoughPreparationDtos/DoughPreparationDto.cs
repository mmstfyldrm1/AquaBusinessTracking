namespace DTOLayer.Dtos.DoughPreparationDtos.DoughPreparationHeadDtos
{
    public class DoughPreparationDto
    {
        public int RecId { get; set; }


        public DateTime ReceiptDate { get; set; } = DateTime.Now;

        public string PulperNo { get; set; }

        public string InventoryCode { get; set; }

        public string InventoryName { get; set; }

        public decimal QueueNo { get; set; }

        public decimal Clippings { get; set; }

        public decimal Bale { get; set; }

        public decimal KG { get; set; }

        public DateTime? InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }


        public DateTime? DeleteDate { get; set; }

        public int DepartmentId { get; set; }
        public int AppUserId { get; set; }

        public int ShiftId { get; set; }
        public Int16? InUse { get; set; }

        public string CreatedByName { get; set; }
        public string ShiftName { get; set; }

        public int? DeletedBy { get; set; }

        public int? UpdatedBy { get; set; }
    }
}
