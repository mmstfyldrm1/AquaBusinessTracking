namespace DTOLayer.Dtos.ElectricDtos.CumulativeElectricityConsumptionDtos
{
    public class CumulativeElectricityConsumptionBulkDto
    {
        public DateTime? ReceiptDate { get; set; } = DateTime.Now;
        public int Year { get; set; } = DateTime.Now.Year;
        public int Month { get; set; } = DateTime.Now.Month;
        public int ShiftId { get; set; }

        public List<LocationConsumptionRowDto> Rows { get; set; } = new();
    }
}
