using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.UserDashboardDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Security.Claims;

namespace AquaBusinessTrackingWebUI.ViewComponents
{
    public class _UserDashboardFavoriteMenuComponentPartial : ViewComponent
    {
        private readonly AuthorizedHttpClientService _httpClientFactory;
        private readonly ApiSettings _apiSettings;

        public _UserDashboardFavoriteMenuComponentPartial(AuthorizedHttpClientService httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }

        [HttpGet]
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var cilent = _httpClientFactory.CreateClient();
            var userId = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var response = await cilent.GetAsync($"{_apiSettings.BaseUrl}/UserDashboard/userDashboard/{userId}");

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                return View(new List<UserDashboardFavoriteMenuDto>());

            }

            var json = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<UserDashboardFavoriteMenuDto>>(json);

            if (values == null)
                return View(new List<UserDashboardFavoriteMenuDto>());


            return View(values);
        }
    }
}
