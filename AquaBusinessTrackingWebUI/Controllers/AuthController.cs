using AquaBusinessTrackingWebUI.Models;
using DTOLayer.Dtos.AuthDtos;
using DTOLayer.Dtos.DepartmentDto;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AquaBusinessTrackingWebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ApiSettings _apiSettings;

        public AuthController(HttpClient httpClient, IHttpClientFactory httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClient = httpClient;
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_apiSettings.BaseUrl}/Auth/login", loginDto);
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "E-posta veya şifre hatalı.";
                return View(loginDto);
            }

            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<UserInfoDto>(responseContent);

            var handler = new JwtSecurityTokenHandler();
            handler.InboundClaimTypeMap.Clear();
            var jwtToken = handler.ReadJwtToken(result.Token);



            var claims = new List<Claim>();

            foreach (var c in jwtToken.Claims)
            {
                // Permission claim'lerini koru
                if (c.Type == "Permission")
                    claims.Add(new Claim("Permission", c.Value));

                // Role claim'lerini normalize et
                else if (c.Type == "role" || c.Type == ClaimTypes.Role ||
                         c.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role")
                    claims.Add(new Claim(ClaimTypes.Role, c.Value));

                // Diğer claim'leri olduğu gibi ekle
                else
                    claims.Add(new Claim(c.Type, c.Value));
            }



            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            Response.Cookies.Append("AuthToken", result.Token, new CookieOptions { HttpOnly = true, Secure = false });

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTime.UtcNow.AddHours(2),
                AllowRefresh = true,
                IssuedUtc = DateTimeOffset.UtcNow
            });

            var isAdmin = claims.Any(c => c.Type == ClaimTypes.Role &&
               string.Equals(c.Value, "Admin", StringComparison.OrdinalIgnoreCase));
            if (isAdmin)
                return RedirectToAction("Index", "AdminDashboard");

            return RedirectToAction("Index", "UserDashboard");



        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            await LoadDepartmentListAsync();
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var dto = new RegisterDto
            {
                Name = registerDto.Name,
                SurName = registerDto.SurName,
                UserName = ConvertToEnglishCharacter($"{registerDto.Name?.Trim()}{registerDto.SurName?.Trim()}".Replace(" ", "")),
                DepartmentId = registerDto.DepartmentId,
                Email = registerDto.Email,
                Phone = registerDto.Phone,
                Password = registerDto.Password,
                CoverImgUrl = "/img/ProfilPhotos/Default.png"

            };
            var response = await _httpClient.PostAsJsonAsync($"{_apiSettings.BaseUrl}/Auth/register", dto);
            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Error = "Kayıt işlemi başarısız.";
                var ErrorMessage = response.Content.ReadAsStringAsync();
                return View(dto);
            }
            return RedirectToAction("Login");

        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Auth");
        }

        private async Task LoadDepartmentListAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_apiSettings.BaseUrl}/Department");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<RegisterComboBoxDepartmentResponseDto>>(jsonData);
                if (values != null)
                {
                    ViewBag.Department = values.Select(r => new SelectListItem
                    {
                        Value = r.RecId.ToString(),
                        Text = r.DepartmentName.ToString()
                    }).ToList();
                }
            }
        }

        private string ConvertToEnglishCharacter(string text)
        {
            return text
                .Replace("ç", "c")
                .Replace("Ç", "C")
                .Replace("ğ", "g")
                .Replace("Ğ", "G")
                .Replace("ı", "i")
                .Replace("İ", "I")
                .Replace("ö", "o")
                .Replace("Ö", "O")
                .Replace("ş", "s")
                .Replace("Ş", "S")
                .Replace("ü", "u")
                .Replace("Ü", "U");
        }


    }
}
