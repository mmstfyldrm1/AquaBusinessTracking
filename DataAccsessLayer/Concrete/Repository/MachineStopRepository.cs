using DataAccsessLayer.Abstract;
using DTOLayer.Dtos.AdminDashboardDtos;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccsessLayer.Concrete.Repository
{
    public class MachineStopRepository : GenericRepository<DB_MachineStop>, IMachineStopRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public MachineStopRepository(AquaBusinessTrackingContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<DB_MachineStop>> GetWithDetails()
        {
            return await _context.Db_MachineStop
           .Include(x => x.Shift)
           .Include(x => x.AppUser)
           .ToListAsync();
        }

        public async Task<List<StopChartDto>> GetStopChart()
        {
            var durusData = await _context.Db_MachineStop
             .GroupBy(x => x.BreakLocation)
             .Select(x => new StopChartDto
             {
                 Reason = x.Key,
                 TotalDuration = x.Sum(y => y.DowntimeDuration)
             })
             .ToListAsync();

            return (durusData);
        }
    }
}
