using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccsessLayer.Migrations
{
    /// <inheritdoc />
    public partial class kazanenergyv3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Db_BoilerOperationandChemicalConsumption_ScalePlaceId",
                table: "Db_BoilerOperationandChemicalConsumption",
                column: "ScalePlaceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Db_BoilerOperationandChemicalConsumption_Db_Department_ScalePlaceId",
                table: "Db_BoilerOperationandChemicalConsumption",
                column: "ScalePlaceId",
                principalTable: "Db_Department",
                principalColumn: "RecId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Db_BoilerOperationandChemicalConsumption_Db_Department_ScalePlaceId",
                table: "Db_BoilerOperationandChemicalConsumption");

            migrationBuilder.DropIndex(
                name: "IX_Db_BoilerOperationandChemicalConsumption_ScalePlaceId",
                table: "Db_BoilerOperationandChemicalConsumption");
        }
    }
}
