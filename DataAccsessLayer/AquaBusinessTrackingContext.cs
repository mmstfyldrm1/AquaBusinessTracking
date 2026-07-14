using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccsessLayer
{
    public class AquaBusinessTrackingContext : IdentityDbContext<DB_AppUser, DB_AppRole, int>
    {
        public AquaBusinessTrackingContext(DbContextOptions<AquaBusinessTrackingContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AquaBusinessTrackingContext).Assembly);

        }


        public DbSet<DB_Basin> Db_Basin { get; set; }
        public DbSet<DB_BasinMeasurement> Db_BasinMeasurement { get; set; }
        public DbSet<DB_BoilerSteamFeedWaterCondensateData> Db_BoilerSteamFeedWaterCondensateData { get; set; }
        public DbSet<DB_BufferAnalysisReport> Db_BufferAnalysisReport { get; set; }
        public DbSet<DB_BufferGramajProfile> Db_BufferGramajProfile { get; set; }
        public DbSet<DB_CirculationTankAirPressureMeasurementTurbidity> Db_CirculationTankAirPressureMeasurementTurbidity { get; set; }
        public DbSet<DB_Department> Db_Department { get; set; }
        public DbSet<DB_DoughPreparationAnalysisResults> Db_DoughPreparationAnalysisResults { get; set; }
        public DbSet<DB_ElectricMotorTracking> Db_ElectricMotorTracking { get; set; }
        public DbSet<DB_ElectricShiftWork> Db_ElectricShiftWork { get; set; }
        public DbSet<DB_KazanDailyShiftMonitoring> Db_KazanDailyShiftMonitoring { get; set; }
        public DbSet<DB_LabWork> Db_LabWork { get; set; }
        public DbSet<DB_LogisticsTrackingReport> Db_LogisticsTrackingReport { get; set; }
        public DbSet<DB_MassWasteSupplier> Db_MassWasteSupplier { get; set; }

        public DbSet<DB_MassWasteBalance> Db_MassWasteBalance { get; set; }
        public DbSet<DB_NaturelGasMeterMonitoring> Db_NaturelGasMeterMonitoring { get; set; }
        public DbSet<DB_OilAnalysisReport> Db_OilAnalysisReport { get; set; }
        public DbSet<DB_PapperMachineChemical> Db_PapperMachineChemical { get; set; }
        public DbSet<DB_PurificationChemicalsConsumption> Db_PurificationChemicalsConsumption { get; set; }
        public DbSet<DB_SalesScale> Db_SalesScale { get; set; }
        public DbSet<DB_SentezAllData> Db_SentezAllData { get; set; }
        public DbSet<DB_SentezNotOrder> Db_SentezNotOrder { get; set; }
        public DbSet<DB_Shift> Db_Shift { get; set; }
        public DbSet<DB_StarchAnalysisHeading> Db_StarchAnalysisHeading { get; set; }
        public DbSet<DB_StarchAnalysisHeadingDetail> Db_StarchAnalysisHeadingDetail { get; set; }
        public DbSet<DB_TestDetail> Db_TestDetail { get; set; }
        public DbSet<DB_TestHeader> Db_TestHeader { get; set; }
        public DbSet<DB_VechileFuelLogs> Db_VechileFuelLogs { get; set; }
        public DbSet<DB_WarehouseRequestWait> Db_WarehouseRequestWait { get; set; }
        public DbSet<DB_WastePaperControl> Db_WastePaperControl { get; set; }
        public DbSet<DB_WastePaperCost> Db_WastePaperCost { get; set; }
        public DbSet<DB_WaterPreparationAndConsumption> Db_WaterPreparationAndConsumption { get; set; }
        public DbSet<DB_WaterTreatmentAnalysisResults> Db_WaterTreatmentAnalysisResults { get; set; }
        public DbSet<DB_WinderCoilLengthControl> Db_WinderCoilLengthControl { get; set; }
        public DbSet<DB_WinderCoilTracking> Db_WinderCoilTracking { get; set; }

        public DbSet<DB_KazanChemicalsHead> Db_KazanChemicalsHead { get; set; }
        public DbSet<DB_SteamConsumption> Db_SteamConsumption { get; set; }

        public DbSet<DB_DoughPreparation> Db_DoughPreparation { get; set; }

        public DbSet<DB_RetentionAnalysisHead> Db_RetentionAnalysisHead { get; set; }

        public DbSet<DB_RetantionAnalysisDetail> Db_RetantionAnalysisDetail { get; set; }

        public DbSet<DB_Permission> Db_Permission { get; set; }

        public DbSet<DB_RolePermission> Db_RolePermission { get; set; }

        public DbSet<DB_PlcTags> Db_PlcTags { get; set; }

        public DbSet<DB_PlcMachine> Db_PlcMachine { get; set; }

        public DbSet<DB_PlcReading> Db_PlcReading { get; set; }

        public DbSet<DB_ElectricMeterLocation> Db_ElectricMeterLocation { get; set; }
        public DbSet<DB_CumulativeElectricityConsumption> Db_CumulativeElectricityConsumption { get; set; }

        public DbSet<DB_BoilerRoomDailyShiftMonitoring> Db_BoilerRoomDailyShiftMonitoring { get; set; }

        public DbSet<DB_BufferProduction> Db_BufferProduction { get; set; }

        public DbSet<DB_MachineStop> Db_MachineStop { get; set; }

        public DbSet<DB_PlanningScorBoardView> Db_PlanningScorBoardView { get; set; }

        public DbSet<DB_FavoriteMenuItem> Db_FavoriteMenuItem { get; set; }
        public DbSet<DB_Message> Db_Message { get; set; }


    }
}
