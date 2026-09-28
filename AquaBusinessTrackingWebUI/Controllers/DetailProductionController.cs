using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.Integrations;
using DTOLayer.Dtos.SentezIntegrationsDtos.SentezIntegrationProductionDtos;
using DTOLayer.Dtos.SentezProductionDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AquaBusinessTrackingWebUI.Controllers
{
    public class DetailProductionController : Controller
    {
        private readonly AuthorizedHttpClientService _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        private readonly CurrentUserService _currentUserService;
        private readonly ProductionDetailBuilder _productionDetailBuilder;

        public DetailProductionController(AuthorizedHttpClientService httpClientFactory, IOptions<ApiSettings> apiSettings, CurrentUserService currentUserService, ProductionDetailBuilder productionDetailBuilder)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
            _currentUserService = currentUserService;
            _productionDetailBuilder = productionDetailBuilder;
        }

        public async Task<IActionResult> Index()
        {
            var emptyMachineData = new List<PlcReadingDto>();
            var emptyCombineDetails = new SentezIntegrationsResponsoDto<SentezIntegrationsGetCombineDetailsDto>();
            var emptyProductionDetails = new SentezIntegrationsResponsoDto<SentezIntegrationsGetProductionDetailsDto>();

            var client = _httpClientFactory.CreateClient();
            var jsonOptions = new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(100));

            var machineData = await client.GetAsync($"{_apiSettings.BaseUrl}/Plc/readings/{6}", cts.Token);
            var combineDetails = await client.GetAsync($"{_apiSettings.BaseUrl}/DetailProduction/GetCombinationDetails", cts.Token);
            var productionDetails = await client.GetAsync($"{_apiSettings.BaseUrl}/DetailProduction/GetProductionDetails", cts.Token);


            var machineDataResponse = machineData.IsSuccessStatusCode
                ? System.Text.Json.JsonSerializer.Deserialize<List<PlcReadingDto>>(
                    await machineData.Content.ReadAsStringAsync(), jsonOptions) ?? emptyMachineData
                : emptyMachineData;

            var combineDetailsResponse = combineDetails.IsSuccessStatusCode
                ? System.Text.Json.JsonSerializer.Deserialize<SentezIntegrationsResponsoDto<SentezIntegrationsGetCombineDetailsDto>>(
                    await combineDetails.Content.ReadAsStringAsync(), jsonOptions) ?? emptyCombineDetails
                : emptyCombineDetails;


            var productionDetailsResponse = productionDetails.IsSuccessStatusCode
            ? System.Text.Json.JsonSerializer.Deserialize<SentezIntegrationsResponsoDto<SentezIntegrationsGetProductionDetailsDto>>(
                await productionDetails.Content.ReadAsStringAsync(), jsonOptions)
                ?? emptyProductionDetails : emptyProductionDetails;

            var viewModel = _productionDetailBuilder.Build(
                machineDataResponse,
                combineDetailsResponse.Data,
                productionDetailsResponse.Data
            );

            return View(viewModel);
        }


    }
    public class ProductionDetailBuilder
    {
        private const int TamponSerialLength = 12;
        private const int BobinSerialLength = 16;

        public DetailProductionViewModel Build(
            List<PlcReadingDto> plcReadings,
            List<SentezIntegrationsGetCombineDetailsDto> combineList,
            List<SentezIntegrationsGetProductionDetailsDto> prodListRaw)
        {
            var prodList = prodListRaw ?? new();
            var combines = combineList ?? new();

            // ============================================================
            // TİP AYRIMI: SerialCode uzunluğu + InventoryCode prefix
            // ============================================================
            var tamponList = prodList
                .Where(x => IsTampon(x))
                .GroupBy(x => x.RecId)
                .Select(g => g.First())
                .ToList();

            var bobinList = prodList
                .Where(x => !IsTampon(x))
                .GroupBy(x => x.RecId)
                .Select(g => g.First())
                .ToList();

            System.Diagnostics.Debug.WriteLine(
                $"[Builder] Toplam={prodList.Count}, Tampon={tamponList.Count}, Bobin={bobinList.Count}");

            // ============================================================
            // PARENT-CHILD EŞLEŞTİRME
            // Öncelik 1: ParentId doluysa direkt eşleştir
            // Öncelik 2: Bobin SerialCode'un ilk 12 hanesi = Tampon SerialCode
            // ============================================================
            var tamponByRecId = tamponList.ToDictionary(x => x.RecId, x => x);

            var tamponCutTree = tamponList
                .OrderByDescending(t => t.ReceiptDate)
                .Select(t =>
                {
                    List<SentezIntegrationsGetProductionDetailsDto> bobinler;

                    // 1) ParentId dolu olan bobinler
                    bobinler = bobinList
                        .Where(b => b.ParentId.HasValue && b.ParentId.Value > 0
                                    && b.ParentId.Value == t.RecId)
                        .OrderByDescending(b => b.ReceiptDate)
                        .ToList();

                    // 2) ParentId eşleşmesi yoksa: bobin SerialCode ilk 12 hane = tampon SerialCode
                    if (!bobinler.Any() && !string.IsNullOrEmpty(t.SerialCode))
                    {
                        var tamponSeri12 = t.SerialCode.Length >= 12
                            ? t.SerialCode.Substring(0, 12)
                            : t.SerialCode;

                        bobinler = bobinList
                            .Where(b => !string.IsNullOrEmpty(b.SerialCode)
                                        && b.SerialCode.Length >= 12
                                        && b.SerialCode.Substring(0, 12) == tamponSeri12)
                            .OrderByDescending(b => b.ReceiptDate)
                            .ToList();
                    }

                    var bobinQty = bobinler.Sum(b => b.Quantity ?? 0);
                    var yieldPct = (t.Quantity ?? 0) > 0 ? (bobinQty / (t.Quantity ?? 1)) * 100 : 0;

                    return new TamponCutNodeVm
                    {
                        Tampon = t,
                        Bobinler = bobinler,
                        NodeYieldPercent = yieldPct
                    };
                })
                .ToList();

            var cutTampons = tamponCutTree.Where(x => x.Bobinler.Any()).ToList();
            var waitingTampons = tamponCutTree
                .Where(x => !x.Bobinler.Any())
                .Select(x => x.Tampon)
                .OrderByDescending(t => t.ReceiptDate)
                .ToList();

            var cutTamponsQty = cutTampons.Sum(x => x.Tampon.Quantity ?? 0);
            var bobinFromCutQty = cutTampons.Sum(x => x.Bobinler.Sum(b => b.Quantity ?? 0));
            var cuttingYieldPercent = cutTamponsQty > 0 ? (bobinFromCutQty / cutTamponsQty) * 100 : 0;

            // ============================================================
            // EŞLEŞMEYEN BOBİNLER
            // Hiçbir tampona bağlanamayan bobinler kayıp gitmesin diye
            // ayrı bir listede tutuluyor. (Daha önce hiçbir view model
            // alanına yazılmıyordu; bu yüzden Summary.BobinCount doğru
            // sayıyı gösterirken TamponCutTree altında bobinler görünmüyordu.)
            // ============================================================
            var matchedBobinIds = cutTampons
                .SelectMany(x => x.Bobinler)
                .Select(b => b.RecId)
                .ToHashSet();

            var unmatchedBobinList = bobinList
                .Where(b => !matchedBobinIds.Contains(b.RecId))
                .OrderByDescending(b => b.ReceiptDate)
                .ToList();

            System.Diagnostics.Debug.WriteLine(
                $"[Builder] Bobin toplam={bobinList.Count}, Eşleşen={matchedBobinIds.Count}, Eşleşmeyen={unmatchedBobinList.Count}");

            var summary = new ProductionSummaryVm
            {
                TotalPlc = plcReadings?.Count ?? 0,
                TotalCombine = combines.Count,
                TotalProd = prodList.Count,
                TotalCombineQty = combines.Sum(x => x.Quantity),
                TotalProdQty = prodList.Sum(x => x.Quantity ?? 0),
                ActiveSets = combines.Select(x => x.CombinationNo).Distinct().Count(),

                TamponCount = tamponList.Count,
                TamponQty = tamponList.Sum(x => x.Quantity ?? 0),
                TamponSets = tamponList.Select(x => x.CombinationNo)
                    .Where(x => !string.IsNullOrEmpty(x)).Distinct().Count(),
                StrapCompletionPercent = tamponList.Count > 0
                    ? (decimal)tamponList.Count(x => x.IsStrapping == 1) / tamponList.Count * 100 : 0,

                BobinCount = bobinList.Count,
                BobinQty = bobinList.Sum(x => x.Quantity ?? 0),
                BobinSets = bobinList.Select(x => x.CombinationNo)
                    .Where(x => !string.IsNullOrEmpty(x)).Distinct().Count(),
                WrapCompletionPercent = bobinList.Count > 0
                    ? (decimal)bobinList.Count(x => x.IsWrapping == 1) / bobinList.Count * 100 : 0,

                CuttingYieldPercent = cuttingYieldPercent,
                FireLossQty = cutTamponsQty > 0 ? cutTamponsQty - bobinFromCutQty : 0,
                FireLossPercent = cutTamponsQty > 0 ? 100 - cuttingYieldPercent : 0,
                WaitingRatioPercent = tamponList.Count > 0
                    ? (decimal)waitingTampons.Count / tamponList.Count * 100 : 0,
                PlanActualPercent = combines.Sum(x => x.Quantity) > 0
                    ? prodList.Sum(x => x.Quantity ?? 0) / combines.Sum(x => x.Quantity) * 100 : 0,
                AvgResourceSpeed = prodList.Where(x => x.ResourceSpeed.HasValue)
                    .Select(x => (double)x.ResourceSpeed!.Value).DefaultIfEmpty(0).Average(),
                AvgCycleMinutes = prodList.Where(x => x.StartTime.HasValue
                                                    && x.EndTime.HasValue
                                                    && x.EndTime > x.StartTime)
                    .Select(x => (x.EndTime!.Value - x.StartTime!.Value).TotalMinutes)
                    .DefaultIfEmpty(0).Average()
            };

            return new DetailProductionViewModel
            {
                PlcReading = plcReadings,
                SentezIntegrationsGetCombineDetails = combines,
                SentezIntegrationsGetProductionDetails = prodList,
                Summary = summary,
                TamponCutTree = cutTampons,
                WaitingTampons = waitingTampons,
                AllBobinList = bobinList,
                UnmatchedBobinList = unmatchedBobinList,
                //TamponRecIds = tamponList.Select(x => (object)x.RecId).ToHashSet()
            };
        }

        // ============================================================
        // TİP AYIRIMI
        // Kural 1: SerialCode uzunluğu 16 ise → Bobin
        // Kural 2: SerialCode uzunluğu 12 ise → Tampon
        // Kural 3: InventoryCode 9 ile başlıyorsa → Bobin
        // Kural 4: InventoryCode 8 ile başlıyorsa → Tampon
        // Kural 5: ParentId doluysa → Bobin (fallback)
        // ============================================================
        private static bool IsTampon(SentezIntegrationsGetProductionDetailsDto x)
        {
            // SerialCode normalize et
            var serial = x.SerialCode?.Trim() ?? string.Empty;
            var invCode = x.InventoryCode?.Trim() ?? string.Empty;

            // 1) InventoryCode prefix'i EN GÜVENİLİR (sizin verdiğiniz bilgi)
            //    "9" ile başlıyorsa bobin, "8" ile başlıyorsa tampon
            if (invCode.Length > 0)
            {
                var first = invCode[0];
                if (first == '9') return false;  // Bobin
                if (first == '8') return true;   // Tampon
            }

            // 2) SerialCode uzunluğu
            if (serial.Length > 0)
            {
                if (serial.Length >= BobinSerialLength) return false;  // 16+ → Bobin
                if (serial.Length == TamponSerialLength) return true;  // 12 → Tampon
                if (serial.Length < TamponSerialLength) return true;   // <12 → Tampon
            }

            // 3) ParentId fallback
            return !x.ParentId.HasValue || x.ParentId == 0;
        }
    }
}
