using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccsessLayer.Concrete.Repository
{
    public class BoilerOperationandChemicalConsumptionRepository : GenericRepository<DB_BoilerOperationandChemicalConsumption>, IBoilerOperationandChemicalConsumptionRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public BoilerOperationandChemicalConsumptionRepository(AquaBusinessTrackingContext context, ILogger<GenericRepository<DB_BoilerOperationandChemicalConsumption>> logger) : base(context, logger)
        {
            _context = context;
        }

        public async Task<List<DB_BoilerOperationandChemicalConsumption>> GetWithDetails()
        {
            return await _context.Db_BoilerOperationandChemicalConsumption
           .Include(x => x.Shift)
           .Include(x => x.ScalePlace)
           .Include(x => x.KazanEnergyConsumption)
           .Include(x => x.AppUser)
           .OrderByDescending(x => x.RecId)
           .Take(500)
           .ToListAsync();

        }

        public async Task<List<DB_BoilerOperationandChemicalConsumption>> GetWithSearchDetails(DateTime StartDate, DateTime EndDate)
        {

            var query = _context.Db_BoilerOperationandChemicalConsumption
                .Include(x => x.Shift)
                .Include(x => x.AppUser)
                .Include(x => x.ScalePlace)
                .Include(x => x.KazanEnergyConsumption)
                .Where(x => x.ReceiptDate >= StartDate && x.ReceiptDate < EndDate);

            var sql = query.ToQueryString();
            Console.WriteLine(sql);

            return await query.ToListAsync();
        }


    }
}
