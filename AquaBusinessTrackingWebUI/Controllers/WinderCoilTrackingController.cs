using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.ShiftDtos;
using DTOLayer.Dtos.WinderCoilTrackingDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace AquaBusinessTrackingWebUI.Controllers
{

    public class WinderCoilTrackingController : Controller
    {
        private readonly AuthorizedHttpClientService _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        private readonly CurrentUserService _currentUserService;

        public WinderCoilTrackingController(AuthorizedHttpClientService httpClientFactory, IOptions<ApiSettings> apiSettings, CurrentUserService currentUserService)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
            _currentUserService = currentUserService;
        }

        [HttpGet]
        public async Task<IActionResult> WinderCoilTrackingList()
        {
            if (!_currentUserService.HasPermission("BOBINKESME.WinderCoilTracking.View"))
            {
                return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
            }
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_apiSettings.BaseUrl}/WinderCoilTracking/details");
            if (!response.IsSuccessStatusCode)
                return View(new List<WinderCoilTrackingDto>());
            var json = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<WinderCoilTrackingDto>>(json);
            if (values == null || !values.Any())
                return View(new List<WinderCoilTrackingDto>());
            return View(values);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            await LoadShiftListAsync();
            ViewBag.AppUserName = User.Identity?.Name;

            if (id.HasValue)
            {
                if (!_currentUserService.HasPermission("BOBINKESME.WinderCoilTracking.Update"))
                {
                    return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
                }
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync($"{_apiSettings.BaseUrl}/WinderCoilTracking/GetById/{id}");
                if (!response.IsSuccessStatusCode)
                    return RedirectToAction("WinderCoilTrackingList");

                var json = await response.Content.ReadAsStringAsync();
                var dto = JsonConvert.DeserializeObject<WinderCoilTrackingDto>(json);

                var model = new ModalViewModel<WinderCoilTrackingDto>
                {
                    Entity = dto,
                    IsEdit = true,
                    ModalTitle = "Kombin Güncelle",
                    FormAction = "Edit"
                };
                return PartialView("_Edit", model);
            }
            else
            {
                if (!_currentUserService.HasPermission("BOBINKESME.WinderCoilTracking.Add"))
                {
                    return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
                }
                var model = new ModalViewModel<WinderCoilTrackingDto>
                {
                    Entity = new WinderCoilTrackingDto(),
                    IsEdit = false,
                    ModalTitle = "Kombin Ekle",
                    FormAction = "Edit"
                };
                return PartialView("_Edit", model);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Edit(ModalViewModel<WinderCoilTrackingDto> model)
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
                var result = await client.PutAsync($"{_apiSettings.BaseUrl}/WinderCoilTracking/Update/{dto.RecId}", content);
                if (!result.IsSuccessStatusCode)
                {
                    var errorMessage = await result.Content.ReadAsStringAsync();
                    return PartialView("_Edit", result);
                }
            }
            else
            {
                dto.InsertDate = DateTime.Now;
                var result = await client.PostAsync($"{_apiSettings.BaseUrl}/WinderCoilTracking/Add", content);
                if (!result.IsSuccessStatusCode)
                {
                    var errorMessage = await result.Content.ReadAsStringAsync();
                    return PartialView("_Edit", result);
                }
            }

            return RedirectToAction("WinderCoilTrackingList");
        }


        [HttpPost]
        public async Task<IActionResult> DeleteBuffer(int id)
        {
            if (!_currentUserService.HasPermission("BOBINKESME.WinderCoilTracking.Delete"))
            {
                return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
            }
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"{_apiSettings.BaseUrl}/WinderCoilTracking/Delete/{id}");
            if (response.IsSuccessStatusCode)
                return Redirect("~/WinderCoilTracking/WinderCoilTrackingList");

            return Json(new { success = false, message = "Silme işlemi başarısız oldu." });
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
