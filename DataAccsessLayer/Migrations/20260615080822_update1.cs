using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccsessLayer.Migrations
{
    /// <inheritdoc />
    public partial class update1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Db_CumulativeElectricityConsumption_AspNetUsers_AppUserId",
                table: "Db_CumulativeElectricityConsumption");

            migrationBuilder.DropForeignKey(
                name: "FK_Db_CumulativeElectricityConsumption_Dd_ElectricMeterLocation_ElectricMeterLocationId",
                table: "Db_CumulativeElectricityConsumption");

            migrationBuilder.DropForeignKey(
                name: "FK_Dd_ElectricMeterLocation_AspNetUsers_AppUserId",
                table: "Dd_ElectricMeterLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_Dd_ElectricMeterLocation_Db_Shift_ShiftId",
                table: "Dd_ElectricMeterLocation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Dd_ElectricMeterLocation",
                table: "Dd_ElectricMeterLocation");

            migrationBuilder.RenameTable(
                name: "Dd_ElectricMeterLocation",
                newName: "Db_ElectricMeterLocation");

            migrationBuilder.RenameIndex(
                name: "IX_Dd_ElectricMeterLocation_ShiftId",
                table: "Db_ElectricMeterLocation",
                newName: "IX_Db_ElectricMeterLocation_ShiftId");

            migrationBuilder.RenameIndex(
                name: "IX_Dd_ElectricMeterLocation_AppUserId",
                table: "Db_ElectricMeterLocation",
                newName: "IX_Db_ElectricMeterLocation_AppUserId");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Db_CumulativeElectricityConsumption",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Db_ElectricMeterLocation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Db_ElectricMeterLocation",
                table: "Db_ElectricMeterLocation",
                column: "RecId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_CumulativeElectricityConsumption_DepartmentId",
                table: "Db_CumulativeElectricityConsumption",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_ElectricMeterLocation_DepartmentId",
                table: "Db_ElectricMeterLocation",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Db_CumulativeElectricityConsumption_AspNetUsers_AppUserId",
                table: "Db_CumulativeElectricityConsumption",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Db_CumulativeElectricityConsumption_Db_Department_DepartmentId",
                table: "Db_CumulativeElectricityConsumption",
                column: "DepartmentId",
                principalTable: "Db_Department",
                principalColumn: "RecId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Db_CumulativeElectricityConsumption_Db_ElectricMeterLocation_ElectricMeterLocationId",
                table: "Db_CumulativeElectricityConsumption",
                column: "ElectricMeterLocationId",
                principalTable: "Db_ElectricMeterLocation",
                principalColumn: "RecId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Db_ElectricMeterLocation_AspNetUsers_AppUserId",
                table: "Db_ElectricMeterLocation",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Db_ElectricMeterLocation_Db_Department_DepartmentId",
                table: "Db_ElectricMeterLocation",
                column: "DepartmentId",
                principalTable: "Db_Department",
                principalColumn: "RecId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Db_ElectricMeterLocation_Db_Shift_ShiftId",
                table: "Db_ElectricMeterLocation",
                column: "ShiftId",
                principalTable: "Db_Shift",
                principalColumn: "RecId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Db_CumulativeElectricityConsumption_AspNetUsers_AppUserId",
                table: "Db_CumulativeElectricityConsumption");

            migrationBuilder.DropForeignKey(
                name: "FK_Db_CumulativeElectricityConsumption_Db_Department_DepartmentId",
                table: "Db_CumulativeElectricityConsumption");

            migrationBuilder.DropForeignKey(
                name: "FK_Db_CumulativeElectricityConsumption_Db_ElectricMeterLocation_ElectricMeterLocationId",
                table: "Db_CumulativeElectricityConsumption");

            migrationBuilder.DropForeignKey(
                name: "FK_Db_ElectricMeterLocation_AspNetUsers_AppUserId",
                table: "Db_ElectricMeterLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_Db_ElectricMeterLocation_Db_Department_DepartmentId",
                table: "Db_ElectricMeterLocation");

            migrationBuilder.DropForeignKey(
                name: "FK_Db_ElectricMeterLocation_Db_Shift_ShiftId",
                table: "Db_ElectricMeterLocation");

            migrationBuilder.DropIndex(
                name: "IX_Db_CumulativeElectricityConsumption_DepartmentId",
                table: "Db_CumulativeElectricityConsumption");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Db_ElectricMeterLocation",
                table: "Db_ElectricMeterLocation");

            migrationBuilder.DropIndex(
                name: "IX_Db_ElectricMeterLocation_DepartmentId",
                table: "Db_ElectricMeterLocation");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Db_CumulativeElectricityConsumption");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Db_ElectricMeterLocation");

            migrationBuilder.RenameTable(
                name: "Db_ElectricMeterLocation",
                newName: "Dd_ElectricMeterLocation");

            migrationBuilder.RenameIndex(
                name: "IX_Db_ElectricMeterLocation_ShiftId",
                table: "Dd_ElectricMeterLocation",
                newName: "IX_Dd_ElectricMeterLocation_ShiftId");

            migrationBuilder.RenameIndex(
                name: "IX_Db_ElectricMeterLocation_AppUserId",
                table: "Dd_ElectricMeterLocation",
                newName: "IX_Dd_ElectricMeterLocation_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Dd_ElectricMeterLocation",
                table: "Dd_ElectricMeterLocation",
                column: "RecId");

            migrationBuilder.AddForeignKey(
                name: "FK_Db_CumulativeElectricityConsumption_AspNetUsers_AppUserId",
                table: "Db_CumulativeElectricityConsumption",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Db_CumulativeElectricityConsumption_Dd_ElectricMeterLocation_ElectricMeterLocationId",
                table: "Db_CumulativeElectricityConsumption",
                column: "ElectricMeterLocationId",
                principalTable: "Dd_ElectricMeterLocation",
                principalColumn: "RecId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dd_ElectricMeterLocation_AspNetUsers_AppUserId",
                table: "Dd_ElectricMeterLocation",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Dd_ElectricMeterLocation_Db_Shift_ShiftId",
                table: "Dd_ElectricMeterLocation",
                column: "ShiftId",
                principalTable: "Db_Shift",
                principalColumn: "RecId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
