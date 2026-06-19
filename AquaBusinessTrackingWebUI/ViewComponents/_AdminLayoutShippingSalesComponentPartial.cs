using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.ChartDtos;
using DTOLayer.Dtos.SalesScale;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

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
            var start = DateTime.Today;
            var end = start.AddDays(1);

            var cilent = _httpClientFactory.CreateClient();
            var response = await cilent.GetAsync($"{_apiSettings.BaseUrl}/AdminDashboard/sales");

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = response.Content.ReadAsStringAsync();
                return View(new List<SalesScaleDto>());
            }

            var json = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<SalesScaleDto>>(json);
            if (values == null || !values.Any())
                return View(new List<SalesScaleDto>());

            var model = new ShippingViewModel
            {
                Last10 = values.OrderByDescending(x => x.InsertDate).Take(10).ToList(),


                TotalShipment = values.Where(x => x.InsertDate >= start && x.InsertDate < end).Sum(x => x.DeliveryQuantity),

                TotalSales = values.Where(x => x.InsertDate >= start && x.InsertDate < end).Count(),

                //TotalInvoice = values.Where(x => x.Status == "Invoice").Sum(x => x.Quantity),

                //PendingShipment = values.Where(x => x.Status == "Pending").Sum(x => x.Quantity),

                Trend = values
               .GroupBy(x => x.InsertDate.Date)
                   .Select(g => new ChartPointDto
                   {
                       Date = g.Key,
                       Value = g.Sum(x => x.DeliveryQuantity)
                   })
               .ToList()
            };
            return View(model);
        }
    }
}
