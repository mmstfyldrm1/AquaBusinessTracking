using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccsessLayer.Migrations
{
    /// <inheritdoc />
    public partial class logistickRecaftoringv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Db_LogisticsTrackingReport");

            migrationBuilder.DropColumn(
                name: "Explanation",
                table: "Db_DailyShipmentPlan");

            migrationBuilder.DropColumn(
                name: "IncomingCurrentAccountName",
                table: "Db_DailyShipmentPlan");

            migrationBuilder.DropColumn(
                name: "Quanity",
                table: "Db_DailyShipmentPlan");

            migrationBuilder.DropColumn(
                name: "ReturnDate",
                table: "Db_DailyShipmentPlan");

            migrationBuilder.DropColumn(
                name: "SentezInventoryCode",
                table: "Db_DailyShipmentPlan");

            migrationBuilder.DropColumn(
                name: "WarehouseEntryDate",
                table: "Db_DailyShipmentPlan");

            migrationBuilder.RenameColumn(
                name: "Vehicle",
                table: "Db_LogisticsTrackingReport",
                newName: "UploadStatus");

            migrationBuilder.RenameColumn(
                name: "DriverNameOrPlate",
                table: "Db_LogisticsTrackingReport",
                newName: "TruckPlate");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Db_LogisticsTrackingReport",
                newName: "TrailerType");

            migrationBuilder.RenameColumn(
                name: "ArrivalLocation",
                table: "Db_LogisticsTrackingReport",
                newName: "TrailerPlate");

            migrationBuilder.RenameColumn(
                name: "WaybillNo",
                table: "Db_DailyShipmentPlan",
                newName: "ShipmentNo");

            migrationBuilder.RenameColumn(
                name: "WaybillInvoiceNo",
                table: "Db_DailyShipmentPlan",
                newName: "District");

            migrationBuilder.RenameColumn(
                name: "WaitingTime",
                table: "Db_DailyShipmentPlan",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "Unit",
                table: "Db_DailyShipmentPlan",
                newName: "CompanyName");

            migrationBuilder.RenameColumn(
                name: "SentezInventoryName",
                table: "Db_DailyShipmentPlan",
                newName: "CompanyCode");

            migrationBuilder.RenameColumn(
                name: "SentezInventoryGroup",
                table: "Db_DailyShipmentPlan",
                newName: "City");

            migrationBuilder.AddColumn<string>(
                name: "ArrivalCity",
                table: "Db_LogisticsTrackingReport",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ArrivalDistrict",
                table: "Db_LogisticsTrackingReport",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "CoilQuantity",
                table: "Db_LogisticsTrackingReport",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "DriverIdentityNumber",
                table: "Db_LogisticsTrackingReport",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DriverName",
                table: "Db_LogisticsTrackingReport",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DriverPhone",
                table: "Db_LogisticsTrackingReport",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "LoadingDepartureTime",
                table: "Db_LogisticsTrackingReport",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LoadingEntryTime",
                table: "Db_LogisticsTrackingReport",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "OperationDuration",
                table: "Db_LogisticsTrackingReport",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<decimal>(
                name: "ScaleQuantity",
                table: "Db_LogisticsTrackingReport",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ShipmentPlanId",
                table: "Db_LogisticsTrackingReport",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Db_DailyShipmentPlan",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Db_LogisticsTrackingReport_ShipmentPlanId",
                table: "Db_LogisticsTrackingReport",
                column: "ShipmentPlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_Db_LogisticsTrackingReport_Db_DailyShipmentPlan_ShipmentPlanId",
                table: "Db_LogisticsTrackingReport",
                column: "ShipmentPlanId",
                principalTable: "Db_DailyShipmentPlan",
                principalColumn: "RecId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Db_LogisticsTrackingReport_Db_DailyShipmentPlan_ShipmentPlanId",
                table: "Db_LogisticsTrackingReport");

            migrationBuilder.DropIndex(
                name: "IX_Db_LogisticsTrackingReport_ShipmentPlanId",
                table: "Db_LogisticsTrackingReport");

            migrationBuilder.DropColumn(
                name: "ArrivalCity",
                table: "Db_LogisticsTrackingReport");

            migrationBuilder.DropColumn(
                name: "ArrivalDistrict",
                table: "Db_LogisticsTrackingReport");

            migrationBuilder.DropColumn(
                name: "CoilQuantity",
                table: "Db_LogisticsTrackingReport");

            migrationBuilder.DropColumn(
                name: "DriverIdentityNumber",
                table: "Db_LogisticsTrackingReport");

            migrationBuilder.DropColumn(
                name: "DriverName",
                table: "Db_LogisticsTrackingReport");

            migrationBuilder.DropColumn(
                name: "DriverPhone",
                table: "Db_LogisticsTrackingReport");

            migrationBuilder.DropColumn(
                name: "LoadingDepartureTime",
                table: "Db_LogisticsTrackingReport");

            migrationBuilder.DropColumn(
                name: "LoadingEntryTime",
                table: "Db_LogisticsTrackingReport");

            migrationBuilder.DropColumn(
                name: "OperationDuration",
                table: "Db_LogisticsTrackingReport");

            migrationBuilder.DropColumn(
                name: "ScaleQuantity",
                table: "Db_LogisticsTrackingReport");

            migrationBuilder.DropColumn(
                name: "ShipmentPlanId",
                table: "Db_LogisticsTrackingReport");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Db_DailyShipmentPlan");

            migrationBuilder.RenameColumn(
                name: "UploadStatus",
                table: "Db_LogisticsTrackingReport",
                newName: "Vehicle");

            migrationBuilder.RenameColumn(
                name: "TruckPlate",
                table: "Db_LogisticsTrackingReport",
                newName: "DriverNameOrPlate");

            migrationBuilder.RenameColumn(
                name: "TrailerType",
                table: "Db_LogisticsTrackingReport",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "TrailerPlate",
                table: "Db_LogisticsTrackingReport",
                newName: "ArrivalLocation");

            migrationBuilder.RenameColumn(
                name: "ShipmentNo",
                table: "Db_DailyShipmentPlan",
                newName: "WaybillNo");

            migrationBuilder.RenameColumn(
                name: "District",
                table: "Db_DailyShipmentPlan",
                newName: "WaybillInvoiceNo");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Db_DailyShipmentPlan",
                newName: "WaitingTime");

            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "Db_DailyShipmentPlan",
                newName: "Unit");

            migrationBuilder.RenameColumn(
                name: "CompanyCode",
                table: "Db_DailyShipmentPlan",
                newName: "SentezInventoryName");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Db_DailyShipmentPlan",
                newName: "SentezInventoryGroup");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Db_LogisticsTrackingReport",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Explanation",
                table: "Db_DailyShipmentPlan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IncomingCurrentAccountName",
                table: "Db_DailyShipmentPlan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Quanity",
                table: "Db_DailyShipmentPlan",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "ReturnDate",
                table: "Db_DailyShipmentPlan",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<string>(
                name: "SentezInventoryCode",
                table: "Db_DailyShipmentPlan",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "WarehouseEntryDate",
                table: "Db_DailyShipmentPlan",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
