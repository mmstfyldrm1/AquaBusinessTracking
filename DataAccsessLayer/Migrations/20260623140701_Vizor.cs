using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccsessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Vizor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShiftSupervisor",
                table: "Db_BufferProduction");

            migrationBuilder.AddColumn<int>(
                name: "ShiftSupervisorId",
                table: "Db_BufferProduction",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShiftSupervisorId",
                table: "Db_BufferProduction");

            migrationBuilder.AddColumn<string>(
                name: "ShiftSupervisor",
                table: "Db_BufferProduction",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
