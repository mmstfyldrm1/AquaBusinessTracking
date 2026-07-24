using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccsessLayer.Concrete.Repository
{
    public class PurificationChemicalsConsumptionRepository : GenericRepository<DB_PurificationChemicalsConsumption>, IPurificationChemicalsConsumptionRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public PurificationChemicalsConsumptionRepository(AquaBusinessTrackingContext context, ILogger<GenericRepository<DB_PurificationChemicalsConsumption>> logger) : base(context, logger)
        {
            _context = context;
        }

        public async Task<List<DB_PurificationChemicalsConsumption>> GetPreviousDay()
        {
            DateTime? startDate = DateTime.Today.AddDays(-1);
            DateTime? endDate = DateTime.Today;

            return await _context.Db_PurificationChemicalsConsumption
              .Include(x => x.Shift)
              .Include(x => x.AppUser)
              .Where(x => x.ReceiptDate >= startDate && x.ReceiptDate < endDate)
              .ToListAsync();
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
