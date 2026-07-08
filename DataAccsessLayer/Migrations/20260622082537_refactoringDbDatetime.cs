using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccsessLayer.Migrations
{
    /// <inheritdoc />
    public partial class refactoringDbDatetime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Db_WastePaperCost");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Db_WastePaperControl");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Db_VechileFuelLogs");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Db_SteamConsumption");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Db_SentezAllData");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Db_RetentionAnalysisHead");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Db_PapperMachineChemical");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Db_OilAnalysisReport");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Db_NaturelGasMeterMonitoring");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Db_LogisticsTrackingReport");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Db_KazanChemicalsHead");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Db_DoughPreparation");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Db_CumulativeElectricityConsumption");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Db_CirculationTankAirPressureMeasurementTurbidity");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Db_BufferAnalysisReport");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Db_BoilerSteamFeedWaterCondensateData");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Db_StarchAnalysisHeadingDetail",
                newName: "ReceiptDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReceiptDate",
                table: "Db_StarchAnalysisHeadingDetail",
                newName: "Date");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Db_WastePaperCost",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Db_WastePaperControl",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Db_VechileFuelLogs",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Date",
                table: "Db_SteamConsumption",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Db_SentezAllData",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Db_RetentionAnalysisHead",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Db_PapperMachineChemical",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Db_OilAnalysisReport",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Db_NaturelGasMeterMonitoring",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Db_LogisticsTrackingReport",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Db_KazanChemicalsHead",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Db_DoughPreparation",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Db_CumulativeElectricityConsumption",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Db_CirculationTankAirPressureMeasurementTurbidity",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Db_BufferAnalysisReport",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Db_BoilerSteamFeedWaterCondensateData",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
