using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;

namespace DataAccsessLayer.Concrete.Repository
{
    public class PlcMachineRepository : GenericRepository<DB_PlcMachine>, IPlcMachineRepository
    {
        public PlcMachineRepository(AquaBusinessTrackingContext context) : base(context)
        {
        }
    }
}
