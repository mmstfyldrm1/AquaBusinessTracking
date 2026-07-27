using DTOLayer.Dtos.QueryDtos;

namespace DataAccsessLayer.Abstract
{
    public interface IQueryRepository
    {
        Task<List<Dictionary<string, object>>> ExecuteQueryAsync(QueryRequestDto request);
    }
}
