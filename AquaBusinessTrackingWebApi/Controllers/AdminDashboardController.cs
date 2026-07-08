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

        private readonly ISalesScaleService _service;
        private readonly IDoughPreparationHeadService _headService;
        private readonly IPapperMachineChemicalService _machineChemicalService;
        private readonly IMachineStopService _machineStopService;
        private readonly IWaterPreparationAndConsumptionService _waterPreparationAndConsumptionService;
        private readonly ICumulativeElectricityConsumptionService _cumulativeElectricityConsumptionService;
        private readonly INaturelGasMeterMonitoringService _minerMonitoringService;

        public AdminDashboardController(ISalesScaleService service, IDoughPreparationHeadService headService, IPapperMachineChemicalService machineChemicalService, IMachineStopService machineStopService, IWaterPreparationAndConsumptionService waterPreparationAndConsumptionService, ICumulativeElectricityConsumptionService cumulativeElectricityConsumptionService, INaturelGasMeterMonitoringService minerMonitoringService)
        {
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
            return Ok();
        }

        [HttpGet("sales")]
        public async Task<IActionResult> GetDailySales()
        {
            var result = await _service.GetWithDetails();
            return Ok(result);
        }

        [HttpGet("rawmaterials")]
        public async Task<IActionResult> GetDailyRawMaterials()
        {
            var resultDoughPrepation = await _headService.GetWithDetails();
            var resultPaperMachine = await _machineChemicalService.GetWithDetails();

            var AdminDasboardRawmateriels = new RawMaterialsDto
            {
                DoughPreparation = resultDoughPrepation,
                PapperMachineChemical = resultPaperMachine,
            };

            return Ok(AdminDasboardRawmateriels);
        }

        [HttpGet("stopChart")]
        public async Task<IActionResult> GetMachineStop()
        {
            var result = await _machineStopService.GetStopChart();
            return Ok(result);
        }


        [HttpGet("electricConsumable")]
        public async Task<IActionResult> GetElectricConsumable()
        {

            var electric = await _cumulativeElectricityConsumptionService.GetLast7Days();
            return Ok(electric);
        }

        [HttpGet("Last7DaysNaturelGas")]
        public async Task<IActionResult> GetLast7DaysNaturelGas()
        {

            var electric = await _minerMonitoringService.GetLast7DaysNaturelGas();
            return Ok(electric);
        }
    }
}
