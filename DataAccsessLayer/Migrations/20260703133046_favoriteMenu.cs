using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccsessLayer.Migrations
{
    /// <inheritdoc />
    public partial class favoriteMenu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Db_FavoriteMenuItem",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleId = table.Column<int>(type: "int", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayOrder = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Db_FavoriteMenuItem", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_FavoriteMenuItem_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_FavoriteMenuItem_Db_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Db_Department",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Db_FavoriteMenuItem_Db_Permission_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "Db_Permission",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_FavoriteMenuItem_Db_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Db_FavoriteMenuItem_AppUserId",
                table: "Db_FavoriteMenuItem",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_FavoriteMenuItem_DepartmentId",
                table: "Db_FavoriteMenuItem",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_FavoriteMenuItem_ModuleId",
                table: "Db_FavoriteMenuItem",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_FavoriteMenuItem_ShiftId",
                table: "Db_FavoriteMenuItem",
                column: "ShiftId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Db_FavoriteMenuItem");
        }
    }
}
