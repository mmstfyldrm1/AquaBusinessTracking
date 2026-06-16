using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccsessLayer.Migrations
{
    /// <inheritdoc />
    public partial class plcIntegrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Db_PlcMachine",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rack = table.Column<int>(type: "int", nullable: false),
                    Slot = table.Column<int>(type: "int", nullable: false),
                    CpuType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Db_PlcMachine", x => x.RecId);
                });

            migrationBuilder.CreateTable(
                name: "Db_PlcTags",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Group = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    MachineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Db_PlcTags", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_PlcTags_Db_PlcMachine_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Db_PlcMachine",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Db_PlcReading",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReadingTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Value = table.Column<double>(type: "float", nullable: false),
                    PlcTagId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Db_PlcReading", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_PlcReading_Db_PlcTags_PlcTagId",
                        column: x => x.PlcTagId,
                        principalTable: "Db_PlcTags",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Db_PlcReading_PlcTagId",
                table: "Db_PlcReading",
                column: "PlcTagId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_PlcReading_ReadingTime",
                table: "Db_PlcReading",
                column: "ReadingTime");

            migrationBuilder.CreateIndex(
                name: "IX_Db_PlcTags_MachineId",
                table: "Db_PlcTags",
                column: "MachineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Db_PlcReading");

            migrationBuilder.DropTable(
                name: "Db_PlcTags");

            migrationBuilder.DropTable(
                name: "Db_PlcMachine");
        }
    }
}
