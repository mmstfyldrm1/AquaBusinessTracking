using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.SentezProductionDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace AquaBusinessTrackingWebUI.ViewComponents
{
    public class _AdminLayoutIntakeRawMaterialComponentPartial : ViewComponent
    {
        private readonly AuthorizedHttpClientService _httpClientFactory;
        private readonly ApiSettings _apiSettings;

        public _AdminLayoutIntakeRawMaterialComponentPartial(AuthorizedHttpClientService httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var empty = new SentezIntegrationsResponsoDto<SentezProductionDto>
            {
                Data = new List<SentezProductionDto>()
            };

            try
            {
                var client = _httpClientFactory.CreateClient();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));

                // İki isteği paralel at
                var previousDayTask = client.GetAsync($"{_apiSettings.BaseUrl}/SentezIntegrations/getRawMaterielsPreviousDayStockAsync", cts.Token);
                var stockTask = client.GetAsync($"{_apiSettings.BaseUrl}/SentezIntegrations/getRawMaterielsStockAsync", cts.Token);

                await Task.WhenAll(previousDayTask, stockTask);

                var previousDayResponse = await previousDayTask;
                var stockResponse = await stockTask;

                var previousDay = previousDayResponse.IsSuccessStatusCode
                    ? JsonSerializer.Deserialize<SentezIntegrationsResponsoDto<SentezProductionDto>>(
                        await previousDayResponse.Content.ReadAsStringAsync(), options) ?? empty
                    : empty;

                var stock = stockResponse.IsSuccessStatusCode
                    ? JsonSerializer.Deserialize<SentezIntegrationsResponsoDto<SentezProductionDto>>(
                        await stockResponse.Content.ReadAsStringAsync(), options) ?? empty
                    : empty;

                return View(new SentezStockViewModel
                {
                    PreviousDay = previousDay,
                    Stock = stock
                });
            }
            catch
            {
                return View(new SentezStockViewModel
                {
                    PreviousDay = empty,
                    Stock = empty
                });
            }
        }
    }
}

