using AIAgent.Services.Abstract.Shipment;
using DTOLayer.Dtos.SalesScale;
using System.Net.Http.Json;

namespace AIAgent.Services.Manager
{
    public class ShipmentApiManager : IShipmentApiService
    {
        private readonly HttpClient _httpClient;

        public ShipmentApiManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<SalesScaleDto>> GetLast30daysShipment()
        {
            var response = await _httpClient.GetAsync("SalesScale/last30days");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<List<SalesScaleDto>>();


            if (result == null)
            {
                throw new Exception(
                    "Üretim API'sinden geçerli bir cevap alınamadı.");
            }



            return result;
        }

        public async Task<List<SalesScaleDto>> GetWithBySearch(DateTime StartDate, DateTime EndDate)
        {
            var response = await _httpClient.GetAsync($"SalesScale/search?startDate={StartDate:yyyy-MM-dd}&endDate={EndDate:yyyy-MM-dd}");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<List<SalesScaleDto>>();


            if (result == null)
            {
                throw new Exception(
                    "Üretim API'sinden geçerli bir cevap alınamadı.");
            }



            return result;
        }
    }
}
