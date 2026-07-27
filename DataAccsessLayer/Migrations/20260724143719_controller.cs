using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccsessLayer.Migrations
{
    /// <inheritdoc />
    public partial class controller : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Controller",
                table: "Db_FavoriteMenuItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Controller",
                table: "Db_FavoriteMenuItem");
        }
    }
}
