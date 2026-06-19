using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.DoughPreparationDtos.DoughPreparationHeadDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace AquaBusinessTrackingWebUI.ViewComponents
{
    public class _AdminLayoutRawmaterialsComponentPartial : ViewComponent
    {
        private readonly AuthorizedHttpClientService _httpClientFactory;
        private readonly ApiSettings _apiSettings;

        public _AdminLayoutRawmaterialsComponentPartial(AuthorizedHttpClientService httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var start = DateTime.Today;
            var end = start.AddDays(1);

            var cilent = _httpClientFactory.CreateClient();
            var response = await cilent.GetAsync($"{_apiSettings.BaseUrl}/AdminDashboard/rawmaterials");

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = response.Content.ReadAsStringAsync();
                return View(new List<DoughPreparationDto>());
            }

            var json = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<DoughPreparationDto>>(json);

            if (values == null || !values.Any())
                return View(new List<DoughPreparationDto>());

            var model = values
                .OrderByDescending(x => x.InsertDate)
                .Take(10)
                .ToList();

            return View(model);
        }
    }
}
