using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.SentezProductionDtos;
using DTOLayer.Dtos.SupplierDashboardDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace AquaBusinessTrackingWebUI.ViewComponents
{
    public class _SupplierDashboardBySupplierComponentPartial : ViewComponent
    {
        private readonly AuthorizedHttpClientService _client;
        private readonly ApiSettings _apiSettings;

        public _SupplierDashboardBySupplierComponentPartial(AuthorizedHttpClientService client, IOptions<ApiSettings> apiSettings)
        {
            _client = client;
            _apiSettings = apiSettings.Value;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = new SentezIntegrationsResponsoDto<SupplierDashboardBySupplierDto>();
            DateTime endDate = DateTime.Today;
            DateTime startDate = DateTime.Today.AddDays(-30).AddTicks(-1);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var client = _client.CreateClient();
            var response = await client.GetAsync($"{_apiSettings.BaseUrl}/SupplierDashboard/by-supplier?startDate={startDate}&endDate={endDate}");

            SupplierDashboardBySupplierDto summaryModel = new SupplierDashboardBySupplierDto();

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                result = JsonSerializer.Deserialize<SentezIntegrationsResponsoDto<SupplierDashboardBySupplierDto>>(content, options);


            }


            return View(result);
        }
    }
}
