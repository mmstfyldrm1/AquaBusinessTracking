using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.AdminDashboardDtos;
using DTOLayer.Dtos.NaturelGasMeterMonitoringDtos;
using DTOLayer.Dtos.SentezProductionDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace AquaBusinessTrackingWebUI.ViewComponents
{
    public class _AdminLayoutNaturelGasTrackingComponentPartial : ViewComponent
    {
        private readonly AuthorizedHttpClientService _httpClientFactory;
        private readonly ApiSettings _apiSettings;

        public _AdminLayoutNaturelGasTrackingComponentPartial(AuthorizedHttpClientService httpClientFactory, IOptions<ApiSettings> apiSettings)
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

                var productionTask = client.GetAsync($"{_apiSettings.BaseUrl}/SentezIntegrations/getLas7DaysProductionAsync", cts.Token);
                var naturelGasTask = client.GetAsync($"{_apiSettings.BaseUrl}/AdminDashboard/Last7DaysNaturelGas", cts.Token);

                await Task.WhenAll(productionTask, naturelGasTask);

                var production = productionTask.Result.IsSuccessStatusCode
                     ? JsonSerializer.Deserialize<SentezIntegrationsResponsoDto<AdminDahboardLast7DaysStock>>(
                         await productionTask.Result.Content.ReadAsStringAsync(), jsonOptions)?.Data ?? new()
                     : new();

                var naturelGas = naturelGasTask.Result.IsSuccessStatusCode
                    ? JsonSerializer.Deserialize<List<NaturelGasMeterMonitoringDto>>(
                        await naturelGasTask.Result.Content.ReadAsStringAsync(), jsonOptions) ?? new()
                    : new();

                return View(new NaturelGasProductionViewModel
                {
                    Production = production,
                    NaturelGas = naturelGas
                });
            }
            catch
            {
                return View(emptyModel);
            }
        }
    }
}
