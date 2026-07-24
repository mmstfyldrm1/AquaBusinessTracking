using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.Extensions.Logging;

namespace DataAccsessLayer.Concrete.Repository
{
    public class ShiftRepository : GenericRepository<DB_Shift>, IShiftRepository
    {
        public ShiftRepository(AquaBusinessTrackingContext context, ILogger<GenericRepository<DB_Shift>> logger) : base(context, logger)
        {
        }
    }
}
