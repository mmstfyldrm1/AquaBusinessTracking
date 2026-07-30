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

            var emptySentez = new SentezIntegrationsResponsoDto<AdminDahboardLast7DaysStock>
            {
                Data = new List<AdminDahboardLast7DaysStock>()
            };
            var emptyModel = new AdminDashboardSummaryViewModel
            {
                GetLast7Sales = emptySentez,
                GetLast7Days = emptySentez,
                GetLast7RawMateriels = emptySentez
            };


            var cilent = _httpClientFactory.CreateClient();
            var jsonOptions = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));

            var response = cilent.GetAsync($"{_apiSettings.BaseUrl}/SentezIntegrations/getLas7DaysSalesAsync", cts.Token);
            var responseRawMateriles = cilent.GetAsync($"{_apiSettings.BaseUrl}/SentezIntegrations/getLas7DaysRawMaterilsAsync", cts.Token);
            var responseProduction = cilent.GetAsync($"{_apiSettings.BaseUrl}/SentezIntegrations/getLas7DaysProductionAsync", cts.Token);


            await Task.WhenAll(response, responseProduction, responseRawMateriles);

            var stock = responseProduction.Result.IsSuccessStatusCode
                ? System.Text.Json.JsonSerializer.Deserialize<SentezIntegrationsResponsoDto<AdminDahboardLast7DaysStock>>(
                    await responseProduction.Result.Content.ReadAsStringAsync(), jsonOptions) ?? emptySentez
                : emptySentez;



            var sales = response.Result.IsSuccessStatusCode
                  ? System.Text.Json.JsonSerializer.Deserialize<SentezIntegrationsResponsoDto<AdminDahboardLast7DaysStock>>(
                      await response.Result.Content.ReadAsStringAsync(), jsonOptions) ?? emptySentez
                  : emptySentez;

            var rawMateriels = responseRawMateriles.Result.IsSuccessStatusCode
                  ? System.Text.Json.JsonSerializer.Deserialize<SentezIntegrationsResponsoDto<AdminDahboardLast7DaysStock>>(
                      await responseRawMateriles.Result.Content.ReadAsStringAsync(), jsonOptions) ?? emptySentez
                  : emptySentez;




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
