using BusinessLayer.Abstract;
using DTOLayer.Dtos.AdminDashboardDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdminDashboardController : ControllerBase
    {
        private readonly ILogger<AdminDashboardController> _logger;

        private readonly ISalesScaleService _service;
        private readonly IDoughPreparationHeadService _headService;
        private readonly IPapperMachineChemicalService _machineChemicalService;
        private readonly IMachineStopService _machineStopService;
        private readonly IWaterPreparationAndConsumptionService _waterPreparationAndConsumptionService;
        private readonly ICumulativeElectricityConsumptionService _cumulativeElectricityConsumptionService;
        private readonly INaturelGasMeterMonitoringService _minerMonitoringService;

        public AdminDashboardController(
            ILogger<AdminDashboardController> logger,
            ISalesScaleService service,
            IDoughPreparationHeadService headService,
            IPapperMachineChemicalService machineChemicalService,
            IMachineStopService machineStopService,
            IWaterPreparationAndConsumptionService waterPreparationAndConsumptionService,
            ICumulativeElectricityConsumptionService cumulativeElectricityConsumptionService,
            INaturelGasMeterMonitoringService minerMonitoringService)
        {
            _logger = logger;
            _service = service;
            _headService = headService;
            _machineChemicalService = machineChemicalService;
            _machineStopService = machineStopService;
            _waterPreparationAndConsumptionService = waterPreparationAndConsumptionService;
            _cumulativeElectricityConsumptionService = cumulativeElectricityConsumptionService;
            _minerMonitoringService = minerMonitoringService;
        }

        [HttpGet("production")]
        public async Task<IActionResult> GetDailyProduction()
        {
            _logger.LogInformation("Production dashboard istendi. User: {User}",
                User?.Identity?.Name);

            return Ok();
        }

        [HttpGet("sales")]
        public async Task<IActionResult> GetDailySales()
        {
            _logger.LogInformation("Sales dashboard istendi. User: {User}",
                User?.Identity?.Name);

            var result = await _service.GetWithDetails();

            _logger.LogInformation("Sales dashboard başarıyla döndü.");

            return Ok(result);
        }

        [HttpGet("rawmaterials")]
        public async Task<IActionResult> GetDailyRawMaterials()
        {
            _logger.LogInformation("Raw Materials dashboard istendi.");

            var resultDoughPrepation = await _headService.GetWithDetails();
            var resultPaperMachine = await _machineChemicalService.GetWithDetails();

            var dashboard = new RawMaterialsDto
            {
                DoughPreparation = resultDoughPrepation,
                PapperMachineChemical = resultPaperMachine
            };

            _logger.LogInformation("Raw Materials dashboard oluşturuldu.");

            return Ok(dashboard);
        }

        [HttpGet("stopChart")]
        public async Task<IActionResult> GetMachineStop()
        {
            _logger.LogInformation("Machine Stop Chart istendi.");

            var result = await _machineStopService.GetStopChart();

            return Ok(result);
        }

        [HttpGet("Last30DaysElectricConsumable")]
        public async Task<IActionResult> GetLast30DaysElectricConsumable()
        {
            _logger.LogInformation("Son 30 günlük elektrik tüketimi istendi.");

            var result = await _cumulativeElectricityConsumptionService.GetLast30DaysElectricConsumable();

            return Ok(result);
        }

        [HttpGet("Last30DaysNaturelGas")]
        public async Task<IActionResult> GetLast30DaysNaturelGas()
        {
            _logger.LogInformation("Son 30 günlük doğal gaz tüketimi istendi.");

            var result = await _minerMonitoringService.GetLast30DaysNaturelGas();

            return Ok(result);
        }
    }
}