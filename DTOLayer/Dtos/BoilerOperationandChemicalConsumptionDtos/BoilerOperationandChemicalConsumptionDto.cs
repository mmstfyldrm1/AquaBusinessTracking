using DTOLayer.Dtos.BoilerOperationandChemicalConsumptionDtos;

namespace DTOLayer.Dtos.BoilerRoomDailyShiftMonitoringDtos
{
    public class BoilerOperationandChemicalConsumptionDto
    {
        public int RecId { get; set; }

        public string? Explanation { get; set; }
        public int ConsumptionPlaceId { get; set; }

        public string? ScalePlaceName { get; set; }
        public string? ConsumptionPlace { get; set; }

        public int ScalePlaceId { get; set; }
        public decimal ConsumptionQuantity { get; set; }

        public DateTime ReceiptDate { get; set; } = DateTime.Now;

        public int? ShiftId { get; set; }
        public int? AppUserId { get; set; }


        public int DepartmentId { get; set; }

        public string? CreatedByName { get; set; }

        public string? ShiftName { get; set; }
        public string? DepartmentName { get; set; }


        public DateTime? InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }


        public DateTime? DeleteDate { get; set; }

        public Int16? InUse { get; set; }

        public int? DeletedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public List<EnergyConsumptionStatusDto>? status { get; set; } = new List<EnergyConsumptionStatusDto>();
    }
}
