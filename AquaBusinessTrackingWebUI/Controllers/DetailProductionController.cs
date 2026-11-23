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
        public DetailProductionViewModel Build(
            List<PlcReadingDto> plcReadings,
            List<SentezIntegrationsGetCombineDetailsDto> combineList,
            List<SentezIntegrationsGetProductionDetailsDto> prodListRaw)
        {
            var prodList = prodListRaw ?? new();
            var combines = combineList ?? new();


            var distinct = prodList.GroupBy(x => x.RecId).Select(g => g.First()).ToList();

            var tamponList = distinct.Where(IsTampon).ToList();
            var bobinList = distinct.Where(x => !IsTampon(x)).ToList();


            var tamponByRecId = tamponList.ToDictionary(t => Convert.ToInt64(t.RecId));

            var tamponBySerial = tamponList
                .Where(t => !string.IsNullOrWhiteSpace(t.SerialCode))
                .GroupBy(t => t.SerialCode!.Trim(), StringComparer.OrdinalIgnoreCase)
                .ToDictionary(g => g.Key, g => g.First(), StringComparer.OrdinalIgnoreCase);


            SentezIntegrationsGetProductionDetailsDto? FindParent(SentezIntegrationsGetProductionDetailsDto b)
            {
                if (b.ParentSerialId.HasValue && b.ParentSerialId.Value > 0
                    && tamponByRecId.TryGetValue(Convert.ToInt64(b.ParentSerialId.Value), out var byId))
                    return byId;

                var serial = b.SerialCode?.Trim();
                if (!string.IsNullOrEmpty(serial) && serial.Length >= 12
                    && tamponBySerial.TryGetValue(serial.Substring(0, 12), out var bySerial))
                    return bySerial;

                return null;
            }


            var bobinParents = bobinList.Select(b => (Bobin: b, Parent: FindParent(b))).ToList();

            var bobinsByTampon = bobinParents
                .Where(x => x.Parent != null)
                .ToLookup(x => Convert.ToInt64(x.Parent!.RecId), x => x.Bobin);


            var tamponCutTree = tamponList
                .OrderByDescending(t => t.ReceiptDate)
                .Select(t =>
                {
                    var bobinler = bobinsByTampon[Convert.ToInt64(t.RecId)]
                        .OrderByDescending(b => b.ReceiptDate)
                        .ToList();

                    var bobinQty = bobinler.Sum(b => b.Quantity ?? 0);
                    var tamponQty = t.Quantity ?? 0;

                    return new TamponCutNodeVm
                    {
                        Tampon = t,
                        Bobinler = bobinler,
                        NodeYieldPercent = tamponQty > 0 ? bobinQty / tamponQty * 100 : 0
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
            var cuttingYieldPercent = cutTamponsQty > 0 ? bobinFromCutQty / cutTamponsQty * 100 : 0;


            var unmatchedBobinList = bobinParents
                .Where(x => x.Parent == null)
                .Select(x => x.Bobin)
                .OrderByDescending(b => b.ReceiptDate)
                .ToList();


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
                UnmatchedBobinList = unmatchedBobinList
            };
        }


        public static bool IsTampon(SentezIntegrationsGetProductionDetailsDto x)
        {
            if (x.ParentSerialId.HasValue && x.ParentSerialId.Value > 0)
                return false;
            var invCode = x.InventoryCode?.Trim();
            if (!string.IsNullOrEmpty(invCode) && invCode[0] == '9')
                return false;
            var serial = x.SerialCode?.Trim();
            if (!string.IsNullOrEmpty(serial) && serial.Length >= 16)
                return false;
            return true;
        }
    }
}

