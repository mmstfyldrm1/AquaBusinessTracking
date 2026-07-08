using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccsessLayer.Migrations
{
    /// <inheritdoc />
    public partial class BufferProduction : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Db_BufferProduction",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftSupervisor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Product = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GrPerM2 = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BufferNo = table.Column<int>(type: "int", nullable: false),
                    BufferStart = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BufferEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalDurationMinutes = table.Column<int>(type: "int", nullable: false),
                    DowntimeMinutes = table.Column<int>(type: "int", nullable: false),
                    BufferSpeed = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BufferWidthCm = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BufferSetCount = table.Column<int>(type: "int", nullable: false),
                    TheoreticalBufferKg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MeasuredKg = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiptDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ShiftId = table.Column<int>(type: "int", nullable: true),
                    AppUserId = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InUse = table.Column<short>(type: "smallint", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Db_BufferProduction", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_BufferProduction_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_BufferProduction_Db_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Db_Department",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_BufferProduction_Db_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Db_BufferProduction_AppUserId",
                table: "Db_BufferProduction",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_BufferProduction_DepartmentId",
                table: "Db_BufferProduction",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_BufferProduction_ShiftId",
                table: "Db_BufferProduction",
                column: "ShiftId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Db_BufferProduction");
        }
    }
}
