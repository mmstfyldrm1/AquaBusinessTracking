using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccsessLayer.Concrete.Repository
{
    public class KazanChemicalsHeadRepository : GenericRepository<DB_KazanChemicalsHead>, IKazanChemicalsHeadRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public KazanChemicalsHeadRepository(AquaBusinessTrackingContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<DB_KazanChemicalsHead>> GetPreviousDay()
        {
            DateTime? startDate = DateTime.Today.AddDays(-1);
            DateTime? endDate = DateTime.Today;

            return await _context.Db_KazanChemicalsHead
              .Include(x => x.Shift)
              .Include(x => x.AppUser)
              .Where(x => x.InsertDate > startDate && x.InsertDate < endDate)
              .ToListAsync();
        }

        public async Task<List<DB_KazanChemicalsHead>> GetWithDetails()
        {
            return await _context.Db_KazanChemicalsHead
                .Include(x => x.Shift)
                .Include(x => x.AppUser)
                .ToListAsync();
        }
    }
}
