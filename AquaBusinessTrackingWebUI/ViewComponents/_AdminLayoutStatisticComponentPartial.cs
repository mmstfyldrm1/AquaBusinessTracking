using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.Integrations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace AquaBusinessTrackingWebUI.ViewComponents
{
    public class _AdminLayoutStatisticComponentPartial : ViewComponent
    {
        private readonly AuthorizedHttpClientService _httpClientFactory;
        private readonly ApiSettings _apiSettings;

        public _AdminLayoutStatisticComponentPartial(AuthorizedHttpClientService httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }

        public async Task<IViewComponentResult> InvokeAsync(int machineId = 2)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync(
                    $"{_apiSettings.BaseUrl}/Plc/readings/{machineId}");

                if (!response.IsSuccessStatusCode)
                    return View(new List<PlcReadingDto>());

                var json = await response.Content.ReadAsStringAsync();
                var readings = JsonSerializer.Deserialize<List<PlcReadingDto>>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true })
                    ?? new List<PlcReadingDto>();

                return View(readings);
            }
            catch
            {
                return View(new List<PlcReadingDto>());
            }
        }
    }
}
