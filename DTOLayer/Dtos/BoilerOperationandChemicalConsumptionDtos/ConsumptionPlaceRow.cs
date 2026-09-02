namespace DTOLayer.Dtos.BoilerOperationandChemicalConsumptionDtos
{
    public class ConsumptionPlaceRow
    {
        public int ConsumptionPlaceId { get; set; }
        public string? ConsumptionPlaceName { get; set; }
        public decimal? ConsumptionQuantity { get; set; }
        public string? Explanation { get; set; }
    }
}
