namespace DTOLayer.Dtos.KazanEnergyConsumptionDtos
{
    public class CreateKazanEnergyConsumptionDto
    {
        public int RecId { get; set; }

        public string ConsumptionPlace { get; set; }

        public string? ConsumptionUnit { get; set; }

        public string? Explanation { get; set; }

        public int DepartmentId { get; set; }
        public int AppUserId { get; set; }
        public DateTime? InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public int ShiftId { get; set; }

        public Int16? InUse { get; set; }

        public int? DeletedBy { get; set; }

        public int? UpdatedBy { get; set; }
    }
}
