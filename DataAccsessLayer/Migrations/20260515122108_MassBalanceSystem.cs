using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccsessLayer.Migrations
{
    /// <inheritdoc />
    public partial class MassBalanceSystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Db_Department",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InUse = table.Column<short>(type: "smallint", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Db_Department", x => x.RecId);
                });

            migrationBuilder.CreateTable(
                name: "Db_Permission",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Db_Permission", x => x.RecId);
                });

            migrationBuilder.CreateTable(
                name: "Db_Shift",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShiftCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShiftStartHours = table.Column<TimeSpan>(type: "time", nullable: true),
                    ShiftEndHours = table.Column<TimeSpan>(type: "time", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InUse = table.Column<short>(type: "smallint", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Db_Shift", x => x.RecId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    ShiftTitle = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Db_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Db_Department",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Db_RolePermission",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Db_RolePermission", x => new { x.RoleId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_Db_RolePermission_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_RolePermission_Db_Permission_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Db_Permission",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Db_Basin",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InUse = table.Column<short>(type: "smallint", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Db_Basin", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_Basin_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_Basin_Db_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Db_Department",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_Basin_Db_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Db_BoilerSteamFeedWaterCondensateData",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Boil = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FeedWater = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KM2Kodens = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Hvac = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InUse = table.Column<short>(type: "smallint", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Db_BoilerSteamFeedWaterCondensateData", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_BoilerSteamFeedWaterCondensateData_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_BoilerSteamFeedWaterCondensateData_Db_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Db_Department",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_BoilerSteamFeedWaterCondensateData_Db_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Db_BufferAnalysisReport",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BufferExitTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    SampleCollectionTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    SampleResultTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    BufferNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TargetGrammage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GrammageTop = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GrammageMiddle = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GrammageBottom = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LabAverageGrammage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    QcsGrammage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ThicknessMicrons = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MoistureTop = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MoistureMiddle = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MoistureBottom = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AverageMoisture = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    QcsMoisture = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BurstStrengthKpa = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BurstIndex = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Cobb60Uncoated = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Cobb60Coated = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RctKnM = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CmtNewton = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CctKnM = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SctCd = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SctIndexCd = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GurleyPorosity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BentsenPorosityUncoated = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ColorLStar = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ColorAStar = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ColorBStar = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TensileStrengthWidth = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TensileStrengthLength = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FillerPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DyeDosageAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SizerGrammage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Starch = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Silica = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SuitableForMondi = table.Column<bool>(type: "bit", nullable: true),
                    AquaEcoFL16 = table.Column<bool>(type: "bit", nullable: true),
                    AquaFL18 = table.Column<bool>(type: "bit", nullable: true),
                    AquaPowerFL20 = table.Column<bool>(type: "bit", nullable: true),
                    AquaHighPowerFL22 = table.Column<bool>(type: "bit", nullable: true),
                    AquaTestliner = table.Column<bool>(type: "bit", nullable: true),
                    TlProductionGivenToFl = table.Column<bool>(type: "bit", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InUse = table.Column<short>(type: "smallint", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Db_BufferAnalysisReport", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_BufferAnalysisReport_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_BufferAnalysisReport_Db_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Db_Department",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_BufferAnalysisReport_Db_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Db_BufferGramajProfile",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BufferNo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SampleNo = table.Column<int>(type: "int", nullable: false),
                    Gramaj = table.Column<int>(type: "int", nullable: false),
                    Thickness = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Db_BufferGramajProfile", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_BufferGramajProfile_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_BufferGramajProfile_Db_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Db_Department",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_BufferGramajProfile_Db_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Db_CirculationTankAirPressureMeasurementTurbidity",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<TimeSpan>(type: "time", nullable: false),
                    MachineSpeed = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grammage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TurnCount = table.Column<int>(type: "int", nullable: false),
                    Fau = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Ntu = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InUse = table.Column<short>(type: "smallint", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Db_CirculationTankAirPressureMeasurementTurbidity", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_CirculationTankAirPressureMeasurementTurbidity_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_CirculationTankAirPressureMeasurementTurbidity_Db_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Db_Department",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_CirculationTankAirPressureMeasurementTurbidity_Db_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Db_DoughPreparation",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PulperNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InventoryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InventoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QueueNo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Clippings = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Bale = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KG = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    InUse = table.Column<short>(type: "smallint", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Db_DoughPreparation", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_DoughPreparation_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_DoughPreparation_Db_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Db_Department",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_DoughPreparation_Db_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Db_DoughPreparationAnalysisResults",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SampleCollectionTime = table.Column<int>(type: "int", nullable: false),
                    SampleResultDeliveryTime = table.Column<int>(type: "int", nullable: false),
                    SampleTakenLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KM = table.Column<float>(type: "real", nullable: false),
                    SR = table.Column<int>(type: "int", nullable: false),
                    DryMatter = table.Column<int>(type: "int", nullable: false),
                    pH = table.Column<float>(type: "real", nullable: false),
                    Conductivity = table.Column<int>(type: "int", nullable: false),
                    CaCO3 = table.Column<int>(type: "int", nullable: false),
                    Filling = table.Column<float>(type: "real", nullable: false),
                    Blur = table.Column<int>(type: "int", nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    InUse = table.Column<short>(type: "smallint", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Db_DoughPreparationAnalysisResults", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_DoughPreparationAnalysisResults_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_DoughPreparationAnalysisResults_Db_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Db_Department",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_DoughPreparationAnalysisResults_Db_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Db_ElectricMotorTracking",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ElectricMotorOrderNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ElectricMotorBrand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    kW = table.Column<float>(type: "real", nullable: false),
                    Voltage = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    InUse = table.Column<short>(type: "smallint", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Db_ElectricMotorTracking", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_ElectricMotorTracking_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_ElectricMotorTracking_Db_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Db_Department",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_ElectricMotorTracking_Db_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Db_ElectricShiftWork",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Db_ElectricShiftWork", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_ElectricShiftWork_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_ElectricShiftWork_Db_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Db_Department",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_ElectricShiftWork_Db_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Db_KazanChemicalsHead",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InventoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                    table.PrimaryKey("PK_Db_KazanChemicalsHead", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_KazanChemicalsHead_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_KazanChemicalsHead_Db_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Db_Department",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_KazanChemicalsHead_Db_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Db_KazanDailyShiftMonitoring",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShihtId = table.Column<int>(type: "int", nullable: false),
                    ShiftUserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobDone = table.Column<int>(type: "int", nullable: false),
                    InventoryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InventoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Permission = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InUse = table.Column<short>(type: "smallint", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Db_KazanDailyShiftMonitoring", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_KazanDailyShiftMonitoring_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_KazanDailyShiftMonitoring_Db_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Db_Department",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_KazanDailyShiftMonitoring_Db_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_KazanDailyShiftMonitoring_Db_Shift_ShihtId",
                        column: x => x.ShihtId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Db_LabWork",
                columns: table => new
                {
                    Recıd = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LabTestName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LabTestRequest = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LabTestCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LabTestUserNames = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    InUse = table.Column<short>(type: "smallint", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Db_LabWork", x => x.Recıd);
                    table.ForeignKey(
                        name: "FK_Db_LabWork_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_LabWork_Db_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Db_Department",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_LabWork_Db_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Db_LogisticsTrackingReport",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CarrierCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartureLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ArrivalLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vehicle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DriverNameOrPlate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ProcessingCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    InUse = table.Column<short>(type: "smallint", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Db_LogisticsTrackingReport", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_LogisticsTrackingReport_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_LogisticsTrackingReport_Db_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Db_Department",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_LogisticsTrackingReport_Db_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DB_MassWasteBalance",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    WasteCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreviousMonthCarryover = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    UsedInProduction = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NextMonthCarryover = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    InUse = table.Column<short>(type: "smallint", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DB_MassWasteBalance", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_DB_MassWasteBalance_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DB_MassWasteBalance_Db_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Db_Department",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DB_MassWasteBalance_Db_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DB_MassWasteSupplier",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Month = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GrossWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NetWeight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WasteCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    InUse = table.Column<short>(type: "smallint", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DB_MassWasteSupplier", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_DB_MassWasteSupplier_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DB_MassWasteSupplier_Db_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Db_Department",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DB_MassWasteSupplier_Db_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Db_NaturelGasMeterMonitoring",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DailyConsumption = table.Column<int>(type: "int", nullable: false),
                    Pressure = table.Column<float>(type: "real", nullable: false),
                    Heat = table.Column<float>(type: "real", nullable: false),
                    CalorificValue = table.Column<float>(type: "real", nullable: false),
                    StandartCubicmeter = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ConversionFactor = table.Column<float>(type: "real", nullable: false),
                    kW = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Control = table.Column<int>(type: "int", nullable: false),
                    IsApproved = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InUse = table.Column<short>(type: "smallint", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Db_NaturelGasMeterMonitoring", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_NaturelGasMeterMonitoring_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_NaturelGasMeterMonitoring_Db_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Db_Department",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_NaturelGasMeterMonitoring_Db_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Db_OilAnalysisReport",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    MyProperty = table.Column<int>(type: "int", nullable: false),
                    Hours = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    InUse = table.Column<short>(type: "smallint", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Db_OilAnalysisReport", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_OilAnalysisReport_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_OilAnalysisReport_Db_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Db_Department",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_OilAnalysisReport_Db_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Db_PapperMachineChemical",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InventoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IncomingQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ConsumedQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RemainingQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    table.PrimaryKey("PK_Db_PapperMachineChemical", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_PapperMachineChemical_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_PapperMachineChemical_Db_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Db_Department",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_PapperMachineChemical_Db_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Db_PurificationChemicalsConsumption",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InventoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    IncomingQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ConsumedQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RemainingQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    table.PrimaryKey("PK_Db_PurificationChemicalsConsumption", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_PurificationChemicalsConsumption_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_PurificationChemicalsConsumption_Db_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Db_Department",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_PurificationChemicalsConsumption_Db_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Db_SalesScale",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ScaleDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScaleHours = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScaleNo = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DeliveryNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CurrentAccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TruckPlate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    DeliveryQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ScaleQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ScaleGap = table.Column<int>(type: "int", nullable: true),
                    GapSuperVisior = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GapDesicion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    InUse = table.Column<short>(type: "smallint", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Db_SalesScale", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_SalesScale_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_SalesScale_Db_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Db_Department",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_SalesScale_Db_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Db_SentezAllData",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BufferNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grammage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BufferRollDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: true),
                    IdealMachineSpeed = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ActualMachineSpeed = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SpeedReductionReason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BufferWidth = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ProducedQuantityKg = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DefectiveQuantityKg = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetProductionKg = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RetentionDosageLtMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RetentionDosagePercent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SizerStarchGsm = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OperatingStarchSolidContent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OperatingStarchTemperature = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PreparationStarchSolidContent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PreparationStarchTemperature = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    QualityControlNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MeasuredGrammageAvg = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MeasuredThicknessAvg = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MeasuredMoistureAvg = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BurstStrengthKpa = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BurstIndex = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SctCd = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SctIndex = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RctKgf = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EctKnM = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CctKnM = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CmtKnM = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GurleyPorositySec = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BendsenPorosity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Cobb60Absorption = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TensileSpeed = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Schopper = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Filler = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Ash = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ColorL = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ColorA = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ColorB = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Laborant = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SilicaAdded = table.Column<bool>(type: "bit", nullable: true),
                    SilicaDosageAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AtcAdded = table.Column<bool>(type: "bit", nullable: true),
                    AtcAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DyeDosageAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    SuitableForSpecialCustomer = table.Column<bool>(type: "bit", nullable: true),
                    ComplaintReceived = table.Column<bool>(type: "bit", nullable: true),
                    QcsGrammage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    QcsMoisture = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MachineSr = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PulpChestSr = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    InUse = table.Column<short>(type: "smallint", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Db_SentezAllData", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_SentezAllData_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_SentezAllData_Db_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Db_Department",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_SentezAllData_Db_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Db_SentezNotOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupplierCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SynthesisCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductMaterial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductMaterialGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WarehouseEntryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    WaitingPeriod = table.Column<int>(type: "int", nullable: true),
                    PurchaseDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    InUse = table.Column<short>(type: "smallint", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Db_SentezNotOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Db_SentezNotOrder_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Db_SentezNotOrder_Db_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Db_Department",
                        principalColumn: "RecId");
                    table.ForeignKey(
                        name: "FK_Db_SentezNotOrder_Db_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Db_StarchAnalysisHeading",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SampleCollectionTime = table.Column<int>(type: "int", nullable: false),
                    SampleResultDeliveryTime = table.Column<int>(type: "int", nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    InUse = table.Column<short>(type: "smallint", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Db_StarchAnalysisHeading", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_StarchAnalysisHeading_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_StarchAnalysisHeading_Db_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Db_Department",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_StarchAnalysisHeading_Db_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Db_SteamConsumption",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Day = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<TimeSpan>(type: "time", nullable: false),
                    ConsumptionQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    InUse = table.Column<short>(type: "smallint", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Db_SteamConsumption", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_SteamConsumption_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_SteamConsumption_Db_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Db_Department",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_SteamConsumption_Db_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Db_TestHeader",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestDepartmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_Db_TestHeader", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_TestHeader_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_TestHeader_Db_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Db_Department",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_TestHeader_Db_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Db_VechileFuelLogs",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleLicensePlate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EngineHourOrKm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FuelDeliveredLiters = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Recipient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResponsibleDepartment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FuelPricePerLiter = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    InUse = table.Column<short>(type: "smallint", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Db_VechileFuelLogs", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_VechileFuelLogs_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_VechileFuelLogs_Db_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Db_Department",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_VechileFuelLogs_Db_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Db_WarehouseRequestWait",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WaybillNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WaybillInvoiceNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IncomingCurrentAccountName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SentezInventoryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SentezInventoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quanity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SentezInventoryGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    WarehouseEntryDate = table.Column<TimeSpan>(type: "time", nullable: false),
                    ReturnDate = table.Column<TimeSpan>(type: "time", nullable: false),
                    WaitingTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    InUse = table.Column<short>(type: "smallint", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Db_WarehouseRequestWait", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_WarehouseRequestWait_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_WarehouseRequestWait_Db_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Db_Department",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_WarehouseRequestWait_Db_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Db_WastePaperControl",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SequenceNumber = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WaybillNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleLicensePlate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfBales = table.Column<int>(type: "int", nullable: true),
                    ReceivedPaperType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CorrugatedPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MixedPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    WaybillQuantityKg = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GrossVehicleWeightKg = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EmptyVehicleWeightKg = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GrossEntryQuantityKg = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AverageBaleWeightKg = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ForeignMaterialPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DeviceMoisturePercent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OvenMoisturePercent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AverageMoisturePercent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MoistureExemptionPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetMoisturePercent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MoistureDeductionKg = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ForeignMaterialDeductionKg = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetInvoiceBaseKg = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InUse = table.Column<short>(type: "smallint", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Db_WastePaperControl", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_WastePaperControl_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_WastePaperControl_Db_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Db_Department",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_WastePaperControl_Db_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Db_WastePaperCost",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SequenceNumber = table.Column<int>(type: "int", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WaybillNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Company = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    VehicleLicensePlate = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NumberOfBales = table.Column<int>(type: "int", nullable: true),
                    ReceivedPaperType = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CorrugatedPercent = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    MixedPercent = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    WaybillQuantityKg = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GrossVehicleWeightKg = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EmptyVehicleWeightKg = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GrossEntryQuantityKg = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AverageBaleWeightKg = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ForeignMaterialPercent = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    DeviceMoisturePercent = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    OvenMoisturePercent = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    AverageMoisturePercent = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    MoistureExemptionPercent = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    NetMoisturePercent = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    MoistureDeductionKg = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ForeignMaterialDeductionKg = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetInvoiceBaseKg = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AgreedPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    GrossAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NetPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    NetAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InUse = table.Column<short>(type: "smallint", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Db_WastePaperCost", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_WastePaperCost_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_WastePaperCost_Db_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Db_Department",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_WastePaperCost_Db_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Db_WaterPreparationAndConsumption",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InventoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IncomingQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ConsumedQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    RemainingQuantity = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
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
                    table.PrimaryKey("PK_Db_WaterPreparationAndConsumption", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_WaterPreparationAndConsumption_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_WaterPreparationAndConsumption_Db_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Db_Department",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_WaterPreparationAndConsumption_Db_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Db_WaterTreatmentAnalysisResults",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SampleCollectionTime = table.Column<int>(type: "int", nullable: false),
                    SampleResultDeliveryTime = table.Column<int>(type: "int", nullable: false),
                    SampleTakenLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DryMatter = table.Column<int>(type: "int", nullable: false),
                    Filling = table.Column<float>(type: "real", nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    InUse = table.Column<short>(type: "smallint", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Db_WaterTreatmentAnalysisResults", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_WaterTreatmentAnalysisResults_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_WaterTreatmentAnalysisResults_Db_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Db_Department",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_WaterTreatmentAnalysisResults_Db_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Db_WinderCoilLengthControl",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoilWidth = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WinderCoilLength = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Gramaj = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    TheoreticCoilLength = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CoilLengthDifference = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CoilLengthDeflection = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    InUse = table.Column<short>(type: "smallint", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Db_WinderCoilLengthControl", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_WinderCoilLengthControl_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_WinderCoilLengthControl_Db_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Db_Department",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_WinderCoilLengthControl_Db_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Db_WinderCoilTracking",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppUserId = table.Column<int>(type: "int", nullable: false),
                    BufferNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaperType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SetNo = table.Column<int>(type: "int", nullable: false),
                    Gramaj = table.Column<int>(type: "int", nullable: false),
                    SetCutterStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SetCutterEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MachineSpeed = table.Column<int>(type: "int", nullable: false),
                    CoilDiameter = table.Column<float>(type: "real", nullable: false),
                    CoilLength = table.Column<int>(type: "int", nullable: false),
                    OutDiamater = table.Column<int>(type: "int", nullable: false),
                    AdditionalNumber = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false),
                    Coil1 = table.Column<int>(type: "int", nullable: true),
                    Coil2 = table.Column<int>(type: "int", nullable: true),
                    Coil3 = table.Column<int>(type: "int", nullable: true),
                    Coil4 = table.Column<int>(type: "int", nullable: true),
                    Coil5 = table.Column<int>(type: "int", nullable: true),
                    Coil6 = table.Column<int>(type: "int", nullable: true),
                    Coil7 = table.Column<int>(type: "int", nullable: true),
                    Coil8 = table.Column<int>(type: "int", nullable: true),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InsertDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    InUse = table.Column<short>(type: "smallint", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Db_WinderCoilTracking", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_WinderCoilTracking_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_WinderCoilTracking_Db_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Db_Department",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Db_WinderCoilTracking_Db_Shift_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "Db_Shift",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Db_BasinMeasurement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BasinId = table.Column<int>(type: "int", nullable: false),
                    EnteranceAKM = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OutAKM = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EnteranceKOI = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OutKOI = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TN = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Fosfat = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    pH = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Renk = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DO = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Imhoff = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StartHours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndHours = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Db_BasinMeasurement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Db_BasinMeasurement_Db_Basin_BasinId",
                        column: x => x.BasinId,
                        principalTable: "Db_Basin",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Db_KazanChemicalsDetail",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Incoming = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Consumption = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Remaining = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    KazanChemicalsHeadId = table.Column<int>(type: "int", nullable: false),
                    InUse = table.Column<short>(type: "smallint", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Db_KazanChemicalsDetail", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_KazanChemicalsDetail_Db_KazanChemicalsHead_KazanChemicalsHeadId",
                        column: x => x.KazanChemicalsHeadId,
                        principalTable: "Db_KazanChemicalsHead",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Db_StarchAnalysisHeadingDetail",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Time = table.Column<TimeSpan>(type: "time", nullable: true),
                    MachineSpeed = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ProductionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Grammage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TurnCount = table.Column<int>(type: "int", nullable: true),
                    Fau = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Ntu = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DryMatterOven = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DryMatterRefractometer = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Temperature1 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ViscosityCp1 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ViscosityFord1 = table.Column<int>(type: "int", nullable: true),
                    StarchAnalysisHeadingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Db_StarchAnalysisHeadingDetail", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_StarchAnalysisHeadingDetail_Db_StarchAnalysisHeading_StarchAnalysisHeadingId",
                        column: x => x.StarchAnalysisHeadingId,
                        principalTable: "Db_StarchAnalysisHeading",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Db_TestDetail",
                columns: table => new
                {
                    RecId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InletFlowRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    InletDryMatterPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PolyelectrolyteConcentration = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PolyelectrolyteFlowRate = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BowlSpeed = table.Column<int>(type: "int", nullable: true),
                    ActualTorque = table.Column<int>(type: "int", nullable: true),
                    ActualDifferentialSpeed = table.Column<int>(type: "int", nullable: true),
                    CentrateWeirLevel = table.Column<int>(type: "int", nullable: true),
                    CakeDryMatterPercent = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CentrateTSS = table.Column<int>(type: "int", nullable: true),
                    PolyelectrolyteConsumption = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BowlTorque = table.Column<int>(type: "int", nullable: true),
                    Vibration = table.Column<int>(type: "int", nullable: true),
                    EnergyConsumption = table.Column<int>(type: "int", nullable: true),
                    EnergyConsumptionPerFeed = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TestHeaderId = table.Column<int>(type: "int", nullable: false),
                    InUse = table.Column<short>(type: "smallint", nullable: true),
                    DeletedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Db_TestDetail", x => x.RecId);
                    table.ForeignKey(
                        name: "FK_Db_TestDetail_Db_TestHeader_TestHeaderId",
                        column: x => x.TestHeaderId,
                        principalTable: "Db_TestHeader",
                        principalColumn: "RecId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartmentId",
                table: "AspNetUsers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Db_Basin_AppUserId",
                table: "Db_Basin",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_Basin_DepartmentId",
                table: "Db_Basin",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_Basin_ShiftId",
                table: "Db_Basin",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_BasinMeasurement_BasinId",
                table: "Db_BasinMeasurement",
                column: "BasinId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_BoilerSteamFeedWaterCondensateData_AppUserId",
                table: "Db_BoilerSteamFeedWaterCondensateData",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_BoilerSteamFeedWaterCondensateData_DepartmentId",
                table: "Db_BoilerSteamFeedWaterCondensateData",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_BoilerSteamFeedWaterCondensateData_ShiftId",
                table: "Db_BoilerSteamFeedWaterCondensateData",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_BufferAnalysisReport_AppUserId",
                table: "Db_BufferAnalysisReport",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_BufferAnalysisReport_DepartmentId",
                table: "Db_BufferAnalysisReport",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_BufferAnalysisReport_ShiftId",
                table: "Db_BufferAnalysisReport",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_BufferGramajProfile_AppUserId",
                table: "Db_BufferGramajProfile",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_BufferGramajProfile_DepartmentId",
                table: "Db_BufferGramajProfile",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_BufferGramajProfile_ShiftId",
                table: "Db_BufferGramajProfile",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_CirculationTankAirPressureMeasurementTurbidity_AppUserId",
                table: "Db_CirculationTankAirPressureMeasurementTurbidity",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_CirculationTankAirPressureMeasurementTurbidity_DepartmentId",
                table: "Db_CirculationTankAirPressureMeasurementTurbidity",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_CirculationTankAirPressureMeasurementTurbidity_ShiftId",
                table: "Db_CirculationTankAirPressureMeasurementTurbidity",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_DoughPreparation_AppUserId",
                table: "Db_DoughPreparation",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_DoughPreparation_DepartmentId",
                table: "Db_DoughPreparation",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_DoughPreparation_ShiftId",
                table: "Db_DoughPreparation",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_DoughPreparationAnalysisResults_AppUserId",
                table: "Db_DoughPreparationAnalysisResults",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_DoughPreparationAnalysisResults_DepartmentId",
                table: "Db_DoughPreparationAnalysisResults",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_DoughPreparationAnalysisResults_ShiftId",
                table: "Db_DoughPreparationAnalysisResults",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_ElectricMotorTracking_AppUserId",
                table: "Db_ElectricMotorTracking",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_ElectricMotorTracking_DepartmentId",
                table: "Db_ElectricMotorTracking",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_ElectricMotorTracking_ShiftId",
                table: "Db_ElectricMotorTracking",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_ElectricShiftWork_AppUserId",
                table: "Db_ElectricShiftWork",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_ElectricShiftWork_DepartmentId",
                table: "Db_ElectricShiftWork",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_ElectricShiftWork_ShiftId",
                table: "Db_ElectricShiftWork",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_KazanChemicalsDetail_KazanChemicalsHeadId",
                table: "Db_KazanChemicalsDetail",
                column: "KazanChemicalsHeadId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_KazanChemicalsHead_AppUserId",
                table: "Db_KazanChemicalsHead",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_KazanChemicalsHead_DepartmentId",
                table: "Db_KazanChemicalsHead",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_KazanChemicalsHead_ShiftId",
                table: "Db_KazanChemicalsHead",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_KazanDailyShiftMonitoring_AppUserId",
                table: "Db_KazanDailyShiftMonitoring",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_KazanDailyShiftMonitoring_DepartmentId",
                table: "Db_KazanDailyShiftMonitoring",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_KazanDailyShiftMonitoring_ShiftId",
                table: "Db_KazanDailyShiftMonitoring",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_KazanDailyShiftMonitoring_ShihtId",
                table: "Db_KazanDailyShiftMonitoring",
                column: "ShihtId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_LabWork_AppUserId",
                table: "Db_LabWork",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_LabWork_DepartmentId",
                table: "Db_LabWork",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_LabWork_ShiftId",
                table: "Db_LabWork",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_LogisticsTrackingReport_AppUserId",
                table: "Db_LogisticsTrackingReport",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_LogisticsTrackingReport_DepartmentId",
                table: "Db_LogisticsTrackingReport",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_LogisticsTrackingReport_ShiftId",
                table: "Db_LogisticsTrackingReport",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_DB_MassWasteBalance_AppUserId",
                table: "DB_MassWasteBalance",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DB_MassWasteBalance_DepartmentId",
                table: "DB_MassWasteBalance",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DB_MassWasteBalance_ShiftId",
                table: "DB_MassWasteBalance",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_DB_MassWasteSupplier_AppUserId",
                table: "DB_MassWasteSupplier",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_DB_MassWasteSupplier_DepartmentId",
                table: "DB_MassWasteSupplier",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DB_MassWasteSupplier_ShiftId",
                table: "DB_MassWasteSupplier",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_NaturelGasMeterMonitoring_AppUserId",
                table: "Db_NaturelGasMeterMonitoring",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_NaturelGasMeterMonitoring_DepartmentId",
                table: "Db_NaturelGasMeterMonitoring",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_NaturelGasMeterMonitoring_ShiftId",
                table: "Db_NaturelGasMeterMonitoring",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_OilAnalysisReport_AppUserId",
                table: "Db_OilAnalysisReport",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_OilAnalysisReport_DepartmentId",
                table: "Db_OilAnalysisReport",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_OilAnalysisReport_ShiftId",
                table: "Db_OilAnalysisReport",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_PapperMachineChemical_AppUserId",
                table: "Db_PapperMachineChemical",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_PapperMachineChemical_DepartmentId",
                table: "Db_PapperMachineChemical",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_PapperMachineChemical_ShiftId",
                table: "Db_PapperMachineChemical",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_PurificationChemicalsConsumption_AppUserId",
                table: "Db_PurificationChemicalsConsumption",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_PurificationChemicalsConsumption_DepartmentId",
                table: "Db_PurificationChemicalsConsumption",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_PurificationChemicalsConsumption_ShiftId",
                table: "Db_PurificationChemicalsConsumption",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_RolePermission_PermissionId",
                table: "Db_RolePermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_SalesScale_AppUserId",
                table: "Db_SalesScale",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_SalesScale_DepartmentId",
                table: "Db_SalesScale",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_SalesScale_ShiftId",
                table: "Db_SalesScale",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_SentezAllData_AppUserId",
                table: "Db_SentezAllData",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_SentezAllData_DepartmentId",
                table: "Db_SentezAllData",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_SentezAllData_ShiftId",
                table: "Db_SentezAllData",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_SentezNotOrder_AppUserId",
                table: "Db_SentezNotOrder",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_SentezNotOrder_DepartmentId",
                table: "Db_SentezNotOrder",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_SentezNotOrder_ShiftId",
                table: "Db_SentezNotOrder",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_StarchAnalysisHeading_AppUserId",
                table: "Db_StarchAnalysisHeading",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_StarchAnalysisHeading_DepartmentId",
                table: "Db_StarchAnalysisHeading",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_StarchAnalysisHeading_ShiftId",
                table: "Db_StarchAnalysisHeading",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_StarchAnalysisHeadingDetail_StarchAnalysisHeadingId",
                table: "Db_StarchAnalysisHeadingDetail",
                column: "StarchAnalysisHeadingId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_SteamConsumption_AppUserId",
                table: "Db_SteamConsumption",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_SteamConsumption_DepartmentId",
                table: "Db_SteamConsumption",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_SteamConsumption_ShiftId",
                table: "Db_SteamConsumption",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_TestDetail_TestHeaderId",
                table: "Db_TestDetail",
                column: "TestHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_TestHeader_AppUserId",
                table: "Db_TestHeader",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_TestHeader_DepartmentId",
                table: "Db_TestHeader",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_TestHeader_ShiftId",
                table: "Db_TestHeader",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_VechileFuelLogs_AppUserId",
                table: "Db_VechileFuelLogs",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_VechileFuelLogs_DepartmentId",
                table: "Db_VechileFuelLogs",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_VechileFuelLogs_ShiftId",
                table: "Db_VechileFuelLogs",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_WarehouseRequestWait_AppUserId",
                table: "Db_WarehouseRequestWait",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_WarehouseRequestWait_DepartmentId",
                table: "Db_WarehouseRequestWait",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_WarehouseRequestWait_ShiftId",
                table: "Db_WarehouseRequestWait",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_WastePaperControl_AppUserId",
                table: "Db_WastePaperControl",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_WastePaperControl_DepartmentId",
                table: "Db_WastePaperControl",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_WastePaperControl_ShiftId",
                table: "Db_WastePaperControl",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_WastePaperCost_AppUserId",
                table: "Db_WastePaperCost",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_WastePaperCost_DepartmentId",
                table: "Db_WastePaperCost",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_WastePaperCost_ShiftId",
                table: "Db_WastePaperCost",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_WaterPreparationAndConsumption_AppUserId",
                table: "Db_WaterPreparationAndConsumption",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_WaterPreparationAndConsumption_DepartmentId",
                table: "Db_WaterPreparationAndConsumption",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_WaterPreparationAndConsumption_ShiftId",
                table: "Db_WaterPreparationAndConsumption",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_WaterTreatmentAnalysisResults_AppUserId",
                table: "Db_WaterTreatmentAnalysisResults",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_WaterTreatmentAnalysisResults_DepartmentId",
                table: "Db_WaterTreatmentAnalysisResults",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_WaterTreatmentAnalysisResults_ShiftId",
                table: "Db_WaterTreatmentAnalysisResults",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_WinderCoilLengthControl_AppUserId",
                table: "Db_WinderCoilLengthControl",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_WinderCoilLengthControl_DepartmentId",
                table: "Db_WinderCoilLengthControl",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_WinderCoilLengthControl_ShiftId",
                table: "Db_WinderCoilLengthControl",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_WinderCoilTracking_AppUserId",
                table: "Db_WinderCoilTracking",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_WinderCoilTracking_DepartmentId",
                table: "Db_WinderCoilTracking",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Db_WinderCoilTracking_ShiftId",
                table: "Db_WinderCoilTracking",
                column: "ShiftId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Db_BasinMeasurement");

            migrationBuilder.DropTable(
                name: "Db_BoilerSteamFeedWaterCondensateData");

            migrationBuilder.DropTable(
                name: "Db_BufferAnalysisReport");

            migrationBuilder.DropTable(
                name: "Db_BufferGramajProfile");

            migrationBuilder.DropTable(
                name: "Db_CirculationTankAirPressureMeasurementTurbidity");

            migrationBuilder.DropTable(
                name: "Db_DoughPreparation");

            migrationBuilder.DropTable(
                name: "Db_DoughPreparationAnalysisResults");

            migrationBuilder.DropTable(
                name: "Db_ElectricMotorTracking");

            migrationBuilder.DropTable(
                name: "Db_ElectricShiftWork");

            migrationBuilder.DropTable(
                name: "Db_KazanChemicalsDetail");

            migrationBuilder.DropTable(
                name: "Db_KazanDailyShiftMonitoring");

            migrationBuilder.DropTable(
                name: "Db_LabWork");

            migrationBuilder.DropTable(
                name: "Db_LogisticsTrackingReport");

            migrationBuilder.DropTable(
                name: "DB_MassWasteBalance");

            migrationBuilder.DropTable(
                name: "DB_MassWasteSupplier");

            migrationBuilder.DropTable(
                name: "Db_NaturelGasMeterMonitoring");

            migrationBuilder.DropTable(
                name: "Db_OilAnalysisReport");

            migrationBuilder.DropTable(
                name: "Db_PapperMachineChemical");

            migrationBuilder.DropTable(
                name: "Db_PurificationChemicalsConsumption");

            migrationBuilder.DropTable(
                name: "Db_RolePermission");

            migrationBuilder.DropTable(
                name: "Db_SalesScale");

            migrationBuilder.DropTable(
                name: "Db_SentezAllData");

            migrationBuilder.DropTable(
                name: "Db_SentezNotOrder");

            migrationBuilder.DropTable(
                name: "Db_StarchAnalysisHeadingDetail");

            migrationBuilder.DropTable(
                name: "Db_SteamConsumption");

            migrationBuilder.DropTable(
                name: "Db_TestDetail");

            migrationBuilder.DropTable(
                name: "Db_VechileFuelLogs");

            migrationBuilder.DropTable(
                name: "Db_WarehouseRequestWait");

            migrationBuilder.DropTable(
                name: "Db_WastePaperControl");

            migrationBuilder.DropTable(
                name: "Db_WastePaperCost");

            migrationBuilder.DropTable(
                name: "Db_WaterPreparationAndConsumption");

            migrationBuilder.DropTable(
                name: "Db_WaterTreatmentAnalysisResults");

            migrationBuilder.DropTable(
                name: "Db_WinderCoilLengthControl");

            migrationBuilder.DropTable(
                name: "Db_WinderCoilTracking");

            migrationBuilder.DropTable(
                name: "Db_Basin");

            migrationBuilder.DropTable(
                name: "Db_KazanChemicalsHead");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Db_Permission");

            migrationBuilder.DropTable(
                name: "Db_StarchAnalysisHeading");

            migrationBuilder.DropTable(
                name: "Db_TestHeader");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Db_Shift");

            migrationBuilder.DropTable(
                name: "Db_Department");
        }
    }
}
