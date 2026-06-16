using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract.Integrations
{
    public interface IPlcReadingRepository : IGenericRepository<DB_PlcReading>
    {
        Task<IEnumerable<DB_PlcReading>> GetLastNByTagAsync(int tagId, int count);
        Task<IEnumerable<DB_PlcReading>> GetByDateRangeAsync(int tagId, DateTime from, DateTime to);
        Task BulkInsertAsync(IEnumerable<DB_PlcReading> readings, CancellationToken ct);
    }
}
