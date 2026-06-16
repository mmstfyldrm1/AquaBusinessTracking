namespace DTOLayer.Dtos.ElectricDtos.ElectricShiftDtos
{
    public class ElectricShiftWorkDto
    {
        public int RecId { get; set; }
        public int ShiftId { get; set; }
        public int AppUserId { get; set; }

        public string CreatedByName { get; set; }
        public string ShiftName { get; set; }
        public int DepartmentId { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
    }
}
