using AIAgent.Services.Abstract.NaturelGas;
using DTOLayer.Dtos.NaturelGasMeterMonitoringDtos;
using System.Net.Http.Json;

namespace AIAgent.Services.Manager
{
    public class NaturelGasManager : INaturelGasApiService
    {
        private readonly HttpClient _httpClient;

        public NaturelGasManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<NaturelGasMeterMonitoringDto>> GetWithBySearch(DateTime StartDate, DateTime EndDate)
        {
            var response = await _httpClient.GetAsync($"NaturelGasMeterMonitoring/search?startDate={StartDate:yyyy-MM-dd}&endDate={EndDate:yyyy-MM-dd}");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<List<NaturelGasMeterMonitoringDto>>();


            if (result == null)
            {
                throw new Exception(
                    "Üretim API'sinden geçerli bir cevap alınamadı.");
            }



            return result;
        }
    }
}
