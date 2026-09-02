namespace DTOLayer.Dtos.BoilerRoomDailyShiftMonitoringDtos
{
    public class UpdateBoilerOperationandChemicalConsumptionDto
    {
        public int RecId { get; set; }
        public string? Explanation { get; set; }
        public int ConsumptionPlaceId { get; set; }

        public int ScalePlaceId { get; set; }
        public decimal ConsumptionQuantity { get; set; }
        public string? ConsumptionPlaceName { get; set; }
        public DateTime? ReceiptDate { get; set; }
        public int? ShiftId { get; set; }
        public int? AppUserId { get; set; }
        public int DepartmentId { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Int16? InUse { get; set; }
        public int? DeletedBy { get; set; }

        public int? UpdatedBy { get; set; }
    }
}
