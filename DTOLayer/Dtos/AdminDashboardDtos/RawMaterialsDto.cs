using DTOLayer.Dtos.DoughPreparationDtos.DoughPreparationHeadDtos;
using DTOLayer.Dtos.PapperMachineChemicalDtos;

namespace DTOLayer.Dtos.AdminDashboardDtos
{
    public class RawMaterialsDto
    {
        public List<DoughPreparationDto> DoughPreparation { get; set; }

        public List<PapperMachineChemicalDto> PapperMachineChemical { get; set; }
    }
}
