using AIAgent.Models.Sales;
using AIAgent.Services.Abstract.Sales;
using DTOLayer.Dtos.SentezProductionDtos;
using System.Net.Http.Json;

namespace AIAgent.Services.Manager
{
    public class SalesApiManager : ISalesApiService
    {
        private readonly HttpClient _httpClient;

        public SalesApiManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<SentezProductionDto>> GetSalesGetbyDateAsync(DateTime startDate, DateTime endDate)
        {
            var response = await _httpClient.GetAsync($"SentezIntegrations/searchSales?startDate={startDate:yyyy-MM-dd}&endDate={endDate:yyyy-MM-dd}");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<SalesApiResponse>();


            if (result == null)
            {
                throw new Exception(
                    "Üretim API'sinden geçerli bir cevap alınamadı.");
            }



            return result.Data;

        }
    }
}
