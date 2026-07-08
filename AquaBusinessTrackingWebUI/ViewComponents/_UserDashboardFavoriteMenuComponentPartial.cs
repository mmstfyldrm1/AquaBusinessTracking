using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

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
        public async Task<IViewComponentResult> InvokeAsync(string appUserId)
        {

            return View();
        }
    }
}
