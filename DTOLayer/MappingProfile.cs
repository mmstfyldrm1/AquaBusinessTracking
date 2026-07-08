using AutoMapper;
using DTOLayer.Dtos.BasinDtos.BasinDto;
using DTOLayer.Dtos.BasinDtos.BasinMeasurement;
using DTOLayer.Dtos.BoilerRoomDailyShiftMonitoringDtos;
using DTOLayer.Dtos.BoilerSteamFeedWaterCondensateDataDtos;
using DTOLayer.Dtos.BufferAnalysisReportDtos;
using DTOLayer.Dtos.BufferGramajProfile;
using DTOLayer.Dtos.BufferGramajProfileDtos;
using DTOLayer.Dtos.BufferProductionDtos;
using DTOLayer.Dtos.CirculationTankAirPressureMeasurementTurbidity;
using DTOLayer.Dtos.CirculationTankAirPressureMeasurementTurbidityDtos;
using DTOLayer.Dtos.DepartmentDtos;
using DTOLayer.Dtos.DoughPreparationDtos.DoughPreparationDetailDtos;
using DTOLayer.Dtos.DoughPreparationDtos.DoughPreparationHeadDtos;
using DTOLayer.Dtos.ElectricDtos.CumulativeElectricityConsumptionDtos;
using DTOLayer.Dtos.ElectricDtos.ElectricMeterLocationDtos;
using DTOLayer.Dtos.ElectricDtos.ElectricMotorTrackingDto;
using DTOLayer.Dtos.ElectricDtos.ElectricShiftDtos;
using DTOLayer.Dtos.KazanDtos.KazanHeadDtos;
using DTOLayer.Dtos.LabWork;
using DTOLayer.Dtos.LabWorkDtos;
using DTOLayer.Dtos.LogisticsTrackingReportDtos;
using DTOLayer.Dtos.MachineStopDtos;
using DTOLayer.Dtos.MassWasteDtos.MassWasteBalanceDtos;
using DTOLayer.Dtos.MassWasteDtos.MassWasteSupplierDtos;
using DTOLayer.Dtos.NaturelGasMeterMonitoringDtos;
using DTOLayer.Dtos.OilAnalysisReportDtos;
using DTOLayer.Dtos.PapperMachineChemicalDtos;
using DTOLayer.Dtos.PlanningScorBoardViewDto;
using DTOLayer.Dtos.PlanningScorBoardViewDtos;
using DTOLayer.Dtos.PlcDtos.PlcMachineDtos;
using DTOLayer.Dtos.PlcDtos.PlcTagsDtos;
using DTOLayer.Dtos.PurificationChemicalsConsumptionDtos;
using DTOLayer.Dtos.RetentionAnalysis.RetentionAnalysisDetailDtos;
using DTOLayer.Dtos.RetentionAnalysis.RetentionAnalysisHeadDtos;
using DTOLayer.Dtos.SalesScale;
using DTOLayer.Dtos.SentezAllDataDtos;
using DTOLayer.Dtos.SentezNotOrdersDtos;
using DTOLayer.Dtos.ShiftDtos;
using DTOLayer.Dtos.StarchAnalysis.StarchAnalysisHeadingDetail;
using DTOLayer.Dtos.StarchAnalysis.StarchAnalysisHeadingDtos;
using DTOLayer.Dtos.TestDtos.TestDetailDtos;
using DTOLayer.Dtos.TestDtos.TestHeadDtos;
using DTOLayer.Dtos.UserDashboardDtos;
using DTOLayer.Dtos.UserDtos;
using DTOLayer.Dtos.VechileFuelLogsDtos;
using DTOLayer.Dtos.WarehouseRequestWaitDtos;
using DTOLayer.Dtos.WastePaperControlDtos;
using DTOLayer.Dtos.WastePaperCost;
using DTOLayer.Dtos.WaterPreparationAndConsumptionDtos;
using DTOLayer.Dtos.WaterTreatmentAnalysisResultsDtos;
using DTOLayer.Dtos.WinderCoilLengthControlDto;
using DTOLayer.Dtos.WinderCoilTrackingDto;
using EntityLayer.Concrete;

