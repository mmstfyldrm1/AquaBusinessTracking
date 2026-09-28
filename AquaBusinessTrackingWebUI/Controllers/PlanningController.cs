using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.PlanningDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Security.Claims;

namespace AquaBusinessTrackingWebUI.Controllers
{
    public class PlanningController : Controller
    {
        private readonly AuthorizedHttpClientService _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        private readonly CurrentUserService _currentUserService;
        private readonly UserFavoriteService _userFavoriteService;

        public PlanningController(AuthorizedHttpClientService httpClientFactory, IOptions<ApiSettings> apiSettings, CurrentUserService currentUserService, UserFavoriteService userFavoriteService)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
            _currentUserService = currentUserService;
            _userFavoriteService = userFavoriteService;
        }

        public async Task<IActionResult> GetDailyConsumables()
        {

            var client = _httpClientFactory.CreateClient();

            int appUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var value = await _userFavoriteService.GetUserFavorites(appUserId, "Planning/GetDailyConsumables");
            if (value == 1)
            {
                ViewBag.FavMenu = 1;
            }
            else
            {
                ViewBag.FavMenu = 0;
            }

            var response = await client.GetAsync($"{_apiSettings.BaseUrl}/Planning/planning");
            if (!response.IsSuccessStatusCode)
                return View(new PlanningDto());

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<PlanningDto>(json);
            return View(data);
        }
    }
}
