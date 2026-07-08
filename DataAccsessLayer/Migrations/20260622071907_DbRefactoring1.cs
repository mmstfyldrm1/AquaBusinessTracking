using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccsessLayer.Migrations
{
    /// <inheritdoc />
    public partial class DbRefactoring1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Db_CumulativeElectricityConsumption_Db_Department_DepartmentId",
                table: "Db_CumulativeElectricityConsumption");

            migrationBuilder.DropForeignKey(
                name: "FK_Db_ElectricMeterLocation_Db_Department_DepartmentId",
                table: "Db_ElectricMeterLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_Db_KazanDailyShiftMonitoring_Db_Shift_ShihtId",
                table: "Db_KazanDailyShiftMonitoring");

            migrationBuilder.DropForeignKey(
                name: "FK_DB_MassWasteBalance_AspNetUsers_AppUserId",
                table: "DB_MassWasteBalance");

            migrationBuilder.DropForeignKey(
                name: "FK_DB_MassWasteBalance_Db_Department_DepartmentId",
                table: "DB_MassWasteBalance");

            migrationBuilder.DropForeignKey(
                name: "FK_DB_MassWasteBalance_Db_Shift_ShiftId",
                table: "DB_MassWasteBalance");

            migrationBuilder.DropForeignKey(
                name: "FK_DB_MassWasteSupplier_AspNetUsers_AppUserId",
                table: "DB_MassWasteSupplier");

            migrationBuilder.DropForeignKey(
                name: "FK_DB_MassWasteSupplier_Db_Department_DepartmentId",
                table: "DB_MassWasteSupplier");

            migrationBuilder.DropForeignKey(
                name: "FK_DB_MassWasteSupplier_Db_Shift_ShiftId",
                table: "DB_MassWasteSupplier");

            migrationBuilder.DropForeignKey(
                name: "FK_Db_RetentionAnalysisHead_AspNetUsers_AppUserId",
                table: "Db_RetentionAnalysisHead");

            migrationBuilder.DropForeignKey(
                name: "FK_Db_RetentionAnalysisHead_Db_Shift_ShiftId",
                table: "Db_RetentionAnalysisHead");

            migrationBuilder.DropForeignKey(
                name: "FK_Db_SentezNotOrder_AspNetUsers_AppUserId",
                table: "Db_SentezNotOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_Db_SentezNotOrder_Db_Department_DepartmentId",
                table: "Db_SentezNotOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_Db_SentezNotOrder_Db_Shift_ShiftId",
                table: "Db_SentezNotOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DB_MassWasteSupplier",
                table: "DB_MassWasteSupplier");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DB_MassWasteBalance",
                table: "DB_MassWasteBalance");

            migrationBuilder.DropIndex(
                name: "IX_Db_KazanDailyShiftMonitoring_ShihtId",
                table: "Db_KazanDailyShiftMonitoring");

            migrationBuilder.DropColumn(
                name: "ShihtId",
                table: "Db_KazanDailyShiftMonitoring");

            migrationBuilder.RenameTable(
                name: "DB_MassWasteSupplier",
                newName: "Db_MassWasteSupplier");

            migrationBuilder.RenameTable(
                name: "DB_MassWasteBalance",
                newName: "Db_MassWasteBalance");

            migrationBuilder.RenameIndex(
                name: "IX_DB_MassWasteSupplier_ShiftId",
                table: "Db_MassWasteSupplier",
                newName: "IX_Db_MassWasteSupplier_ShiftId");

            migrationBuilder.RenameIndex(
                name: "IX_DB_MassWasteSupplier_DepartmentId",
                table: "Db_MassWasteSupplier",
                newName: "IX_Db_MassWasteSupplier_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_DB_MassWasteSupplier_AppUserId",
                table: "Db_MassWasteSupplier",
                newName: "IX_Db_MassWasteSupplier_AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_DB_MassWasteBalance_ShiftId",
                table: "Db_MassWasteBalance",
                newName: "IX_Db_MassWasteBalance_ShiftId");

            migrationBuilder.RenameIndex(
                name: "IX_DB_MassWasteBalance_DepartmentId",
                table: "Db_MassWasteBalance",
                newName: "IX_Db_MassWasteBalance_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_DB_MassWasteBalance_AppUserId",
                table: "Db_MassWasteBalance",
                newName: "IX_Db_MassWasteBalance_AppUserId");

            migrationBuilder.RenameColumn(
                name: "InsertDate",
                table: "Db_ElectricMeterLocation",
                newName: "ReceiptDate");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Db_ElectricMeterLocation",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Db_ElectricMeterLocation_DepartmentId",
                table: "Db_ElectricMeterLocation",
                newName: "IX_Db_ElectricMeterLocation_DepartmentId");

            migrationBuilder.RenameColumn(
                name: "InsertDate",
                table: "Db_CumulativeElectricityConsumption",
                newName: "ReceiptDate");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Db_CumulativeElectricityConsumption",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Db_CumulativeElectricityConsumption_DepartmentId",
                table: "Db_CumulativeElectricityConsumption",
                newName: "IX_Db_CumulativeElectricityConsumption_DepartmentId");

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_WinderCoilTracking",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_WinderCoilTracking",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceiptDate",
                table: "Db_WinderCoilTracking",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_WinderCoilLengthControl",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_WinderCoilLengthControl",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceiptDate",
                table: "Db_WinderCoilLengthControl",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_WaterTreatmentAnalysisResults",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_WaterTreatmentAnalysisResults",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceiptDate",
                table: "Db_WaterTreatmentAnalysisResults",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_WaterPreparationAndConsumption",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_WaterPreparationAndConsumption",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceiptDate",
                table: "Db_WaterPreparationAndConsumption",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_WastePaperCost",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_WastePaperCost",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceiptDate",
                table: "Db_WastePaperCost",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_WastePaperControl",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_WastePaperControl",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceiptDate",
                table: "Db_WastePaperControl",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_WarehouseRequestWait",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_WarehouseRequestWait",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceiptDate",
                table: "Db_WarehouseRequestWait",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_VechileFuelLogs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_VechileFuelLogs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceiptDate",
                table: "Db_VechileFuelLogs",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_TestHeader",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_TestHeader",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceiptDate",
                table: "Db_TestHeader",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_SteamConsumption",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_SteamConsumption",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceiptDate",
                table: "Db_SteamConsumption",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_StarchAnalysisHeading",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_StarchAnalysisHeading",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceiptDate",
                table: "Db_StarchAnalysisHeading",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_SentezNotOrder",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Db_SentezNotOrder",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_SentezNotOrder",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceiptDate",
                table: "Db_SentezNotOrder",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_SentezAllData",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_SentezAllData",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceiptDate",
                table: "Db_SentezAllData",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_SalesScale",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_SalesScale",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceiptDate",
                table: "Db_SalesScale",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_RetentionAnalysisHead",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_RetentionAnalysisHead",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceiptDate",
                table: "Db_RetentionAnalysisHead",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_PurificationChemicalsConsumption",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_PurificationChemicalsConsumption",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceiptDate",
                table: "Db_PurificationChemicalsConsumption",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_PapperMachineChemical",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_PapperMachineChemical",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceiptDate",
                table: "Db_PapperMachineChemical",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_OilAnalysisReport",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_OilAnalysisReport",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceiptDate",
                table: "Db_OilAnalysisReport",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_NaturelGasMeterMonitoring",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_NaturelGasMeterMonitoring",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceiptDate",
                table: "Db_NaturelGasMeterMonitoring",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_MassWasteSupplier",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_MassWasteSupplier",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceiptDate",
                table: "Db_MassWasteSupplier",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_MassWasteBalance",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_MassWasteBalance",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceiptDate",
                table: "Db_MassWasteBalance",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_LogisticsTrackingReport",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_LogisticsTrackingReport",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceiptDate",
                table: "Db_LogisticsTrackingReport",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_LabWork",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_LabWork",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceiptDate",
                table: "Db_LabWork",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_KazanDailyShiftMonitoring",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_KazanDailyShiftMonitoring",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceiptDate",
                table: "Db_KazanDailyShiftMonitoring",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_KazanChemicalsHead",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_KazanChemicalsHead",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceiptDate",
                table: "Db_KazanChemicalsHead",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_ElectricShiftWork",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_ElectricShiftWork",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceiptDate",
                table: "Db_ElectricShiftWork",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_ElectricMotorTracking",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_ElectricMotorTracking",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceiptDate",
                table: "Db_ElectricMotorTracking",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Db_ElectricMeterLocation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "InUse",
                table: "Db_ElectricMeterLocation",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDate",
                table: "Db_ElectricMeterLocation",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "Db_ElectricMeterLocation",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_DoughPreparationAnalysisResults",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_DoughPreparationAnalysisResults",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceiptDate",
                table: "Db_DoughPreparationAnalysisResults",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_DoughPreparation",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_DoughPreparation",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceiptDate",
                table: "Db_DoughPreparation",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DeletedBy",
                table: "Db_CumulativeElectricityConsumption",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "InUse",
                table: "Db_CumulativeElectricityConsumption",
                type: "smallint",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InsertDate",
                table: "Db_CumulativeElectricityConsumption",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "Db_CumulativeElectricityConsumption",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_CirculationTankAirPressureMeasurementTurbidity",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_CirculationTankAirPressureMeasurementTurbidity",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceiptDate",
                table: "Db_CirculationTankAirPressureMeasurementTurbidity",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_BufferGramajProfile",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_BufferGramajProfile",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceiptDate",
                table: "Db_BufferGramajProfile",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_BufferAnalysisReport",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_BufferAnalysisReport",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceiptDate",
                table: "Db_BufferAnalysisReport",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_BoilerSteamFeedWaterCondensateData",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_BoilerSteamFeedWaterCondensateData",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceiptDate",
                table: "Db_BoilerSteamFeedWaterCondensateData",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_Basin",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_Basin",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReceiptDate",
                table: "Db_Basin",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Db_MassWasteSupplier",
                table: "Db_MassWasteSupplier",
                column: "RecId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Db_MassWasteBalance",
                table: "Db_MassWasteBalance",
                column: "RecId");

            migrationBuilder.CreateTable(
                name: "Db_BoilerRoomDailyShiftMonitoring",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelToWork = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkIsDone = table.Column<bool>(type: "bit", nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkPermit = table.Column<bool>(type: "bit", nullable: false),
                    NextShiftWork = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiptDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ShiftId = table.Column<int>(type: "int", nullable: true),
                    AppUserId = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InUse = table.Column<short>(type: "smallint", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Db_BoilerRoomDailyShiftMonitoring", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_BoilerRoomDailyShiftMonitoring_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_BoilerRoomDailyShiftMonitoring_Db_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Db_Department",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_BoilerRoomDailyShiftMonitoring_Db_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Db_BoilerRoomDailyShiftMonitoring_AppUserId",
                table: "Db_BoilerRoomDailyShiftMonitoring",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_BoilerRoomDailyShiftMonitoring_DepartmentId",
                table: "Db_BoilerRoomDailyShiftMonitoring",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_BoilerRoomDailyShiftMonitoring_ShiftId",
                table: "Db_BoilerRoomDailyShiftMonitoring",
                column: "ShiftId");

            migrationBuilder.AddForeignKey(
                name: "FK_Db_CumulativeElectricityConsumption_Db_Department_DepartmentId",
                table: "Db_CumulativeElectricityConsumption",
                column: "DepartmentId",
                principalTable: "Db_Department",
                principalColumn: "RecId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Db_ElectricMeterLocation_Db_Department_DepartmentId",
                table: "Db_ElectricMeterLocation",
                column: "DepartmentId",
                principalTable: "Db_Department",
                principalColumn: "RecId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Db_MassWasteBalance_AspNetUsers_AppUserId",
                table: "Db_MassWasteBalance",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Db_MassWasteBalance_Db_Department_DepartmentId",
                table: "Db_MassWasteBalance",
                column: "DepartmentId",
                principalTable: "Db_Department",
                principalColumn: "RecId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Db_MassWasteBalance_Db_Shift_ShiftId",
                table: "Db_MassWasteBalance",
                column: "ShiftId",
                principalTable: "Db_Shift",
                principalColumn: "RecId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Db_MassWasteSupplier_AspNetUsers_AppUserId",
                table: "Db_MassWasteSupplier",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Db_MassWasteSupplier_Db_Department_DepartmentId",
                table: "Db_MassWasteSupplier",
                column: "DepartmentId",
                principalTable: "Db_Department",
                principalColumn: "RecId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Db_MassWasteSupplier_Db_Shift_ShiftId",
                table: "Db_MassWasteSupplier",
                column: "ShiftId",
                principalTable: "Db_Shift",
                principalColumn: "RecId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Db_RetentionAnalysisHead_AspNetUsers_AppUserId",
                table: "Db_RetentionAnalysisHead",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Db_RetentionAnalysisHead_Db_Shift_ShiftId",
                table: "Db_RetentionAnalysisHead",
                column: "ShiftId",
                principalTable: "Db_Shift",
                principalColumn: "RecId");

            migrationBuilder.AddForeignKey(
                name: "FK_Db_SentezNotOrder_AspNetUsers_AppUserId",
                table: "Db_SentezNotOrder",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Db_SentezNotOrder_Db_Department_DepartmentId",
                table: "Db_SentezNotOrder",
                column: "DepartmentId",
                principalTable: "Db_Department",
                principalColumn: "RecId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Db_SentezNotOrder_Db_Shift_ShiftId",
                table: "Db_SentezNotOrder",
                column: "ShiftId",
                principalTable: "Db_Shift",
                principalColumn: "RecId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Db_CumulativeElectricityConsumption_Db_Department_DepartmentId",
                table: "Db_CumulativeElectricityConsumption");

            migrationBuilder.DropForeignKey(
                name: "FK_Db_ElectricMeterLocation_Db_Department_DepartmentId",
                table: "Db_ElectricMeterLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_Db_MassWasteBalance_AspNetUsers_AppUserId",
                table: "Db_MassWasteBalance");

            migrationBuilder.DropForeignKey(
                name: "FK_Db_MassWasteBalance_Db_Department_DepartmentId",
                table: "Db_MassWasteBalance");

            migrationBuilder.DropForeignKey(
                name: "FK_Db_MassWasteBalance_Db_Shift_ShiftId",
                table: "Db_MassWasteBalance");

            migrationBuilder.DropForeignKey(
                name: "FK_Db_MassWasteSupplier_AspNetUsers_AppUserId",
                table: "Db_MassWasteSupplier");

            migrationBuilder.DropForeignKey(
                name: "FK_Db_MassWasteSupplier_Db_Department_DepartmentId",
                table: "Db_MassWasteSupplier");

            migrationBuilder.DropForeignKey(
                name: "FK_Db_MassWasteSupplier_Db_Shift_ShiftId",
                table: "Db_MassWasteSupplier");

            migrationBuilder.DropForeignKey(
                name: "FK_Db_RetentionAnalysisHead_AspNetUsers_AppUserId",
                table: "Db_RetentionAnalysisHead");

            migrationBuilder.DropForeignKey(
                name: "FK_Db_RetentionAnalysisHead_Db_Shift_ShiftId",
                table: "Db_RetentionAnalysisHead");

            migrationBuilder.DropForeignKey(
                name: "FK_Db_SentezNotOrder_AspNetUsers_AppUserId",
                table: "Db_SentezNotOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_Db_SentezNotOrder_Db_Department_DepartmentId",
                table: "Db_SentezNotOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_Db_SentezNotOrder_Db_Shift_ShiftId",
                table: "Db_SentezNotOrder");

            migrationBuilder.DropTable(
                name: "Db_BoilerRoomDailyShiftMonitoring");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Db_MassWasteSupplier",
                table: "Db_MassWasteSupplier");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Db_MassWasteBalance",
                table: "Db_MassWasteBalance");

            migrationBuilder.DropColumn(
                name: "ReceiptDate",
                table: "Db_WinderCoilTracking");

            migrationBuilder.DropColumn(
                name: "ReceiptDate",
                table: "Db_WinderCoilLengthControl");

            migrationBuilder.DropColumn(
                name: "ReceiptDate",
                table: "Db_WaterTreatmentAnalysisResults");

            migrationBuilder.DropColumn(
                name: "ReceiptDate",
                table: "Db_WaterPreparationAndConsumption");

            migrationBuilder.DropColumn(
                name: "ReceiptDate",
                table: "Db_WastePaperCost");

            migrationBuilder.DropColumn(
                name: "ReceiptDate",
                table: "Db_WastePaperControl");

            migrationBuilder.DropColumn(
                name: "ReceiptDate",
                table: "Db_WarehouseRequestWait");

            migrationBuilder.DropColumn(
                name: "ReceiptDate",
                table: "Db_VechileFuelLogs");

            migrationBuilder.DropColumn(
                name: "ReceiptDate",
                table: "Db_TestHeader");

            migrationBuilder.DropColumn(
                name: "ReceiptDate",
                table: "Db_SteamConsumption");

            migrationBuilder.DropColumn(
                name: "ReceiptDate",
                table: "Db_StarchAnalysisHeading");

            migrationBuilder.DropColumn(
                name: "ReceiptDate",
                table: "Db_SentezNotOrder");

            migrationBuilder.DropColumn(
                name: "ReceiptDate",
                table: "Db_SentezAllData");

            migrationBuilder.DropColumn(
                name: "ReceiptDate",
                table: "Db_SalesScale");

            migrationBuilder.DropColumn(
                name: "ReceiptDate",
                table: "Db_RetentionAnalysisHead");

            migrationBuilder.DropColumn(
                name: "ReceiptDate",
                table: "Db_PurificationChemicalsConsumption");

            migrationBuilder.DropColumn(
                name: "ReceiptDate",
                table: "Db_PapperMachineChemical");

            migrationBuilder.DropColumn(
                name: "ReceiptDate",
                table: "Db_OilAnalysisReport");

            migrationBuilder.DropColumn(
                name: "ReceiptDate",
                table: "Db_NaturelGasMeterMonitoring");

            migrationBuilder.DropColumn(
                name: "ReceiptDate",
                table: "Db_MassWasteSupplier");

            migrationBuilder.DropColumn(
                name: "ReceiptDate",
                table: "Db_MassWasteBalance");

            migrationBuilder.DropColumn(
                name: "ReceiptDate",
                table: "Db_LogisticsTrackingReport");

            migrationBuilder.DropColumn(
                name: "ReceiptDate",
                table: "Db_LabWork");

            migrationBuilder.DropColumn(
                name: "ReceiptDate",
                table: "Db_KazanDailyShiftMonitoring");

            migrationBuilder.DropColumn(
                name: "ReceiptDate",
                table: "Db_KazanChemicalsHead");

            migrationBuilder.DropColumn(
                name: "ReceiptDate",
                table: "Db_ElectricShiftWork");

            migrationBuilder.DropColumn(
                name: "ReceiptDate",
                table: "Db_ElectricMotorTracking");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Db_ElectricMeterLocation");

            migrationBuilder.DropColumn(
                name: "InUse",
                table: "Db_ElectricMeterLocation");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "Db_ElectricMeterLocation");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Db_ElectricMeterLocation");

            migrationBuilder.DropColumn(
                name: "ReceiptDate",
                table: "Db_DoughPreparationAnalysisResults");

            migrationBuilder.DropColumn(
                name: "ReceiptDate",
                table: "Db_DoughPreparation");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Db_CumulativeElectricityConsumption");

            migrationBuilder.DropColumn(
                name: "InUse",
                table: "Db_CumulativeElectricityConsumption");

            migrationBuilder.DropColumn(
                name: "InsertDate",
                table: "Db_CumulativeElectricityConsumption");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Db_CumulativeElectricityConsumption");

            migrationBuilder.DropColumn(
                name: "ReceiptDate",
                table: "Db_CirculationTankAirPressureMeasurementTurbidity");

            migrationBuilder.DropColumn(
                name: "ReceiptDate",
                table: "Db_BufferGramajProfile");

            migrationBuilder.DropColumn(
                name: "ReceiptDate",
                table: "Db_BufferAnalysisReport");

            migrationBuilder.DropColumn(
                name: "ReceiptDate",
                table: "Db_BoilerSteamFeedWaterCondensateData");

            migrationBuilder.DropColumn(
                name: "ReceiptDate",
                table: "Db_Basin");

            migrationBuilder.RenameTable(
                name: "Db_MassWasteSupplier",
                newName: "DB_MassWasteSupplier");

            migrationBuilder.RenameTable(
                name: "Db_MassWasteBalance",
                newName: "DB_MassWasteBalance");

            migrationBuilder.RenameIndex(
                name: "IX_Db_MassWasteSupplier_ShiftId",
                table: "DB_MassWasteSupplier",
                newName: "IX_DB_MassWasteSupplier_ShiftId");

            migrationBuilder.RenameIndex(
                name: "IX_Db_MassWasteSupplier_DepartmentId",
                table: "DB_MassWasteSupplier",
                newName: "IX_DB_MassWasteSupplier_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Db_MassWasteSupplier_AppUserId",
                table: "DB_MassWasteSupplier",
                newName: "IX_DB_MassWasteSupplier_AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Db_MassWasteBalance_ShiftId",
                table: "DB_MassWasteBalance",
                newName: "IX_DB_MassWasteBalance_ShiftId");

            migrationBuilder.RenameIndex(
                name: "IX_Db_MassWasteBalance_DepartmentId",
                table: "DB_MassWasteBalance",
                newName: "IX_DB_MassWasteBalance_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Db_MassWasteBalance_AppUserId",
                table: "DB_MassWasteBalance",
                newName: "IX_DB_MassWasteBalance_AppUserId");

            migrationBuilder.RenameColumn(
                name: "ReceiptDate",
                table: "Db_ElectricMeterLocation",
                newName: "InsertDate");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Db_ElectricMeterLocation",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Db_ElectricMeterLocation_DepartmentId",
                table: "Db_ElectricMeterLocation",
                newName: "IX_Db_ElectricMeterLocation_DepartmentId");

            migrationBuilder.RenameColumn(
                name: "ReceiptDate",
                table: "Db_CumulativeElectricityConsumption",
                newName: "InsertDate");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Db_CumulativeElectricityConsumption",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Db_CumulativeElectricityConsumption_DepartmentId",
                table: "Db_CumulativeElectricityConsumption",
                newName: "IX_Db_CumulativeElectricityConsumption_DepartmentId");

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_WinderCoilTracking",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_WinderCoilTracking",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_WinderCoilLengthControl",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_WinderCoilLengthControl",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_WaterTreatmentAnalysisResults",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_WaterTreatmentAnalysisResults",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_WaterPreparationAndConsumption",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_WaterPreparationAndConsumption",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_WastePaperCost",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_WastePaperCost",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_WastePaperControl",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_WastePaperControl",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_WarehouseRequestWait",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_WarehouseRequestWait",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_VechileFuelLogs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_VechileFuelLogs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_TestHeader",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_TestHeader",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_SteamConsumption",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_SteamConsumption",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_StarchAnalysisHeading",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_StarchAnalysisHeading",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_SentezNotOrder",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartmentId",
                table: "Db_SentezNotOrder",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_SentezNotOrder",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_SentezAllData",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_SentezAllData",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_SalesScale",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_SalesScale",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_RetentionAnalysisHead",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_RetentionAnalysisHead",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_PurificationChemicalsConsumption",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_PurificationChemicalsConsumption",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_PapperMachineChemical",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_PapperMachineChemical",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_OilAnalysisReport",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_OilAnalysisReport",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_NaturelGasMeterMonitoring",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_NaturelGasMeterMonitoring",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "DB_MassWasteSupplier",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "DB_MassWasteSupplier",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "DB_MassWasteBalance",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "DB_MassWasteBalance",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_LogisticsTrackingReport",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_LogisticsTrackingReport",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_LabWork",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_LabWork",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_KazanDailyShiftMonitoring",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_KazanDailyShiftMonitoring",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShihtId",
                table: "Db_KazanDailyShiftMonitoring",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_KazanChemicalsHead",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_KazanChemicalsHead",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_ElectricShiftWork",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_ElectricShiftWork",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_ElectricMotorTracking",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_ElectricMotorTracking",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_DoughPreparationAnalysisResults",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_DoughPreparationAnalysisResults",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_DoughPreparation",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_DoughPreparation",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_CirculationTankAirPressureMeasurementTurbidity",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_CirculationTankAirPressureMeasurementTurbidity",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_BufferGramajProfile",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_BufferGramajProfile",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_BufferAnalysisReport",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_BufferAnalysisReport",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_BoilerSteamFeedWaterCondensateData",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_BoilerSteamFeedWaterCondensateData",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShiftId",
                table: "Db_Basin",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Db_Basin",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_DB_MassWasteSupplier",
                table: "DB_MassWasteSupplier",
                column: "RecId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DB_MassWasteBalance",
                table: "DB_MassWasteBalance",
                column: "RecId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_KazanDailyShiftMonitoring_ShihtId",
                table: "Db_KazanDailyShiftMonitoring",
                column: "ShihtId");

            migrationBuilder.AddForeignKey(
                name: "FK_Db_CumulativeElectricityConsumption_Db_Department_DepartmentId",
                table: "Db_CumulativeElectricityConsumption",
                column: "DepartmentId",
                principalTable: "Db_Department",
                principalColumn: "RecId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Db_ElectricMeterLocation_Db_Department_DepartmentId",
                table: "Db_ElectricMeterLocation",
                column: "DepartmentId",
                principalTable: "Db_Department",
                principalColumn: "RecId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Db_KazanDailyShiftMonitoring_Db_Shift_ShihtId",
                table: "Db_KazanDailyShiftMonitoring",
                column: "ShihtId",
                principalTable: "Db_Shift",
                principalColumn: "RecId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DB_MassWasteBalance_AspNetUsers_AppUserId",
                table: "DB_MassWasteBalance",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DB_MassWasteBalance_Db_Department_DepartmentId",
                table: "DB_MassWasteBalance",
                column: "DepartmentId",
                principalTable: "Db_Department",
                principalColumn: "RecId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DB_MassWasteBalance_Db_Shift_ShiftId",
                table: "DB_MassWasteBalance",
                column: "ShiftId",
                principalTable: "Db_Shift",
                principalColumn: "RecId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DB_MassWasteSupplier_AspNetUsers_AppUserId",
                table: "DB_MassWasteSupplier",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DB_MassWasteSupplier_Db_Department_DepartmentId",
                table: "DB_MassWasteSupplier",
                column: "DepartmentId",
                principalTable: "Db_Department",
                principalColumn: "RecId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DB_MassWasteSupplier_Db_Shift_ShiftId",
                table: "DB_MassWasteSupplier",
                column: "ShiftId",
                principalTable: "Db_Shift",
                principalColumn: "RecId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Db_RetentionAnalysisHead_AspNetUsers_AppUserId",
                table: "Db_RetentionAnalysisHead",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Db_RetentionAnalysisHead_Db_Shift_ShiftId",
                table: "Db_RetentionAnalysisHead",
                column: "ShiftId",
                principalTable: "Db_Shift",
                principalColumn: "RecId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Db_SentezNotOrder_AspNetUsers_AppUserId",
                table: "Db_SentezNotOrder",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Db_SentezNotOrder_Db_Department_DepartmentId",
                table: "Db_SentezNotOrder",
                column: "DepartmentId",
                principalTable: "Db_Department",
                principalColumn: "RecId");

            migrationBuilder.AddForeignKey(
                name: "FK_Db_SentezNotOrder_Db_Shift_ShiftId",
                table: "Db_SentezNotOrder",
                column: "ShiftId",
                principalTable: "Db_Shift",
                principalColumn: "RecId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
