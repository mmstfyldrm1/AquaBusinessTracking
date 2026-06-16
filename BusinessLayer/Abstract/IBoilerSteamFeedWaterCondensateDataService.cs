using DTOLayer.Dtos.BoilerSteamFeedWaterCondensateDataDtos;

namespace BusinessLayer.Abstract
{
    public interface IBoilerSteamFeedWaterCondensateDataService : IGenericService<BoilerSteamFeedWaterCondensateDataDto, CreateBoilerSteamFeedWaterCondensateDataDto, UpdateBoilerSteamFeedWaterCondensateDataDto>
    {
        public Task<List<BoilerSteamFeedWaterCondensateDataDto>> GetWithDetails();
    }
}
