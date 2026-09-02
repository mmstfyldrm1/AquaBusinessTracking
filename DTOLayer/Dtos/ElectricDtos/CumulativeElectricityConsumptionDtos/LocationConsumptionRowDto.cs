namespace DTOLayer.Dtos.ElectricDtos.CumulativeElectricityConsumptionDtos
{
    public class LocationConsumptionRowDto
    {
        public int ElectricMeterLocationId { get; set; }

        public string? LocationName { get; set; }
        public decimal? Consumption { get; set; }
        public decimal? InductiveReactive { get; set; }
        public decimal? CapacitiveReactive { get; set; }
    }
}
