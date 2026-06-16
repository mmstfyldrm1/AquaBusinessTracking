using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccsessLayer.Concrete.Repository
{
    public class NaturelGasMeterMonitoringRepository : GenericRepository<DB_NaturelGasMeterMonitoring>, INaturelGasMeterMonitoringRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public NaturelGasMeterMonitoringRepository(AquaBusinessTrackingContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<DB_NaturelGasMeterMonitoring>> GetWithDetails()
        {
            return await _context.Db_NaturelGasMeterMonitoring
                .Include(x => x.Shift)
                .Include(x => x.AppUser)
                .ToListAsync();
        }
    }
}
