using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccsessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailReportRecipient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DB_EmailReportRecipient",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(320)", maxLength: 320, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
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
                    table.PrimaryKey("PK_DB_EmailReportRecipient", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_DB_EmailReportRecipient_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DB_EmailReportRecipient_Db_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Db_Department",
                        principalColumn: "RecId");
                    table.ForeignKey(
                        name: "FK_DB_EmailReportRecipient_Db_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DB_EmailReportRecipient_AppUserId",
                table: "DB_EmailReportRecipient",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DB_EmailReportRecipient_DepartmentId",
                table: "DB_EmailReportRecipient",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DB_EmailReportRecipient_ReportCode_EmailAddress",
                table: "DB_EmailReportRecipient",
                columns: new[] { "ReportCode", "EmailAddress" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DB_EmailReportRecipient_ShiftId",
                table: "DB_EmailReportRecipient",
                column: "ShiftId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DB_EmailReportRecipient");
        }
    }
}
