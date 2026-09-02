using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccsessLayer.Migrations
{
    /// <inheritdoc />
    public partial class userupdatev2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Operator",
                table: "Db_RawMaterialIntake");

            migrationBuilder.AddColumn<int>(
                name: "OperatorId",
                table: "Db_RawMaterialIntake",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OperatorId",
                table: "Db_RawMaterialIntake");

            migrationBuilder.AddColumn<string>(
                name: "Operator",
                table: "Db_RawMaterialIntake",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
