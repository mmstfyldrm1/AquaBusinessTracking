namespace DTOLayer.Dtos.DailyShipmentPlanDtos
{
    public class DailyShipmentPlanDto
    {
        public int RecId { get; set; }
        public string ShipmentNo { get; set; }
        public string CompanyCode { get; set; }
        public string CompanyName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string? Address { get; set; }
        public DateTime ReceiptDate { get; set; } = DateTime.Now;

        public int DepartmentId { get; set; }

        public string ShiftName { get; set; }

        public string CreatedByName { get; set; }

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
