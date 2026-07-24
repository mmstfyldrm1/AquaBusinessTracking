using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccsessLayer.Migrations
{
    /// <inheritdoc />
    public partial class IncomeTracking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Db_IncomingGoodsTracking",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WaybillNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScaleHours = table.Column<TimeSpan>(type: "time", nullable: false),
                    ReceiptNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentAccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InventoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Operator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WaybillQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FilledQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EmptyQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceiptDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ShiftId = table.Column<int>(type: "int", nullable: true),
                    AppUserId = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InUse = table.Column<short>(type: "smallint", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Db_IncomingGoodsTracking", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_IncomingGoodsTracking_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_IncomingGoodsTracking_Db_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Db_Department",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_IncomingGoodsTracking_Db_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Db_RawMaterialIntake",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScaleHours = table.Column<TimeSpan>(type: "time", nullable: false),
                    WaybillNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentAccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TruckPlate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Operator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WaybillQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FilledQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmptyQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ReceiptDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ShiftId = table.Column<int>(type: "int", nullable: true),
                    AppUserId = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InUse = table.Column<short>(type: "smallint", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Db_RawMaterialIntake", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_RawMaterialIntake_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_RawMaterialIntake_Db_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Db_Department",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_RawMaterialIntake_Db_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Db_IncomingGoodsTracking_AppUserId",
                table: "Db_IncomingGoodsTracking",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_IncomingGoodsTracking_DepartmentId",
                table: "Db_IncomingGoodsTracking",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_IncomingGoodsTracking_ShiftId",
                table: "Db_IncomingGoodsTracking",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_RawMaterialIntake_AppUserId",
                table: "Db_RawMaterialIntake",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_RawMaterialIntake_DepartmentId",
                table: "Db_RawMaterialIntake",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_RawMaterialIntake_ShiftId",
                table: "Db_RawMaterialIntake",
                column: "ShiftId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Db_IncomingGoodsTracking");

            migrationBuilder.DropTable(
                name: "Db_RawMaterialIntake");
        }
    }
}
