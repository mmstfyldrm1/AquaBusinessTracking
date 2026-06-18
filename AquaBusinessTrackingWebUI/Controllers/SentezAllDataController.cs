using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.SentezAllDataDtos;
using DTOLayer.Dtos.ShiftDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace AquaBusinessTrackingWebUI.Controllers
{

    public class SentezAllDataController : Controller
    {
        private readonly AuthorizedHttpClientService _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        private readonly CurrentUserService _currentUserService;
        public SentezAllDataController(AuthorizedHttpClientService httpClientFactory, IOptions<ApiSettings> apiSettings, CurrentUserService currentUserService)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
            _currentUserService = currentUserService;
        }
        [HttpGet]
        public async Task<IActionResult> GetSentezAllData()
        {
            if (!_currentUserService.HasPermission("KALITE.SentezAllData.View"))
            {
                return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
            }
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_apiSettings.BaseUrl}/SentezAllData/details");
            if (!response.IsSuccessStatusCode)
                return View(new List<SentezAllDataDto>());
            var json = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<SentezAllDataDto>>(json);
            if (values == null || !values.Any())
                return View(new List<SentezAllDataDto>());
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            await LoadShiftListAsync();
            ViewBag.AppUserName = User.Identity?.Name;

            if (id.HasValue)
            {
                if (!_currentUserService.HasPermission("KALITE.SentezAllData.Update"))
                {
                    return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
                }
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync($"{_apiSettings.BaseUrl}/SentezAllData/getbyid/{id}");
                if (!response.IsSuccessStatusCode)
                    return RedirectToAction("GetSentezAllData");

                var json = await response.Content.ReadAsStringAsync();
                var dto = JsonConvert.DeserializeObject<SentezAllDataDto>(json);

                var model = new ModalViewModel<SentezAllDataDto>
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
                if (!_currentUserService.HasPermission("KALITE.SentezAllData.Add"))
                {
                    return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
                }
                var model = new ModalViewModel<SentezAllDataDto>
                {
                    Entity = new SentezAllDataDto(),
                    IsEdit = false,
                    ModalTitle = "Kayıt Ekle",
                    FormAction = "Edit"
                };
                return PartialView("_Edit", model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ModalViewModel<SentezAllDataDto> model)
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
                var result = await client.PutAsync($"{_apiSettings.BaseUrl}/SentezAllData/update/{dto.RecId}", content);
                if (!result.IsSuccessStatusCode)
                {
                    var errorMessage = await content.ReadAsStringAsync();
                    return PartialView("_Edit", model);

                }
            }
            else
            {
                dto.InsertDate = DateTime.Now;
                var result = await client.PostAsync($"{_apiSettings.BaseUrl}/SentezAllData/add", content);
                if (!result.IsSuccessStatusCode)
                {
                    var errorMessage = await content.ReadAsStringAsync();
                    return PartialView("_Edit", model);

                }
            }

            return RedirectToAction("GetSentezAllData");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (!_currentUserService.HasPermission("KALITE.SentezAllData.Delete"))
            {
                return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
            }
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"{_apiSettings.BaseUrl}/SentezAllData/delete/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("GetSentezAllData");
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
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
