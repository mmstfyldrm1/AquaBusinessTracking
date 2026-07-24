using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.Extensions.Logging;

namespace DataAccsessLayer.Concrete.Repository
{
    public class BasinMeasurementRepository : GenericRepository<DB_BasinMeasurement>, IBasinMeasurementRepository
    {
        public BasinMeasurementRepository(AquaBusinessTrackingContext context, ILogger<GenericRepository<DB_BasinMeasurement>> logger) : base(context, logger)
        {
        }
    }
}