namespace DTOLayer
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DB_ElectricShiftWork, CreateElectricShiftWorkDto>().ReverseMap();
            CreateMap<DB_ElectricShiftWork, UpdateElectiricShiftWorkDto>().ReverseMap();
            CreateMap<DB_ElectricShiftWork, ElectricShiftWorkDto>().ReverseMap();
            CreateMap<DB_ElectricShiftWork, ElectricShiftWorkDto>()
                .ForMember(x => x.ShiftName, x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName, x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            CreateMap<DB_BufferProduction, CreateBufferProductionDto>().ReverseMap();
            CreateMap<DB_BufferProduction, UpdateBufferProductionDto>().ReverseMap();
            CreateMap<DB_BufferProduction, BufferProductionDto>().ReverseMap();
            CreateMap<DB_BufferProduction, BufferProductionDto>().ForMember(x => x.ShiftName, x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName, x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null))
                .ForMember(x => x.ShiftSupervisorUser, x => x.MapFrom(s => s.ShiftSupervisorUser != null ? s.ShiftSupervisorUser.UserName : null));


            CreateMap<DB_PlanningScorBoardView, CreatePlanningScorBoardViewDto>().ReverseMap();
            CreateMap<DB_PlanningScorBoardView, UpdatePlanningScorBoardViewDto>().ReverseMap();
            CreateMap<DB_PlanningScorBoardView, PlanningScorBoardViewDto>().ReverseMap();
            CreateMap<DB_PlanningScorBoardView, PlanningScorBoardViewDto>().ForMember(x => x.ShiftName, x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName, x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));


            CreateMap<DB_Department, CreateDepartmentDto>().ReverseMap();
            CreateMap<DB_Department, UpdateDepartmentDto>().ReverseMap();
            CreateMap<DB_Department, DepartmentDto>().ReverseMap();


            CreateMap<DB_Shift, CreateShiftDto>().ReverseMap();
            CreateMap<DB_Shift, UpdateShiftDto>().ReverseMap();
            CreateMap<DB_Shift, ShiftDto>().ReverseMap();

            CreateMap<DB_ElectricMotorTracking, CreateElectricMotorDto>().ReverseMap();
            CreateMap<DB_ElectricMotorTracking, UpdateElectricMotorDto>().ReverseMap();
            CreateMap<DB_ElectricMotorTracking, ElectricMotorDto>().ReverseMap();
            CreateMap<DB_ElectricMotorTracking, ElectricMotorDto>().ForMember(x => x.ShiftName, x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName, x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            CreateMap<DB_MachineStop, CreateMachineStopDto>().ReverseMap();
            CreateMap<DB_MachineStop, UpdateMachineStopDto>().ReverseMap();
            CreateMap<DB_MachineStop, MachineStopDto>().ReverseMap();
            CreateMap<DB_MachineStop, MachineStopDto>().ForMember(x => x.ShiftName, x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName, x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            CreateMap<DB_SalesScale, CreateSalesScaleDto>().ReverseMap();
            CreateMap<DB_SalesScale, UpdateSalesScaleDto>().ReverseMap();
            CreateMap<DB_SalesScale, SalesScaleDto>().ReverseMap();
            CreateMap<DB_SalesScale, SalesScaleDto>().ForMember(x => x.ShiftName, x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName, x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));




            CreateMap<DB_Basin, CreateBasinDto>().ReverseMap();
            CreateMap<DB_Basin, UpdateBasinDto>().ReverseMap();
            CreateMap<DB_Basin, BasinDto>().ReverseMap();
            CreateMap<DB_Basin, BasinDto>().ForMember(x => x.ShiftName, x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName, x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));


            CreateMap<DB_BasinMeasurement, CreateBasinMeasurementDto>().ReverseMap();
            CreateMap<DB_BasinMeasurement, UpdateBasinMeasurementDto>().ReverseMap();
            CreateMap<DB_BasinMeasurement, BasinMeasurementDto>().ReverseMap();

            CreateMap<DB_WinderCoilTracking, CreateWinderCoilTrackingDto>().ReverseMap();
            CreateMap<DB_WinderCoilTracking, UpdateWinderCoilTrackingDto>().ReverseMap();
            CreateMap<DB_WinderCoilTracking, WinderCoilTrackingDto>().ReverseMap();
            CreateMap<DB_WinderCoilTracking, WinderCoilTrackingDto>().ForMember(x => x.ShiftName, x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null)).ForMember(x => x.CreatedByName, x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            CreateMap<DB_BoilerRoomDailyShiftMonitoring, CreateBoilerRoomDailyShiftMonitoringDto>().ReverseMap();
            CreateMap<DB_BoilerRoomDailyShiftMonitoring, UpdateBoilerRoomDailyShiftMonitoringDto>().ReverseMap();
            CreateMap<DB_BoilerRoomDailyShiftMonitoring, BoilerRoomDailyShiftMonitoringDto>().ReverseMap();
            CreateMap<DB_BoilerRoomDailyShiftMonitoring, BoilerRoomDailyShiftMonitoringDto>().ForMember(x => x.ShiftName, x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null)).ForMember(x => x.CreatedByName, x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            CreateMap<DB_WinderCoilLengthControl, CreateWinderLengthControlDto>().ReverseMap();
            CreateMap<DB_WinderCoilLengthControl, UpdateWinderCoilLengthControlDto>().ReverseMap();
            CreateMap<DB_WinderCoilLengthControl, WinderCoilLengthControlDto>().ReverseMap();
            CreateMap<DB_WinderCoilLengthControl, WinderCoilLengthControlDto>().ForMember(x => x.ShiftName, x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null)).ForMember(x => x.CreatedByName, x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));


            CreateMap<DB_WastePaperControl, CreateWastePaperControlDto>().ReverseMap();
            CreateMap<DB_WastePaperControl, UpdateWastePaperControlDto>().ReverseMap();
            CreateMap<DB_WastePaperControl, WastePaperControlDto>().ReverseMap();
            CreateMap<DB_WastePaperControl, WastePaperControlDto>().ForMember(x => x.ShiftName, x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null)).ForMember(x => x.CreatedByName, x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            CreateMap<DB_WastePaperCost, CreateWastePaperCostDto>().ReverseMap();
            CreateMap<DB_WastePaperCost, UpdateWastePaperCostDto>().ReverseMap();
            CreateMap<DB_WastePaperCost, WastePaperCostDto>().ReverseMap();
            CreateMap<DB_WastePaperCost, WastePaperCostDto>().ForMember(x => x.ShiftName, x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null)).ForMember(x => x.CreatedByName, x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));


            CreateMap<DB_KazanChemicalsHead, CreateKazanChemicalsHeadDto>().ReverseMap();
            CreateMap<DB_KazanChemicalsHead, UpdateKazanChemicalsHeadDto>().ReverseMap();
            CreateMap<DB_KazanChemicalsHead, KazanChemicalsHeadDto>().ReverseMap();
            CreateMap<DB_KazanChemicalsHead, KazanChemicalsHeadDto>().ForMember(x => x.ShiftName, x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null)).ForMember(x => x.CreatedByName, x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            CreateMap<DB_PapperMachineChemical, CreatePapperMachineChemicalDto>().ReverseMap();
            CreateMap<DB_PapperMachineChemical, UpdatePapperMachineChemicalDto>().ReverseMap();
            CreateMap<DB_PapperMachineChemical, PapperMachineChemicalDto>().ReverseMap();
            CreateMap<DB_PapperMachineChemical, PapperMachineChemicalDto>().ForMember(x => x.ShiftName, x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null)).ForMember(x => x.CreatedByName, x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            CreateMap<DB_BufferAnalysisReport, BufferAnalysisReportDto>().ReverseMap();
            CreateMap<DB_BufferAnalysisReport, UpdateBufferAnalysisReportDto>().ReverseMap();
            CreateMap<DB_BufferAnalysisReport, CreateBufferAnalysisReportDto>().ReverseMap();
            CreateMap<DB_BufferAnalysisReport, BufferAnalysisReportDto>().ForMember(x => x.ShiftName, x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null)).ForMember(x => x.CreatedByName, x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));


            CreateMap<DB_BufferGramajProfile, BufferGramajProfileDto>().ReverseMap();
            CreateMap<DB_BufferGramajProfile, UpdateBufferGramajProfileDto>().ReverseMap();
            CreateMap<DB_BufferGramajProfile, CreateBufferGramajProfileDto>().ReverseMap();
            CreateMap<DB_BufferGramajProfile, BufferGramajProfileDto>().ForMember(x => x.ShiftName, x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null)).ForMember(x => x.CreatedByName, x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));


            CreateMap<DB_BoilerSteamFeedWaterCondensateData, CreateBoilerSteamFeedWaterCondensateDataDto>().ReverseMap();
            CreateMap<DB_BoilerSteamFeedWaterCondensateData, UpdateBoilerSteamFeedWaterCondensateDataDto>().ReverseMap();
            CreateMap<DB_BoilerSteamFeedWaterCondensateData, BoilerSteamFeedWaterCondensateDataDto>().ReverseMap();
            CreateMap<DB_BoilerSteamFeedWaterCondensateData, BoilerSteamFeedWaterCondensateDataDto>().ForMember(x => x.ShiftName, x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null)).ForMember(x => x.CreatedByName, x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));


            CreateMap<DB_DoughPreparation, DoughPreparationDto>().ReverseMap();
            CreateMap<DB_DoughPreparation, UpdateDoughPreparationDto>().ReverseMap();
            CreateMap<DB_DoughPreparation, CreateDoughPreparationDto>().ReverseMap();
            CreateMap<DB_DoughPreparation, DoughPreparationDto>().ForMember(x => x.ShiftName, x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null)).ForMember(x => x.CreatedByName, x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            CreateMap<DB_DoughPreparationAnalysisResults, DoughPreparationAnalysisResultsDto>().ReverseMap();
            CreateMap<DB_DoughPreparationAnalysisResults, UpdateDoughPreparationAnalysisResultsDto>().ReverseMap();
            CreateMap<DB_DoughPreparationAnalysisResults, CreateDoughPreparationAnalysisResultsDto>().ReverseMap();
            CreateMap<DB_DoughPreparationAnalysisResults, DoughPreparationAnalysisResultsDto>().ForMember(x => x.ShiftName, x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null)).ForMember(x => x.CreatedByName, x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            CreateMap<DB_LabWork, LabWorkDto>().ReverseMap();
            CreateMap<DB_LabWork, CreateLabWorkDto>().ReverseMap();
            CreateMap<DB_LabWork, UpdateLabWorkDto>().ReverseMap();
            CreateMap<DB_LabWork, LabWorkDto>().ForMember(x => x.ShiftName, x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null)).ForMember(x => x.CreatedByName, x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));



            CreateMap<DB_LogisticsTrackingReport, LogisticsTrackingReportDto>().ReverseMap();
            CreateMap<DB_LogisticsTrackingReport, CreateLogisticsTrackingReportDto>().ReverseMap();
            CreateMap<DB_LogisticsTrackingReport, UpdateLogisticsTrackingReportDto>().ReverseMap();
            CreateMap<DB_LogisticsTrackingReport, LogisticsTrackingReportDto>().ForMember(x => x.ShiftName, x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null)).ForMember(x => x.CreatedByName, x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            CreateMap<DB_NaturelGasMeterMonitoring, CreateNaturelGasMeterMonitoringDto>().ReverseMap();
            CreateMap<DB_NaturelGasMeterMonitoring, NaturelGasMeterMonitoringDto>().ReverseMap();
            CreateMap<DB_NaturelGasMeterMonitoring, UpdateNaturelGasMeterMonitoringDto>().ReverseMap();
            CreateMap<DB_NaturelGasMeterMonitoring, NaturelGasMeterMonitoringDto>().ForMember(x => x.ShiftName, x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null)).ForMember(x => x.CreatedByName, x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));



            CreateMap<DB_OilAnalysisReport, CreateOilAnalysisReportDto>().ReverseMap();
            CreateMap<DB_OilAnalysisReport, OilAnalysisReportDto>().ReverseMap();
            CreateMap<DB_OilAnalysisReport, UpdateOilAnalysisReportDto>().ReverseMap();
            CreateMap<DB_OilAnalysisReport, OilAnalysisReportDto>().ForMember(x => x.ShiftName, x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null)).ForMember(x => x.CreatedByName, x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));


            CreateMap<DB_MassWasteBalance, CreateMassWasteBalanceDto>().ReverseMap();
            CreateMap<DB_MassWasteBalance, UpdateMassWasteBalanceDto>().ReverseMap();
            CreateMap<DB_MassWasteBalance, MassWasteBalanceDto>().ReverseMap();
            CreateMap<DB_MassWasteBalance, MassWasteBalanceDto>().ForMember(x => x.ShiftName, x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null)).ForMember(x => x.CreatedByName, x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            CreateMap<DB_MassWasteSupplier, CreateMassWasteSupplierDto>().ReverseMap();
            CreateMap<DB_MassWasteSupplier, UpdateMassWasteSupplierDto>().ReverseMap();
            CreateMap<DB_MassWasteSupplier, MassWasteSupplierDto>().ReverseMap();
            CreateMap<DB_MassWasteSupplier, MassWasteSupplierDto>().ForMember(x => x.ShiftName, x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null)).ForMember(x => x.CreatedByName, x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));


            CreateMap<DB_VechileFuelLogs, CreateVechileFuelLogsDto>().ReverseMap();
            CreateMap<DB_VechileFuelLogs, UpdateVechileFuelLogsDto>().ReverseMap();
            CreateMap<DB_VechileFuelLogs, VechileFuelLogsDto>().ReverseMap();
            CreateMap<DB_VechileFuelLogs, VechileFuelLogsDto>().ForMember(x => x.ShiftName, x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null)).ForMember(x => x.CreatedByName, x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));



            CreateMap<DB_WarehouseRequestWait, CreateWarehouseRequestWaitDto>().ReverseMap();
            CreateMap<DB_WarehouseRequestWait, UpdateWarehouseRequestWaitDto>().ReverseMap();
            CreateMap<DB_WarehouseRequestWait, WarehouseRequestWaitDto>().ReverseMap();
            CreateMap<DB_WarehouseRequestWait, WarehouseRequestWaitDto>().ForMember(x => x.ShiftName, x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null)).ForMember(x => x.CreatedByName, x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));


            CreateMap<DB_WaterTreatmentAnalysisResults, CreateWaterTreatmentAnalysisResultsDto>().ReverseMap();
            CreateMap<DB_WaterTreatmentAnalysisResults, UpdateWaterTreatmentAnalysisResultsDto>().ReverseMap();
            CreateMap<DB_WaterTreatmentAnalysisResults, WaterTreatmentAnalysisResultsDto>().ReverseMap();
            CreateMap<DB_WaterTreatmentAnalysisResults, WaterTreatmentAnalysisResultsDto>().ForMember(x => x.ShiftName, x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null)).ForMember(x => x.CreatedByName, x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            CreateMap<DB_WaterPreparationAndConsumption, WaterPreparationAndConsumptionDto>().ReverseMap();
            CreateMap<DB_WaterPreparationAndConsumption, UpdateWaterPreparationAndConsumptionDto>().ReverseMap();
            CreateMap<DB_WaterPreparationAndConsumption, CreateWaterPreparationAndConsumptionDto>().ReverseMap();
            CreateMap<DB_WaterPreparationAndConsumption, WaterPreparationAndConsumptionDto>().ForMember(x => x.ShiftName, x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null)).ForMember(x => x.CreatedByName, x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));


            CreateMap<DB_TestHeader, CreateTestHeadDto>().ReverseMap();
            CreateMap<DB_TestHeader, UpdateTestHeadDto>().ReverseMap();
            CreateMap<DB_TestHeader, TestHeadDto>().ReverseMap();
            CreateMap<DB_TestHeader, TestHeadDto>().ForMember(x => x.ShiftName, x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null)).ForMember(x => x.CreatedByName, x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));


            CreateMap<DB_TestDetail, TestDetailDto>().ReverseMap();
            CreateMap<DB_TestDetail, UpdateTestDetailDto>().ReverseMap();
            CreateMap<DB_TestDetail, CreateTestDetailDto>().ReverseMap();


            CreateMap<DB_SentezAllData, SentezAllDataDto>().ReverseMap();
            CreateMap<DB_SentezAllData, CreateSentezAllDataDto>().ReverseMap();
            CreateMap<DB_SentezAllData, UpdateSentezAllDataDto>().ReverseMap();
            CreateMap<DB_SentezAllData, SentezAllDataDto>().ForMember(x => x.ShiftName, x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null)).ForMember(x => x.CreatedByName, x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));

            CreateMap<DB_SentezNotOrder, SentezNotOrderDto>().ReverseMap();
            CreateMap<DB_SentezNotOrder, CreateSentezNotOrdersDto>().ReverseMap();
            CreateMap<DB_SentezNotOrder, UpdateSentezNotOrdersDto>().ReverseMap();
            CreateMap<DB_SentezNotOrder, SentezNotOrderDto>().ForMember(x => x.ShiftName, x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null)).ForMember(x => x.CreatedByName, x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));


            CreateMap<DB_StarchAnalysisHeading, StarchAnalysisHeadingDto>().ReverseMap();
            CreateMap<DB_StarchAnalysisHeading, CreateStarchAnalysisHeadingDto>().ReverseMap();
            CreateMap<DB_StarchAnalysisHeading, UpdateStarchAnalysisHeadingDto>().ReverseMap();
            CreateMap<DB_StarchAnalysisHeading, StarchAnalysisHeadingDto>().ForMember(x => x.ShiftName, x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null)).ForMember(x => x.CreatedByName, x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));


            CreateMap<DB_StarchAnalysisHeadingDetail, StarchAnalysisHeadingDetailDto>().ReverseMap();
            CreateMap<DB_StarchAnalysisHeadingDetail, CreateStarchAnalysisHeadingDetailDto>().ReverseMap();
            CreateMap<DB_StarchAnalysisHeadingDetail, UpdateStarchAnalysisHeadingDetailDto>().ReverseMap();

            CreateMap<DB_RetentionAnalysisHead, RetentionAnalysisHeadDto>().ReverseMap();
            CreateMap<DB_RetentionAnalysisHead, CreateRetentionAnalysisHeadDto>().ReverseMap();
            CreateMap<DB_RetentionAnalysisHead, UpdateRetentionAnalysisHeadDto>().ReverseMap();
            CreateMap<DB_RetentionAnalysisHead, RetentionAnalysisHeadDto>().ForMember(x => x.ShiftName, x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null)).ForMember(x => x.CreatedByName, x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));


            CreateMap<DB_RetantionAnalysisDetail, RetentionAnalysisDetailDto>().ReverseMap();
            CreateMap<DB_RetantionAnalysisDetail, CreateRetentionAnalysisHeadDto>().ReverseMap();
            CreateMap<DB_RetantionAnalysisDetail, UpdateRetentionAnalysisHeadDto>().ReverseMap();


            CreateMap<DB_PurificationChemicalsConsumption, PurificationChemicalsConsumptionDto>().ReverseMap();
            CreateMap<DB_PurificationChemicalsConsumption, CreatePurificationChemicalsConsumptionDto>().ReverseMap();
            CreateMap<DB_PurificationChemicalsConsumption, UpdatePurificationChemicalsConsumptionDto>().ReverseMap();
            CreateMap<DB_PurificationChemicalsConsumption, PurificationChemicalsConsumptionDto>().ForMember(x => x.ShiftName, x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null)).ForMember(x => x.CreatedByName, x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));


            CreateMap<DB_CirculationTankAirPressureMeasurementTurbidity, CirculationTankAirPressureMeasurementTurbidityDto>().ReverseMap();
            CreateMap<DB_CirculationTankAirPressureMeasurementTurbidity, CreateCirculationTankAirPressureMeasurementTurbidityDto>().ReverseMap();
            CreateMap<DB_CirculationTankAirPressureMeasurementTurbidity, UpdateCirculationTankAirPressureMeasurementTurbidityDto>().ReverseMap();
            CreateMap<DB_CirculationTankAirPressureMeasurementTurbidity, CirculationTankAirPressureMeasurementTurbidityDto>().ForMember(x => x.ShiftName, x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null)).ForMember(x => x.CreatedByName, x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));



            CreateMap<DB_PlcMachine, PlcMachineDto>().ReverseMap();
            CreateMap<DB_PlcMachine, CreatePlcMachineDto>().ReverseMap();
            CreateMap<DB_PlcMachine, UpdatePlcMachineDto>().ReverseMap();

            CreateMap<DB_PlcTags, PlcMachineTagsDto>().ReverseMap();
            CreateMap<DB_PlcTags, CreatePlcMachineTagsDto>().ReverseMap().ForMember(x => x.Machine, opt => opt.Ignore());
            CreateMap<DB_PlcTags, UpdatePlcMachineTagsDto>().ReverseMap();
            CreateMap<DB_PlcTags, PlcMachineTagsDto>().ForMember(x => x.MachineName, x => x.MapFrom(s => s.Machine != null ? s.Machine.Name : null));

            CreateMap<DB_ElectricMeterLocation, ElectricMeterLocationDto>().ReverseMap();
            CreateMap<DB_ElectricMeterLocation, UpdateElectricMeterLocationDto>().ReverseMap();
            CreateMap<DB_ElectricMeterLocation, CreateElectricMeterLocationDto>().ReverseMap();
            CreateMap<DB_ElectricMeterLocation, ElectricMeterLocationDto>().ForMember(x => x.ShiftName, x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null)).ForMember(x => x.CreatedByName, x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null));


            CreateMap<DB_CumulativeElectricityConsumption, CumulativeElectricityConsumptionDto>().ReverseMap();
            CreateMap<DB_CumulativeElectricityConsumption, CreateCumulativeElectricityConsumptionDto>().ReverseMap().ForMember(x => x.ElectricMeterLocation, opt => opt.Ignore());
            CreateMap<DB_CumulativeElectricityConsumption, UpdateCumulativeElectricityConsumptionDto>().ReverseMap().ForMember(x => x.ElectricMeterLocation, opt => opt.Ignore()).ForMember(x => x.Department, opt => opt.Ignore());
            CreateMap<DB_CumulativeElectricityConsumption, CumulativeElectricityConsumptionDto>().ForMember(x => x.ShiftName, x => x.MapFrom(s => s.Shift != null ? s.Shift.ShiftName : null))
                .ForMember(x => x.CreatedByName, x => x.MapFrom(s => s.AppUser != null ? s.AppUser.UserName : null))
                .ForMember(x => x.LocationName, x => x.MapFrom(s => s.ElectricMeterLocation != null ? s.ElectricMeterLocation.LocationName : null));



            CreateMap<DB_FavoriteMenuItem, UserDashboardFavoriteMenuDto>().ReverseMap();
            CreateMap<DB_FavoriteMenuItem, UserDashboardAddFavoriteModuleDto>().ReverseMap();

            CreateMap<DB_AppUser, UpdateUserDto>().ForMember(x => x.DepartmentName, x => x.MapFrom(s => s.Department != null ? s.Department.DepartmentName : null)).ReverseMap();



        }
    }
}
