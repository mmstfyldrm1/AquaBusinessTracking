namespace DTOLayer.Dtos.ElectricDtos.ElectricMeterLocationDtos
{
    public class UpdateElectricMeterLocationDto
    {
        public int RecId { get; set; }
        public DateTime ReceiptDate { get; set; }

        public string LocationName { get; set; }

        public string? Explanation { get; set; }

        public DateTime? InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public DateTime? DeleteDate { get; set; }
        public int ShiftId { get; set; }

        public int DepartmentId { get; set; }
        public int AppUserId { get; set; }
    }
}
