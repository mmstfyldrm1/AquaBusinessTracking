using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.ElectricDtos.CumulativeElectricityConsumptionDtos;
using DTOLayer.Dtos.ShiftDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace AquaBusinessTrackingWebUI.Controllers
{
    public class CumulativeElectricityConsumptionController : Controller
    {
        private readonly AuthorizedHttpClientService _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        private readonly CurrentUserService _currentUserService;

        public CumulativeElectricityConsumptionController(AuthorizedHttpClientService httpClientFactory, IOptions<ApiSettings> apiSettings, CurrentUserService currentUserService)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
            _currentUserService = currentUserService;
        }


        [HttpGet]
        public async Task<IActionResult> GetCumulativeElectricityConsumptionList()
        {
            if (!_currentUserService.HasPermission("ELEKTIRIK.CumulativeElectricityConsumption.View"))
            {
                return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
            }
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync($"{_apiSettings.BaseUrl}/CumulativeElectricityConsumption/details");
            if (!response.IsSuccessStatusCode)
                return View(new List<CumulativeElectricityConsumptionDto>());
            var json = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<CumulativeElectricityConsumptionDto>>(json);
            if (values == null || !values.Any())
                return View(new List<CumulativeElectricityConsumptionDto>());
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var client = _httpClientFactory.CreateClient();
            await LoadShiftListAsync();
            ViewBag.AppUserName = User.Identity?.Name;
            var responseLocationList = await client.GetAsync($"{_apiSettings.BaseUrl}/CumulativeElectricityConsumption/location");
            var jsonLocation = await responseLocationList.Content.ReadAsStringAsync();
            var dtoLocation = JsonConvert.DeserializeObject<List<CumulativeElectricityConsumptionDto>>(jsonLocation);

            if (dtoLocation == null || !responseLocationList.IsSuccessStatusCode)
            {
                var errorMessage = await responseLocationList.Content.ReadAsStringAsync();
                return RedirectToAction("GetCumulativeElectricityConsumptionList");
            }
            var Location = dtoLocation?
                 .Select(x => new SelectListItem
                 {
                     Value = x.RecId.ToString(),
                     Text = x.LocationName
                 })
                 .ToList() ?? new();

            ViewBag.Location = Location;
            if (id.HasValue)
            {
                if (!_currentUserService.HasPermission("ELEKTIRIK.CumulativeElectricityConsumption.Update"))
                {
                    return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
                }

                var response = await client.GetAsync($"{_apiSettings.BaseUrl}/CumulativeElectricityConsumption/getbyid/{id}");
                if (!response.IsSuccessStatusCode)
                    return RedirectToAction("GetCumulativeElectricityConsumptionList");

                var json = await response.Content.ReadAsStringAsync();
                var dto = JsonConvert.DeserializeObject<CumulativeElectricityConsumptionDto>(json);

                var model = new ModalViewModel<CumulativeElectricityConsumptionDto>
                {
                    Entity = dto,
                    IsEdit = true,
                    ModalTitle = "Kayıt Güncelle",
                    FormAction = "Edit"
                };
                return PartialView("_Edit", model);
            }
            else
            {
                if (!_currentUserService.HasPermission("ELEKTIRIK.CumulativeElectricityConsumption.Add"))
                {
                    return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
                }
                var model = new ModalViewModel<CumulativeElectricityConsumptionDto>
                {
                    Entity = new CumulativeElectricityConsumptionDto(),
                    IsEdit = false,
                    ModalTitle = "Kayıt Ekle",
                    FormAction = "Edit"
                };
                return PartialView("_Edit", model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ModalViewModel<CumulativeElectricityConsumptionDto> model)
        {

            var dto = model.Entity;
            var client = _httpClientFactory.CreateClient();
            dto.DepartmanId = int.Parse(User.FindFirst("DepartmentId")?.Value);
            dto.AppUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            if (model.Entity.RecId != null && model.Entity.RecId > 0)
            {

                var result = await client.PutAsync($"{_apiSettings.BaseUrl}/CumulativeElectricityConsumption/update/{dto.RecId}", content);
                if (!result.IsSuccessStatusCode)
                {
                    var errorMessage = result.Content.ReadAsStringAsync();
                    return PartialView("_Edit", model);
                }
            }
            else
            {

                var result = await client.PostAsync($"{_apiSettings.BaseUrl}/CumulativeElectricityConsumption/add", content);
                if (!result.IsSuccessStatusCode)
                {
                    var errorMessage = result.Content.ReadAsStringAsync();
                    return PartialView("_Edit", model);
                }
            }

            return RedirectToAction("GetCumulativeElectricityConsumptionList");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (!_currentUserService.HasPermission("ELEKTIRIK.CumulativeElectricityConsumption.Delete"))
            {
                return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
            }
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"{_apiSettings.BaseUrl}/CumulativeElectricityConsumption/delete/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("GetCumulativeElectricityConsumptionList");
            }
            else
            {
                return Json(new { success = false, message = "Silme işlemi başarısız oldu." });
            }


        }

        private async Task LoadShiftListAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var sb = new StringBuilder();
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
    }

}
