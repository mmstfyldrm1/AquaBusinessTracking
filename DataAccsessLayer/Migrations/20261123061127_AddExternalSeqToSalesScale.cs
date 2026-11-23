using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccsessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddExternalSeqToSalesScale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ExternalSeq",
                table: "Db_SalesScale",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ExternalSeq",
                table: "Db_RawMaterialIntake",
                type: "bigint",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ExternalSeq",
                table: "Db_SalesScale");

            migrationBuilder.DropColumn(
                name: "ExternalSeq",
                table: "Db_RawMaterialIntake");
        }
    }
}
