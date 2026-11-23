using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccsessLayer.Migrations
{
    /// <inheritdoc />
    public partial class machineStopv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DowntimeReason",
                table: "Db_MachineStop",
                newName: "ReasonDisconnection");

            migrationBuilder.RenameColumn(
                name: "BreakLocation",
                table: "Db_MachineStop",
                newName: "PointofRupture");

            migrationBuilder.AddColumn<string>(
                name: "Equipment",
                table: "Db_MachineStop",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Equipment",
                table: "Db_MachineStop");

            migrationBuilder.RenameColumn(
                name: "ReasonDisconnection",
                table: "Db_MachineStop",
                newName: "DowntimeReason");

            migrationBuilder.RenameColumn(
                name: "PointofRupture",
                table: "Db_MachineStop",
                newName: "BreakLocation");
        }
    }
}
