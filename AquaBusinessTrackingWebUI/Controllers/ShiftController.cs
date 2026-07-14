using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.ShiftDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace AquaBusinessTrackingWebUI.Controllers
{
    public class ShiftController : Controller
    {
        private readonly AuthorizedHttpClientService _httpClientFactory;
        private readonly ModalService _modalService;
        private readonly ApiSettings _apiSettings;
        private readonly CurrentUserService _currentUserService;

        public ShiftController(AuthorizedHttpClientService httpClientFactory, ModalService modalService, IOptions<ApiSettings> apiSettings, CurrentUserService currentUserService)
        {
            _httpClientFactory = httpClientFactory;
            _modalService = modalService;
            _apiSettings = apiSettings.Value;
            _currentUserService = currentUserService;
        }

        [HttpGet]
        public async Task<IActionResult> GetShiftList()
        {
            if (!_currentUserService.HasPermission("AYARLAR.Shifts.View"))
            {
                return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
            }
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_apiSettings.BaseUrl}/Shift/getall");
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                return View(new List<ShiftDto>());
            }

            var json = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ShiftDto>>(json);
            if (values == null || !values.Any())
                return View(new List<ShiftDto>());
            var sb = new StringBuilder();
            ViewBag.AppUserName = User.Identity?.Name;


            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            //ViewBag.AppUserName = User.Identity?.Name;
            if (id.HasValue)
            {
                if (!_currentUserService.HasPermission("AYARLAR.Shifts.Update"))
                {
                    return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
                }
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync($"{_apiSettings.BaseUrl}/Shift/{id}");
                if (!response.IsSuccessStatusCode)
                    return RedirectToAction("GetShiftList");

                var json = await response.Content.ReadAsStringAsync();
                var dto = JsonConvert.DeserializeObject<ShiftDto>(json);

                var model = new ModalViewModel<ShiftDto>
                {
                    Entity = dto,
                    IsEdit = true,
                    ModalTitle = "Vardiya Güncelle",
                    FormAction = "Edit"
                };
                return PartialView("_Edit", model);
            }
            else
            {
                if (!_currentUserService.HasPermission("AYARLAR.Shifts.Add"))
                {
                    return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
                }
                var model = new ModalViewModel<ShiftDto>
                {
                    Entity = new ShiftDto(),
                    IsEdit = false,
                    ModalTitle = "Vardiya Ekle",
                    FormAction = "Edit"
                };
                return PartialView("_Edit", model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ModalViewModel<ShiftDto> model)
        {
            var dto = model.Entity;
            //dto.DepartmentId = int.Parse(User.FindFirst("DepartmentId")?.Value);
            //dto.AppUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);  Refaktoringten sonra eklenebilir

            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            if (model.Entity.RecId != null)
            {
                dto.UpdateDate = DateTime.Now;
                var result = await client.PutAsync($"{_apiSettings.BaseUrl}/Shift/{dto.RecId}", content);
                if (!result.IsSuccessStatusCode)
                {
                    var errorMessage = result.Content.ReadAsStringAsync();
                }
            }
            else
            {
                dto.InsertDate = DateTime.Now;
                var result = await client.PostAsync($"{_apiSettings.BaseUrl}/Shift", content);
                if (!result.IsSuccessStatusCode)
                {
                    var errorMessage = result.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("GetShiftList");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteShift(int id)
        {
            if (!_currentUserService.HasPermission("AYARLAR.Shifts.Delete"))
            {
                return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
            }
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"{_apiSettings.BaseUrl}/Shift/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("GetShiftList");
            }
            else
            {
                return Json(new { success = false, message = "Silme işlemi başarısız oldu." });
            }


        }


    }
}
