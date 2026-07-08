using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.AdminDashboardDtos;
using DTOLayer.Dtos.SentezProductionDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;


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
                DurusDagilim = null,
                GetLast7Days = emptySentez
            };


            var cilent = _httpClientFactory.CreateClient();
            var jsonOptions = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));

            var response = cilent.GetAsync($"{_apiSettings.BaseUrl}/AdminDashboard/stopChart", cts.Token);
            var responseProduction = cilent.GetAsync($"{_apiSettings.BaseUrl}/SentezIntegrations/getLas7DaysProductionAsync", cts.Token);


            await Task.WhenAll(response, responseProduction);

            var stock = responseProduction.Result.IsSuccessStatusCode
                ? System.Text.Json.JsonSerializer.Deserialize<SentezIntegrationsResponsoDto<AdminDahboardLast7DaysStock>>(
                    await responseProduction.Result.Content.ReadAsStringAsync(), jsonOptions) ?? emptySentez
                : emptySentez;



            var json = await response.Result.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<StopChartDto>>(json);


            if (values == null)
                return View(new AdminDashboardSummaryViewModel
                {
                    DurusDagilim = new List<StopChartDto>(),
                    GetLast7Days = emptySentez
                });



            if (values == null)
                return View(new List<StopChartDto>());

            var result = new AdminDashboardSummaryViewModel
            {
                DurusDagilim = values,
                GetLast7Days = stock
            };



            return View(result);
        }
    }
}
