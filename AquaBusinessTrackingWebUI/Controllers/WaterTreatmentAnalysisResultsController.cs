using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.ResponseComboBoxDtos;
using DTOLayer.Dtos.WaterTreatmentAnalysisResultsDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace AquaBusinessTrackingWebUI.Controllers
{

    public class WaterTreatmentAnalysisResultsController : Controller
    {
        private readonly AuthorizedHttpClientService _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        private readonly CurrentUserService _currentUserService;

        public WaterTreatmentAnalysisResultsController(AuthorizedHttpClientService httpClientFactory, IOptions<ApiSettings> apiSettings, CurrentUserService currentUserService)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
            _currentUserService = currentUserService;
        }

        [HttpGet]
        public async Task<IActionResult> GetWaterAnalysisResults()
        {
            if (!_currentUserService.HasPermission("KALITE.WaterTreatmentAnalysis.View"))
            {
                return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
            }
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_apiSettings.BaseUrl}/WaterTreatmentAnalysisResults/details");
            if (!response.IsSuccessStatusCode)
                return View(new List<WaterTreatmentAnalysisResultsDto>());
            var json = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<WaterTreatmentAnalysisResultsDto>>(json);
            if (values == null || !values.Any())
                return View(new List<WaterTreatmentAnalysisResultsDto>());
            return View(values);

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            await LoadShiftListAsync();
            ViewBag.AppUserName = User.Identity?.Name;

            if (id.HasValue)
            {
                if (!_currentUserService.HasPermission("KALITE.WaterTreatmentAnalysis.Update"))
                {
                    return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
                }
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync($"{_apiSettings.BaseUrl}/WaterTreatmentAnalysisResults/getbyid/{id}");
                if (!response.IsSuccessStatusCode)
                    return RedirectToAction("GetWaterAnalysisResults");

                var json = await response.Content.ReadAsStringAsync();
                var dto = JsonConvert.DeserializeObject<WaterTreatmentAnalysisResultsDto>(json);

                var model = new ModalViewModel<WaterTreatmentAnalysisResultsDto>
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
                if (!_currentUserService.HasPermission("KALITE.WaterTreatmentAnalysis.Add"))
                {
                    return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
                }
                var model = new ModalViewModel<WaterTreatmentAnalysisResultsDto>
                {
                    Entity = new WaterTreatmentAnalysisResultsDto(),
                    IsEdit = false,
                    ModalTitle = "Kayıt Ekle",
                    FormAction = "Edit"
                };
                return PartialView("_Edit", model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ModalViewModel<WaterTreatmentAnalysisResultsDto> model)
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
                await client.PutAsync($"{_apiSettings.BaseUrl}/WaterTreatmentAnalysisResults/update/{dto.RecId}", content);
            }
            else
            {
                dto.InsertDate = DateTime.Now;
                await client.PostAsync($"{_apiSettings.BaseUrl}/WaterTreatmentAnalysisResults/add", content);
            }

            return RedirectToAction("GetWaterAnalysisResults");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (!_currentUserService.HasPermission("KALITE.WaterTreatmentAnalysis.Delete"))
            {
                return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
            }

            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"{_apiSettings.BaseUrl}/WaterTreatmentAnalysisResults/delete/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("GetWaterAnalysisResults");
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
            sb.AppendLine("Select RecId [Id] , ShiftCode [Name] from Db_Shift");
            var queryObj = new { query = sb.ToString() };
            var content = new StringContent(JsonConvert.SerializeObject(queryObj), Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{_apiSettings.BaseUrl}/Query/execute", content);

            if (response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResponseComboBoxDto>>(jsonData);
                if (values != null)
                {
                    ViewBag.Shifts = values.Select(r => new SelectListItem
                    {
                        Value = r.Id.ToString(),
                        Text = r.Name.ToString()
                    }).ToList();
                }
            }
        }
    }
}
