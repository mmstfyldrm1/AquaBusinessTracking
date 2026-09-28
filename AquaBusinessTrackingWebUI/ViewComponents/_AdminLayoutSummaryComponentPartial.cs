using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.AdminDashboardDtos;
using DTOLayer.Dtos.SentezProductionDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AquaBusinessTrackingWebUI.ViewComponents
{
    public class _AdminLayoutSummaryComponentPartial : ViewComponent
    {
        private readonly AuthorizedHttpClientService _httpClientFactory;
        private readonly ApiSettings _apiSettings;

        public _AdminLayoutSummaryComponentPartial(AuthorizedHttpClientService httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var emptySentez = new SentezIntegrationsResponsoDto<AdminDashboardSales>
            {
                Data = new List<AdminDashboardSales>()
            };

            var emptySentezStock = new SentezIntegrationsResponsoDto<AdminDahboardDaysStock>
            {
                Data = new List<AdminDahboardDaysStock>()
            };

            var client = _httpClientFactory.CreateClient();
            var jsonOptions = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));


            var today = DateTime.Today;
            var start = today.AddDays(-6);
            var qs = $"?startDate={start:yyyy-MM-dd}&endDate={today:yyyy-MM-dd}";

            var salesTask = client.GetAsync($"{_apiSettings.BaseUrl}/SentezIntegrations/getLas7DaysSalesAsync{qs}", cts.Token);
            var rawTask = client.GetAsync($"{_apiSettings.BaseUrl}/SentezIntegrations/getLas7DaysRawMaterilsAsync{qs}", cts.Token);
            var prodTask = client.GetAsync($"{_apiSettings.BaseUrl}/SentezIntegrations/getLas7DaysProductionAsync{qs}", cts.Token);

            await Task.WhenAll(salesTask, rawTask, prodTask);

            var stock = prodTask.Result.IsSuccessStatusCode
                ? System.Text.Json.JsonSerializer.Deserialize<SentezIntegrationsResponsoDto<AdminDahboardDaysStock>>(
                    await prodTask.Result.Content.ReadAsStringAsync(), jsonOptions) ?? emptySentezStock
                : emptySentezStock;

            var sales = salesTask.Result.IsSuccessStatusCode
                ? System.Text.Json.JsonSerializer.Deserialize<SentezIntegrationsResponsoDto<AdminDashboardSales>>(
                    await salesTask.Result.Content.ReadAsStringAsync(), jsonOptions) ?? emptySentez
                : emptySentez;

            var rawMateriels = rawTask.Result.IsSuccessStatusCode
                ? System.Text.Json.JsonSerializer.Deserialize<SentezIntegrationsResponsoDto<AdminDahboardDaysStock>>(
                    await rawTask.Result.Content.ReadAsStringAsync(), jsonOptions) ?? emptySentezStock
                : emptySentezStock;

            var result = new AdminDashboardSummaryViewModel
            {
                GetLast7Sales = sales,
                GetLast7Days = stock,
                GetLast7RawMateriels = rawMateriels,
            };

            return View(result);
        }
    }
}