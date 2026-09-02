using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccsessLayer.Concrete.Repository
{
    public class BasinMeasurementRepository : GenericRepository<DB_BasinMeasurement>, IBasinMeasurementRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public BasinMeasurementRepository(AquaBusinessTrackingContext context, ILogger<GenericRepository<DB_BasinMeasurement>> logger) : base(context, logger)
        {

            _context = context;

        }

        public async Task<List<DB_BasinMeasurement>> GetWithDetails()
        {
            return await _context.Db_BasinMeasurement
                .Include(x => x.Basin)
                .Include(x => x.Shift)
                .Include(x => x.AppUser)
                .OrderByDescending(x => x.RecId)
                .Take(200)
                .ToListAsync();

        }

        public async Task<List<DB_BasinMeasurement>> GetWithSearchDetails(DateTime StartDate, DateTime EndDate)
        {

            var query = _context.Db_BasinMeasurement
                .Include(x => x.Shift)
                .Include(x => x.AppUser)
                .Include(x => x.Basin)
                .Where(x => x.ReceiptDate >= StartDate && x.ReceiptDate < EndDate);

            var sql = query.ToQueryString();
            Console.WriteLine(sql);

            return await query.ToListAsync();
        }


    }
}
