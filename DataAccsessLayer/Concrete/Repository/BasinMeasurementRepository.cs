using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;

namespace DataAccsessLayer.Concrete.Repository
{
    public class BasinMeasurementRepository : GenericRepository<DB_BasinMeasurement>, IBasinMeasurementRepository
    {
        public BasinMeasurementRepository(AquaBusinessTrackingContext context) : base(context)
        {
        }
    }
}
