namespace DTOLayer.Dtos.WarehouseRequestWaitDtos
{
    public class UpdateWarehouseRequestWaitDto
    {
        public int RecId { get; set; }
        public string WaybillNo { get; set; }
        public string WaybillInvoiceNo { get; set; }
        public string IncomingCurrentAccountName { get; set; }
        public string SentezInventoryCode { get; set; }
        public string SentezInventoryName { get; set; }
        public decimal Quanity { get; set; }
        public string Unit { get; set; }
        public string Explanation { get; set; }
        public string SentezInventoryGroup { get; set; }
        public int DepartmentId { get; set; }

        public TimeSpan WarehouseEntryDate { get; set; }
        public TimeSpan ReturnDate { get; set; }
        public string WaitingTime { get; set; }
        public DateTime? InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }


        public DateTime? DeleteDate { get; set; }

        public int AppUserId { get; set; }
        public int ShiftId { get; set; }
        public Int16? InUse { get; set; }

        public int? DeletedBy { get; set; }

        public int? UpdatedBy { get; set; }
    }
}
