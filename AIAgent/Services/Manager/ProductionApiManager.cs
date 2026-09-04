using AIAgent.Models.Production;
using AIAgent.Services.Abstract.Production;
using DTOLayer.Dtos.SentezProductionDtos;
using System.Net.Http.Json;

namespace AIAgent.Services.Manager
{
    public class ProductionApiManager : IProductionApiService
    {
        private readonly HttpClient _httpClient;

        public ProductionApiManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<DailyProductionDto>> GetDailyProductionAsync()
        {
            var response = await _httpClient.GetAsync("SentezIntegrations/getLas7DaysProductionAsync");


            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<ProductionApiResponse>();


            if (result == null)
            {
                throw new Exception(
                    "Üretim API'sinden geçerli bir cevap alınamadı.");
            }

            if (!result.IsOk)
            {
                throw new Exception(
                    $"Üretim API hatası: {result.ErrorMessage}");
            }

            return result.Data;
        }

        public async Task<List<SentezProductionDto>> GetDailyWithByDateRangeProduction(DateTime startDate, DateTime endDate)
        {
            var response = await _httpClient.GetAsync($"SentezIntegrations/searchProduction?startDate={startDate:yyyy-MM-dd}&endDate={endDate:yyyy-MM-dd}");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<ProductionApiResponseGetbyDateRange>();

            if (result == null)
            {
                throw new Exception(
                    "Üretim API'sinden geçerli bir cevap alınamadı.");
            }



            return result.Data;
        }
    }
}
