using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccsessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migelectircCum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dd_ElectricMeterLocation",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: true),
                    AppUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dd_ElectricMeterLocation", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Dd_ElectricMeterLocation_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Dd_ElectricMeterLocation_Db_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Db_CumulativeElectricityConsumption",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Consumption = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsertedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ElectricMeterLocationId = table.Column<int>(type: "int", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: true),
                    AppUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Db_CumulativeElectricityConsumption", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_CumulativeElectricityConsumption_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Db_CumulativeElectricityConsumption_Db_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_CumulativeElectricityConsumption_Dd_ElectricMeterLocation_ElectricMeterLocationId",
                        column: x => x.ElectricMeterLocationId,
                        principalTable: "Dd_ElectricMeterLocation",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Db_CumulativeElectricityConsumption_AppUserId",
                table: "Db_CumulativeElectricityConsumption",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_CumulativeElectricityConsumption_ElectricMeterLocationId",
                table: "Db_CumulativeElectricityConsumption",
                column: "ElectricMeterLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_CumulativeElectricityConsumption_ShiftId",
                table: "Db_CumulativeElectricityConsumption",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Dd_ElectricMeterLocation_AppUserId",
                table: "Dd_ElectricMeterLocation",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Dd_ElectricMeterLocation_ShiftId",
                table: "Dd_ElectricMeterLocation",
                column: "ShiftId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Db_CumulativeElectricityConsumption");

            migrationBuilder.DropTable(
                name: "Dd_ElectricMeterLocation");
        }
    }
}
