using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccsessLayer.Migrations
{
    /// <inheritdoc />
    public partial class shipmentorderv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Db_ShipmentOrderPlan",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentAccountId = table.Column<int>(type: "int", nullable: false),
                    CurrentAccountCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentAccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlanDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Db_ShipmentOrderPlan", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_ShipmentOrderPlan_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_ShipmentOrderPlan_Db_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Db_Department",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_ShipmentOrderPlan_Db_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Db_ShipmentOrderPlanDetail",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShipmentPlanId = table.Column<int>(type: "int", nullable: false),
                    OrderNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaperType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grammage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Width = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tonnage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Checklist = table.Column<bool>(type: "bit", nullable: false),
                    DeliveryNoteNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Shipped = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Db_ShipmentOrderPlanDetail", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_ShipmentOrderPlanDetail_Db_ShipmentOrderPlan_ShipmentPlanId",
                        column: x => x.ShipmentPlanId,
                        principalTable: "Db_ShipmentOrderPlan",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Db_ShipmentOrderPlan_AppUserId",
                table: "Db_ShipmentOrderPlan",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_ShipmentOrderPlan_DepartmentId",
                table: "Db_ShipmentOrderPlan",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_ShipmentOrderPlan_ShiftId",
                table: "Db_ShipmentOrderPlan",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_ShipmentOrderPlanDetail_ShipmentPlanId",
                table: "Db_ShipmentOrderPlanDetail",
                column: "ShipmentPlanId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Db_ShipmentOrderPlanDetail");

            migrationBuilder.DropTable(
                name: "Db_ShipmentOrderPlan");
        }
    }
}
