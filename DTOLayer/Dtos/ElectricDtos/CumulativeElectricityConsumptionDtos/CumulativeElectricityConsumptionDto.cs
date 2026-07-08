namespace DTOLayer.Dtos.ElectricDtos.CumulativeElectricityConsumptionDtos
{
    public class CumulativeElectricityConsumptionDto
    {
        public int RecId { get; set; }
        public int Year { get; set; } = DateTime.Now.Year;
        public int Month { get; set; } = DateTime.Now.Month;

        public decimal Consumption { get; set; }

        public DateTime ReceiptDate { get; set; } = DateTime.Now;

        public string ShiftName { get; set; }

        public string CreatedByName { get; set; }

        public int AppUserId { get; set; }

        public int ShiftId { get; set; }

        public DateTime? InsertDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        public DateTime? UpdateDate { get; set; }
        public int ElectricMeterLocationId { get; set; }

        public int DepartmentId { get; set; }
        //Location

        public string? LocationName { get; set; }


    }
}
