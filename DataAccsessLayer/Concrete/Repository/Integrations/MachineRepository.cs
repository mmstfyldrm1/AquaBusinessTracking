using DataAccsessLayer.Abstract.Integrations;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccsessLayer.Concrete.Repository.Integrations
{
    public class MachineRepository : GenericRepository<DB_PlcMachine>, IMachineRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public MachineRepository(AquaBusinessTrackingContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DB_PlcMachine>> GetAllActiveAsync()
        {
            return await _context.Db_PlcMachine
           .Include(m => m.Tags)
           .Where(m => m.IsActive)
           .ToListAsync();
        }

        public async Task<DB_PlcMachine?> GetWithTagsAsync(int machineId)
        {
            return await _context.Db_PlcMachine
           .Include(m => m.Tags.Where(t => t.IsActive))
           .FirstOrDefaultAsync(m => m.RecId == machineId);
        }
    }
}
