using DTOLayer.Dtos.BoilerSteamFeedWaterCondensateDataDtos;

namespace BusinessLayer.Abstract
{
    public interface IBoilerSteamFeedWaterCondensateDataService : IGenericService<BoilerSteamFeedWaterCondensateDataDto, CreateBoilerSteamFeedWaterCondensateDataDto, UpdateBoilerSteamFeedWaterCondensateDataDto>
    {
        public Task<List<BoilerSteamFeedWaterCondensateDataDto>> GetWithDetails();

        public Task<List<BoilerSteamFeedWaterCondensateDataDto>> GetPreviousDay();
        public Task<List<BoilerSteamFeedWaterCondensateDataDto>> GetLast30DaysBoilerConsumable();

        public Task<List<BoilerSteamFeedWaterCondensateDataDto>> GetWithSearchDetails(DateTime StartDate, DateTime EndDate);
    }
}
