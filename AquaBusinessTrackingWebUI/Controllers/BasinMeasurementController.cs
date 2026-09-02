using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.BasinDtos.BasinDto;
using DTOLayer.Dtos.BasinDtos.BasinMeasurement;
using DTOLayer.Dtos.ShiftDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace AquaBusinessTrackingWebUI.Controllers
{
    public class BasinMeasurementController : Controller
    {
        private readonly AuthorizedHttpClientService _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        private readonly CurrentUserService _currentUserService;

        public BasinMeasurementController(AuthorizedHttpClientService httpClientFactory, IOptions<ApiSettings> apiSettings, CurrentUserService currentUserService)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
            _currentUserService = currentUserService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasinMeasurementList()
        {
            if (!_currentUserService.HasPermission("ARITMA.BasinMeasurement.View"))
            {
                return Json(new { success = false, message = "Bu işlemi gerçekleştirmek için gerekli izniniz bulunmamaktadır." });
            }

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_apiSettings.BaseUrl}/BasinMeasurement/details");
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = response.Content.ReadAsStringAsync();
                return View(new List<BasinMeasurementDto>());
            }


            var json = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<BasinMeasurementDto>>(json);
            if (values == null || !values.Any())
                return View(new List<BasinMeasurementDto>());

            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var client = _httpClientFactory.CreateClient();
            await LoadShiftListAsync();
            await LoadBasinListAsync();
            ViewBag.AppUserName = User.Identity?.Name;
            if (id.HasValue)
            {
                if (!_currentUserService.HasPermission("ARITMA.BasinMeasurement.Update"))
                {
                    return Json(new { success = false, message = "Bu işlemi gerçekleştirmek için gerekli izniniz bulunmamaktadır." });
                }


                var basinResponse = await client.GetAsync($"{_apiSettings.BaseUrl}/BasinMeasurement/getbyid/{id}");
                var basinJson = await basinResponse.Content.ReadAsStringAsync();
                var dto = JsonConvert.DeserializeObject<BasinMeasurementDto>(basinJson);

                var model = new ModalViewModel<BasinMeasurementDto>
                {
                    Entity = dto,
                    IsEdit = true,
                    ModalTitle = "Havuz Güncelle",
                    FormAction = "Edit"
                };
                return PartialView("_Edit", model);
            }
            else
            {
                if (!_currentUserService.HasPermission("ARITMA.BasinMeasurement.Add"))
                {
                    return Json(new { success = false, message = "Bu işlemi gerçekleştirmek için gerekli izniniz bulunmamaktadır." });
                }

                var model = new ModalViewModel<BasinMeasurementDto>
                {
                    Entity = new BasinMeasurementDto(),
                    IsEdit = false,
                    ModalTitle = "Havuz Ekle",
                    FormAction = "Edit"
                };
                return PartialView("_Edit", model);
            }
        }

        [HttpGet]
        public IActionResult GetWithSearchDetails()
        {
            ViewData["Title"] = "Analiz Defteri Tüketim Arama";
            return View();
        }


        [HttpGet]
        public async Task<IActionResult> GetWithSearchDetailsJson(DateTime StartDate, DateTime EndDate)
        {
            if (!_currentUserService.HasPermission("ARITMA.BasinMeasurement.View"))
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
            var response = await client.GetAsync($"{_apiSettings.BaseUrl}/BasinMeasurement/search?startDate={startDateStr}&endDate={endDateStr}");
            if (!response.IsSuccessStatusCode)
                return View(new List<BasinMeasurementDto>());
            var json = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<BasinMeasurementDto>>(json);
            if (values == null || !values.Any())
                return Json(new List<BasinMeasurementDto>());

            return Json(values ?? new List<BasinMeasurementDto>());
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ModalViewModel<BasinMeasurementDto> model)
        {
            var dto = model.Entity;
            dto.DepartmentId = int.Parse(User.FindFirst("DepartmentId")?.Value);
            dto.AppUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var client = _httpClientFactory.CreateClient();

            if (dto.RecId > 0)
            {
                dto.UpdateDate = DateTime.Now;
                var basinJson = JsonConvert.SerializeObject(dto);
                var basinContent = new StringContent(basinJson, Encoding.UTF8, "application/json");
                await client.PutAsync($"{_apiSettings.BaseUrl}/BasinMeasurement/update", basinContent);
            }
            else
            {
                dto.InsertDate = DateTime.Now;
                var basinJson = JsonConvert.SerializeObject(dto);
                var basinContent = new StringContent(basinJson, Encoding.UTF8, "application/json");
                await client.PostAsync($"{_apiSettings.BaseUrl}/BasinMeasurement/add", basinContent);
            }

            return RedirectToAction("GetBasinMeasurementList");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (!_currentUserService.HasPermission("ARITMA.BasinMeasurement.Delete"))
            {
                return Json(new { success = false, message = "Bu işlemi gerçekleştirmek için gerekli izniniz bulunmamaktadır." });
            }

            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"{_apiSettings.BaseUrl}/BasinMeasurement/delete/{id}");

            if (response.IsSuccessStatusCode)
                return RedirectToAction("GetBasinMeasurementList");

            return Json(new { success = false, message = "Silme işlemi başarısız oldu." });
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


        private async Task LoadBasinListAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var sb = new StringBuilder();
            var response = await client.GetAsync($"{_apiSettings.BaseUrl}/Basin/details");
            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<BasinDto>>(jsonData);
                if (values != null)
                {
                    ViewBag.BasinPlaces = values.Select(r => new SelectListItem
                    {
                        Value = r.RecId.ToString(),
                        Text = r.Name.ToString()
                    }).ToList();
                }
            }
        }
    }
}
