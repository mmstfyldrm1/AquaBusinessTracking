using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.SentezProductionDtos;
using DTOLayer.Dtos.SupplierDashboardDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace AquaBusinessTrackingWebUI.ViewComponents
{
    public class _SupplierDashboardSummaryComponentPartial : ViewComponent
    {
        private readonly AuthorizedHttpClientService _client;
        private readonly ApiSettings _apiSettings;

        public _SupplierDashboardSummaryComponentPartial(AuthorizedHttpClientService client, IOptions<ApiSettings> apiSettings)
        {
            _client = client;
            _apiSettings = apiSettings.Value;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            DateTime startDate = DateTime.Today;
            DateTime endDate = DateTime.Today.AddDays(1).AddTicks(-1);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            var client = _client.CreateClient();
            var response = await client.GetAsync($"{_apiSettings.BaseUrl}/SupplierDashboard/summary?startDate={startDate}&endDate={endDate}");

            SupplierDashboardSummaryDto summaryModel = new SupplierDashboardSummaryDto();

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<SentezIntegrationsResponsoDto<SupplierDashboardSummaryDto>>(content, options);

                if (result?.Data != null)
                {
                    summaryModel = result.Data.FirstOrDefault() ?? new SupplierDashboardSummaryDto();
                }
            }

            // View'a doğrudan 'SupplierDashboardSummaryDto' nesnesini geçiriyoruz
            return View(summaryModel);
        }
    }
}