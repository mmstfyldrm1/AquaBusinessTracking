using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.RolePermission;
using DTOLayer.Dtos.UserDashboardDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Security.Claims;

namespace AquaBusinessTrackingWebUI.Controllers
{
    public class UserDashboardController : Controller
    {
        private readonly AuthorizedHttpClientService _httpClientFactory;
        private readonly ApiSettings _apiSettings;

        public UserDashboardController(AuthorizedHttpClientService httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }


        public async Task<IActionResult> AddFavorite(string permisionsName)
        {
            if (string.IsNullOrWhiteSpace(permisionsName))
            {
                return BadRequest("Yetki adı belirtilmedi.");
            }


            var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (!int.TryParse(userIdClaim, out var appUserId))
            {
                return Unauthorized("Kullanıcı kimliği doğrulanamadı.");
            }

            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync(
                $"{_apiSettings.BaseUrl}/Permission/getPermisionsName?permisionsName={permisionsName}");

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode, "Yetki bilgisi alınırken hata oluştu.");
            }

            var json = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<PermissionDto>>(json);

            if (values == null || !values.Any())
            {
                return NotFound("İlgili yetki bulunamadı.");
            }

            var permission = values.First();

            var dto = new UserDashboardAddFavoriteModuleDto
            {
                Controller = permission.Controller ?? string.Empty,
                ModuleId = permission.RecId,
                AppUserId = appUserId,
                Url = $"{permission.Controller}/View",
                DisplayOrder = 1,
                DepartmentId = int.Parse(User.FindFirst("DepartmentId")?.Value)
            };

            var addFavoriteResponse = await client.PostAsJsonAsync(
                $"{_apiSettings.BaseUrl}/UserDashboard/addFavorite", dto);

            if (!addFavoriteResponse.IsSuccessStatusCode)
            {
                return StatusCode((int)addFavoriteResponse.StatusCode, "Favori eklenirken hata oluştu.");
            }

            TempData["SuccessMessage"] = "Favorilere eklendi.";
            return Ok();
        }
    }
}

