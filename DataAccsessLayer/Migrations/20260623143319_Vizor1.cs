using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccsessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Vizor1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShiftSupervisorId",
                table: "Db_BufferProduction",
                newName: "ShiftSupervisorUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_BufferProduction_ShiftSupervisorUserId",
                table: "Db_BufferProduction",
                column: "ShiftSupervisorUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Db_BufferProduction_AspNetUsers_ShiftSupervisorUserId",
                table: "Db_BufferProduction",
                column: "ShiftSupervisorUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Db_BufferProduction_AspNetUsers_ShiftSupervisorUserId",
                table: "Db_BufferProduction");

            migrationBuilder.DropIndex(
                name: "IX_Db_BufferProduction_ShiftSupervisorUserId",
                table: "Db_BufferProduction");

            migrationBuilder.RenameColumn(
                name: "ShiftSupervisorUserId",
                table: "Db_BufferProduction",
                newName: "ShiftSupervisorId");
        }
    }
}
