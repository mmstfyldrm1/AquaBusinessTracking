using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.AdminDashboardDtos;
using DTOLayer.Dtos.BoilerSteamFeedWaterCondensateDataDtos;
using DTOLayer.Dtos.SentezProductionDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace AquaBusinessTrackingWebUI.ViewComponents
{
    public class _AdminLayoutBoilerComponentPartial : ViewComponent
    {
        private readonly AuthorizedHttpClientService _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        private readonly CurrentUserService _currentUserService;

        public _AdminLayoutBoilerComponentPartial(AuthorizedHttpClientService httpClientFactory, IOptions<ApiSettings> apiSettings, CurrentUserService currentUserService)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
            _currentUserService = currentUserService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var emptyModel = new BoilerProductionViewModel();

            try
            {
                var client = _httpClientFactory.CreateClient();
                var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
                DateTime StartDate = DateTime.UtcNow.AddDays(-7);
                DateTime EndDate = DateTime.UtcNow;

                var productionTask = client.GetAsync($"{_apiSettings.BaseUrl}/SentezIntegrations/getLas30DaysProductionAsync", cts.Token);
                var boilerTask = client.GetAsync($"{_apiSettings.BaseUrl}/AdminDashboard/Last30DaysBoiler", cts.Token);

                await Task.WhenAll(productionTask, boilerTask);

                // Üretim verisi
                var productionList = new List<AdminDahboardDaysStock>();
                if (productionTask.Result.IsSuccessStatusCode)
                {
                    var productionResponse = JsonSerializer.Deserialize<SentezIntegrationsResponsoDto<AdminDahboardDaysStock>>(
                        await productionTask.Result.Content.ReadAsStringAsync(), jsonOptions);

                    if (productionResponse?.Data != null)
                        productionList = productionResponse?.Data;
                }

                // Boiler verisi
                var boilerList = new List<BoilerSteamFeedWaterCondensateDataDto>();
                if (boilerTask.Result.IsSuccessStatusCode)
                {
                    boilerList = JsonSerializer.Deserialize<List<BoilerSteamFeedWaterCondensateDataDto>>(
                        await boilerTask.Result.Content.ReadAsStringAsync(), jsonOptions) ?? new();
                }



                var model = new BoilerProductionViewModel
                {
                    Remaning = productionList,
                    Boiler = boilerList

                };

                return View(model);
            }
            catch
            {
                return View(emptyModel);
            }
        }
    }
}


