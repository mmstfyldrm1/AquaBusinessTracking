using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.PlanningDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace AquaBusinessTrackingWebUI.Controllers
{
    public class PlanningController : Controller
    {
        private readonly AuthorizedHttpClientService _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        private readonly CurrentUserService _currentUserService;

        public PlanningController(AuthorizedHttpClientService httpClientFactory, IOptions<ApiSettings> apiSettings, CurrentUserService currentUserService)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
            _currentUserService = currentUserService;
        }

        public async Task<IActionResult> GetDailyConsumables()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_apiSettings.BaseUrl}/Planning/planning");
            if (!response.IsSuccessStatusCode)
                return View(new PlanningDto());

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<PlanningDto>(json);
            return View(data);
        }
    }
}
