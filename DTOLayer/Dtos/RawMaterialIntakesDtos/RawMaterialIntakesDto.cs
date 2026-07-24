namespace DTOLayer.Dtos.RawMaterialIntakesDtos
{
    public class RawMaterialIntakesDto
    {
        public int RecId { get; set; }

        public TimeSpan ScaleHours { get; set; } = DateTime.Now.TimeOfDay;

        public string WaybillNo { get; set; }

        public string CurrentAccountName { get; set; }

        public string TruckPlate { get; set; }

        public string Operator { get; set; }

        public decimal WaybillQuantity { get; set; }

        public decimal FilledQuantity { get; set; }

        public decimal EmptyQuantity { get; set; }

        public decimal NetQuantity { get; set; }

        public DateTime? ReceiptDate { get; set; }

        public int? ShiftId { get; set; }
        public int? AppUserId { get; set; }

        public int? DepartmentId { get; set; }

        public DateTime? InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        public string ShiftName { get; set; }

        public string CreatedByName { get; set; }
    }
}
