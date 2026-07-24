using Microsoft.AspNetCore.Identity;
using System.Text.Json.Serialization;

namespace EntityLayer.Concrete
{
    public class DB_AppUser : IdentityUser<int>
    {
        public string Name { get; set; }

        public string SurName { get; set; }

        public string? CoverImgUrl { get; set; }

        public int DepartmentId { get; set; }

        public int ShiftTitle { get; set; }
        public DB_Department Department { get; set; }

        [JsonIgnore]
        public ICollection<DB_IncomingGoodsTracking> IncomingGoodsTracking { get; set; }

        [JsonIgnore]
        public ICollection<DB_RawMaterialIntake> RawMaterialIntakes { get; set; }

        [JsonIgnore]
        public ICollection<DB_SteamConsumption> SteamConsumptions { get; set; }


        [JsonIgnore]
        public ICollection<DB_FavoriteMenuItem> FavoriteMenuItems { get; set; }


        [JsonIgnore]
        public ICollection<DB_PlanningScorBoardView> PlanningScorBoardView { get; set; }

        [JsonIgnore]
        public ICollection<DB_MachineStop> MachineStop { get; set; }

        [JsonIgnore]
        public ICollection<DB_BufferProduction> BufferProduction { get; set; }

        [JsonIgnore]
        public ICollection<DB_DoughPreparation> DoughPreparations { get; set; }


        [JsonIgnore]
        public ICollection<DB_KazanChemicalsHead> KazanChemicalsHead { get; set; }

        [JsonIgnore]
        public ICollection<DB_BufferGramajProfile> BufferGramajProfiles { get; set; }

        [JsonIgnore]
        public ICollection<DB_WaterPreparationAndConsumption> WaterPreparationAndConsumption { get; set; }

        [JsonIgnore]
        public ICollection<DB_OilAnalysisReport> OilAnalysisReport { get; set; }

        [JsonIgnore]
        public ICollection<DB_WastePaperCost> WastePaperCosts { get; set; }


        [JsonIgnore]
        public ICollection<DB_WastePaperControl> WastePaperControls { get; set; }

        [JsonIgnore]
        public ICollection<DB_SentezAllData> SentezAllData { get; set; }

        [JsonIgnore]
        public ICollection<DB_NaturelGasMeterMonitoring> NaturelGasMeterMonitorings { get; set; }

        [JsonIgnore]
        public ICollection<DB_KazanDailyShiftMonitoring> KazanDailyShiftMonitoring { get; set; }


        [JsonIgnore]
        public ICollection<DB_BufferAnalysisReport> BufferAnalysisReports { get; set; }

        [JsonIgnore]
        public ICollection<DB_WaterTreatmentAnalysisResults> WaterTreatmentAnalysisResults { get; set; }

        [JsonIgnore]
        public ICollection<DB_Basin> Basins { get; set; }

        [JsonIgnore]
        public ICollection<DB_DoughPreparationAnalysisResults> DoughPreparationAnalysisResults { get; set; }


        [JsonIgnore]
        public ICollection<DB_ElectricShiftWork> ElectricShiftWork { get; set; }

        [JsonIgnore]
        public ICollection<DB_PurificationChemicalsConsumption> PurificationChemicalsConsumptions { get; set; }

        [JsonIgnore]
        public ICollection<DB_LogisticsTrackingReport> LogisticsTrackingReports { get; set; }


        [JsonIgnore]
        public ICollection<DB_TestHeader> TestHeader { get; set; }


        [JsonIgnore]
        public ICollection<DB_CirculationTankAirPressureMeasurementTurbidity> CirculationTankAirPressureMeasurementTurbidities { get; set; }

        [JsonIgnore]
        public ICollection<DB_StarchAnalysisHeading> StarchAnalysisHeadings { get; set; }


        [JsonIgnore]
        public ICollection<DB_WinderCoilTracking> WinderCoilTrackings { get; set; }

        [JsonIgnore]
        public ICollection<DB_BoilerSteamFeedWaterCondensateData> BoilerSteamFeedWaterCondensateData { get; set; }



        [JsonIgnore]
        public ICollection<DB_WinderCoilLengthControl> WinderCoilLengthControl { get; set; }

        [JsonIgnore]
        public ICollection<DB_WarehouseRequestWait> WarehouseRequestWaits { get; set; }

        [JsonIgnore]
        public ICollection<DB_VechileFuelLogs> VechileFuelLogs { get; set; }


        [JsonIgnore]
        public ICollection<DB_LabWork> LabWorks { get; set; }

        [JsonIgnore]
        public ICollection<DB_SalesScale> SalesScales { get; set; }

        [JsonIgnore]
        public ICollection<DB_ElectricMotorTracking> ElectricMotorTrackings { get; set; }

        [JsonIgnore]
        public ICollection<DB_PapperMachineChemical> PapperMachineChemicals { get; set; }

        [JsonIgnore]
        public ICollection<DB_MassWasteSupplier> MassWasteSupplier { get; set; }

        [JsonIgnore]
        public ICollection<DB_MassWasteBalance> MassWasteBalance { get; set; }


        [JsonIgnore]
        public ICollection<DB_CumulativeElectricityConsumption> CumulativeElectricityConsumption { get; set; }

        [JsonIgnore]
        public ICollection<DB_ElectricMeterLocation> ElectricMeterLocation { get; set; }

        [JsonIgnore]
        public ICollection<DB_BoilerRoomDailyShiftMonitoring> BoilerRoomDailyShiftMonitoring { get; set; }

        public DateTime? InsertDate { get; set; }

        public DateTime? UpdateDate { get; set; }


        public DateTime? DeleteDate { get; set; }


    }
}
