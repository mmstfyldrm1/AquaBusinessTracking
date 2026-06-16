namespace DTOLayer.Dtos.BasinDtos.BasinDto
{
    public class BasinDto
    {

        public int RecId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int DepartmentId { get; set; }
        public int AppUserId { get; set; }

        public string? CreatedByName { get; set; }
        public int ShiftId { get; set; }
        public string? ShiftName { get; set; }


        public DateTime InsertDate { get; set; } = DateTime.Now;

        public DateTime? UpdateDate { get; set; }


        public DateTime? DeleteDate { get; set; }

    }
}
