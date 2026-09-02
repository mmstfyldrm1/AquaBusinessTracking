namespace DTOLayer.Dtos.BoilerOperationandChemicalConsumptionDtos
{
    public class BoilerOperationandChemicalConsumptionBulkDto
    {
        public DateTime? ReceiptDate { get; set; }
        public int ScalePlaceId { get; set; }
        public int ShiftId { get; set; }
        public bool InUse { get; set; } = true;

        public List<ConsumptionPlaceRow> Rows { get; set; } = new();
    }
}
