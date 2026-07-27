using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DTOLayer.Dtos.QueryDtos;

namespace BusinessLayer.Concrete
{
    public class QueryManager : IQueryService
    {
        private readonly IQueryRepository _queryService;

        public QueryManager(IQueryRepository queryService)
        {
            _queryService = queryService;
        }

        public async Task<List<Dictionary<string, object>>> ExecuteQueryAsync(QueryRequestDto request)
        {
            if (string.IsNullOrWhiteSpace(request.Query))
                throw new Exception("Query boş olamaz.");

            return await _queryService.ExecuteQueryAsync(request);
        }
    }
}
