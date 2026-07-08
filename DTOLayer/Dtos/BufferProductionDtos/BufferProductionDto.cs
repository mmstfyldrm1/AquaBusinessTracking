namespace DTOLayer.Dtos.BufferProductionDtos
{
    public class BufferProductionDto
    {
        public int RecId { get; set; }
        public string ShiftSupervisorUser { get; set; }

        public string Product { get; set; }

        public decimal GrPerM2 { get; set; }

        public int BufferNo { get; set; }
        public int ShiftSupervisorUserId { get; set; }

        public DateTime? BufferStart { get; set; }

        public DateTime? BufferEnd { get; set; }

        public int TotalDurationMinutes { get; set; }

        public int DowntimeMinutes { get; set; }

        public decimal BufferSpeed { get; set; }

        public decimal BufferWidthCm { get; set; }

        public int BufferSetCount { get; set; }

        public decimal TheoreticalBufferKg { get; set; }

        public decimal MeasuredKg { get; set; }

        public string Description { get; set; }

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

        public DateTime ReceiptDate { get; set; } = DateTime.Now;
    }
}
