using AIAgent.Services.Abstract.RawMaterials;
using DTOLayer.Dtos.RawMaterialIntakesDtos;
using System.Net.Http.Json;

namespace AIAgent.Services.Manager
{
    public class RawMaterialsApiManager : IRawMaterialsApiService
    {
        private readonly HttpClient _httpClient;

        public RawMaterialsApiManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<RawMaterialIntakesDto>> GetWithSearchDetails(DateTime StartDate, DateTime EndDate)
        {
            var response = await _httpClient.GetAsync($"RawMaterialIntake/search?startDate={StartDate:yyyy-MM-dd}&endDate={EndDate:yyyy-MM-dd}");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<List<RawMaterialIntakesDto>>();


            if (result == null)
            {
                throw new Exception(
                    "Üretim API'sinden geçerli bir cevap alınamadı.");
            }



            return result;
        }
    }
}
