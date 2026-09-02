using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccsessLayer.Migrations
{
    /// <inheritdoc />
    public partial class KazansUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NextShiftWork",
                table: "Db_BoilerRoomDailyShiftMonitoring");

            migrationBuilder.DropColumn(
                name: "WorkIsDone",
                table: "Db_BoilerRoomDailyShiftMonitoring");

            migrationBuilder.DropColumn(
                name: "WorkPermit",
                table: "Db_BoilerRoomDailyShiftMonitoring");

            migrationBuilder.RenameColumn(
                name: "PersonelToWorkId",
                table: "Db_BoilerRoomDailyShiftMonitoring",
                newName: "ConsumptionPlaceId");

            migrationBuilder.AlterColumn<string>(
                name: "Explanation",
                table: "Db_BoilerRoomDailyShiftMonitoring",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "DB_KazanEnergyConsumption",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConsumptionPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConsumptionUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReceiptDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ShiftId = table.Column<int>(type: "int", nullable: true),
                    AppUserId = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InUse = table.Column<short>(type: "smallint", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DB_KazanEnergyConsumption", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_DB_KazanEnergyConsumption_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DB_KazanEnergyConsumption_Db_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Db_Department",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DB_KazanEnergyConsumption_Db_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Db_BoilerRoomDailyShiftMonitoring_ConsumptionPlaceId",
                table: "Db_BoilerRoomDailyShiftMonitoring",
                column: "ConsumptionPlaceId");

            migrationBuilder.CreateIndex(
                name: "IX_DB_KazanEnergyConsumption_AppUserId",
                table: "DB_KazanEnergyConsumption",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DB_KazanEnergyConsumption_DepartmentId",
                table: "DB_KazanEnergyConsumption",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DB_KazanEnergyConsumption_ShiftId",
                table: "DB_KazanEnergyConsumption",
                column: "ShiftId");

            migrationBuilder.AddForeignKey(
                name: "FK_Db_BoilerRoomDailyShiftMonitoring_DB_KazanEnergyConsumption_ConsumptionPlaceId",
                table: "Db_BoilerRoomDailyShiftMonitoring",
                column: "ConsumptionPlaceId",
                principalTable: "DB_KazanEnergyConsumption",
                principalColumn: "RecId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Db_BoilerRoomDailyShiftMonitoring_DB_KazanEnergyConsumption_ConsumptionPlaceId",
                table: "Db_BoilerRoomDailyShiftMonitoring");

            migrationBuilder.DropTable(
                name: "DB_KazanEnergyConsumption");

            migrationBuilder.DropIndex(
                name: "IX_Db_BoilerRoomDailyShiftMonitoring_ConsumptionPlaceId",
                table: "Db_BoilerRoomDailyShiftMonitoring");

            migrationBuilder.RenameColumn(
                name: "ConsumptionPlaceId",
                table: "Db_BoilerRoomDailyShiftMonitoring",
                newName: "PersonelToWorkId");

            migrationBuilder.AlterColumn<string>(
                name: "Explanation",
                table: "Db_BoilerRoomDailyShiftMonitoring",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NextShiftWork",
                table: "Db_BoilerRoomDailyShiftMonitoring",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "WorkIsDone",
                table: "Db_BoilerRoomDailyShiftMonitoring",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "WorkPermit",
                table: "Db_BoilerRoomDailyShiftMonitoring",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
