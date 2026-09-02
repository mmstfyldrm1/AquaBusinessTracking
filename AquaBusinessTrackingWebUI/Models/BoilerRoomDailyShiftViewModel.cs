using DTOLayer.Dtos.BoilerOperationandChemicalConsumptionDtos;
using DTOLayer.Dtos.BoilerRoomDailyShiftMonitoringDtos;

namespace AquaBusinessTrackingWebUI.Models
{
    public class BoilerRoomDailyShiftViewModel
    {
        public List<BoilerOperationandChemicalConsumptionDto> BoilerList { get; set; }
           = new List<BoilerOperationandChemicalConsumptionDto>();

        public List<EnergyConsumptionStatusDto> EnergyStatus { get; set; }
            = new List<EnergyConsumptionStatusDto>();
    }
}
