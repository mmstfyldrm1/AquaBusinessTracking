using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccsessLayer.Concrete.Repository
{
    public class LabWorkRepository : GenericRepository<DB_LabWork>, ILabWorkRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public LabWorkRepository(AquaBusinessTrackingContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<DB_LabWork>> GetWithDetails()
        {
            return await _context.Db_LabWork
                .Include(x => x.Shift)
                .Include(x => x.AppUser)
                .ToListAsync();
        }
    }
}
