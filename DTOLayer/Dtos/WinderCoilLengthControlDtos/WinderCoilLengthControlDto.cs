namespace DTOLayer.Dtos.WinderCoilLengthControlDto
{
    public class WinderCoilLengthControlDto
    {
        public int RecId { get; set; }
        public DateTime ReceiptDate { get; set; } = DateTime.Now;
        public decimal CoilWidth { get; set; }

        public decimal WinderCoilLength { get; set; }

        public decimal Gramaj { get; set; }


        public decimal Weight { get; set; }

        public int DepartmentId { get; set; }


        public decimal TheoreticCoilLength { get; set; }

        public decimal CoilLengthDifference { get; set; }
        public decimal CoilLengthDeflection { get; set; } // Sapma

        public DateTime? InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }


        public DateTime? DeleteDate { get; set; }

        public int AppUserId { get; set; }
        public int ShiftId { get; set; }

        public string CreatedByName { get; set; }
        public string ShiftName { get; set; }
        public Int16? InUse { get; set; }

        public int? DeletedBy { get; set; }

        public int? UpdatedBy { get; set; }
    }
}
