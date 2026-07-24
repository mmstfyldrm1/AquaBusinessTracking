using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.Extensions.Logging;

namespace DataAccsessLayer.Concrete.Repository
{
    public class PlcMachineRepository : GenericRepository<DB_PlcMachine>, IPlcMachineRepository
    {
        public PlcMachineRepository(AquaBusinessTrackingContext context, ILogger<GenericRepository<DB_PlcMachine>> logger) : base(context, logger)
        {
        }
    }
}
