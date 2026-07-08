using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.MachineStopDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace AquaBusinessTrackingWebUI.ViewComponents
{
    public class _AdminLayoutStanceComponentPartial : ViewComponent
    {
        private readonly AuthorizedHttpClientService _httpClientFactory;
        private readonly ApiSettings _apiSettings;

        public _AdminLayoutStanceComponentPartial(AuthorizedHttpClientService httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {


            var cilent = _httpClientFactory.CreateClient();
            var response = await cilent.GetAsync($"{_apiSettings.BaseUrl}/MachineStop/details");

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = response.Content.ReadAsStringAsync();
                return View(new List<MachineStopDto>());
            }

            var json = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<MachineStopDto>>(json);

            if (values == null)
                return View(new List<MachineStopDto>());



            var model = values?
             .OrderByDescending(x => x.InsertDate)
             .Take(5)
             .ToList() ?? new List<MachineStopDto>();

            return View(model);
        }
    }
}
