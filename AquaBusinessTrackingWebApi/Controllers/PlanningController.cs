using BusinessLayer.Abstract;
using DTOLayer.Dtos.PlanningDto;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanningController : ControllerBase
    {
        private readonly IWastePaperControlService _wastepPaperService;
        private readonly IDoughPreparationHeadService _doughPreparationHeadService;
        private readonly IPapperMachineChemicalService _paperMachineChemicalService;
        private readonly IKazanChemicalsHeadService _kazanChemicalsHeadService;
        private readonly IWaterPreparationAndConsumptionService _waterPreparationAndConsumptionService;
        private readonly IBoilerSteamFeedWaterCondensateDataService _boilerSteamFeedWaterCondensateDataService;
        private readonly IPurificationChemicalsConsumptionService _purificationChemicalsConsumptionService;
        private readonly IBufferAnalysisReportService _bufferAnalysisReportService;
        private readonly INaturelGasMeterMonitoringService _naturelGasMeterMonitoringService;
        private readonly ICumulativeElectricityConsumptionService _cumulativeElectricityConsumptionService;
        private readonly ILogger<PlanningController> _logger;

        public PlanningController(
            IWastePaperControlService wastepPaperService,
            IDoughPreparationHeadService doughPreparationHeadService,
            IPapperMachineChemicalService paperMachineChemicalService,
            IKazanChemicalsHeadService kazanChemicalsHeadService,
            IWaterPreparationAndConsumptionService waterPreparationAndConsumptionService,
            IBoilerSteamFeedWaterCondensateDataService boilerSteamFeedWaterCondensateDataService,
            IPurificationChemicalsConsumptionService purificationChemicalsConsumptionService,
            IBufferAnalysisReportService bufferAnalysisReportService,
            INaturelGasMeterMonitoringService naturelGasMeterMonitoringService,
            ICumulativeElectricityConsumptionService cumulativeElectricityConsumptionService,
            ILogger<PlanningController> logger)
        {
            _wastepPaperService = wastepPaperService;
            _doughPreparationHeadService = doughPreparationHeadService;
            _paperMachineChemicalService = paperMachineChemicalService;
            _kazanChemicalsHeadService = kazanChemicalsHeadService;
            _waterPreparationAndConsumptionService = waterPreparationAndConsumptionService;
            _boilerSteamFeedWaterCondensateDataService = boilerSteamFeedWaterCondensateDataService;
            _purificationChemicalsConsumptionService = purificationChemicalsConsumptionService;
            _bufferAnalysisReportService = bufferAnalysisReportService;
            _naturelGasMeterMonitoringService = naturelGasMeterMonitoringService;
            _cumulativeElectricityConsumptionService = cumulativeElectricityConsumptionService;
            _logger = logger;
        }

        [HttpGet("planning")]
        public async Task<IActionResult> GetPreviosDay()
        {
            _logger.LogInformation(
                "Planlama verileri isteniyor. User={User}",
                User?.Identity?.Name);

            var wastePaperControl = await _wastepPaperService.GetPreviousDay();
            var doughPreparationHeads = await _doughPreparationHeadService.GetPreviousDay();
            var paperMachineChemicals = await _paperMachineChemicalService.GetPreviousDay();
            var kazanChemicalsHeads = await _kazanChemicalsHeadService.GetPreviousDay();
            var waterPreparationAndConsumptions = await _waterPreparationAndConsumptionService.GetPreviousDay();
            var boilerSteamFeedWaterCondensateDatas = await _boilerSteamFeedWaterCondensateDataService.GetPreviousDay();
            var purificationChemicalsConsumptions = await _purificationChemicalsConsumptionService.GetPreviousDay();
            var bufferAnalysisReports = await _bufferAnalysisReportService.GetPreviousDay();
            var naturelGasMeterMonitorings = await _naturelGasMeterMonitoringService.GetPreviousDay();
            var cumulativeElectricityConsumptions = await _cumulativeElectricityConsumptionService.GetPreviousDay();

            var planningDto = new PlanningDto
            {
                PapperMachineChemicals = paperMachineChemicals,
                BoilerSteamFeedWaterCondensateDatas = boilerSteamFeedWaterCondensateDatas,
                BufferAnalysisReports = bufferAnalysisReports,
                CumulativeElectricityConsumptions = cumulativeElectricityConsumptions,
                DoughPreparations = doughPreparationHeads,
                KazanChemicalsForms = kazanChemicalsHeads,
                NaturelGasMeterMonitorings = naturelGasMeterMonitorings,
                PurificationChemicalsConsumptions = purificationChemicalsConsumptions,
                WastePaperControls = wastePaperControl,
                WaterPreparationAndConsumptions = waterPreparationAndConsumptions
            };

            _logger.LogInformation(
                "Planlama verileri başarıyla oluşturuldu ve döndürüldü.");

            return Ok(planningDto);
        }
    }
}