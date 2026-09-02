using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccsessLayer.Concrete.Repository
{
    public class KazanEnergyConsumptionRepository : GenericRepository<DB_KazanEnergyConsumption>, IKazanEnergyConsumptionRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public KazanEnergyConsumptionRepository(AquaBusinessTrackingContext context, ILogger<GenericRepository<DB_KazanEnergyConsumption>> logger) : base(context, logger)
        {
            _context = context;
        }

        public async Task<List<DB_KazanEnergyConsumption>> GetWithDetails()
        {
            return await _context.Db_KazanEnergyConsumption
                .Include(x => x.Shift)
                .Include(x => x.AppUser)
                 .OrderByDescending(x => x.RecId)
                .ToListAsync();
        }
    }
}
