using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.SentezProductionDtos;
using DTOLayer.Dtos.SupplierDashboardDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace AquaBusinessTrackingWebUI.ViewComponents
{
    public class _SupplierDashboardMaterialDistributionComponentPartial : ViewComponent
    {
        private readonly AuthorizedHttpClientService _client;
        private readonly ApiSettings _apiSettings;

        public _SupplierDashboardMaterialDistributionComponentPartial(AuthorizedHttpClientService client, IOptions<ApiSettings> apiSettings)
        {
            _client = client;
            _apiSettings = apiSettings.Value;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = new SentezIntegrationsResponsoDto<SupplierDashboardMaterialDistributionDto>();
            DateTime endDate = DateTime.Today;
            DateTime startDate = DateTime.Today.AddDays(-30).AddTicks(-1);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var client = _client.CreateClient();
            var response = await client.GetAsync($"{_apiSettings.BaseUrl}/SupplierDashboard/material-distribution?startDate={startDate}&endDate={endDate}");

            SupplierDashboardMaterialDistributionDto summaryModel = new SupplierDashboardMaterialDistributionDto();

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                result = JsonSerializer.Deserialize<SentezIntegrationsResponsoDto<SupplierDashboardMaterialDistributionDto>>(content, options);


            }


            return View(result);
        }
    }
}
