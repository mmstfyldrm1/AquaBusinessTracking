using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SentezIntegrationsController : ControllerBase
    {
        private readonly ISentezQueryService _service;


        public SentezIntegrationsController(ISentezQueryService service)
        {
            _service = service;
        }

        [HttpGet("getpreviousdaystock")]
        public async Task<IActionResult> GetPreviousDay()
        {
            var result = await _service.GetPreviousDayStockAsync();
            return Ok(result);
        }

        [HttpGet("getStock")]
        public async Task<IActionResult> GetStock()
        {
            var result = await _service.GetStockAsync();
            return Ok(result);

        }

        [HttpGet("getpreviousdaySales")]
        public async Task<IActionResult> GetSalesPreviousDay()
        {
            var result = await _service.GetPreviousDaySalesAsync();
            return Ok(result);
        }

        [HttpGet("getSales")]
        public async Task<IActionResult> GetSales()
        {
            var result = await _service.GetSalesAsync();
            return Ok(result);

        }

        [HttpGet("getLas7DaysProductionAsync")]
        public async Task<IActionResult> GetLas7DaysProductionAsync()
        {
            var result = await _service.GetLas7DaysProductionAsync();
            return Ok(result);

        }
    }
}
