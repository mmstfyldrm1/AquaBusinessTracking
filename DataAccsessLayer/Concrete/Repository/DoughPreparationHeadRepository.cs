using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccsessLayer.Concrete.Repository
{
    public class DoughPreparationHeadRepository : GenericRepository<DB_DoughPreparation>, IDoughPreparationHeadRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public DoughPreparationHeadRepository(AquaBusinessTrackingContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<DB_DoughPreparation>> GetPreviousDay()
        {
            DateTime startdate = DateTime.Today.AddDays(-1);
            DateTime endDate = DateTime.Today;


            return await _context.Db_DoughPreparation
                .Include(x => x.Shift)
                .Include(x => x.AppUser)
                .Where(x => x.ReceiptDate >= startdate && x.ReceiptDate < endDate)
                .ToListAsync();
        }

        public async Task<List<DB_DoughPreparation>> GetWithDetails()
        {
            return await _context.Db_DoughPreparation
                .Include(x => x.Shift)
                .Include(x => x.AppUser)
                .ToListAsync();
        }
    }
}
