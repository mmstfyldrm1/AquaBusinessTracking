using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface IBasinMeasurementRepository : IGenericRepository<DB_BasinMeasurement>
    {
        public Task<List<DB_BasinMeasurement>> GetWithDetails();

        public Task<List<DB_BasinMeasurement>> GetWithSearchDetails(DateTime StartDate, DateTime EndDate);


    }
}
