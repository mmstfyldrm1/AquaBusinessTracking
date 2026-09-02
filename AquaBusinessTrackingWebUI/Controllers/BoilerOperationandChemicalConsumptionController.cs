using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.BoilerOperationandChemicalConsumptionDtos;
using DTOLayer.Dtos.BoilerRoomDailyShiftMonitoringDtos;
using DTOLayer.Dtos.DepartmentDtos;
using DTOLayer.Dtos.KazanEnergyConsumptionDtos;
using DTOLayer.Dtos.ShiftDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace AquaBusinessTrackingWebUI.Controllers
{
    public class BoilerOperationandChemicalConsumptionController : Controller
    {
        private readonly AuthorizedHttpClientService _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        private readonly CurrentUserService _currentUserService;

        public BoilerOperationandChemicalConsumptionController(AuthorizedHttpClientService httpClientFactory, IOptions<ApiSettings> apiSettings, CurrentUserService currentUserService)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
            _currentUserService = currentUserService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBoilerRoomDailyShiftData()
        {
            if (!_currentUserService.HasPermission("KAZAN.BoilerOperationandChemicalConsumption.View"))
            {
                return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
            }

            var client = _httpClientFactory.CreateClient();
            var model = new BoilerRoomDailyShiftViewModel();

            var response = await client.GetAsync($"{_apiSettings.BaseUrl}/BoilerOperationandChemicalConsumption/details");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<BoilerOperationandChemicalConsumptionDto>>(json);
                if (values != null)
                    model.BoilerList = values;
            }

            var kazanLocation = await client.GetAsync($"{_apiSettings.BaseUrl}/BoilerOperationandChemicalConsumption/kazanEnergyStatus");
            if (kazanLocation.IsSuccessStatusCode)
            {
                var json = await kazanLocation.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<EnergyConsumptionStatusDto>>(json);
                if (values != null)
                    model.EnergyStatus = values;
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var client = _httpClientFactory.CreateClient();
            await LoadShiftListAsync();
            await LoadDepartmentListAsync();
            await LoadKazanEnergyListAsync();
            ViewBag.AppUserName = User.Identity?.Name;

            if (id.HasValue)
            {
                if (!_currentUserService.HasPermission("KAZAN.BoilerOperationandChemicalConsumption.Update"))
                {
                    return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
                }

                var response = await client.GetAsync($"{_apiSettings.BaseUrl}/BoilerOperationandChemicalConsumption/getbyid/{id}");
                if (!response.IsSuccessStatusCode)
                    return RedirectToAction("GetBoilerRoomDailyShiftData");

                var json = await response.Content.ReadAsStringAsync();
                var dto = JsonConvert.DeserializeObject<BoilerOperationandChemicalConsumptionDto>(json);

                var editModel = new ModalViewModel<BoilerOperationandChemicalConsumptionDto>
                {
                    Entity = dto,
                    IsEdit = true,
                    ModalTitle = "Kayıt Güncelle",
                    FormAction = "Edit"
                };
                return PartialView("_Edit", editModel);
            }
            else
            {
                if (!_currentUserService.HasPermission("KAZAN.BoilerOperationandChemicalConsumption.Add"))
                {
                    return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
                }

                // ConsumptionPlaces listesini ViewBag'den değil, direkt API'den çekip Rows'a dolduruyoruz
                var kazanResponse = await client.GetAsync($"{_apiSettings.BaseUrl}/KazanEnergyConsumption/details");
                var kazanJson = await kazanResponse.Content.ReadAsStringAsync();
                var kazanList = JsonConvert.DeserializeObject<List<KazanEnergyConsumptionDto>>(kazanJson);

                if (kazanList == null || !kazanResponse.IsSuccessStatusCode)
                {
                    return RedirectToAction("GetBoilerRoomDailyShiftData");
                }

                var bulkDto = new BoilerOperationandChemicalConsumptionBulkDto
                {
                    ReceiptDate = DateTime.Now,
                    Rows = kazanList.Select(x => new ConsumptionPlaceRow
                    {
                        ConsumptionPlaceId = x.RecId,
                        ConsumptionPlaceName = x.ConsumptionPlace
                    }).ToList()
                };

                var bulkModel = new ModalViewModel<BoilerOperationandChemicalConsumptionBulkDto>
                {
                    Entity = bulkDto,
                    IsEdit = false,
                    ModalTitle = "Kayıt Ekle",
                    FormAction = "EditBulk"
                };
                return PartialView("_AddBulk", bulkModel);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ModalViewModel<BoilerOperationandChemicalConsumptionDto> model)
        {
            var dto = model.Entity;
            dto.DepartmentId = int.Parse(User.FindFirst("DepartmentId")?.Value);
            dto.AppUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            if (model.Entity.RecId != null && model.Entity.RecId > 0)
            {
                dto.UpdateDate = DateTime.Now;
                var result = await client.PutAsync($"{_apiSettings.BaseUrl}/BoilerOperationandChemicalConsumption/update/{dto.RecId}", content);
                if (!result.IsSuccessStatusCode)
                {
                    var errorMessage = result.Content.ReadAsStringAsync();
                    return PartialView("_Edit", model);
                }
            }
            else
            {
                dto.InsertDate = DateTime.Now;
                var result = await client.PostAsync($"{_apiSettings.BaseUrl}/BoilerOperationandChemicalConsumption/add", content);
                if (!result.IsSuccessStatusCode)
                {
                    var errorMessage = result.Content.ReadAsStringAsync();
                    return PartialView("_Edit", model);
                }
            }

            return RedirectToAction("GetBoilerRoomDailyShiftData");
        }

        [HttpGet]
        public IActionResult GetWithSearchDetails()
        {
            ViewData["Title"] = "Doğalgaz Tüketim  Arama";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetWithSearchDetailsJson(DateTime StartDate, DateTime EndDate)
        {
            if (!_currentUserService.HasPermission("KAZAN.BoilerOperationandChemicalConsumption.View"))
            {
                return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
            }
            if (StartDate == default || EndDate == default)
            {
                return Json(new { success = false, message = "Başlangıç ve bitiş tarihleri geçerli olmalıdır." });
            }

            var startDateStr = StartDate.ToString("yyyy-MM-dd");
            var endDateStr = EndDate.ToString("yyyy-MM-dd");
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_apiSettings.BaseUrl}/BoilerOperationandChemicalConsumption/search?startDate={startDateStr}&endDate={endDateStr}");
            if (!response.IsSuccessStatusCode)
                return Json(new List<BoilerOperationandChemicalConsumptionDto>());

            var json = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<BoilerOperationandChemicalConsumptionDto>>(json);

            return Json(values ?? new List<BoilerOperationandChemicalConsumptionDto>());
        }

        [HttpPost]
        public async Task<IActionResult> EditBulk(ModalViewModel<BoilerOperationandChemicalConsumptionBulkDto> model)
        {
            if (!_currentUserService.HasPermission("KAZAN.BoilerOperationandChemicalConsumption.Add"))
            {
                return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
            }

            var client = _httpClientFactory.CreateClient();
            var departmentId = int.Parse(User.FindFirst("DepartmentId")?.Value);
            var appUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var bulk = model.Entity;
            var rowsToSave = bulk.Rows.Where(r => r.ConsumptionQuantity.HasValue);

            int failCount = 0;

            foreach (var row in rowsToSave)
            {
                var dto = new BoilerOperationandChemicalConsumptionDto
                {
                    ReceiptDate = bulk.ReceiptDate ?? DateTime.Now,
                    ScalePlaceId = bulk.ScalePlaceId,
                    ShiftId = bulk.ShiftId,
                    InUse = 1,
                    ConsumptionPlaceId = row.ConsumptionPlaceId,
                    ConsumptionQuantity = row.ConsumptionQuantity.Value,
                    Explanation = row.Explanation,
                    DepartmentId = departmentId,
                    AppUserId = appUserId,
                    InsertDate = DateTime.Now
                };

                var json = JsonConvert.SerializeObject(dto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var result = await client.PostAsync($"{_apiSettings.BaseUrl}/BoilerOperationandChemicalConsumption/add", content);
                if (!result.IsSuccessStatusCode)
                {
                    failCount++;
                }
            }

            if (failCount > 0)
                TempData["Warning"] = $"{failCount} kayıt için ekleme başarısız oldu.";

            return RedirectToAction("GetBoilerRoomDailyShiftData");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (!_currentUserService.HasPermission("KAZAN.BoilerOperationandChemicalConsumption.Delete"))
            {
                return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
            }

            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"{_apiSettings.BaseUrl}/BoilerOperationandChemicalConsumption/delete/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("GetBoilerRoomDailyShiftData");
            }
            else
            {
                return Json(new { success = false, message = "Silme işlemi başarısız oldu." });
            }
        }

        private async Task LoadShiftListAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_apiSettings.BaseUrl}/Shift/getall");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ShiftDto>>(jsonData);
                if (values != null)
                {
                    ViewBag.Shifts = values.Select(r => new SelectListItem
                    {
                        Value = r.RecId.ToString(),
                        Text = r.ShiftName.ToString()
                    }).ToList();
                }
            }
        }

        private async Task LoadDepartmentListAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_apiSettings.BaseUrl}/Department");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<DepartmentDto>>(jsonData);
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

        private async Task LoadKazanEnergyListAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_apiSettings.BaseUrl}/KazanEnergyConsumption/details");

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<KazanEnergyConsumptionDto>>(jsonData);
                if (values != null)
                {
                    ViewBag.ConsumptionPlaces = values.Select(r => new SelectListItem
                    {
                        Value = r.RecId.ToString(),
                        Text = r.ConsumptionPlace.ToString()
                    }).ToList();
                }
            }
        }
    }
}