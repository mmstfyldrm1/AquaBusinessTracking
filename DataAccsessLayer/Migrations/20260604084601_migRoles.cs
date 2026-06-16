using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccsessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Db_Permission",
                newName: "Module");

            migrationBuilder.AddColumn<string>(
                name: "Action",
                table: "Db_Permission",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Controller",
                table: "Db_Permission",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Db_RetentionAnalysisHead",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SampleCollectionTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    SampleResultTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    MachineSpeedRpm = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BasisWeightGrM2 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ProductionType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RetentionPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RetentionFeedLtMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PulpFlowLtMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    UnderScreenCaCO3 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SilicaLtHour = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AtcFeedLtHour = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PlydacmacFeedLtHour = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PacFeedLtHour = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DiscFilterPulpFlowLtMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    InUse = table.Column<short>(type: "smallint", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Db_RetentionAnalysisHead", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_RetentionAnalysisHead_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Db_RetentionAnalysisHead_Db_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Db_Department",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Db_RetentionAnalysisHead_Db_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Db_RetantionAnalysisDetail",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConsistencyPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AshGr = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FillerPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SrDegree = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Ph = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RetentionAnalysisHeadId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Db_RetantionAnalysisDetail", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_RetantionAnalysisDetail_Db_RetentionAnalysisHead_RetentionAnalysisHeadId",
                        column: x => x.RetentionAnalysisHeadId,
                        principalTable: "Db_RetentionAnalysisHead",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Db_RetantionAnalysisDetail_RetentionAnalysisHeadId",
                table: "Db_RetantionAnalysisDetail",
                column: "RetentionAnalysisHeadId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_RetentionAnalysisHead_AppUserId",
                table: "Db_RetentionAnalysisHead",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_RetentionAnalysisHead_DepartmentId",
                table: "Db_RetentionAnalysisHead",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_RetentionAnalysisHead_ShiftId",
                table: "Db_RetentionAnalysisHead",
                column: "ShiftId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Db_RetantionAnalysisDetail");

            migrationBuilder.DropTable(
                name: "Db_RetentionAnalysisHead");

            migrationBuilder.DropColumn(
                name: "Action",
                table: "Db_Permission");

            migrationBuilder.DropColumn(
                name: "Controller",
                table: "Db_Permission");

            migrationBuilder.RenameColumn(
                name: "Module",
                table: "Db_Permission",
                newName: "Name");
        }
    }
}
