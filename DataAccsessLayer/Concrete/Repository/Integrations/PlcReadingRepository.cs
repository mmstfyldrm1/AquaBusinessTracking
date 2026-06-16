using DataAccsessLayer.Abstract.Integrations;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccsessLayer.Concrete.Repository.Integrations
{
    public class PlcReadingRepository : GenericRepository<DB_PlcReading>, IPlcReadingRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public PlcReadingRepository(AquaBusinessTrackingContext context) : base(context)
        {
            _context = context;
        }

        public async Task BulkInsertAsync(IEnumerable<DB_PlcReading> readings, CancellationToken ct)
        {
            await _context.Db_PlcReading.AddRangeAsync(readings, ct);
            await _context.Db_PlcReading.AddRangeAsync(readings, ct);
        }

        public async Task<IEnumerable<DB_PlcReading>> GetByDateRangeAsync(int tagId, DateTime from, DateTime to)
        {
            return await _context.Db_PlcReading
         .Where(r => r.PlcTagId == tagId
                  && r.ReadingTime >= from
                  && r.ReadingTime <= to)
         .OrderBy(r => r.ReadingTime)
         .ToListAsync();
        }

        public async Task<IEnumerable<DB_PlcReading>> GetLastNByTagAsync(int tagId, int count)
        {
            return await _context.Db_PlcReading
           .Where(r => r.PlcTagId == tagId)
           .OrderByDescending(r => r.ReadingTime)
           .Take(count)
           .ToListAsync();
        }
    }
}
