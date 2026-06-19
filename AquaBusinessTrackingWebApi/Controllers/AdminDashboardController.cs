using BusinessLayer.Abstract;
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

        public AdminDashboardController(ISalesScaleService service, IDoughPreparationHeadService headService)
        {
            _service = service;
            _headService = headService;
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
            var result = await _headService.GetWithDetails();
            return Ok(result);
        }

    }
}
