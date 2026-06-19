using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;

namespace DataAccsessLayer.Concrete.Repository
{
    public class ShiftRepository : GenericRepository<DB_Shift>, IShiftRepository
    {
        public ShiftRepository(AquaBusinessTrackingContext context) : base(context)
        {
        }
    }
}
