using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccsessLayer.Concrete.Repository
{
    public class PapperMachineChemicalRepository : GenericRepository<DB_PapperMachineChemical>, IPapperMachineChemicalRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public PapperMachineChemicalRepository(AquaBusinessTrackingContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<DB_PapperMachineChemical>> GetWithDetails()
        {
            return await _context.Db_PapperMachineChemical
                .Include(x => x.Shift)
                .Include(x => x.AppUser)
                .ToListAsync();
        }
    }
}
