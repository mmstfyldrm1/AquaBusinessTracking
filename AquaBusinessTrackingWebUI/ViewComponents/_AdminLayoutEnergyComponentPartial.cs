using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.AdminDashboardDtos;
using DTOLayer.Dtos.ElectricDtos.CumulativeElectricityConsumptionDtos;
using DTOLayer.Dtos.SentezProductionDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace AquaBusinessTrackingWebUI.ViewComponents
{
    public class _AdminLayoutEnergyComponentPartial : ViewComponent
    {
        private readonly AuthorizedHttpClientService _httpClientFactory;
        private readonly ApiSettings _apiSettings;

        public _AdminLayoutEnergyComponentPartial(AuthorizedHttpClientService httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var emptyModel = new EnergyProductionViewModel();

            try
            {
                var client = _httpClientFactory.CreateClient();
                var jsonOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));

                var productionTask = client.GetAsync($"{_apiSettings.BaseUrl}/SentezIntegrations/getLas30DaysProductionAsync", cts.Token);
                var electricTask = client.GetAsync($"{_apiSettings.BaseUrl}/AdminDashboard/Last30DaysElectricConsumable", cts.Token);

                await Task.WhenAll(productionTask, electricTask);

                var production = productionTask.Result.IsSuccessStatusCode
                     ? JsonSerializer.Deserialize<SentezIntegrationsResponsoDto<AdminDahboardLast7DaysStock>>(
                         await productionTask.Result.Content.ReadAsStringAsync(), jsonOptions)?.Data ?? new()
                     : new();

                var electric = electricTask.Result.IsSuccessStatusCode
                    ? JsonSerializer.Deserialize<List<CumulativeElectricityConsumptionDto>>(
                        await electricTask.Result.Content.ReadAsStringAsync(), jsonOptions) ?? new()
                    : new();

                return View(new EnergyProductionViewModel
                {
                    Remaning = production,
                    Electric = electric
                });
            }
            catch
            {
                return View(emptyModel);
            }
        }
    }
}
