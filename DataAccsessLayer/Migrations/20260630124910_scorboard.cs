using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccsessLayer.Migrations
{
    /// <inheritdoc />
    public partial class scorboard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Db_PurificationChemicalsConsumption_AspNetUsers_AppUserId",
                table: "Db_PurificationChemicalsConsumption");

            migrationBuilder.DropForeignKey(
                name: "FK_Db_PurificationChemicalsConsumption_Db_Department_DepartmentId",
                table: "Db_PurificationChemicalsConsumption");

            migrationBuilder.DropForeignKey(
                name: "FK_Db_SentezAllData_AspNetUsers_AppUserId",
                table: "Db_SentezAllData");

            migrationBuilder.DropForeignKey(
                name: "FK_Db_SentezAllData_Db_Shift_ShiftId",
                table: "Db_SentezAllData");

            migrationBuilder.CreateTable(
                name: "Db_PlanningScorBoardView",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlanNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UploadPdf = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    table.PrimaryKey("PK_Db_PlanningScorBoardView", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_PlanningScorBoardView_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_PlanningScorBoardView_Db_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Db_Department",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_PlanningScorBoardView_Db_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Db_PlanningScorBoardView_AppUserId",
                table: "Db_PlanningScorBoardView",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_PlanningScorBoardView_DepartmentId",
                table: "Db_PlanningScorBoardView",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_PlanningScorBoardView_ShiftId",
                table: "Db_PlanningScorBoardView",
                column: "ShiftId");

            migrationBuilder.AddForeignKey(
                name: "FK_Db_PurificationChemicalsConsumption_AspNetUsers_AppUserId",
                table: "Db_PurificationChemicalsConsumption",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Db_PurificationChemicalsConsumption_Db_Department_DepartmentId",
                table: "Db_PurificationChemicalsConsumption",
                column: "DepartmentId",
                principalTable: "Db_Department",
                principalColumn: "RecId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Db_SentezAllData_AspNetUsers_AppUserId",
                table: "Db_SentezAllData",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Db_SentezAllData_Db_Shift_ShiftId",
                table: "Db_SentezAllData",
                column: "ShiftId",
                principalTable: "Db_Shift",
                principalColumn: "RecId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Db_PurificationChemicalsConsumption_AspNetUsers_AppUserId",
                table: "Db_PurificationChemicalsConsumption");

            migrationBuilder.DropForeignKey(
                name: "FK_Db_PurificationChemicalsConsumption_Db_Department_DepartmentId",
                table: "Db_PurificationChemicalsConsumption");

            migrationBuilder.DropForeignKey(
                name: "FK_Db_SentezAllData_AspNetUsers_AppUserId",
                table: "Db_SentezAllData");

            migrationBuilder.DropForeignKey(
                name: "FK_Db_SentezAllData_Db_Shift_ShiftId",
                table: "Db_SentezAllData");

            migrationBuilder.DropTable(
                name: "Db_PlanningScorBoardView");

            migrationBuilder.AddForeignKey(
                name: "FK_Db_PurificationChemicalsConsumption_AspNetUsers_AppUserId",
                table: "Db_PurificationChemicalsConsumption",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Db_PurificationChemicalsConsumption_Db_Department_DepartmentId",
                table: "Db_PurificationChemicalsConsumption",
                column: "DepartmentId",
                principalTable: "Db_Department",
                principalColumn: "RecId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Db_SentezAllData_AspNetUsers_AppUserId",
                table: "Db_SentezAllData",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Db_SentezAllData_Db_Shift_ShiftId",
                table: "Db_SentezAllData",
                column: "ShiftId",
                principalTable: "Db_Shift",
                principalColumn: "RecId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
