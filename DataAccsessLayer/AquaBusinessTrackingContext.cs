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
            // ---------------------------------------- PLC ilişkileri -------------------------------------------------------

            // DB_PlcMachine → DB_PlcTags (1'e çok)
            builder.Entity<DB_PlcTags>()
                .HasOne(x => x.Machine)
                .WithMany(x => x.Tags)
                .HasForeignKey(x => x.MachineId)
                .OnDelete(DeleteBehavior.Cascade); // makine silinince tagler de silinsin

            // DB_PlcTags → DB_PlcReading (1'e çok)
            builder.Entity<DB_PlcReading>()
                .HasOne(x => x.PlcTag)
                .WithMany(x => x.Readings)
                .HasForeignKey(x => x.PlcTagId)
                .OnDelete(DeleteBehavior.Cascade); // tag silinince okumalar da silinsin

            // ReadingTime üzerine index — zaman serisi sorguları hızlansın
            builder.Entity<DB_PlcReading>()
                .HasIndex(x => x.ReadingTime);

            // MachineId üzerine index — makineye göre tag sorguları hızlansın
            builder.Entity<DB_PlcTags>()
                .HasIndex(x => x.MachineId);
            //----------------------------------------  Department ilişkileri -------------------------------------------------------   

            builder.Entity<DB_AppUser>()
                .HasOne(x => x.Department)        // User → 1 Department
                .WithMany(x => x.AppUsers)           // Department → çok User
                .HasForeignKey(x => x.DepartmentId) // FK bu kolon
                .OnDelete(DeleteBehavior.Restrict); // department silinince user silinmesin


            builder.Entity<DB_WinderCoilTracking>()
                .HasOne(x => x.Department)
                .WithMany(x => x.WinderCoilTrackings)
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_WinderCoilLengthControl>()
                .HasOne(x => x.Department)
                .WithMany(x => x.WinderCoilLengthControl)
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_WaterTreatmentAnalysisResults>()
                .HasOne(x => x.Department)
                .WithMany(x => x.WaterTreatmentAnalysisResults)
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<DB_WaterPreparationAndConsumption>()
                .HasOne(x => x.Department)
                .WithMany(x => x.WaterPreparationAndConsumption)
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<DB_WastePaperCost>()
                .HasOne(x => x.Department)
                .WithMany(x => x.WastePaperCosts)
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<DB_WastePaperControl>()
                .HasOne(x => x.Department)
                .WithMany(x => x.WastePaperControls)
                .HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<DB_WarehouseRequestWait>()
              .HasOne(x => x.Department)
              .WithMany(x => x.WarehouseRequestWaits)
              .HasForeignKey(x => x.DepartmentId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_VechileFuelLogs>()
              .HasOne(x => x.Department)
              .WithMany(x => x.VechileFuelLogs)
              .HasForeignKey(x => x.DepartmentId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_TestHeader>()
             .HasOne(x => x.Department)
             .WithMany(x => x.TestHeaders)
             .HasForeignKey(x => x.DepartmentId)
             .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_TestDetail>()
            .HasOne(x => x.TestHeader)
            .WithMany(x => x.TestDetails)
            .HasForeignKey(x => x.TestHeaderId)
            .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<DB_StarchAnalysisHeading>()
           .HasOne(x => x.Department)
           .WithMany(x => x.StarchAnalysisHeadings)
           .HasForeignKey(x => x.DepartmentId)
           .OnDelete(DeleteBehavior.Restrict);



            builder.Entity<DB_StarchAnalysisHeadingDetail>()
           .HasOne(x => x.StarchAnalysisHeading)
           .WithMany(x => x.StarchAnalysisHeadingDetails)
           .HasForeignKey(x => x.StarchAnalysisHeadingId)
           .OnDelete(DeleteBehavior.Restrict);



            builder.Entity<DB_SentezAllData>()
           .HasOne(x => x.Department)
           .WithMany(x => x.SentezAllData)
           .HasForeignKey(x => x.DepartmentId)
           .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_SalesScale>()
            .HasOne(x => x.Department)
            .WithMany(x => x.SalesScales)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_PurificationChemicalsConsumption>()
           .HasOne(x => x.Department)
           .WithMany(x => x.PurificationChemicalsConsumptions)
           .HasForeignKey(x => x.DepartmentId)
           .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_PapperMachineChemical>()
           .HasOne(x => x.Department)
           .WithMany(x => x.PapperMachineChemicals)
           .HasForeignKey(x => x.DepartmentId)
           .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<DB_OilAnalysisReport>()
           .HasOne(x => x.Department)
           .WithMany(x => x.OilAnalysisReport)
           .HasForeignKey(x => x.DepartmentId)
           .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_NaturelGasMeterMonitoring>()
           .HasOne(x => x.Department)
           .WithMany(x => x.NaturelGasMeterMonitorings)
           .HasForeignKey(x => x.DepartmentId)
           .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_MassWasteSupplier>()
             .HasOne(x => x.Department)
             .WithMany(x => x.MassWasteSupplier)
             .HasForeignKey(x => x.DepartmentId)
             .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_MassWasteBalance>()
             .HasOne(x => x.Department)
             .WithMany(x => x.MassWasteBalance)
             .HasForeignKey(x => x.DepartmentId)
             .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_LogisticsTrackingReport>()
           .HasOne(x => x.Department)
           .WithMany(x => x.LogisticsTrackingReports)
           .HasForeignKey(x => x.DepartmentId)
           .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_LabWork>()
           .HasOne(x => x.Department)
           .WithMany(x => x.LabWorks)
           .HasForeignKey(x => x.DepartmentId)
           .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_KazanDailyShiftMonitoring>()
           .HasOne(x => x.Department)
           .WithMany(x => x.KazanDailyShiftMonitoring)
           .HasForeignKey(x => x.DepartmentId)
           .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_ElectricShiftWork>()
            .HasOne(x => x.Department)
            .WithMany(x => x.ElectricShiftWork)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_ElectricMotorTracking>()
            .HasOne(x => x.Department)
            .WithMany(x => x.ElectricMotorTrackings)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_DoughPreparationAnalysisResults>()
          .HasOne(x => x.Department)
          .WithMany(x => x.DoughPreparationAnalysisResults)
          .HasForeignKey(x => x.DepartmentId)
          .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_CirculationTankAirPressureMeasurementTurbidity>()
           .HasOne(x => x.Department)
           .WithMany(x => x.CirculationTankAirPressureMeasurementTurbidities)
           .HasForeignKey(x => x.DepartmentId)
           .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_BufferGramajProfile>()
           .HasOne(x => x.Department)
           .WithMany(x => x.BufferGramajProfiles)
           .HasForeignKey(x => x.DepartmentId)
           .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_BufferAnalysisReport>()
            .HasOne(x => x.Department)
            .WithMany(x => x.BufferAnalysisReports)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_BoilerSteamFeedWaterCondensateData>()
            .HasOne(x => x.Department)
            .WithMany(x => x.BoilerSteamFeedWaterCondensateData)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_Basin>()
           .HasOne(x => x.Department)
           .WithMany(x => x.Basins)
           .HasForeignKey(x => x.DepartmentId)
           .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_BasinMeasurement>()
            .HasOne(x => x.Basin)
            .WithMany(x => x.Measurements)
            .HasForeignKey(x => x.BasinId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_KazanChemicalsHead>()
            .HasOne(x => x.Department)
            .WithMany(x => x.KazanChemicalsHead)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);



            builder.Entity<DB_DoughPreparation>()
            .HasOne(x => x.Department)
            .WithMany(x => x.DoughPreparations)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_SteamConsumption>()
            .HasOne(x => x.Department)
            .WithMany(x => x.SteamConsumptions)
            .HasForeignKey(x => x.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_ElectricMeterLocation>()
                    .HasOne(x => x.Department)
                    .WithMany(x => x.ElectricMeterLocation)
                    .HasForeignKey(x => x.DepartmanId)
                    .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_CumulativeElectricityConsumption>()
                 .HasOne(x => x.Department)
                 .WithMany(x => x.CumulativeElectricityConsumption)
                 .HasForeignKey(x => x.DepartmanId)
                 .OnDelete(DeleteBehavior.Restrict);


            //-------------------------------------------------------  AppUser ilişkileri -------------------------------------------------------

            builder.Entity<DB_KazanChemicalsHead>()
               .HasOne(x => x.AppUser)
               .WithMany(x => x.KazanChemicalsHead)
               .HasForeignKey(x => x.AppUserId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_DoughPreparation>()
               .HasOne(x => x.AppUser)
               .WithMany(x => x.DoughPreparations)
               .HasForeignKey(x => x.AppUserId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_SteamConsumption>()
            .HasOne(x => x.AppUser)
            .WithMany(x => x.SteamConsumptions)
            .HasForeignKey(x => x.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_WinderCoilTracking>()
                .HasOne(x => x.AppUser)
                .WithMany(x => x.WinderCoilTrackings)
                .HasForeignKey(x => x.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_WinderCoilLengthControl>()
                .HasOne(x => x.AppUser)
                .WithMany(x => x.WinderCoilLengthControl)
                .HasForeignKey(x => x.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_WaterTreatmentAnalysisResults>()
                .HasOne(x => x.AppUser)
                .WithMany(x => x.WaterTreatmentAnalysisResults)
                .HasForeignKey(x => x.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<DB_WaterPreparationAndConsumption>()
                .HasOne(x => x.AppUser)
                .WithMany(x => x.WaterPreparationAndConsumption)
                .HasForeignKey(x => x.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<DB_WastePaperCost>()
                .HasOne(x => x.AppUser)
                .WithMany(x => x.WastePaperCosts)
                .HasForeignKey(x => x.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<DB_WastePaperControl>()
                .HasOne(x => x.AppUser)
                .WithMany(x => x.WastePaperControls)
                .HasForeignKey(x => x.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<DB_WarehouseRequestWait>()
              .HasOne(x => x.AppUser)
              .WithMany(x => x.WarehouseRequestWaits)
              .HasForeignKey(x => x.AppUserId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_VechileFuelLogs>()
              .HasOne(x => x.AppUser)
              .WithMany(x => x.VechileFuelLogs)
              .HasForeignKey(x => x.AppUserId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_TestHeader>()
             .HasOne(x => x.AppUser)
             .WithMany(x => x.TestHeader)
             .HasForeignKey(x => x.AppUserId)
             .OnDelete(DeleteBehavior.Restrict);




            builder.Entity<DB_StarchAnalysisHeading>()
           .HasOne(x => x.AppUser)
           .WithMany(x => x.StarchAnalysisHeadings)
           .HasForeignKey(x => x.AppUserId)
           .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<DB_SentezAllData>()
           .HasOne(x => x.AppUser)
           .WithMany(x => x.SentezAllData)
           .HasForeignKey(x => x.AppUserId)
           .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_SalesScale>()
            .HasOne(x => x.AppUser)
            .WithMany(x => x.SalesScales)
            .HasForeignKey(x => x.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_PurificationChemicalsConsumption>()
           .HasOne(x => x.AppUser)
           .WithMany(x => x.PurificationChemicalsConsumptions)
           .HasForeignKey(x => x.AppUserId)
           .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_PapperMachineChemical>()
           .HasOne(x => x.AppUser)
           .WithMany(x => x.PapperMachineChemicals)
           .HasForeignKey(x => x.AppUserId)
           .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<DB_OilAnalysisReport>()
           .HasOne(x => x.AppUser)
           .WithMany(x => x.OilAnalysisReport)
           .HasForeignKey(x => x.AppUserId)
           .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_NaturelGasMeterMonitoring>()
           .HasOne(x => x.AppUser)
           .WithMany(x => x.NaturelGasMeterMonitorings)
           .HasForeignKey(x => x.AppUserId)
           .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_MassWasteSupplier>()
             .HasOne(x => x.AppUser)
             .WithMany(x => x.MassWasteSupplier)
             .HasForeignKey(x => x.AppUserId)
             .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_MassWasteBalance>()
             .HasOne(x => x.AppUser)
             .WithMany(x => x.MassWasteBalance)
             .HasForeignKey(x => x.AppUserId)
             .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_LogisticsTrackingReport>()
           .HasOne(x => x.AppUser)
           .WithMany(x => x.LogisticsTrackingReports)
           .HasForeignKey(x => x.AppUserId)
           .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_LabWork>()
           .HasOne(x => x.AppUser)
           .WithMany(x => x.LabWorks)
           .HasForeignKey(x => x.AppUserId)
           .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_KazanDailyShiftMonitoring>()
           .HasOne(x => x.AppUser)
           .WithMany(x => x.KazanDailyShiftMonitoring)
           .HasForeignKey(x => x.AppUserId)
           .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_ElectricShiftWork>()
            .HasOne(x => x.AppUser)
            .WithMany(x => x.ElectricShiftWork)
            .HasForeignKey(x => x.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_ElectricMotorTracking>()
            .HasOne(x => x.AppUser)
            .WithMany(x => x.ElectricMotorTrackings)
            .HasForeignKey(x => x.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_DoughPreparationAnalysisResults>()
          .HasOne(x => x.AppUser)
          .WithMany(x => x.DoughPreparationAnalysisResults)
          .HasForeignKey(x => x.AppUserId)
          .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_CirculationTankAirPressureMeasurementTurbidity>()
           .HasOne(x => x.AppUser)
           .WithMany(x => x.CirculationTankAirPressureMeasurementTurbidities)
           .HasForeignKey(x => x.AppUserId)
           .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_BufferGramajProfile>()
           .HasOne(x => x.AppUser)
           .WithMany(x => x.BufferGramajProfiles)
           .HasForeignKey(x => x.AppUserId)
           .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_BufferAnalysisReport>()
            .HasOne(x => x.AppUser)
            .WithMany(x => x.BufferAnalysisReports)
            .HasForeignKey(x => x.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_BoilerSteamFeedWaterCondensateData>()
            .HasOne(x => x.AppUser)
            .WithMany(x => x.BoilerSteamFeedWaterCondensateData)
            .HasForeignKey(x => x.AppUserId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_Basin>()
           .HasOne(x => x.AppUser)
           .WithMany(x => x.Basins)
           .HasForeignKey(x => x.AppUserId)
           .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_ElectricMeterLocation>()
                 .HasOne(x => x.AppUser)
                 .WithMany(x => x.ElectricMeterLocation)
                 .HasForeignKey(x => x.AppUserId)
                 .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_CumulativeElectricityConsumption>()
                 .HasOne(x => x.AppUser)
                 .WithMany(x => x.CumulativeElectricityConsumption)
                 .HasForeignKey(x => x.AppUserId)
                 .OnDelete(DeleteBehavior.Restrict);


            //------------------------------ Shift ilişkileri -------------------------------------------------------


            builder.Entity<DB_WinderCoilTracking>()
               .HasOne(x => x.Shift)
               .WithMany(x => x.WinderCoilTrackings)
               .HasForeignKey(x => x.ShiftId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_WinderCoilLengthControl>()
                .HasOne(x => x.Shift)
                .WithMany(x => x.WinderCoilLengthControl)
                .HasForeignKey(x => x.ShiftId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_WaterTreatmentAnalysisResults>()
                .HasOne(x => x.Shift)
                .WithMany(x => x.WaterTreatmentAnalysisResults)
                .HasForeignKey(x => x.ShiftId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<DB_WaterPreparationAndConsumption>()
                .HasOne(x => x.Shift)
                .WithMany(x => x.WaterPreparationAndConsumption)
                .HasForeignKey(x => x.ShiftId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<DB_WastePaperCost>()
                .HasOne(x => x.Shift)
                .WithMany(x => x.WastePaperCosts)
                .HasForeignKey(x => x.ShiftId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<DB_WastePaperControl>()
                .HasOne(x => x.Shift)
                .WithMany(x => x.WastePaperControls)
                .HasForeignKey(x => x.ShiftId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<DB_WarehouseRequestWait>()
              .HasOne(x => x.Shift)
              .WithMany(x => x.WarehouseRequestWaits)
              .HasForeignKey(x => x.ShiftId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_VechileFuelLogs>()
              .HasOne(x => x.Shift)
              .WithMany(x => x.VechileFuelLogs)
              .HasForeignKey(x => x.ShiftId)
              .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_TestHeader>()
             .HasOne(x => x.Shift)
             .WithMany(x => x.TestHeaders)
             .HasForeignKey(x => x.ShiftId)
             .OnDelete(DeleteBehavior.Restrict);




            builder.Entity<DB_StarchAnalysisHeading>()
           .HasOne(x => x.Shift)
           .WithMany(x => x.StarchAnalysisHeadings)
           .HasForeignKey(x => x.ShiftId)
           .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<DB_SentezAllData>()
           .HasOne(x => x.Shift)
           .WithMany(x => x.SentezAllData)
           .HasForeignKey(x => x.ShiftId)
           .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_SalesScale>()
            .HasOne(x => x.Shift)
            .WithMany(x => x.SalesScales)
            .HasForeignKey(x => x.ShiftId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_PurificationChemicalsConsumption>()
           .HasOne(x => x.Shift)
           .WithMany(x => x.PurificationChemicalsConsumptions)
           .HasForeignKey(x => x.ShiftId)
           .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_PapperMachineChemical>()
           .HasOne(x => x.Shift)
           .WithMany(x => x.PapperMachineChemicals)
           .HasForeignKey(x => x.ShiftId)
           .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<DB_OilAnalysisReport>()
           .HasOne(x => x.Shift)
           .WithMany(x => x.OilAnalysisReport)
           .HasForeignKey(x => x.ShiftId)
           .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_NaturelGasMeterMonitoring>()
           .HasOne(x => x.Shift)
           .WithMany(x => x.NaturelGasMeterMonitorings)
           .HasForeignKey(x => x.ShiftId)
           .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_MassWasteSupplier>()
             .HasOne(x => x.Shift)
             .WithMany(x => x.MassWasteSupplier)
             .HasForeignKey(x => x.ShiftId)
             .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_MassWasteBalance>()
             .HasOne(x => x.Shift)
             .WithMany(x => x.MassWasteBalance)
             .HasForeignKey(x => x.ShiftId)
             .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_LogisticsTrackingReport>()
           .HasOne(x => x.Shift)
           .WithMany(x => x.LogisticsTrackingReports)
           .HasForeignKey(x => x.ShiftId)
           .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_LabWork>()
           .HasOne(x => x.Shift)
           .WithMany(x => x.LabWorks)
           .HasForeignKey(x => x.ShiftId)
           .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_KazanDailyShiftMonitoring>()
           .HasOne(x => x.Shift)
           .WithMany(x => x.KazanDailyShiftMonitoring)
           .HasForeignKey(x => x.ShiftId)
           .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_ElectricShiftWork>()
            .HasOne(x => x.Shift)
            .WithMany(x => x.ElectricShiftWork)
            .HasForeignKey(x => x.ShiftId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_ElectricMotorTracking>()
            .HasOne(x => x.Shift)
            .WithMany(x => x.ElectricMotorTrackings)
            .HasForeignKey(x => x.ShiftId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_DoughPreparationAnalysisResults>()
          .HasOne(x => x.Shift)
          .WithMany(x => x.DoughPreparationAnalysisResults)
          .HasForeignKey(x => x.ShiftId)
          .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_CirculationTankAirPressureMeasurementTurbidity>()
           .HasOne(x => x.Shift)
           .WithMany(x => x.CirculationTankAirPressureMeasurementTurbidities)
           .HasForeignKey(x => x.ShiftId)
           .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_BufferGramajProfile>()
           .HasOne(x => x.Shift)
           .WithMany(x => x.BufferGramajProfiles)
           .HasForeignKey(x => x.ShiftId)
           .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_BufferAnalysisReport>()
            .HasOne(x => x.Shift)
            .WithMany(x => x.BufferAnalysisReports)
            .HasForeignKey(x => x.ShiftId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_BoilerSteamFeedWaterCondensateData>()
            .HasOne(x => x.Shift)
            .WithMany(x => x.BoilerSteamFeedWaterCondensateData)
            .HasForeignKey(x => x.ShiftId)
            .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_Basin>()
           .HasOne(x => x.Shift)
           .WithMany(x => x.Basins)
           .HasForeignKey(x => x.ShiftId)
           .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_KazanChemicalsHead>()
               .HasOne(x => x.Shift)
               .WithMany(x => x.KazanChemicalsHead)
               .HasForeignKey(x => x.ShiftId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_DoughPreparation>()
               .HasOne(x => x.Shift)
               .WithMany(x => x.DoughPreparations)
               .HasForeignKey(x => x.ShiftId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_SteamConsumption>()
            .HasOne(x => x.Shift)
            .WithMany(x => x.SteamConsumptions)
            .HasForeignKey(x => x.ShiftId)
            .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<DB_ElectricMeterLocation>()
                .HasOne(x => x.Shift)
                .WithMany(x => x.ElectricMeterLocation)
                .HasForeignKey(x => x.ShiftId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<DB_CumulativeElectricityConsumption>()
                 .HasOne(x => x.Shift)
                 .WithMany(x => x.CumulativeElectricityConsumption)
                 .HasForeignKey(x => x.ShiftId)
                 .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<DB_CumulativeElectricityConsumption>()
                 .HasOne(x => x.ElectricMeterLocation)
                 .WithMany(x => x.CumulativeElectricityConsumption)
                 .HasForeignKey(x => x.ElectricMeterLocationId)
                 .OnDelete(DeleteBehavior.Restrict);

            //------------------------------ RolePermission ilişkileri -------------------------------------------------------

            // Composite Key
            builder.Entity<DB_RolePermission>()
                .HasKey(x => new { x.RoleId, x.PermissionId });

            // Role ilişkisi
            builder.Entity<DB_RolePermission>()
                .HasOne(rp => rp.Role)
                .WithMany(r => r.RolePermissions)
                .HasForeignKey(rp => rp.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            // Permission ilişkisi
            builder.Entity<DB_RolePermission>()
                .HasOne(rp => rp.Permission)
                .WithMany(p => p.RolePermissions)
                .HasForeignKey(rp => rp.PermissionId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<DB_RolePermission>()
                .HasKey(x => new { x.RoleId, x.PermissionId });



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
        public DbSet<DB_MassWasteSupplier> DB_MassWasteSupplier { get; set; }

        public DbSet<DB_MassWasteBalance> DB_MassWasteBalance { get; set; }
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





    }
}
