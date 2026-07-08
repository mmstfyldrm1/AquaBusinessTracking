using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccsessLayer.Concrete.Repository
{
    public class SalesScaleRepository : GenericRepository<DB_SalesScale>, ISalesScaleRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public SalesScaleRepository(AquaBusinessTrackingContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<DB_SalesScale>> GetWithDetails()
        {
            return await _context.Db_SalesScale
                .Include(x => x.Shift)
                .Include(x => x.AppUser)
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


    }
}
