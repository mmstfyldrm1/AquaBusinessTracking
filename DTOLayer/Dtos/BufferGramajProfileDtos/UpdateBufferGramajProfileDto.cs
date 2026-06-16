namespace DTOLayer.Dtos.BufferGramajProfileDtos
{
    public class UpdateBufferGramajProfileDto
    {
        public int RecId { get; set; }

        public decimal BufferNo { get; set; }

        public int SampleNo { get; set; }

        public int Gramaj { get; set; }
        public int Thickness { get; set; }

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
