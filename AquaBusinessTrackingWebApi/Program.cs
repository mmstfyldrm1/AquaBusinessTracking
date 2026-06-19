
using AquaBusinessTrackingWebApi.Services;
using BusinessLayer.Abstract;
using BusinessLayer.Abstract.Integrations;
using BusinessLayer.Concrete;
using BusinessLayer.Concrete.Integrations;
using DataAccsessLayer;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Abstract.Integrations;
using DataAccsessLayer.Concrete.Repository;
using DataAccsessLayer.Concrete.Repository.Integrations;
using DataAccsessLayer.Concrete.UoW;
using DataAccsessLayer.Seed;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
});
builder.Services.AddDbContext<AquaBusinessTrackingContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<DB_AppUser, DB_AppRole>()
    .AddEntityFrameworkStores<AquaBusinessTrackingContext>()
    .AddDefaultTokenProviders();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IElectricShiftWorkRepository, ElectricShiftWorkRepository>();
builder.Services.AddScoped<IElectiricShiftWorkService, ElectiricShiftWorkManager>();
builder.Services.AddScoped<IRolePermissionRepository, RolePermissionRepository>();
builder.Services.AddScoped<IRolePermissionService, RolePermissionManager>();
builder.Services.AddScoped<IPermissionService, PermissionManager>();
builder.Services.AddScoped<IElectricMotorTrackingRepository, ElectricMotorTrackingRepository>();
builder.Services.AddScoped<IElectricMotorTrackingService, ElectricMotorTrackingManager>();
builder.Services.AddScoped<IShiftService, ShiftManager>();
builder.Services.AddScoped<ISalesScaleRepository, SalesScaleRepository>();
builder.Services.AddScoped<ISalesScaleService, SalesScaleManager>();
builder.Services.AddScoped<IDepartmentService, DepartmentManager>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IBasinRepository, BasinRepository>();
builder.Services.AddScoped<IBasinService, BasinManager>();
builder.Services.AddScoped<IBasinMeasurementRepository, BasinMeasurementRepository>();
builder.Services.AddScoped<IBasinMeasurementService, BasinMeasurementManager>();
builder.Services.AddScoped<IWinderCoilTrackingRepository, WinderCoilTrackingRepository>();
builder.Services.AddScoped<IWinderCoilTrackingService, WinderCoilTrackingManager>();
builder.Services.AddScoped<IWinderCoilLengthControlRepository, WinderCoilLengthControlRepository>();
builder.Services.AddScoped<IWinderCoilLengthControlService, WinderCoilLengthControlManager>();
builder.Services.AddScoped<IWastePaperControlRepository, WastePaperControlRepository>();
builder.Services.AddScoped<IWastePaperControlService, WastePaperControlManager>();
builder.Services.AddScoped<IWastePaperCostRepository, WastePaperCostRepository>();
builder.Services.AddScoped<IWastePaperCostService, WastePaperCostManager>();
builder.Services.AddScoped<IKazanChemicalsHeadRepository, KazanChemicalsHeadRepository>();
builder.Services.AddScoped<IKazanChemicalsHeadService, KazanChemicalsHeadManager>();
builder.Services.AddScoped<IBoilerSteamFeedWaterCondensateDataRepository, BoilerSteamFeedWaterCondensateDataRepository>();
builder.Services.AddScoped<IBoilerSteamFeedWaterCondensateDataService, BoilerSteamFeedWaterCondensateDataManager>();
builder.Services.AddScoped<IBufferGramajProfileRepository, BufferGramajProfileRepository>();
builder.Services.AddScoped<IBufferGramajProfileService, BufferGramajProfileManager>();
builder.Services.AddScoped<IBufferAnalysisReportRepository, BufferAnalysisReportRepository>();
builder.Services.AddScoped<IBufferAnalysisReportService, BufferAnalysisReportManager>();
builder.Services.AddScoped<IDoughPreparationHeadRepository, DoughPreparationHeadRepository>();
builder.Services.AddScoped<IDoughPreparationHeadService, DoughPreparationHeadManager>();
builder.Services.AddScoped<IDoughPreparationAnalysisResultsRepository, DoughPreparationAnalysisResultsRepository>();
builder.Services.AddScoped<IDoughPreparationAnalysisResultsDetailService, DoughPreparationAnalysisResultsManager>();
builder.Services.AddScoped<ICirculationTankAirPressureMeasurementTurbidityRepository, CirculationTankAirPressureMeasurementTurbidityRepository>();
builder.Services.AddScoped<ICirculationTankAirPressureMeasurementTurbidityService, CirculationTankAirPressureMeasurementTurbidityManager>();
builder.Services.AddScoped<ILogisticsTrackingReportRepository, LogisticsTrackingReportRepository>();
builder.Services.AddScoped<ILogisticsTrackingReportService, LogisticsTrackingReportManager>();
builder.Services.AddScoped<INaturelGasMeterMonitoringRepository, NaturelGasMeterMonitoringRepository>();
builder.Services.AddScoped<INaturelGasMeterMonitoringService, NaturelGasMeterMonitoringManager>();
builder.Services.AddScoped<IOilAnalysisReportRepository, OilAnalysisReportRepository>();
builder.Services.AddScoped<IOilAnalysisReportService, OilAnalysisReportManager>();
builder.Services.AddScoped<IPapperMachineChemicalRepository, PapperMachineChemicalRepository>();
builder.Services.AddScoped<IPapperMachineChemicalService, PapperMachineChemicalManager>();
builder.Services.AddScoped<IMassWasteSupplierRepository, MassWasteSupplierRepository>();
builder.Services.AddScoped<IMassWasteSupplierService, MassWasteSupplierManager>();
builder.Services.AddScoped<IMassWasteBalanceRepository, MassWasteBalanceRepository>();
builder.Services.AddScoped<IMassWasteBalanceService, MassWasteBalanceManager>();
builder.Services.AddScoped<IWaterTreatmentAnalysisResultsRepository, WaterTreatmentAnalysisResultsRepository>();
builder.Services.AddScoped<IWaterTreatmentAnalysisResultsService, WaterTreatmentAnalysisResultsManager>();
builder.Services.AddScoped<ILabWorkRepository, LabWorkRepository>();
builder.Services.AddScoped<ILabWorkService, LabWorkManager>();
builder.Services.AddScoped<IWaterPreparationAndConsumptionService, WaterPreparationAndConsumptionManager>();
builder.Services.AddScoped<IWaterPreparationAndConsumptionRepository, WaterPreparationAndConsumptionRepository>();
builder.Services.AddScoped<IVechileFuelLogsRepository, VechileFuelLogsRepository>();
builder.Services.AddScoped<IVechileFuelLogsService, VechileFuelLogsManager>();
builder.Services.AddScoped<IWarehouseRequestWaitRepository, WarehouseRequestWaitRepository>();
builder.Services.AddScoped<IWarehouseRequestWaitService, WarehouseRequestWaitManager>();
builder.Services.AddScoped<ITestHeadRepository, TestHeadRepository>();
builder.Services.AddScoped<ITestHeadService, TestHeadManager>();
builder.Services.AddScoped<ITestDetailRepository, TestDetailRepository>();
builder.Services.AddScoped<ITestDetailService, TestDetailManager>();
builder.Services.AddScoped<ISentezAllDataRepository, SentezAllDataRepository>();
builder.Services.AddScoped<ISentezAllDataService, SentezAllDataManager>();
builder.Services.AddScoped<ISentezNotOrdersRepository, SentezNotOrdersRepository>();
builder.Services.AddScoped<ISentezNotOrdersService, SentezNotOrdersManager>();
builder.Services.AddScoped<IStarchAnalysisHeadingRepository, StarchAnalysisHeadingRepository>();
builder.Services.AddScoped<IStarchAnalysisHeadingService, StarchAnalysisHeadingManager>();
builder.Services.AddScoped<IStarchAnalysisHeadingDetailRepository, StarchAnalysisHeadingDetailRepository>();
builder.Services.AddScoped<IStarchAnalysisHeadingDetailService, StarchAnalysisHeadingDetailManager>();
builder.Services.AddScoped<IRetentionAnalysisHeadRepository, RetentionAnalysisHeadRepository>();
builder.Services.AddScoped<IRetentionAnalysisHeadService, RetentionAnalysisHeadManager>();
builder.Services.AddScoped<IRetentionAnalysisDetailRepository, RetentionAnalysisDetailRepository>();
builder.Services.AddScoped<IRetentionAnalysisDetailService, RetentionAnalysisDetailManager>();
builder.Services.AddScoped<IPurificationChemicalsConsumptionRepository, PurificationChemicalsConsumptionRepository>();
builder.Services.AddScoped<IPurificationChemicalsConsumptionService, PurificationChemicalsConsumptionManager>();
builder.Services.AddScoped<IElectricMeterLocationRepository, ElectricMeterLocationRepository>();
builder.Services.AddScoped<IElectricMeterLocationService, ElectricMeterLocationManager>();
builder.Services.AddScoped<ICumulativeElectricityConsumptionRepository, CumulativeElectricityConsumptionRepository>();
builder.Services.AddScoped<ICumulativeElectricityConsumptionService, CumulativeElectricityConsumptionManager>();
builder.Services.AddScoped<IPlcService, PlcService>();
builder.Services.AddScoped<IPlcReadingRepository, PlcReadingRepository>();
builder.Services.AddScoped<IPlcService, PlcService>();
builder.Services.AddScoped<IPlcMachineRepository, PlcMachineRepository>();
builder.Services.AddScoped<IPlcMachineService, PlcMachineManager>();
builder.Services.AddScoped<IPlcTagsRepository, PlcTagsRepository>();
builder.Services.AddScoped<IPlcTagsService, PlcTagsManager>();
builder.Services.AddSingleton<IPlcReader, OpcUaPlcReader>();
builder.Services.AddHostedService<PlcDailyReadingService>();
builder.Services.AddSignalR();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<GenerateTokenService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();




builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        x => x.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod());
});

// JWT
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
    };
});

// Swagger JWT
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Bearer {token}"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id   = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});



builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(@"C:\AquaAPI\DataProtection-Keys"))
    .SetApplicationName("AquaBusinessTracking");
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AquaBusinessTrackingContext>();

    await PermissionSeed.SeedAsync(context);

    if (!context.Db_Permission.Any())
    {
        await PermissionSeed.SeedAsync(context);
    }
}
app.UseCors("AllowAll");
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
    c.RoutePrefix = "swagger";
});
app.MapHub<PlcHub>("/hubs/plc");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
