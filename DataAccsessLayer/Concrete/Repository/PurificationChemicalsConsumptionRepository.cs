using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccsessLayer.Concrete.Repository
{
    public class PurificationChemicalsConsumptionRepository : GenericRepository<DB_PurificationChemicalsConsumption>, IPurificationChemicalsConsumptionRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public PurificationChemicalsConsumptionRepository(AquaBusinessTrackingContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<DB_PurificationChemicalsConsumption>> GetWithDetails()
        {
            return await _context.Db_PurificationChemicalsConsumption
                .Include(x => x.Shift)
                .Include(x => x.AppUser)
                .ToListAsync();
        }
    }
}
