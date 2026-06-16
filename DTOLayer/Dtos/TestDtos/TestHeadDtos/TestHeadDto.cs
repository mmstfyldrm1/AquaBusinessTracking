namespace DTOLayer.Dtos.TestDtos.TestHeadDtos
{
    public class TestHeadDto
    {
        public int RecId { get; set; }

        public string TestDepartmentName { get; set; }

        public int AppUserId { get; set; }



        public int DepartmentId { get; set; }

        public string ShiftName { get; set; }

        public string CreatedByName { get; set; }


        public DateTime? InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }


        public DateTime? DeleteDate { get; set; }



        public int ShiftId { get; set; }



        public Int16? InUse { get; set; }

        public int? DeletedBy { get; set; }

        public int? UpdatedBy { get; set; }
    }
}
