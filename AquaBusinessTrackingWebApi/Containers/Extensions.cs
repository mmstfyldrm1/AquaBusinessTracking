using AIAgent.Handlers;
using AIAgent.Orchestration.Abstract;
using AIAgent.Orchestration.Manager;
using AIAgent.Services.Abstract.Electric;
using AIAgent.Services.Abstract.Production;
using AIAgent.Services.Abstract.RawMaterials;
using AIAgent.Services.Abstract.Sales;
using AIAgent.Services.Abstract.Shipment;
using AIAgent.Services.Manager;
using AIAgent.Tools;
using AIAgent.Tools.Electric;
using AIAgent.Tools.Production;
using AIAgent.Tools.RawMaterials;
using AIAgent.Tools.Sales;
using AIAgent.Tools.Shipment;
using AquaBusinessTrackingWebApi.Services;
using BusinessLayer.Abstract;
using BusinessLayer.Abstract.Integrations;
using BusinessLayer.Concrete;
using BusinessLayer.Concrete.Integrations;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Abstract.Integrations;
using DataAccsessLayer.Concrete.Repository;
using DataAccsessLayer.Concrete.Repository.Integrations;
using DataAccsessLayer.Concrete.UoW;

namespace AquaBusinessTrackingWebApi.Containers
{
    public static class Extensions
    {
        public static void ContainerDependencies(this IServiceCollection Services)
        {
            Services.AddScoped<IElectricShiftWorkRepository, ElectricShiftWorkRepository>();
            Services.AddScoped<IElectiricShiftWorkService, ElectiricShiftWorkManager>();
            Services.AddScoped<IRolePermissionRepository, RolePermissionRepository>();
            Services.AddScoped<IRolePermissionService, RolePermissionManager>();
            Services.AddScoped<IPermissionService, PermissionManager>();
            Services.AddScoped<IElectricMotorTrackingRepository, ElectricMotorTrackingRepository>();
            Services.AddScoped<IElectricMotorTrackingService, ElectricMotorTrackingManager>();
            Services.AddScoped<IShiftService, ShiftManager>();
            Services.AddScoped<IShiftRepository, ShiftRepository>();
            Services.AddScoped<ISalesScaleRepository, SalesScaleRepository>();
            Services.AddScoped<ISalesScaleService, SalesScaleManager>();
            Services.AddScoped<IDepartmentService, DepartmentManager>();
            Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            Services.AddScoped<IBasinRepository, BasinRepository>();
            Services.AddScoped<IBasinService, BasinManager>();
            Services.AddScoped<IBasinMeasurementRepository, BasinMeasurementRepository>();
            Services.AddScoped<IBasinMeasurementService, BasinMeasurementManager>();
            Services.AddScoped<IWinderCoilTrackingRepository, WinderCoilTrackingRepository>();
            Services.AddScoped<IWinderCoilTrackingService, WinderCoilTrackingManager>();
            Services.AddScoped<IWinderCoilLengthControlRepository, WinderCoilLengthControlRepository>();
            Services.AddScoped<IWinderCoilLengthControlService, WinderCoilLengthControlManager>();
            Services.AddScoped<IWastePaperControlRepository, WastePaperControlRepository>();
            Services.AddScoped<IWastePaperControlService, WastePaperControlManager>();
            Services.AddScoped<IWastePaperCostRepository, WastePaperCostRepository>();
            Services.AddScoped<IWastePaperCostService, WastePaperCostManager>();
            Services.AddScoped<IKazanChemicalsHeadRepository, KazanChemicalsHeadRepository>();
            Services.AddScoped<IKazanChemicalsHeadService, KazanChemicalsHeadManager>();
            Services.AddScoped<IBoilerSteamFeedWaterCondensateDataRepository, BoilerSteamFeedWaterCondensateDataRepository>();
            Services.AddScoped<IBoilerSteamFeedWaterCondensateDataService, BoilerSteamFeedWaterCondensateDataManager>();
            Services.AddScoped<IBufferGramajProfileRepository, BufferGramajProfileRepository>();
            Services.AddScoped<IBufferGramajProfileService, BufferGramajProfileManager>();
            Services.AddScoped<IBufferAnalysisReportRepository, BufferAnalysisReportRepository>();
            Services.AddScoped<IBufferAnalysisReportService, BufferAnalysisReportManager>();
            Services.AddScoped<IDoughPreparationHeadRepository, DoughPreparationHeadRepository>();
            Services.AddScoped<IDoughPreparationHeadService, DoughPreparationHeadManager>();
            Services.AddScoped<IDoughPreparationAnalysisResultsRepository, DoughPreparationAnalysisResultsRepository>();
            Services.AddScoped<IDoughPreparationAnalysisResultsDetailService, DoughPreparationAnalysisResultsManager>();
            Services.AddScoped<ICirculationTankAirPressureMeasurementTurbidityRepository, CirculationTankAirPressureMeasurementTurbidityRepository>();
            Services.AddScoped<ICirculationTankAirPressureMeasurementTurbidityService, CirculationTankAirPressureMeasurementTurbidityManager>();
            Services.AddScoped<ILogisticsTrackingReportRepository, LogisticsTrackingReportRepository>();
            Services.AddScoped<ISentezCurrentAccountQueryService, SentezCurrentAccountQueryManager>();
            Services.AddScoped<ILogisticsTrackingReportService, LogisticsTrackingReportManager>();
            Services.AddScoped<INaturelGasMeterMonitoringRepository, NaturelGasMeterMonitoringRepository>();
            Services.AddScoped<INaturelGasMeterMonitoringService, NaturelGasMeterMonitoringManager>();
            Services.AddScoped<IOilAnalysisReportRepository, OilAnalysisReportRepository>();
            Services.AddScoped<IOilAnalysisReportService, OilAnalysisReportManager>();
            Services.AddScoped<IPapperMachineChemicalRepository, PapperMachineChemicalRepository>();
            Services.AddScoped<IPapperMachineChemicalService, PapperMachineChemicalManager>();
            Services.AddScoped<IMassWasteSupplierRepository, MassWasteSupplierRepository>();
            Services.AddScoped<IMassWasteSupplierService, MassWasteSupplierManager>();
            Services.AddScoped<IMassWasteBalanceRepository, MassWasteBalanceRepository>();
            Services.AddScoped<IMassWasteBalanceService, MassWasteBalanceManager>();
            Services.AddScoped<IWaterTreatmentAnalysisResultsRepository, WaterTreatmentAnalysisResultsRepository>();
            Services.AddScoped<IWaterTreatmentAnalysisResultsService, WaterTreatmentAnalysisResultsManager>();
            Services.AddScoped<ILabWorkRepository, LabWorkRepository>();
            Services.AddScoped<ILabWorkService, LabWorkManager>();
            Services.AddScoped<IWaterPreparationAndConsumptionService, WaterPreparationAndConsumptionManager>();
            Services.AddScoped<IWaterPreparationAndConsumptionRepository, WaterPreparationAndConsumptionRepository>();
            Services.AddScoped<IVechileFuelLogsRepository, VechileFuelLogsRepository>();
            Services.AddScoped<IVechileFuelLogsService, VechileFuelLogsManager>();
            Services.AddScoped<IDailyShipmentPlanRepository, DailyShipmentPlanRepository>();
            Services.AddScoped<IDailyShipmentPlanService, DailyShipmentPlanManager>();
            Services.AddScoped<ITestHeadRepository, TestHeadRepository>();
            Services.AddScoped<ITestHeadService, TestHeadManager>();
            Services.AddScoped<ITestDetailRepository, TestDetailRepository>();
            Services.AddScoped<ITestDetailService, TestDetailManager>();
            Services.AddScoped<ISentezAllDataRepository, SentezAllDataRepository>();
            Services.AddScoped<ISentezAllDataService, SentezAllDataManager>();
            Services.AddScoped<ISentezNotOrdersRepository, SentezNotOrdersRepository>();
            Services.AddScoped<ISentezNotOrdersService, SentezNotOrdersManager>();
            Services.AddScoped<IStarchAnalysisHeadingRepository, StarchAnalysisHeadingRepository>();
            Services.AddScoped<IStarchAnalysisHeadingService, StarchAnalysisHeadingManager>();
            Services.AddScoped<IStarchAnalysisHeadingDetailRepository, StarchAnalysisHeadingDetailRepository>();
            Services.AddScoped<IStarchAnalysisHeadingDetailService, StarchAnalysisHeadingDetailManager>();
            Services.AddScoped<IRetentionAnalysisHeadRepository, RetentionAnalysisHeadRepository>();
            Services.AddScoped<IRetentionAnalysisHeadService, RetentionAnalysisHeadManager>();
            Services.AddScoped<IRetentionAnalysisDetailRepository, RetentionAnalysisDetailRepository>();
            Services.AddScoped<IRetentionAnalysisDetailService, RetentionAnalysisDetailManager>();
            Services.AddScoped<IPurificationChemicalsConsumptionRepository, PurificationChemicalsConsumptionRepository>();
            Services.AddScoped<IPurificationChemicalsConsumptionService, PurificationChemicalsConsumptionManager>();
            Services.AddScoped<IElectricMeterLocationRepository, ElectricMeterLocationRepository>();
            Services.AddScoped<IElectricMeterLocationService, ElectricMeterLocationManager>();
            Services.AddScoped<ICumulativeElectricityConsumptionRepository, CumulativeElectricityConsumptionRepository>();
            Services.AddScoped<ICumulativeElectricityConsumptionService, CumulativeElectricityConsumptionManager>();
            Services.AddScoped<IBoilerOperationandChemicalConsumptionService, BoilerOperationandChemicalConsumption>();
            Services.AddScoped<IBoilerOperationandChemicalConsumptionRepository, BoilerOperationandChemicalConsumptionRepository>();
            Services.AddScoped<IPlanningScorBoardViewRepository, PlanningScorBoardViewRepository>();
            Services.AddScoped<IPlanningScorBoardViewService, PlanningScorBoardViewManager>();
            Services.AddScoped<IKazanEnergyConsumptionRepository, KazanEnergyConsumptionRepository>();
            Services.AddScoped<IKazanEnergyConsumptionService, KazanEnergyConsumptionManager>();
            Services.AddScoped<IMachineStopRepository, MachineStopRepository>();
            Services.AddScoped<IMachineStopService, MachineStopManager>();
            Services.AddScoped<IBufferProductionRepository, BufferProductionRepository>();
            Services.AddScoped<IBufferProductionService, BufferProductionManager>();
            Services.AddScoped<IPlcService, PlcService>();
            Services.AddScoped<IPlcReadingRepository, PlcReadingRepository>();
            Services.AddScoped<IPlcService, PlcService>();
            Services.AddScoped<IPlcMachineRepository, PlcMachineRepository>();
            Services.AddScoped<IPlcMachineService, PlcMachineManager>();
            Services.AddScoped<IPlcTagsRepository, PlcTagsRepository>();
            Services.AddScoped<IPlcTagsService, PlcTagsManager>();
            Services.AddSingleton<IPlcReader, OpcUaPlcReader>();
            Services.AddHostedService<PlcHoursReadingService>();
            Services.AddHostedService<MachineRandomanJob>();
            Services.AddScoped<ISentezIntegrationsService, SentezIntegrationsManager>();
            Services.AddScoped<ISentezQueryService, SentezQueryManager>();
            Services.AddSignalR();
            Services.AddScoped<IUnitOfWork, UnitOfWork>();
            Services.AddScoped<IFavoriteMenuItemRepository, FavoriteMenuItemRepository>();
            Services.AddScoped<IFavoriteMenuItemService, FavoriteMenuItemManager>();
            Services.AddScoped<IMessageRepository, MessageRepository>();
            Services.AddScoped<IMessageService, MessageManager>();
            Services.AddScoped<IRawMaterialIntakeRepository, RawMaterialIntakeRepository>();
            Services.AddScoped<IRawMaterialIntakeService, RawMaterialIntakeManager>();
            Services.AddScoped<IIncomingGoodsTrackingRepository, IncomingGoodsTrackingRepository>();
            Services.AddScoped<IIncomingGoodsTrackingService, IncomingGoodsTrackingManager>();
            Services.AddScoped<ISentezInventoryQueryService, SentezInventoryQueryManager>();
            Services.AddScoped<IChemicalSupplierProductsRepository, ChemicalSupplierProductsRepository>();
            Services.AddScoped<IChemicalSupplierProductsService, ChemicalSupplierProductsManager>();
            Services.AddScoped<INotificationRepository, NotificationRepository>();
            Services.AddScoped<INotificationService, NotificationManager>();
            Services.AddScoped<IShipmentOrderPlanRepository, ShipmentOrderPlanRepository>();
            Services.AddScoped<IShipmentOrderPlanService, ShipmentOrderPlanManager>();
            Services.AddScoped<IShipmentOrderPlanDetailRepository, ShipmentOrderPlanDetailRepository>();
            Services.AddScoped<IShipmentOrderPlanDetailService, ShipmentOrderPlanDetailManager>();
            Services.AddScoped<GenerateTokenService>();
            Services.AddScoped<IQueryService, QueryManager>();
            Services.AddScoped<IQueryRepository, QueryRepository>();

            Services.AddTransient<JwtAuthorizationHandler>();
            Services.AddHttpContextAccessor();
            Services.AddHttpClient();
            Services.AddHttpClient<IProductionApiService, ProductionApiManager>(
                client =>
                {
                    client.BaseAddress = new Uri(
                        "https://localhost:7255/api/");
                }).AddHttpMessageHandler<JwtAuthorizationHandler>();

            Services.AddHttpClient<IShipmentApiService, ShipmentApiManager>(
               client =>
               {
                   client.BaseAddress = new Uri(
                       "https://localhost:7255/api/");
               }).AddHttpMessageHandler<JwtAuthorizationHandler>();

            Services.AddHttpClient<IElectricApiService, ElectricApiManager>(
              client =>
              {
                  client.BaseAddress = new Uri(
                      "https://localhost:7255/api/");
              }).AddHttpMessageHandler<JwtAuthorizationHandler>();

            Services.AddHttpClient<IRawMaterialsApiService, RawMaterialsApiManager>(
            client =>
            {
                client.BaseAddress = new Uri(
                    "https://localhost:7255/api/");
            }).AddHttpMessageHandler<JwtAuthorizationHandler>();

            Services.AddHttpClient<ISalesApiService, SalesApiManager>(
            client =>
            {
                client.BaseAddress = new Uri(
                    "https://localhost:7255/api/");
            }).AddHttpMessageHandler<JwtAuthorizationHandler>();

            Services.AddScoped<AiToolRegistry>();
            Services.AddScoped<IAiTool, GetLast7DaysProductionTool>();
            Services.AddScoped<IAiTool, GetLast30DaysShipment>();
            Services.AddScoped<IAiTool, GetWithBySearchSalesScale>();
            Services.AddScoped<IAiTool, GetWithBySearchCumulativeElectricConsumption>();
            Services.AddScoped<IAiTool, GetWithBySearchRawMaterialsIntake>();
            Services.AddScoped<IAiTool, GetByDateRangeSales>();
            Services.AddScoped<IAiTool, GetWithProductionByDate>();
            Services.AddHttpClient<IAiService, AiManager>(
                client =>
                {
                    client.BaseAddress = new Uri(
                        "https://integrate.api.nvidia.com/v1");

                    client.Timeout = TimeSpan.FromMinutes(5);
                });
        }
    }
}
