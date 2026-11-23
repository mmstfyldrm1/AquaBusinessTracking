using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface IBoilerSteamFeedWaterCondensateDataRepository : IGenericRepository<DB_BoilerSteamFeedWaterCondensateData>
    {
        Task<List<DB_BoilerSteamFeedWaterCondensateData>> GetWithDetails();

        Task<List<DB_BoilerSteamFeedWaterCondensateData>> GetPreviousDay();

        public Task<List<DB_BoilerSteamFeedWaterCondensateData>> GetLast30DaysBoilerConsumable();

        public Task<List<DB_BoilerSteamFeedWaterCondensateData>> GetWithSearchDetails(DateTime StartDate, DateTime EndDate);


    }
}