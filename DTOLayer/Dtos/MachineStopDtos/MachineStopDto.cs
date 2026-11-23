namespace DTOLayer.Dtos.MachineStopDtos
{
    public class MachineStopDto
    {
        public int RecId { get; set; }
        public DateTime? StartTime { get; set; }

        public DateTime? ReceiptDate { get; set; } = DateTime.Now;
        public DateTime? EndTime { get; set; }
        public decimal? DowntimeDuration { get; set; }
        public string? PointofRupture { get; set; }
        public string? ReasonDisconnection { get; set; }
        public string? Equipment { get; set; }

        public string? Explanation { get; set; }
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
