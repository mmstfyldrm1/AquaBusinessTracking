using DataAccsessLayer;
using DTOLayer.Dtos.QueryDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class QueryController : ControllerBase
    {
        private readonly AquaBusinessTrackingContext _context;
        private readonly ILogger<QueryController> _logger;

        public QueryController(
            AquaBusinessTrackingContext context,
            ILogger<QueryController> logger)
        {
            _context = context;
            _logger = logger;
        }


        [HttpPost("execute")]
        public async Task<IActionResult> ExecuteQuery(QueryRequestDto request)
        {
            _logger.LogInformation(
                "Query çalıştırma isteği geldi. User={User}",
                User?.Identity?.Name);


            if (string.IsNullOrWhiteSpace(request.Query))
            {
                _logger.LogWarning(
                    "Boş query gönderildi. User={User}",
                    User?.Identity?.Name);

                return BadRequest("Query cannot be empty.");
            }


            _logger.LogInformation(
                "Query hazırlanıyor. QueryLength={Length}, ParameterCount={ParameterCount}",
                request.Query.Length,
                request.Parameters?.Count ?? 0);


            try
            {
                using var cmd = _context.Database.GetDbConnection().CreateCommand();

                cmd.CommandText = request.Query;
                cmd.CommandType = System.Data.CommandType.Text;


                if (request.Parameters != null)
                {
                    foreach (var p in request.Parameters)
                    {
                        var param = cmd.CreateParameter();

                        param.ParameterName = "@" + p.Name;
                        param.Value = p.Value ?? " ";

                        cmd.Parameters.Add(param);
                    }
                }


                await _context.Database.OpenConnectionAsync();


                var reader = await cmd.ExecuteReaderAsync();


                var result = new List<Dictionary<string, object>>();


                while (await reader.ReadAsync())
                {
                    var row = new Dictionary<string, object>();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row[reader.GetName(i)] = reader.GetValue(i);
                    }

                    result.Add(row);
                }


                _logger.LogInformation(
                    "Query başarıyla çalıştı. Dönen kayıt sayısı={Count}",
                    result.Count);


                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(
                    ex,
                    "Query çalıştırılırken hata oluştu. User={User}",
                    User?.Identity?.Name);

                return StatusCode(500, "Query çalıştırılırken hata oluştu.");
            }
            finally
            {
                await _context.Database.CloseConnectionAsync();

                _logger.LogInformation(
                    "Database bağlantısı kapatıldı.");
            }
        }
    }
}