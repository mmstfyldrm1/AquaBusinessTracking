using DTOLayer.Dtos.SentezIntegrationsDtos;

namespace AIAgent.Services.Abstract.Sales
{
    public interface ISalesApiService
    {
        Task<List<SentezSalesResponseDto>> GetSalesGetbyDateAsync(DateTime startDate, DateTime endDate);
    }
}
