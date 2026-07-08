namespace DTOLayer.Dtos.ElectricDtos.ElectricMeterLocationDtos
{
    public class ElectricMeterLocationDto
    {
        public int RecId { get; set; }
        public DateTime ReceiptDate { get; set; } = DateTime.Now;

        public string LocationName { get; set; }

        public int DepartmentId { get; set; }

        public int ShiftId { get; set; }

        public string ShiftName { get; set; }

        public string CreatedByName { get; set; }

        public int AppUserId { get; set; }

        public string? Explanation { get; set; }

        public DateTime? InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }
    }
}
