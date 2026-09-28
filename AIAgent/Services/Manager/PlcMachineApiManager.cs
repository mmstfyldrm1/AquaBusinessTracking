using AIAgent.Services.Abstract.PlcMachine;
using DTOLayer.Dtos.Integrations;
using System.Net.Http.Json;

namespace AIAgent.Services.Manager
{
    public class PlcMachineApiManager : IPlcMachineApiService
    {
        private readonly HttpClient _httpClient;

        public PlcMachineApiManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PlcReadingDto>> GetReadingsAsync(int machineId, DateTime startTime, DateTime endTime)
        {
            machineId = 6;
            var response = await _httpClient.GetAsync($"Plc/readingsByDate/{machineId}/by-date/{startTime:o}/{endTime:o}");

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<List<PlcReadingDto>>();


            if (result == null)
            {
                throw new Exception(
                    "Üretim API'sinden geçerli bir cevap alınamadı.");
            }

            return result;
        }
    }
}
