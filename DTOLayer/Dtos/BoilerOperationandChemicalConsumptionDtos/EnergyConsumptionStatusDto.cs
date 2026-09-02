namespace DTOLayer.Dtos.BoilerOperationandChemicalConsumptionDtos
{
    public class EnergyConsumptionStatusDto
    {
        public int EnergyConsumptionId { get; set; }

        public string EnergyConsumptionPlace { get; set; }

        public int? ShiftId { get; set; }

        public string? ShiftName { get; set; }

        public DateTime? ReceiptDate { get; set; }

        public bool IsRecorded { get; set; }

    }
}
