using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccsessLayer.Concrete.Repository
{
    public class SalesScaleRepository : GenericRepository<DB_SalesScale>, ISalesScaleRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public SalesScaleRepository(AquaBusinessTrackingContext context, ILogger<GenericRepository<DB_SalesScale>> logger) : base(context, logger)
        {
            _context = context;
        }

        public async Task<List<DB_SalesScale>> GetWithDetails()
        {
            return await _context.Db_SalesScale
              .Include(x => x.Shift)
              .Include(x => x.AppUser)
              .OrderByDescending(x => x.RecId)
                .Take(200)
              .ToListAsync();
        }

        public async Task<decimal> GetPreviousTodaySales()
        {
            DateTime startDate = DateTime.Today;
            DateTime endDate = DateTime.Today.AddDays(1);

            return await _context.Db_SalesScale
             .Where(x => x.ReceiptDate >= startDate && x.ReceiptDate < endDate)
            .SumAsync(x => x.DeliveryQuantity);


        }

        public async Task<List<DB_SalesScale>> GetWithLast30Days()
        {
            DateTime endDate = DateTime.Today;
            DateTime startDate = DateTime.Today.AddDays(-30);

            return await _context.Db_SalesScale
                .Include(x => x.Shift)
                .Include(x => x.AppUser)
                .Where(x => x.ScaleDate >= startDate && x.ScaleDate < endDate)
                .AsNoTracking()
                .ToListAsync();


        }

        public async Task<List<DB_SalesScale>> GetWithSearchDetails(DateTime StartDate, DateTime EndDate)
        {

            var query = _context.Db_SalesScale
                .Include(x => x.Shift)
                .Include(x => x.AppUser)
                .Where(x => x.ScaleDate >= StartDate && x.ScaleDate < EndDate);

            var sql = query.ToQueryString();
            Console.WriteLine(sql);

            return await query.ToListAsync();
        }
    }
}
