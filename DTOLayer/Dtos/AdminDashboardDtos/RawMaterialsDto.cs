using DTOLayer.Dtos.PapperMachineChemicalDtos;
using DTOLayer.Dtos.WaterPreparationAndConsumptionDtos;

namespace DTOLayer.Dtos.AdminDashboardDtos
{
    public class RawMaterialsDto
    {
        public List<WaterPreparationAndConsumptionDto> WaterPreparationAndConsumption { get; set; }

        public List<PapperMachineChemicalDto> PapperMachineChemical { get; set; }
    }
}
