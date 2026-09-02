using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccsessLayer.Migrations
{
    /// <inheritdoc />
    public partial class logistickRecaftoringv3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UploadStatus",
                table: "Db_LogisticsTrackingReport");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Db_LogisticsTrackingReport",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Db_LogisticsTrackingReport",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "UploadStatus",
                table: "Db_LogisticsTrackingReport",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
