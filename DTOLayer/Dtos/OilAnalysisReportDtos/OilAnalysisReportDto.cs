namespace DTOLayer.Dtos.OilAnalysisReportDtos
{
    public class OilAnalysisReportDto
    {
        public int RecId { get; set; }

        public int DepartmentId { get; set; }


        public string LocationSampleWasTaken { get; set; }
        public int Hours { get; set; } = DateTime.Now.Hour;

        public DateTime Date { get; set; } = DateTime.Now;

        public DateTime? InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }


        public string ShiftName { get; set; }

        public string CreatedByName { get; set; }

        public DateTime? DeleteDate { get; set; }
        public int AppUserId { get; set; }

        public int ShiftId { get; set; }
        public Int16? InUse { get; set; }

        public int? DeletedBy { get; set; }

        public int? UpdatedBy { get; set; }
    }
}
