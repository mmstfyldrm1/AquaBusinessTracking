using BusinessLayer.Abstract.Integrations;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlcController : ControllerBase
    {
        private readonly IPlcService _plcService;
        private readonly ILogger<PlcController> _logger;

        public PlcController(
            IPlcService plcService,
            ILogger<PlcController> logger)
        {
            _plcService = plcService;
            _logger = logger;
        }

        [HttpGet("readings/{machineId}")]
        public async Task<IActionResult> GetReadings(
            int machineId,
            [FromQuery] int count = 50)
        {
            _logger.LogInformation(
                "PLC okuma değerleri istendi. MachineId={MachineId}, Count={Count}, User={User}",
                machineId,
                count,
                User?.Identity?.Name);

            try
            {
                var result = await _plcService.GetLastReadingsAsync(machineId, count);

                _logger.LogInformation(
                    "PLC okuma değerleri başarıyla getirildi. MachineId={MachineId}, RecordCount={Count}",
                    machineId,
                    result.Count());

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "PLC okuma değerleri alınırken hata oluştu. MachineId={MachineId}",
                    machineId);

                return StatusCode(
                    500,
                    "PLC okuma verileri alınırken hata oluştu.");
            }
        }

        [HttpGet("machines")]
        public async Task<IActionResult> GetMachines()
        {
            _logger.LogInformation(
                "Aktif PLC makineleri istendi. User={User}",
                User?.Identity?.Name);

            try
            {
                var result = await _plcService.GetActiveMachinesAsync();

                _logger.LogInformation(
                    "{Count} adet aktif PLC makinesi getirildi.",
                    result.Count());

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Aktif PLC makineleri alınırken hata oluştu.");

                return StatusCode(
                    500,
                    "PLC makine bilgileri alınırken hata oluştu.");
            }
        }
    }
}