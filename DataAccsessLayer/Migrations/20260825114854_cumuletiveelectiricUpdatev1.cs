using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccsessLayer.Migrations
{
    /// <inheritdoc />
    public partial class cumuletiveelectiricUpdatev1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "CapacitiveReactive",
                table: "Db_CumulativeElectricityConsumption",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "InductiveReactive",
                table: "Db_CumulativeElectricityConsumption",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CapacitiveReactive",
                table: "Db_CumulativeElectricityConsumption");

            migrationBuilder.DropColumn(
                name: "InductiveReactive",
                table: "Db_CumulativeElectricityConsumption");
        }
    }
}
