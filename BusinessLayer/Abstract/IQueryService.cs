using DTOLayer.Dtos.QueryDtos;

namespace BusinessLayer.Abstract
{
    public interface IQueryService
    {
        public Task<List<Dictionary<string, object>>> ExecuteQueryAsync(QueryRequestDto request);
    }
}
