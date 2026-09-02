using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccsessLayer.Migrations
{
    /// <inheritdoc />
    public partial class kazanenergyv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ConsumptionQuantity",
                table: "Db_BoilerOperationandChemicalConsumption",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "ScalePlaceId",
                table: "Db_BoilerOperationandChemicalConsumption",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConsumptionQuantity",
                table: "Db_BoilerOperationandChemicalConsumption");

            migrationBuilder.DropColumn(
                name: "ScalePlaceId",
                table: "Db_BoilerOperationandChemicalConsumption");
        }
    }
}
