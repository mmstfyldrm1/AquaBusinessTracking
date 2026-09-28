using AquaBusinessTrackingWebUI.Models;
using DTOLayer.Dtos.UserDashboardDtos;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace AquaBusinessTrackingWebUI.Services
{
    public class UserFavoriteService
    {
        private readonly AuthorizedHttpClientService _httpClientFactory;
        private readonly ApiSettings _apiSettings;

        public UserFavoriteService(AuthorizedHttpClientService httpClientFactory, IOptions<ApiSettings> apiSettings)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
        }


        public async Task<int> GetUserFavorites(int userId, string baseUrl)
        {
            var client = _httpClientFactory.CreateClient();
            var favoriteMenuResponse = await client.GetAsync($"{_apiSettings.BaseUrl}/UserDashBoard/userDashboard/{userId}");
            var responseContent = await favoriteMenuResponse.Content.ReadAsStringAsync();
            if (favoriteMenuResponse.IsSuccessStatusCode && !string.IsNullOrEmpty(responseContent))
            {

                var values = JsonConvert.DeserializeObject<List<UserDashboardFavoriteMenuDto>>(responseContent);
                if (values != null && values.Count > 0)
                {
                    foreach (var item in values)
                    {
                        if (item.Url == baseUrl && item.DisplayOrder == 1)
                        {
                            return 1;
                        }
                    }
                    return 0;
                }
            }
            return 0;
        }
    }
}
