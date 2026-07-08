namespace DTOLayer.Dtos.NaturelGasMeterMonitoringDtos
{
    public class CreateNaturelGasMeterMonitoringDto
    {
        public DateTime ReceiptDate { get; set; }


        public int DailyConsumption { get; set; }
        public float Pressure { get; set; }

        public float Heat { get; set; }
        public float CalorificValue { get; set; }
        public decimal StandartCubicmeter { get; set; }
        public float ConversionFactor { get; set; }

        public decimal kW { get; set; }

        public string Explanation { get; set; }

        public int Control { get; set; }

        public int IsApproved { get; set; }

        public int DepartmentId { get; set; }
        public int AppUserId { get; set; }
        public int ShiftId { get; set; }

        public DateTime? InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }


        public DateTime? DeleteDate { get; set; }

        public Int16? InUse { get; set; }

        public int? DeletedBy { get; set; }

        public int? UpdatedBy { get; set; }
    }
}
