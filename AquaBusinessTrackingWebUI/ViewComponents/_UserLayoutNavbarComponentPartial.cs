using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
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
            var DepartmentId = user.FindFirst("DepartmentId")?.Value;

            if (!string.IsNullOrEmpty(DepartmentId))
            {
                var sb = new StringBuilder();
                sb.AppendLine($"select Id, Name , SurName , CoverImgUrl, d.DepartmentName ,d.DepartmentCode   from AspNetUsers anu left join Db_Department d with(nolock) on d.RecId = anu.DepartmentId where anu.Id={user.FindFirstValue(ClaimTypes.NameIdentifier)}");

                var queryObj = new { query = sb.ToString() };
                var content = new StringContent(JsonConvert.SerializeObject(queryObj), Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"{_apiSettings.BaseUrl}/Query/execute", content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonData = await response.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<GetUserDto>>(jsonData);
                    if (string.IsNullOrEmpty(values.First().CoverImgUrl))
                        values.First().CoverImgUrl = "~/img/ProfilPhotos/Default.png";

                    if (values != null && values.Any())
                    {
                        ViewBag.DepartmentName = values.First().DepartmentName;
                        ViewBag.AppUserName = values.FirstOrDefault().Name;
                        ViewBag.AppUserSurName = values.FirstOrDefault().SurName;
                        ViewBag.CoverImgUrl = values.FirstOrDefault().CoverImgUrl;

                    }
                }


            }

            return View();
        }
    }
}
