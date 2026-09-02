using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccsessLayer.Migrations
{
    /// <inheritdoc />
    public partial class KazansUpdatev1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Db_BoilerRoomDailyShiftMonitoring_AspNetUsers_AppUserId",
                table: "Db_BoilerRoomDailyShiftMonitoring");

            migrationBuilder.DropForeignKey(
                name: "FK_Db_BoilerRoomDailyShiftMonitoring_DB_KazanEnergyConsumption_ConsumptionPlaceId",
                table: "Db_BoilerRoomDailyShiftMonitoring");

            migrationBuilder.DropForeignKey(
                name: "FK_Db_BoilerRoomDailyShiftMonitoring_Db_Department_DepartmentId",
                table: "Db_BoilerRoomDailyShiftMonitoring");

            migrationBuilder.DropForeignKey(
                name: "FK_Db_BoilerRoomDailyShiftMonitoring_Db_Shift_ShiftId",
                table: "Db_BoilerRoomDailyShiftMonitoring");

            migrationBuilder.DropForeignKey(
                name: "FK_DB_KazanEnergyConsumption_AspNetUsers_AppUserId",
                table: "DB_KazanEnergyConsumption");

            migrationBuilder.DropForeignKey(
                name: "FK_DB_KazanEnergyConsumption_Db_Department_DepartmentId",
                table: "DB_KazanEnergyConsumption");

            migrationBuilder.DropForeignKey(
                name: "FK_DB_KazanEnergyConsumption_Db_Shift_ShiftId",
                table: "DB_KazanEnergyConsumption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DB_KazanEnergyConsumption",
                table: "DB_KazanEnergyConsumption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Db_BoilerRoomDailyShiftMonitoring",
                table: "Db_BoilerRoomDailyShiftMonitoring");

            migrationBuilder.RenameTable(
                name: "DB_KazanEnergyConsumption",
                newName: "Db_KazanEnergyConsumption");

            migrationBuilder.RenameTable(
                name: "Db_BoilerRoomDailyShiftMonitoring",
                newName: "Db_BoilerOperationandChemicalConsumption");

            migrationBuilder.RenameIndex(
                name: "IX_DB_KazanEnergyConsumption_ShiftId",
                table: "Db_KazanEnergyConsumption",
                newName: "IX_Db_KazanEnergyConsumption_ShiftId");

            migrationBuilder.RenameIndex(
                name: "IX_DB_KazanEnergyConsumption_DepartmentId",
                table: "Db_KazanEnergyConsumption",
                newName: "IX_Db_KazanEnergyConsumption_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_DB_KazanEnergyConsumption_AppUserId",
                table: "Db_KazanEnergyConsumption",
                newName: "IX_Db_KazanEnergyConsumption_AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Db_BoilerRoomDailyShiftMonitoring_ShiftId",
                table: "Db_BoilerOperationandChemicalConsumption",
                newName: "IX_Db_BoilerOperationandChemicalConsumption_ShiftId");

            migrationBuilder.RenameIndex(
                name: "IX_Db_BoilerRoomDailyShiftMonitoring_DepartmentId",
                table: "Db_BoilerOperationandChemicalConsumption",
                newName: "IX_Db_BoilerOperationandChemicalConsumption_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Db_BoilerRoomDailyShiftMonitoring_ConsumptionPlaceId",
                table: "Db_BoilerOperationandChemicalConsumption",
                newName: "IX_Db_BoilerOperationandChemicalConsumption_ConsumptionPlaceId");

            migrationBuilder.RenameIndex(
                name: "IX_Db_BoilerRoomDailyShiftMonitoring_AppUserId",
                table: "Db_BoilerOperationandChemicalConsumption",
                newName: "IX_Db_BoilerOperationandChemicalConsumption_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Db_KazanEnergyConsumption",
                table: "Db_KazanEnergyConsumption",
                column: "RecId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Db_BoilerOperationandChemicalConsumption",
                table: "Db_BoilerOperationandChemicalConsumption",
                column: "RecId");

            migrationBuilder.AddForeignKey(
                name: "FK_Db_BoilerOperationandChemicalConsumption_AspNetUsers_AppUserId",
                table: "Db_BoilerOperationandChemicalConsumption",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Db_BoilerOperationandChemicalConsumption_Db_Department_DepartmentId",
                table: "Db_BoilerOperationandChemicalConsumption",
                column: "DepartmentId",
                principalTable: "Db_Department",
                principalColumn: "RecId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Db_BoilerOperationandChemicalConsumption_Db_KazanEnergyConsumption_ConsumptionPlaceId",
                table: "Db_BoilerOperationandChemicalConsumption",
                column: "ConsumptionPlaceId",
                principalTable: "Db_KazanEnergyConsumption",
                principalColumn: "RecId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Db_BoilerOperationandChemicalConsumption_Db_Shift_ShiftId",
                table: "Db_BoilerOperationandChemicalConsumption",
                column: "ShiftId",
                principalTable: "Db_Shift",
                principalColumn: "RecId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Db_KazanEnergyConsumption_AspNetUsers_AppUserId",
                table: "Db_KazanEnergyConsumption",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Db_KazanEnergyConsumption_Db_Department_DepartmentId",
                table: "Db_KazanEnergyConsumption",
                column: "DepartmentId",
                principalTable: "Db_Department",
                principalColumn: "RecId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Db_KazanEnergyConsumption_Db_Shift_ShiftId",
                table: "Db_KazanEnergyConsumption",
                column: "ShiftId",
                principalTable: "Db_Shift",
                principalColumn: "RecId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Db_BoilerOperationandChemicalConsumption_AspNetUsers_AppUserId",
                table: "Db_BoilerOperationandChemicalConsumption");

            migrationBuilder.DropForeignKey(
                name: "FK_Db_BoilerOperationandChemicalConsumption_Db_Department_DepartmentId",
                table: "Db_BoilerOperationandChemicalConsumption");

            migrationBuilder.DropForeignKey(
                name: "FK_Db_BoilerOperationandChemicalConsumption_Db_KazanEnergyConsumption_ConsumptionPlaceId",
                table: "Db_BoilerOperationandChemicalConsumption");

            migrationBuilder.DropForeignKey(
                name: "FK_Db_BoilerOperationandChemicalConsumption_Db_Shift_ShiftId",
                table: "Db_BoilerOperationandChemicalConsumption");

            migrationBuilder.DropForeignKey(
                name: "FK_Db_KazanEnergyConsumption_AspNetUsers_AppUserId",
                table: "Db_KazanEnergyConsumption");

            migrationBuilder.DropForeignKey(
                name: "FK_Db_KazanEnergyConsumption_Db_Department_DepartmentId",
                table: "Db_KazanEnergyConsumption");

            migrationBuilder.DropForeignKey(
                name: "FK_Db_KazanEnergyConsumption_Db_Shift_ShiftId",
                table: "Db_KazanEnergyConsumption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Db_KazanEnergyConsumption",
                table: "Db_KazanEnergyConsumption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Db_BoilerOperationandChemicalConsumption",
                table: "Db_BoilerOperationandChemicalConsumption");

            migrationBuilder.RenameTable(
                name: "Db_KazanEnergyConsumption",
                newName: "DB_KazanEnergyConsumption");

            migrationBuilder.RenameTable(
                name: "Db_BoilerOperationandChemicalConsumption",
                newName: "Db_BoilerRoomDailyShiftMonitoring");

            migrationBuilder.RenameIndex(
                name: "IX_Db_KazanEnergyConsumption_ShiftId",
                table: "DB_KazanEnergyConsumption",
                newName: "IX_DB_KazanEnergyConsumption_ShiftId");

            migrationBuilder.RenameIndex(
                name: "IX_Db_KazanEnergyConsumption_DepartmentId",
                table: "DB_KazanEnergyConsumption",
                newName: "IX_DB_KazanEnergyConsumption_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Db_KazanEnergyConsumption_AppUserId",
                table: "DB_KazanEnergyConsumption",
                newName: "IX_DB_KazanEnergyConsumption_AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Db_BoilerOperationandChemicalConsumption_ShiftId",
                table: "Db_BoilerRoomDailyShiftMonitoring",
                newName: "IX_Db_BoilerRoomDailyShiftMonitoring_ShiftId");

            migrationBuilder.RenameIndex(
                name: "IX_Db_BoilerOperationandChemicalConsumption_DepartmentId",
                table: "Db_BoilerRoomDailyShiftMonitoring",
                newName: "IX_Db_BoilerRoomDailyShiftMonitoring_DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Db_BoilerOperationandChemicalConsumption_ConsumptionPlaceId",
                table: "Db_BoilerRoomDailyShiftMonitoring",
                newName: "IX_Db_BoilerRoomDailyShiftMonitoring_ConsumptionPlaceId");

            migrationBuilder.RenameIndex(
                name: "IX_Db_BoilerOperationandChemicalConsumption_AppUserId",
                table: "Db_BoilerRoomDailyShiftMonitoring",
                newName: "IX_Db_BoilerRoomDailyShiftMonitoring_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DB_KazanEnergyConsumption",
                table: "DB_KazanEnergyConsumption",
                column: "RecId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Db_BoilerRoomDailyShiftMonitoring",
                table: "Db_BoilerRoomDailyShiftMonitoring",
                column: "RecId");

            migrationBuilder.AddForeignKey(
                name: "FK_Db_BoilerRoomDailyShiftMonitoring_AspNetUsers_AppUserId",
                table: "Db_BoilerRoomDailyShiftMonitoring",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Db_BoilerRoomDailyShiftMonitoring_DB_KazanEnergyConsumption_ConsumptionPlaceId",
                table: "Db_BoilerRoomDailyShiftMonitoring",
                column: "ConsumptionPlaceId",
                principalTable: "DB_KazanEnergyConsumption",
                principalColumn: "RecId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Db_BoilerRoomDailyShiftMonitoring_Db_Department_DepartmentId",
                table: "Db_BoilerRoomDailyShiftMonitoring",
                column: "DepartmentId",
                principalTable: "Db_Department",
                principalColumn: "RecId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Db_BoilerRoomDailyShiftMonitoring_Db_Shift_ShiftId",
                table: "Db_BoilerRoomDailyShiftMonitoring",
                column: "ShiftId",
                principalTable: "Db_Shift",
                principalColumn: "RecId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DB_KazanEnergyConsumption_AspNetUsers_AppUserId",
                table: "DB_KazanEnergyConsumption",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DB_KazanEnergyConsumption_Db_Department_DepartmentId",
                table: "DB_KazanEnergyConsumption",
                column: "DepartmentId",
                principalTable: "Db_Department",
                principalColumn: "RecId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DB_KazanEnergyConsumption_Db_Shift_ShiftId",
                table: "DB_KazanEnergyConsumption",
                column: "ShiftId",
                principalTable: "Db_Shift",
                principalColumn: "RecId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
