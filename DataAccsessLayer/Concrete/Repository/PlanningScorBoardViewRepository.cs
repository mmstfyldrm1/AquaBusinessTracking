using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataAccsessLayer.Concrete.Repository
{
    public class PlanningScorBoardViewRepository : GenericRepository<DB_PlanningScorBoardView>, IPlanningScorBoardViewRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        public PlanningScorBoardViewRepository(AquaBusinessTrackingContext context, ILogger<GenericRepository<DB_PlanningScorBoardView>> logger) : base(context, logger)
        {
            _context = context;
        }

        public async Task<List<DB_PlanningScorBoardView>> GetWithDetails()
        {
            return await _context.Db_PlanningScorBoardView
           .Include(x => x.Shift)
           .Include(x => x.AppUser)
           .ToListAsync();
        }
    }
}
