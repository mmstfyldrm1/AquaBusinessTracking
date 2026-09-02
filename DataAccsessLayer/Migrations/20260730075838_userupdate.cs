using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccsessLayer.Migrations
{
    /// <inheritdoc />
    public partial class userupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GapSuperVisior",
                table: "Db_SalesScale");

            migrationBuilder.DropColumn(
                name: "Operator",
                table: "Db_IncomingGoodsTracking");

            migrationBuilder.DropColumn(
                name: "PersonelToWork",
                table: "Db_BoilerRoomDailyShiftMonitoring");

            migrationBuilder.AddColumn<int>(
                name: "GapSuperVisiorId",
                table: "Db_SalesScale",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OperatorId",
                table: "Db_IncomingGoodsTracking",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonelToWorkId",
                table: "Db_BoilerRoomDailyShiftMonitoring",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GapSuperVisiorId",
                table: "Db_SalesScale");

            migrationBuilder.DropColumn(
                name: "OperatorId",
                table: "Db_IncomingGoodsTracking");

            migrationBuilder.DropColumn(
                name: "PersonelToWorkId",
                table: "Db_BoilerRoomDailyShiftMonitoring");

            migrationBuilder.AddColumn<string>(
                name: "GapSuperVisior",
                table: "Db_SalesScale",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Operator",
                table: "Db_IncomingGoodsTracking",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PersonelToWork",
                table: "Db_BoilerRoomDailyShiftMonitoring",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
