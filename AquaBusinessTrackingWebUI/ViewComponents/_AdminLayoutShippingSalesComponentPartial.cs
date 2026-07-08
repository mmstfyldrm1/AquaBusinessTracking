using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.ChartDtos;
using DTOLayer.Dtos.SalesScale;
using DTOLayer.Dtos.SentezProductionDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AquaBusinessTrackingWebUI.ViewComponents
{
    public class _AdminLayoutShippingSalesComponentPartial : ViewComponent
    {

        private readonly AuthorizedHttpClientService _httpClientFactory;
        private readonly ApiSettings _apiSettings;

        public _AdminLayoutShippingSalesComponentPartial(AuthorizedHttpClientService httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var emptySentez = new SentezIntegrationsResponsoDto<SentezProductionDto>
            {
                Data = new List<SentezProductionDto>()
            };
            var emptyModel = new AdminDashboardSalesShippingViewModel
            {
                Sales = emptySentez,
                PreviousDay = emptySentez,
                Last10 = new(),
                Trend = new(),
                TotalShipment = 0,
                TotalSales = 0,
                TotalInvoice = 0,
                PendingShipment = 0
            };

            try
            {
                decimal totalPreviousDay = 0;
                decimal totalAll = 0;
                var client = _httpClientFactory.CreateClient();
                var jsonOptions = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));

                var previousDayTask = client.GetAsync($"{_apiSettings.BaseUrl}/SentezIntegrations/getpreviousdaySales", cts.Token);
                var stockTask = client.GetAsync($"{_apiSettings.BaseUrl}/SentezIntegrations/getSales", cts.Token);
                var salesTask = client.GetAsync($"{_apiSettings.BaseUrl}/AdminDashboard/sales", cts.Token);

                await Task.WhenAll(previousDayTask, stockTask, salesTask);

                var previousDay = previousDayTask.Result.IsSuccessStatusCode
                    ? System.Text.Json.JsonSerializer.Deserialize<SentezIntegrationsResponsoDto<SentezProductionDto>>(
                        await previousDayTask.Result.Content.ReadAsStringAsync(), jsonOptions) ?? emptySentez
                    : emptySentez;

                var stock = stockTask.Result.IsSuccessStatusCode
                    ? System.Text.Json.JsonSerializer.Deserialize<SentezIntegrationsResponsoDto<SentezProductionDto>>(
                        await stockTask.Result.Content.ReadAsStringAsync(), jsonOptions) ?? emptySentez
                    : emptySentez;

                if (!salesTask.Result.IsSuccessStatusCode)
                    return View(new AdminDashboardSalesShippingViewModel
                    {
                        PreviousDay = previousDay,
                        Sales = stock,
                        Last10 = new(),
                        Trend = new()
                    });

                var salesJson = await salesTask.Result.Content.ReadAsStringAsync();
                var values = System.Text.Json.JsonSerializer.Deserialize<List<SalesScaleDto>>(salesJson, jsonOptions)
                             ?? new List<SalesScaleDto>();

                var start = DateTime.Today;
                var end = start.AddDays(1);

                totalPreviousDay = previousDay.Data.Sum(x => x.Production);
                totalAll += stock.Data.Sum(x => x.Production);

                return View(new AdminDashboardSalesShippingViewModel
                {
                    PreviousDay = previousDay,
                    PreviousTotal = totalPreviousDay,
                    AllTotal = totalAll,
                    Sales = stock,
                    Last10 = values.OrderByDescending(x => x.InsertDate).Take(10).ToList(),
                    TotalShipment = values.Where(x => x.ReceiptDate >= start && x.ReceiptDate < end).Sum(x => x.DeliveryQuantity),
                    TotalSales = values.Where(x => x.ReceiptDate >= start && x.ReceiptDate < end).Count(),
                    Trend = values
                        .GroupBy(x => x.ReceiptDate.Date)
                        .Select(g => new ChartPointDto { Date = g.Key, Value = g.Sum(x => x.DeliveryQuantity) })
                        .ToList()
                });
            }
            catch
            {
                return View(emptyModel);
            }
        }
    }
}
