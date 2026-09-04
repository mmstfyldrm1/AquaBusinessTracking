using DTOLayer.Dtos.SentezProductionDtos;

namespace AIAgent.Services.Abstract.Sales
{
    public interface ISalesApiService
    {
        Task<List<SentezProductionDto>> GetSalesGetbyDateAsync(DateTime startDate, DateTime endDate);
    }
}
