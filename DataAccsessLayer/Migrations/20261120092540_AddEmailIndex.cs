using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccsessLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DB_EmailReportRecipient_ReportCode_EmailAddress",
                table: "DB_EmailReportRecipient");

            migrationBuilder.CreateIndex(
                name: "IX_DB_EmailReportRecipient_ReportCode_EmailAddress",
                table: "DB_EmailReportRecipient",
                columns: new[] { "ReportCode", "EmailAddress" },
                unique: true,
                filter: "[DeleteDate] IS NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DB_EmailReportRecipient_ReportCode_EmailAddress",
                table: "DB_EmailReportRecipient");

            migrationBuilder.CreateIndex(
                name: "IX_DB_EmailReportRecipient_ReportCode_EmailAddress",
                table: "DB_EmailReportRecipient",
                columns: new[] { "ReportCode", "EmailAddress" },
                unique: true);
        }
    }
}
