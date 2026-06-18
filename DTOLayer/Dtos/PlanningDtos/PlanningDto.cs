using DTOLayer.Dtos.BoilerSteamFeedWaterCondensateDataDtos;
using DTOLayer.Dtos.BufferAnalysisReportDtos;
using DTOLayer.Dtos.DoughPreparationDtos.DoughPreparationHeadDtos;
using DTOLayer.Dtos.ElectricDtos.CumulativeElectricityConsumptionDtos;
using DTOLayer.Dtos.KazanDtos.KazanHeadDtos;
using DTOLayer.Dtos.NaturelGasMeterMonitoringDtos;
using DTOLayer.Dtos.PapperMachineChemicalDtos;
using DTOLayer.Dtos.PurificationChemicalsConsumptionDtos;
using DTOLayer.Dtos.WastePaperControlDtos;
using DTOLayer.Dtos.WaterPreparationAndConsumptionDtos;

namespace DTOLayer.Dtos.PlanningDto
{
    public class PlanningDto
    {
        public List<WastePaperControlDto> WastePaperControls { get; set; }

        public List<DoughPreparationDto> DoughPreparations { get; set; }

        public List<WaterPreparationAndConsumptionDto> WaterPreparationAndConsumptions { get; set; }

        public List<KazanChemicalsHeadDto> KazanChemicalsForms { get; set; }

        public List<BoilerSteamFeedWaterCondensateDataDto> BoilerSteamFeedWaterCondensateDatas { get; set; }

        public List<BufferAnalysisReportDto> BufferAnalysisReports { get; set; }

        public List<CumulativeElectricityConsumptionDto> CumulativeElectricityConsumptions { get; set; }

        public List<PurificationChemicalsConsumptionDto> PurificationChemicalsConsumptions { get; set; }

        public List<NaturelGasMeterMonitoringDto> NaturelGasMeterMonitorings { get; set; }


        public List<PapperMachineChemicalDto> PapperMachineChemicals { get; set; }

    }
}