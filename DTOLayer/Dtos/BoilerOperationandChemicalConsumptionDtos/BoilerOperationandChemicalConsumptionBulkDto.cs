namespace DTOLayer.Dtos.BoilerOperationandChemicalConsumptionDtos
{
    public class BoilerOperationandChemicalConsumptionBulkDto
    {
        public DateTime? ReceiptDate { get; set; }
        public int ScalePlaceId { get; set; }
        public int ShiftId { get; set; }
        public Int16 InUse { get; set; } = 1;

        public List<ConsumptionPlaceRow> Rows { get; set; } = new();
    }
}
