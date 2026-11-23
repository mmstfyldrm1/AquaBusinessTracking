using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.SentezProductionDtos;
using DTOLayer.Dtos.SupplierDashboardDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace AquaBusinessTrackingWebUI.ViewComponents
{
    public class _SupplierDashboardQualityComponentPartial : ViewComponent
    {
        private readonly AuthorizedHttpClientService _client;
        private readonly ApiSettings _apiSettings;

        public _SupplierDashboardQualityComponentPartial(AuthorizedHttpClientService client, IOptions<ApiSettings> apiSettings)
        {
            _client = client;
            _apiSettings = apiSettings.Value;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            DateTime startDate = DateTime.Today.AddDays(-30).AddTicks(-1);
            DateTime endDate = DateTime.Today;
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var client = _client.CreateClient();
            var response = await client.GetAsync($"{_apiSettings.BaseUrl}/SupplierDashboard/quality?startDate={startDate}&endDate={endDate}");

            var model = new SentezIntegrationsResponsoDto<SupplierDashboardQualityDto>();

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                model = JsonSerializer.Deserialize<SentezIntegrationsResponsoDto<SupplierDashboardQualityDto>>(content, options)
                        ?? model;
            }


            return View(model);
        }
    }
}
