using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.UserDtos;
using DTOLayer.Dtos.UserDtos.UserProfileDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;



namespace AquaBusinessTrackingWebUI.Controllers
{
    public class UserProfileController : Controller
    {
        private readonly AuthorizedHttpClientService _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        private readonly CurrentUserService _currentUserService;


        public UserProfileController(AuthorizedHttpClientService httpClientFactory, IOptions<ApiSettings> apiSettings, CurrentUserService currentUserService)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
            _currentUserService = currentUserService;

        }

        [HttpGet]
        public async Task<IActionResult> UserProfile()
        {

            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_apiSettings.BaseUrl}/User/getuser/{userId}");
            var json = await response.Content.ReadAsStringAsync();
            var updateUserDto = JsonConvert.DeserializeObject<UpdateUserDto>(json);

            var model = new UserProfileViewModel
            {
                UpdateUser = updateUserDto,
                Password = new PasswordDto()
            };
            return View(model);


        }

        [HttpPost]
        public async Task<IActionResult> UserProfile(UserProfileViewModel dto)
        {
            var client = _httpClientFactory.CreateClient();
            var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            // Profil fotoğrafı
            if (dto.UpdateUser.ProfileImage != null)
            {
                var file = dto.UpdateUser.ProfileImage;

                var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);

                var savePath = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot/img/ProfilPhotos",
                    fileName);

                using var stream = new FileStream(savePath, FileMode.Create);
                await file.CopyToAsync(stream);

                dto.UpdateUser.CoverImgUrl = "/img/ProfilPhotos/" + fileName;
            }

            dto.UpdateUser.Id = userId;
            dto.UpdateUser.UpdateDate = DateTime.Now;
            dto.UpdateUser.DepartmentId = int.Parse(User.FindFirst("DepartmentId")!.Value);

            if (string.IsNullOrWhiteSpace(dto.UpdateUser.CoverImgUrl))
                dto.UpdateUser.CoverImgUrl = "/img/ProfilPhotos/Default.png";

            // Kullanıcı bilgilerini güncelle
            var userContent = new StringContent(
                JsonConvert.SerializeObject(dto.UpdateUser),
                Encoding.UTF8,
                "application/json");

            var userResponse = await client.PutAsync(
                $"{_apiSettings.BaseUrl}/User/updateuser",
                userContent);

            if (!userResponse.IsSuccessStatusCode)
            {
                var errorMessage = await userResponse.Content.ReadAsStringAsync();
                ModelState.AddModelError("", "Kullanıcı bilgileri güncellenemedi.");
                return View(dto);
            }

            // Şifre alanlarından herhangi biri doldurulduysa şifreyi de değiştir
            if (!string.IsNullOrWhiteSpace(dto.Password.OldPassword) ||
                !string.IsNullOrWhiteSpace(dto.Password.NewPassword) ||
                !string.IsNullOrWhiteSpace(dto.Password.ConfirmPassword))
            {
                var passwordContent = new StringContent(
                    JsonConvert.SerializeObject(dto.Password),
                    Encoding.UTF8,
                    "application/json");

                var passwordResponse = await client.PutAsync(
                    $"{_apiSettings.BaseUrl}/User/changeUserPassword/{userId}",
                    passwordContent);

                if (!passwordResponse.IsSuccessStatusCode)
                {
                    var error = await passwordResponse.Content.ReadAsStringAsync();

                    ModelState.AddModelError("", error);

                    return View(dto);
                }
            }

            TempData["Success"] = "Bilgileriniz başarıyla güncellendi.";

            return RedirectToAction(nameof(UserProfile));

        }

    }
}
