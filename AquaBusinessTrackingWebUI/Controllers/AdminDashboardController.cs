using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.AdminDashboardDtos;
using DTOLayer.Dtos.SentezProductionDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AquaBusinessTrackingWebUI.Controllers
{

    public class AdminDashboardController : Controller
    {
        private readonly AuthorizedHttpClientService _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        private readonly ILogger<AdminDashboardController> _logger;

        public AdminDashboardController(
            AuthorizedHttpClientService httpClientFactory,
            IOptions<ApiSettings> apiSettings,
            ILogger<AdminDashboardController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetChartData(string range = "7d")
        {
            var today = DateTime.Today;

            // range -> başlangıç tarihi + yıllıkta aylık gruplama
            var (start, groupByMonth) = range switch
            {
                "30d" => (today.AddDays(-31), false),
                "1y" => (new DateTime(today.Year, today.Month, 1).AddMonths(-11), true),
                _ => (today.AddDays(-6), false)
            };

            var qs = $"?startDate={start:yyyy-MM-dd}&endDate={today:yyyy-MM-dd}";
            var client = _httpClientFactory.CreateClient();
            using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));

            var salesTask = GetAsync<AdminDashboardSales>(client, $"getLas7DaysSalesAsync{qs}", cts.Token);
            var rawTask = GetAsync<AdminDahboardDaysStock>(client, $"getLas7DaysRawMaterilsAsync{qs}", cts.Token);
            var prodTask = GetAsync<AdminDahboardDaysStock>(client, $"getLas7DaysProductionAsync{qs}", cts.Token);
            await Task.WhenAll(salesTask, rawTask, prodTask);

            // Tarihi null/geçersiz olan kayıtlar için null döner (gruplamadan atılır)
            DateTime? Key(object date)
            {
                if (date == null) return null;
                DateTime d;
                try { d = Convert.ToDateTime(date); }
                catch { return null; }
                if (d.Year < 2000) return null; // DateTime.MinValue vb.
                return groupByMonth ? new DateTime(d.Year, d.Month, 1) : d.Date;
            }

            var sales = salesTask.Result
                .Select(x => new { K = Key(x.Date), x.Sales })
                .Where(x => x.K.HasValue)
                .GroupBy(x => x.K!.Value)
                .ToDictionary(g => g.Key, g => g.Sum(x => x.Sales));

            var raw = rawTask.Result
                .Select(x => new { K = Key(x.Date), x.Production })
                .Where(x => x.K.HasValue)
                .GroupBy(x => x.K!.Value)
                .ToDictionary(g => g.Key, g => g.Sum(x => x.Production));

            var prod = prodTask.Result
                .Select(x => new { K = Key(x.Date), x.Remaning })
                .Where(x => x.K.HasValue)
                .GroupBy(x => x.K!.Value)
                .ToDictionary(g => g.Key, g => g.Sum(x => x.Remaning));

            // Üç serinin tarihlerinin birleşimi -> hepsi aynı eksende hizalı
            var keys = prod.Keys.Union(sales.Keys).Union(raw.Keys).OrderBy(d => d).ToList();

            return Json(new
            {
                labels = keys.Select(d => groupByMonth ? d.ToString("MM.yyyy") : d.ToString("dd.MM")),
                production = keys.Select(d => prod.TryGetValue(d, out var v) ? v : 0m),
                sales = keys.Select(d => sales.TryGetValue(d, out var v) ? v : 0m),
                rawMaterial = keys.Select(d => raw.TryGetValue(d, out var v) ? v : 0m)
            });
        }

        [HttpGet]
        public async Task<IActionResult> GetSalesTrend(string range = "7d")
        {
            var today = DateTime.Today;

            var (start, groupByMonth) = range switch
            {
                "30d" => (today.AddDays(-31), false),
                "1y" => (new DateTime(today.Year, today.Month, 1).AddMonths(-11), true),
                _ => (today.AddDays(-6), false)
            };

            var qs = $"?startDate={start:yyyy-MM-dd}&endDate={today:yyyy-MM-dd}";
            var client = _httpClientFactory.CreateClient();
            using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));

            var data = await GetAsync<AdminDashboardSales>(client, $"getLas7DaysSalesAsync{qs}", cts.Token);

            DateTime? Key(object date)
            {
                if (date == null) return null;
                DateTime d;
                try { d = Convert.ToDateTime(date); }
                catch { return null; }
                if (d.Year < 2000) return null;
                return groupByMonth ? new DateTime(d.Year, d.Month, 1) : d.Date;
            }

            var grouped = data
                .Select(x => new { K = Key(x.Date), x.Sales })
                .Where(x => x.K.HasValue)
                .GroupBy(x => x.K!.Value)
                .ToDictionary(g => g.Key, g => g.Sum(x => x.Sales));

            // Satışı olmayan günler de eksende görünsün (0 olarak)
            var keys = new List<DateTime>();
            for (var d = groupByMonth ? start : start.Date;
                 d <= today;
                 d = groupByMonth ? d.AddMonths(1) : d.AddDays(1))
                keys.Add(d);

            return Json(new
            {
                labels = keys.Select(d => groupByMonth ? d.ToString("MM.yyyy") : d.ToString("dd.MM")),
                values = keys.Select(d => grouped.TryGetValue(d, out var v) ? v : 0m)
            });
        }

        private async Task<List<T>> GetAsync<T>(HttpClient client, string path, CancellationToken ct)
        {
            var url = $"{_apiSettings.BaseUrl}/SentezIntegrations/{path}";
            try
            {
                var opts = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var res = await client.GetAsync(url, ct);

                if (!res.IsSuccessStatusCode)
                {
                    _logger.LogWarning("API hata: {Url} -> {Status}", url, (int)res.StatusCode);
                    return new List<T>();
                }

                var json = await res.Content.ReadAsStringAsync(ct);
                var dto = System.Text.Json.JsonSerializer.Deserialize<SentezIntegrationsResponsoDto<T>>(json, opts);

                if (dto?.Data == null)
                {
                    _logger.LogWarning("API Data boş: {Url} -> {Json}", url,
                        json.Length > 500 ? json[..500] : json);
                    return new List<T>();
                }

                // null kayıtları ele (ilk kayıt null geliyorsa burada düşer)
                var list = dto.Data.Where(x => x != null).ToList();
                if (list.Count != dto.Data.Count())
                    _logger.LogWarning("API null kayıt döndü: {Url} ({Count} adet)", url, dto.Data.Count() - list.Count);

                return list;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetAsync başarısız: {Url}", url);
                return new List<T>();
            }
        }
    }
}