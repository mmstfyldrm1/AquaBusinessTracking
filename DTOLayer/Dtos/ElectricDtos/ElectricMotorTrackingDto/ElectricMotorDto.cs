namespace DTOLayer.Dtos.ElectricDtos.ElectricMotorTrackingDto
{
    public class ElectricMotorDto
    {
        public int RecId { get; set; }
        public DateTime ReceiptDate { get; set; } = DateTime.Now;
        public string ElectricMotorOrderNo { get; set; }
        public string ElectricMotorBrand { get; set; }
        public float kW { get; set; }
        public string Voltage { get; set; }

        public string? Explanation { get; set; }

        public string CreatedByName { get; set; }
        public string ShiftName { get; set; }
        public int DepartmentId { get; set; }
        public DateTime InsertDate { get; set; } = DateTime.Now;
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public int AppUserId { get; set; }
        public int ShiftId { get; set; }


    }
}
