using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccsessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migkazanUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Db_KazanChemicalsDetail");

            migrationBuilder.AddColumn<decimal>(
                name: "Consumption",
                table: "Db_KazanChemicalsHead",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Incoming",
                table: "Db_KazanChemicalsHead",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Remaining",
                table: "Db_KazanChemicalsHead",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Consumption",
                table: "Db_KazanChemicalsHead");

            migrationBuilder.DropColumn(
                name: "Incoming",
                table: "Db_KazanChemicalsHead");

            migrationBuilder.DropColumn(
                name: "Remaining",
                table: "Db_KazanChemicalsHead");

            migrationBuilder.CreateTable(
                name: "Db_KazanChemicalsDetail",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KazanChemicalsHeadId = table.Column<int>(type: "int", nullable: false),
                    Consumption = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    InUse = table.Column<short>(type: "smallint", nullable: true),
                    Incoming = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Remaining = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Db_KazanChemicalsDetail", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_KazanChemicalsDetail_Db_KazanChemicalsHead_KazanChemicalsHeadId",
                        column: x => x.KazanChemicalsHeadId,
                        principalTable: "Db_KazanChemicalsHead",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Db_KazanChemicalsDetail_KazanChemicalsHeadId",
                table: "Db_KazanChemicalsDetail",
                column: "KazanChemicalsHeadId");
        }
    }
}
