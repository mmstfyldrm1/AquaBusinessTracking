namespace DTOLayer.Dtos.CirculationTankAirPressureMeasurementTurbidity
{
    public class CirculationTankAirPressureMeasurementTurbidityDto
    {
        public int RecId { get; set; }

        public DateTime ReceiptDate { get; set; } = DateTime.Now;
        public TimeSpan Time { get; set; }
        public decimal MachineSpeed { get; set; }
        public string ProductionType { get; set; }
        public decimal Grammage { get; set; }
        public int TurnCount { get; set; }
        public decimal Fau { get; set; }  // FAU - Fuzzy/Flocculation value
        public decimal Ntu { get; set; }  // NTU - Turbidity/Nephelometric value

        public DateTime? InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }


        public DateTime? DeleteDate { get; set; }

        public Int16? InUse { get; set; }

        public int? DeletedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public int DepartmentId { get; set; }

        public int AppUserId { get; set; }

        public string CreatedByName { get; set; }
        public string ShiftName { get; set; }

        public int ShiftId { get; set; }
    }
}
