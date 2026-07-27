using DataAccsessLayer.Abstract;
using DTOLayer.Dtos.QueryDtos;
using Microsoft.EntityFrameworkCore;

namespace DataAccsessLayer.Concrete.Repository
{
    public class QueryRepository : IQueryRepository
    {
        private readonly AquaBusinessTrackingContext _context;

        public QueryRepository(AquaBusinessTrackingContext context)
        {
            _context = context;
        }

        public async Task<List<Dictionary<string, object>>> ExecuteQueryAsync(QueryRequestDto request)
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
                    param.Value = string.IsNullOrEmpty(p.Value) ? DBNull.Value : p.Value;



                    cmd.Parameters.Add(param);
                }
            }

            await _context.Database.OpenConnectionAsync();

            try
            {
                using var reader = await cmd.ExecuteReaderAsync();

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

                return result;
            }
            finally
            {
                await _context.Database.CloseConnectionAsync();
            }
        }
    }
}
