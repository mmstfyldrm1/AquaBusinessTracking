using AIAgent.Services.Abstract.Electric;
using DTOLayer.Dtos.ElectricDtos.CumulativeElectricityConsumptionDtos;
using System.Net.Http.Json;

namespace AIAgent.Services.Manager
{
    public class ElectricApiManager : IElectricApiService
    {
        private readonly HttpClient _httpClient;

        public ElectricApiManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<CumulativeElectricityConsumptionDto>> GetWithBySearch(DateTime StartDate, DateTime EndDate)
        {
            var response = await _httpClient.GetAsync($"CumulativeElectricityConsumption/search?startDate={StartDate:yyyy-MM-dd}&endDate={EndDate:yyyy-MM-dd}");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<List<CumulativeElectricityConsumptionDto>>();


            if (result == null)
            {
                throw new Exception(
                    "Üretim API'sinden geçerli bir cevap alınamadı.");
            }



            return result;
        }
    }
}
