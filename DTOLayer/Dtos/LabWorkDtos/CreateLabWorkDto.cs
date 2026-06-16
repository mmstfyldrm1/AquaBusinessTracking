namespace DTOLayer.Dtos.LabWorkDtos
{
    public class CreateLabWorkDto
    {


        public string LabTestName { get; set; }

        public string LabTestRequest { get; set; }
        public string LabTestCount { get; set; }
        public string LabTestUserNames { get; set; }
        public int ShiftId { get; set; }

        public int DepartmentId { get; set; }
        public DateTime? InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }
        public int AppUserId { get; set; }


        public Int16? InUse { get; set; }

        public int? DeletedBy { get; set; }

        public int? UpdatedBy { get; set; }
    }
}
