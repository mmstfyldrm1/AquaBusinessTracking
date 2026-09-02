using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccsessLayer.Concrete.Repository
{
    public class PapperMachineChemicalRepository : GenericRepository<DB_PapperMachineChemical>, IPapperMachineChemicalRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public PapperMachineChemicalRepository(AquaBusinessTrackingContext context, ILogger<GenericRepository<DB_PapperMachineChemical>> logger) : base(context, logger)
        {
            _context = context;
        }

        public async Task<List<DB_PapperMachineChemical>> GetPreviousDay()
        {
            DateTime? startDate = DateTime.Today.AddDays(-1);
            DateTime? endDate = DateTime.Today;

            return await _context.Db_PapperMachineChemical
              .Include(x => x.Shift)
              .Include(x => x.AppUser)
              .Where(x => x.ReceiptDate >= startDate && x.ReceiptDate < endDate)
              .ToListAsync();
        }

        public async Task<List<DB_PapperMachineChemical>> GetWithDetails()
        {
            return await _context.Db_PapperMachineChemical
                .Include(x => x.Shift)
                .Include(x => x.AppUser)
                .OrderByDescending(x => x.RecId)
                .Take(200)
                .ToListAsync();

        }

        public async Task<List<DB_PapperMachineChemical>> GetWithSearchDetails(DateTime StartDate, DateTime EndDate)
        {

            var query = _context.Db_PapperMachineChemical
                .Include(x => x.Shift)
                .Include(x => x.AppUser)
                .Where(x => x.ReceiptDate >= StartDate && x.ReceiptDate < EndDate);

            var sql = query.ToQueryString();
            Console.WriteLine(sql);

            return await query.ToListAsync();
        }
    }
}
