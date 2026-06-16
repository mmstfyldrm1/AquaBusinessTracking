using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.ResponseComboBoxDtos;
using DTOLayer.Dtos.RetentionAnalysis.RetentionAnalysisHeadDtos;
using DTOLayer.Dtos.StarchAnalysis.StarchAnalysisHeadingDetail;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace AquaBusinessTrackingWebUI.Controllers
{

    public class StarchAnalysisController : Controller
    {
        private readonly AuthorizedHttpClientService _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        private readonly CurrentUserService _currentUserService;

        public StarchAnalysisController(AuthorizedHttpClientService httpClientFactory, IOptions<ApiSettings> apiSettings, CurrentUserService currentUserService)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
            _currentUserService = currentUserService;
        }
        [HttpGet]
        public async Task<IActionResult> GetStarchAnalysisList()
        {
            if (!_currentUserService.HasPermission("KALITE.StarchAnalysis.View"))
            {
                return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
            }
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_apiSettings.BaseUrl}/StarchAnalysis");
            if (!response.IsSuccessStatusCode)
                return View(new List<RetentionAnalysisHeadDto>());

            var json = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<RetentionAnalysisHeadDto>>(json);
            if (values == null || !values.Any())
                return View(new List<RetentionAnalysisHeadDto>());


            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            await LoadShiftListAsync();
            ViewBag.AppUserName = User.Identity?.Name;
            if (id.HasValue)
            {
                if (!_currentUserService.HasPermission("KALITE.StarchAnalysis.Update"))
                {
                    return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
                }
                var client = _httpClientFactory.CreateClient();
                var headingResponse = await client.GetAsync($"{_apiSettings.BaseUrl}/StarchAnalysis/{id}");
                var headingJson = await headingResponse.Content.ReadAsStringAsync();
                var dto = JsonConvert.DeserializeObject<StarchAnalysisFormDto>(headingJson);
                var detailResponse = await client.GetAsync($"{_apiSettings.BaseUrl}/StarchAnalysis/{id}/starchAnalysisDetail");
                if (detailResponse.IsSuccessStatusCode)
                {
                    var detailJson = await detailResponse.Content.ReadAsStringAsync();
                    var details = JsonConvert.DeserializeObject<List<StarchAnalysisDetailFormDto>>(detailJson);
                    dto.StarchAnalysisDetailForm = details?.FirstOrDefault() ?? new StarchAnalysisDetailFormDto();
                }
                var model = new ModalViewModel<StarchAnalysisFormDto>
                {
                    Entity = dto,
                    IsEdit = true,
                    ModalTitle = "Nişasta Analizi Güncelle",
                    FormAction = "Edit"
                };
                return PartialView("_Edit", model);
            }
            else
            {
                if (!_currentUserService.HasPermission("KALITE.StarchAnalysis.Add"))
                {
                    return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
                }
                var model = new ModalViewModel<StarchAnalysisFormDto>
                {
                    Entity = new StarchAnalysisFormDto
                    {
                        StarchAnalysisDetailForm = new StarchAnalysisDetailFormDto()
                    },
                    IsEdit = false,
                    ModalTitle = "Nişasta Analizi Ekle",
                    FormAction = "Edit"
                };
                return PartialView("_Edit", model);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ModalViewModel<StarchAnalysisFormDto> model)
        {
            var dto = model.Entity;


            dto.DepartmentId = int.Parse(User.FindFirst("DepartmentId")?.Value);
            dto.AppUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var client = _httpClientFactory.CreateClient();
            if (dto.RecId > 0)
            {
                dto.UpdateDate = DateTime.Now;
                dto.UpdatedBy = dto.AppUserId;
                var headingContent = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
                var headingResult = await client.PutAsync($"{_apiSettings.BaseUrl}/StarchAnalysis", headingContent);
                if (!headingResult.IsSuccessStatusCode)
                {
                    var error = await headingResult.Content.ReadAsStringAsync();
                    Console.WriteLine(error);
                    return PartialView("_Edit", model);
                }
                var detailContent = new StringContent(JsonConvert.SerializeObject(dto.StarchAnalysisDetailForm), Encoding.UTF8, "application/json");
                var detailResult = await client.PutAsync($"{_apiSettings.BaseUrl}/StarchAnalysis/{dto.RecId}/starchAnalysisDetail", detailContent);
                if (!detailResult.IsSuccessStatusCode)
                {
                    var error = await detailResult.Content.ReadAsStringAsync();
                    Console.WriteLine(error);
                    return PartialView("_Edit", model);
                }
            }
            else
            {
                dto.InsertDate = DateTime.Now;
                var headingContent = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
                var headingResponse = await client.PostAsync($"{_apiSettings.BaseUrl}/StarchAnalysis", headingContent);
                if (!headingResponse.IsSuccessStatusCode)
                {
                    var error = await headingResponse.Content.ReadAsStringAsync();
                    return PartialView("_Edit", model);
                }
                var headingResponseJson = await headingResponse.Content.ReadAsStringAsync();
                var createdHeading = JsonConvert.DeserializeObject<StarchAnalysisFormDto>(headingResponseJson);

                if (createdHeading == null)
                    return PartialView("_Edit", model);
                var detailContent = new StringContent(JsonConvert.SerializeObject(dto.StarchAnalysisDetailForm), Encoding.UTF8, "application/json");
                var detailResponse = await client.PostAsync($"{_apiSettings.BaseUrl}/StarchAnalysis/{createdHeading.RecId}/starchAnalysisDetail", detailContent);
                if (!detailResponse.IsSuccessStatusCode)
                {
                    var error = await detailResponse.Content.ReadAsStringAsync();
                    return PartialView("_Edit", model);
                }
            }
            return RedirectToAction("GetStarchAnalysisList");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (!_currentUserService.HasPermission("KALITE.StarchAnalysis.Delete"))
            {
                return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
            }
            var client = _httpClientFactory.CreateClient();
            var detailResponse = await client.GetAsync($"{_apiSettings.BaseUrl}/StarchAnalysis/{id}/starchAnalysisDetail");
            if (detailResponse.IsSuccessStatusCode)
            {
                var detailJson = await detailResponse.Content.ReadAsStringAsync();
                var details = JsonConvert.DeserializeObject<List<StarchAnalysisDetailFormDto>>(detailJson);

                if (details != null)
                {
                    foreach (var detail in details)
                    {

                        await client.DeleteAsync($"{_apiSettings.BaseUrl}/StarchAnalysis/{id}/starchAnalysisDetail/{detail.RecId}");
                    }
                }
            }

            var response = await client.DeleteAsync($"{_apiSettings.BaseUrl}/StarchAnalysis/{id}");
            if (response.IsSuccessStatusCode)
                return RedirectToAction("GetStarchAnalysisList");

            return Json(new { success = false, message = "Silme işlemi başarısız oldu." });
        }
        private async Task LoadShiftListAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var sb = new StringBuilder();
            sb.AppendLine("Select RecId [Id], ShiftCode [Name] from Db_Shift");
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