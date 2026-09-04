using AIAgent.Models.Production;
using DTOLayer.Dtos.SentezProductionDtos;

namespace AIAgent.Services.Abstract.Production
{
    public interface IProductionApiService
    {
        Task<List<DailyProductionDto>> GetDailyProductionAsync();

        Task<List<SentezProductionDto>> GetDailyWithByDateRangeProduction(DateTime startDate, DateTime endDate);


    }
}
