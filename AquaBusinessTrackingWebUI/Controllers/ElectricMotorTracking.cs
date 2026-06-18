using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.ElectricDtos.ElectricMotorTrackingDto;
using DTOLayer.Dtos.ShiftDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace AquaBusinessTrackingWebUI.Controllers
{

    public class ElectricMotorTracking : Controller
    {
        private readonly AuthorizedHttpClientService _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        private readonly CurrentUserService _currentUserService;

        public ElectricMotorTracking(AuthorizedHttpClientService httpClientFactory, IOptions<ApiSettings> apiSettings, CurrentUserService currentUserService)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
            _currentUserService = currentUserService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMotorList()
        {
            if (!_currentUserService.HasPermission("ELEKTRIK.ElectricMotorTracking.View"))
            {
                return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });

            }
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_apiSettings.BaseUrl}/ElectricMotorTracking/details");
            if (!response.IsSuccessStatusCode)
                return View(new List<ElectricMotorDto>());
            var json = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ElectricMotorDto>>(json);
            if (values == null || !values.Any())
                return View(new List<ElectricMotorDto>());
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            await LoadShiftListAsync();
            ViewBag.AppUserName = User.Identity?.Name;

            if (id.HasValue)
            {
                if (!_currentUserService.HasPermission("ELEKTRIK.ElectricMotorTracking.Update"))
                {
                    return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });

                }
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync($"{_apiSettings.BaseUrl}/ElectricMotorTracking/{id}");
                if (!response.IsSuccessStatusCode)
                    return RedirectToAction("GetMotorList");

                var json = await response.Content.ReadAsStringAsync();
                var dto = JsonConvert.DeserializeObject<ElectricMotorDto>(json);

                var model = new ModalViewModel<ElectricMotorDto>
                {
                    Entity = dto,
                    IsEdit = true,
                    ModalTitle = "Motor Güncelle",
                    FormAction = "Edit"
                };
                return PartialView("_Edit", model);
            }
            else
            {
                if (!_currentUserService.HasPermission("ELEKTRIK.ElectricMotorTracking.Add"))
                {
                    return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });

                }
                var model = new ModalViewModel<ElectricMotorDto>
                {
                    Entity = new ElectricMotorDto(),
                    IsEdit = false,
                    ModalTitle = "Motor Ekle",
                    FormAction = "Edit"
                };
                return PartialView("_Edit", model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ModalViewModel<ElectricMotorDto> model)
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
                await client.PutAsync($"{_apiSettings.BaseUrl}/ElectricMotorTracking/{dto.RecId}", content);
            }
            else
            {
                dto.InsertDate = DateTime.Now;
                await client.PostAsync($"{_apiSettings.BaseUrl}/ElectricMotorTracking", content);
            }

            return RedirectToAction("GetMotorList");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteMotor(int id)
        {
            if (!_currentUserService.HasPermission("ELEKTRIK.ElectricMotorTracking.Delete"))
            {
                return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });

            }
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"{_apiSettings.BaseUrl}/ElectricMotorTracking/{id}");
            if (response.IsSuccessStatusCode)
                return Redirect("~/ElectricMotorTracking/GetMotorList");

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