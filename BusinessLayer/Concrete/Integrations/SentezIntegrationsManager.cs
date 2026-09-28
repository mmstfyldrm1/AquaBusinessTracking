using BusinessLayer.Abstract.Integrations;
using DTOLayer.Dtos.SentezProductionDtos;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace BusinessLayer.Concrete.Integrations
{
    public class SentezIntegrationsManager : ISentezIntegrationsService
    {
        private readonly HttpClient _httpClient;

        public SentezIntegrationsManager(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<SentezIntegrationsResponsoDto<T>?> ExecuteQueryAsync<T>(string query)
        {


            try
            {
                var loginResponse = await _httpClient.PostAsync("http://10.54.100.110:8484/api/Authentication/Login?userCode=Sentez8&password=Mustafa.41045416&companyCode=54500&userType=0", null);
                var loginResult = await loginResponse.Content.ReadFromJsonAsync<SentezLoginDto>();

                var token = loginResult?.Data;

                var request = new HttpRequestMessage(
                    HttpMethod.Post,
                    "http://10.54.100.110:8484/api/Utility/UtilityQuery");

                request.Headers.Authorization =
                    new AuthenticationHeaderValue("Bearer", token);

                request.Content = JsonContent.Create(new { query });

                var response = await _httpClient.SendAsync(request);

                // hata varsa direkt gör
                var body = await response.Content.ReadAsStringAsync();

                var json = await response.Content.ReadAsStringAsync();
                Console.WriteLine(json);

                response.EnsureSuccessStatusCode();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                try
                {
                    var result = JsonSerializer.Deserialize<SentezIntegrationsResponsoDto<T>>(
                        body,
                        options);

                    return result;
                }
                catch (JsonException ex)
                {
                    throw new Exception(
                        $"Deserialize hatası. T tipi: {typeof(T).FullName}, " +
                        $"Path: {ex.Path}, " +
                        $"Message: {ex.Message}\n" +
                        $"Body: {body}", ex);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"LOGIN İSTEĞİ ATILAMADI. Tip: {ex.GetType().FullName}, " +
                                     $"Message: {ex.Message}, " +
                                     $"Inner: {ex.InnerException?.Message}", ex);
            }

        }


        public async Task<SentezUpdateResponseDto?> ExecuteUpdateQueryAsync(string query)
        {
            var loginResponse = await _httpClient.PostAsync(
         "http://10.54.100.110:8484/api/Authentication/Login?userCode=Sentez8&password=Mustafa.41045416&companyCode=54500&userType=0",
         null);
            var loginResult = await loginResponse.Content.ReadFromJsonAsync<SentezLoginDto>();
            var token = loginResult?.Data;

            var request = new HttpRequestMessage(HttpMethod.Post, "http://10.54.100.110:8484/api/Utility/UtilityNonQuery");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            request.Content = JsonContent.Create(new { query });

            var response = await _httpClient.SendAsync(request);
            var body = await response.Content.ReadAsStringAsync();

            Console.WriteLine("Sentez UPDATE ham cevap: " + body); // teşhis için, sorun çözülünce kaldırabilirsiniz

            response.EnsureSuccessStatusCode();

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var result = JsonSerializer.Deserialize<SentezUpdateResponseDto>(body, options);
            return result;


        }

    }
}
