using AquaBusinessTrackingWebUI.Models.Email;
using AquaBusinessTrackingWebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebUI.Controllers
{
    public class EmailReportRecipientController : Controller
    {
        private readonly AuthorizedHttpClientService _authorizedHttpClient;
        private readonly IConfiguration _configuration;

        public EmailReportRecipientController(AuthorizedHttpClientService authorizedHttpClient, IConfiguration configuration)
        {
            _authorizedHttpClient = authorizedHttpClient;
            _configuration = configuration;
        }

        private HttpClient CreateApiClient()
        {
            var client = _authorizedHttpClient.CreateClient();

            var apiBaseUrl = _configuration["ApiSettings:BaseUrl"];

            if (string.IsNullOrWhiteSpace(apiBaseUrl))
                throw new InvalidOperationException(
                    "ApiSettings:BaseUrl yapılandırması bulunamadı.");

            client.BaseAddress = new Uri(
                apiBaseUrl.EndsWith("/") ? apiBaseUrl : apiBaseUrl + "/");

            return client;
        }

        // Alıcıları listele
        public async Task<IActionResult> Index()
        {
            try
            {
                var client = CreateApiClient();

                var response = await client.GetAsync(
                    "api/EmailReportRecipient");

                if (!response.IsSuccessStatusCode)
                {
                    TempData["Error"] =
                        "E-posta alıcıları API üzerinden getirilemedi.";

                    return View(new List<EmailReportRecipientViewModel>());
                }

                var result = await response.Content
                    .ReadFromJsonAsync<List<EmailReportRecipientViewModel>>();

                return View(result ?? new List<EmailReportRecipientViewModel>());
            }
            catch (Exception)
            {
                TempData["Error"] =
                    "Alıcılar yüklenirken bir bağlantı hatası oluştu.";

                return View(new List<EmailReportRecipientViewModel>());
            }
        }

        // Yeni alıcı ekle
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(
            CreateEmailReportRecipientViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Lütfen bilgileri kontrol edin.";
                return RedirectToAction(nameof(Index));
            }

            try
            {
                var client = CreateApiClient();

                var response = await client.PostAsJsonAsync(
                    "api/EmailReportRecipient",
                    model);

                if (response.IsSuccessStatusCode)
                {
                    TempData["Success"] =
                        "E-posta alıcısı başarıyla eklendi.";
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();

                    TempData["Error"] =
                        $"Alıcı eklenemedi. API yanıtı: {error}";
                }
            }
            catch (Exception)
            {
                TempData["Error"] =
                    "E-posta alıcısı eklenirken bağlantı hatası oluştu.";
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(
    UpdateEmailReportRecipientViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Lütfen bilgileri kontrol edin.";
                return RedirectToAction(nameof(Index));
            }

            try
            {
                var client = CreateApiClient();

                var response = await client.PutAsJsonAsync(
                    "api/EmailReportRecipient",
                    model);

                if (response.IsSuccessStatusCode)
                {
                    TempData["Success"] = "E-posta alıcısı güncellendi.";
                }
                else
                {
                    TempData["Error"] =
                        "Güncelleme başarısız: " +
                        await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception)
            {
                TempData["Error"] = "Güncelleme sırasında bağlantı hatası oluştu.";
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var client = CreateApiClient();

                var response = await client.DeleteAsync(
                    $"api/EmailReportRecipient/{id}");

                if (response.IsSuccessStatusCode)
                {
                    TempData["Success"] = "E-posta alıcısı silindi.";
                }
                else
                {
                    TempData["Error"] =
                        "Silme işlemi başarısız: " +
                        await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception)
            {
                TempData["Error"] = "Silme sırasında bağlantı hatası oluştu.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}