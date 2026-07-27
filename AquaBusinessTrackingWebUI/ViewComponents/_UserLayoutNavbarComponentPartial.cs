using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.QueryDtos;
using DTOLayer.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text;

namespace AquaBusinessTrackingWebUI.ViewComponents
{
    public class _UserLayoutNavbarComponentPartial : ViewComponent
    {
        private readonly AuthorizedHttpClientService _httpClientFactory;
        private readonly ApiSettings _apiSettings;

        public _UserLayoutNavbarComponentPartial(AuthorizedHttpClientService httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var user = HttpContext.User;
            var departmentId = user.FindFirst("DepartmentId")?.Value;

            if (!string.IsNullOrEmpty(departmentId))
            {
                var sb = new StringBuilder();
                sb.AppendLine($"SELECT");
                sb.AppendLine($"anu.Id,");
                sb.AppendLine($"anu.Name,");
                sb.AppendLine($"anu.SurName,");
                sb.AppendLine($"anu.CoverImgUrl,");
                sb.AppendLine($"d.DepartmentName,");
                sb.AppendLine($"d.DepartmentCode");
                sb.AppendLine($" FROM AspNetUsers anu");
                sb.AppendLine($" LEFT JOIN Db_Department d WITH(NOLOCK)");
                sb.AppendLine($" ON d.RecId = anu.DepartmentId");
                sb.AppendLine($" WHERE anu.Id ={user.FindFirstValue(ClaimTypes.NameIdentifier)}");

                var requestDto = new QueryRequestDto
                {
                    Query = sb.ToString(),
                    Parameters = null
                };

                var response = await client.PostAsJsonAsync(
                    $"{_apiSettings.BaseUrl}/Query/execute",
                    requestDto);

                if (response.IsSuccessStatusCode)
                {
                    var values = await response.Content.ReadFromJsonAsync<List<GetUserDto>>();

                    if (values?.Any() == true)
                    {
                        var value = values.First();

                        value.CoverImgUrl ??= "~/img/ProfilPhotos/Default.png";

                        ViewBag.DepartmentName = value.DepartmentName;
                        ViewBag.AppUserName = value.Name;
                        ViewBag.AppUserSurName = value.SurName;
                        ViewBag.CoverImgUrl = value.CoverImgUrl;
                    }
                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                }
            }



            return View();
        }
    }
}
