using BusinessLayer.Abstract;
using DTOLayer.Dtos.QueryDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class QueryController : ControllerBase
    {
        private readonly IQueryService _queryService;
        private readonly ILogger<QueryController> _logger;

        public QueryController(
            IQueryService queryService,
            ILogger<QueryController> logger)
        {
            _queryService = queryService;
            _logger = logger;
        }

        [HttpPost("execute")]
        public async Task<IActionResult> ExecuteQuery(QueryRequestDto request)
        {
            try
            {
                var result = await _queryService.ExecuteQueryAsync(request);

                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Query çalıştırılırken hata oluştu.");

                return StatusCode(500, ex.Message);
            }
        }
    }
}