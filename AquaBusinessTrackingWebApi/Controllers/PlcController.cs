using BusinessLayer.Abstract.Integrations;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlcController : ControllerBase
    {
        private readonly IPlcService _plcService;

        public PlcController(IPlcService plcService) => _plcService = plcService;

        [HttpGet("readings/{machineId}")]
        public async Task<IActionResult> GetReadings(int machineId, [FromQuery] int count = 50)
            => Ok(await _plcService.GetLastReadingsAsync(machineId, count));

        [HttpGet("machines")]
        public async Task<IActionResult> GetMachines()
            => Ok(await _plcService.GetActiveMachinesAsync());
    }
}
