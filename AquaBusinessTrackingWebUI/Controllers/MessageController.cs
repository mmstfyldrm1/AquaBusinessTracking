using AquaBusinessTrackingWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Security.Claims;

namespace AquaBusinessTrackingWebUI.Controllers
{

    public class MessageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSettings;

        public MessageController(IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }

        public async Task<IActionResult> Index()
        {

            var token = Request.Cookies["AuthToken"];
            ViewBag.JwtToken = token;
            ViewBag.ApiBaseUrl = _apiSettings.BaseUrl;


            var currentUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            ViewBag.CurrentUserId = currentUserId;


            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            var response = await client.GetAsync($"{_apiSettings.BaseUrl}/User/getusers");

            List<UserListItemViewModel> users = new();
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                users = JsonConvert.DeserializeObject<List<UserListItemViewModel>>(json) ?? new();
            }

            // Kendini listeden çıkar
            users = users.Where(u => u.Id.ToString() != currentUserId).ToList();

            return View(users);
        }
    }
}

