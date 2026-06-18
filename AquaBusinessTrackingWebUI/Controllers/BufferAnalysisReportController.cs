using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.BufferAnalysisReportDtos;
using DTOLayer.Dtos.ShiftDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace AquaBusinessTrackingWebUI.Controllers
{

    public class BufferAnalysisReportController : Controller
    {
        private readonly AuthorizedHttpClientService _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        private readonly CurrentUserService _currentUserService;

        public BufferAnalysisReportController(AuthorizedHttpClientService httpClientFactory, IOptions<ApiSettings> apiSettings, CurrentUserService currentUserService)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
            _currentUserService = currentUserService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBufferAnalysisReportList()
        {
            var client = _httpClientFactory.CreateClient();
            if (!_currentUserService.HasPermission("KALITE.BufferAnalysisReport.View"))
            {
                return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
            }
            var response = await client.GetAsync($"{_apiSettings.BaseUrl}/BufferAnalysisReport/details");
            if (!response.IsSuccessStatusCode)
                return View(new List<BufferAnalysisReportDto>());
            var json = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<BufferAnalysisReportDto>>(json);
            if (values == null || !values.Any())
                return View(new List<BufferAnalysisReportDto>());
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            await LoadShiftListAsync();
            ViewBag.AppUserName = User.Identity?.Name;

            if (id.HasValue)
            {
                if (!_currentUserService.HasPermission("KALITE.BufferAnalysisReport.Update"))
                {
                    return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
                }
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync($"{_apiSettings.BaseUrl}/BufferAnalysisReport/getbyid/{id}");
                if (!response.IsSuccessStatusCode)
                    return RedirectToAction("GetBufferAnalysisReportList");

                var json = await response.Content.ReadAsStringAsync();
                var dto = JsonConvert.DeserializeObject<BufferAnalysisReportDto>(json);

                var model = new ModalViewModel<BufferAnalysisReportDto>
                {
                    Entity = dto,
                    IsEdit = true,
                    ModalTitle = "Kağıt Kontrol Güncelle",
                    FormAction = "Edit"
                };
                return PartialView("_Edit", model);
            }
            else
            {
                if (!_currentUserService.HasPermission("KALITE.BufferAnalysisReport.Add"))
                {
                    return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
                }
                var model = new ModalViewModel<BufferAnalysisReportDto>
                {
                    Entity = new BufferAnalysisReportDto(),
                    IsEdit = false,
                    ModalTitle = "Kağıt Kontrol Ekle",
                    FormAction = "Edit"
                };
                return PartialView("_Edit", model);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Edit(ModalViewModel<BufferAnalysisReportDto> model)
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
                var result = await client.PutAsync($"{_apiSettings.BaseUrl}/BufferAnalysisReport/update/{dto.RecId}", content);
                if (!result.IsSuccessStatusCode)
                {
                    var errorMessage = await result.Content.ReadAsStringAsync();
                    return PartialView("_Edit", result);
                }
            }
            else
            {
                dto.InsertDate = DateTime.Now;
                var result = await client.PostAsync($"{_apiSettings.BaseUrl}/BufferAnalysisReport/add", content);
                if (!result.IsSuccessStatusCode)
                {
                    var errorMessage = await result.Content.ReadAsStringAsync();
                    return PartialView("_Edit", result);
                }
            }

            return RedirectToAction("GetBufferAnalysisReportList");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (!_currentUserService.HasPermission("KALITE.BufferAnalysisReport.Delete"))
            {
                return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
            }
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"{_apiSettings.BaseUrl}/BufferAnalysisReport/delete/{id}");
            if (response.IsSuccessStatusCode)
                return Redirect("~/BufferAnalysisReport/GetBufferAnalysisReportList");

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
