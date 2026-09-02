namespace DTOLayer.Dtos.ShipmentOrderPlan
{
    public class CreateShipmentOrderPlanDto
    {
        public int? RecId { get; set; }
        public int CurrentAccountId { get; set; }

        public string CurrentAccountCode { get; set; }

        public string CurrentAccountName { get; set; }

        public DateTime PlanDate { get; set; }

        public int Status { get; set; }

        public DateTime ReceiptDate { get; set; } = DateTime.Now;

        public int DepartmentId { get; set; }

        public int AppUserId { get; set; }

        public DateTime? InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }



        public DateTime? DeleteDate { get; set; }

        public int ShiftId { get; set; }
        public Int16? InUse { get; set; }

        public int? DeletedBy { get; set; }

        public int? UpdatedBy { get; set; }
    }
}
