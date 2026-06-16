using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.KazanChemicalsDtos.KazanChemicalsHeadDtos;
using DTOLayer.Dtos.KazanDtos.KazanHeadDtos;
using DTOLayer.Dtos.ResponseComboBoxDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace AquaBusinessTrackingWebUI.Controllers
{

    public class KazanChemicalsController : Controller
    {
        private readonly AuthorizedHttpClientService _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        private readonly CurrentUserService _currentUserService;

        public KazanChemicalsController(AuthorizedHttpClientService httpClientFactory, IOptions<ApiSettings> apiSettings, CurrentUserService currentUserService)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
            _currentUserService = currentUserService;
        }

        public async Task<IActionResult> GetKazanChemicalsList()
        {
            if (!_currentUserService.HasPermission("KAZAN.KazanChemicals.View"))
            {
                return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
            }
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_apiSettings.BaseUrl}/KazanChemicals/details");
            if (!response.IsSuccessStatusCode)
                return View(new List<KazanChemicalsHeadDto>());

            var json = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<KazanChemicalsHeadDto>>(json);
            if (values == null || !values.Any())
                return View(new List<KazanChemicalsHeadDto>());
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            await LoadShiftListAsync();
            ViewBag.AppUserName = User.Identity?.Name;
            if (id.HasValue)
            {
                var client = _httpClientFactory.CreateClient();
                var headingResponse = await client.GetAsync($"{_apiSettings.BaseUrl}/KazanChemicals/{id}");
                var headingJson = await headingResponse.Content.ReadAsStringAsync();
                var dto = JsonConvert.DeserializeObject<KazanChemicalsFormDto>(headingJson);
                var detailResponse = await client.GetAsync($"{_apiSettings.BaseUrl}/KazanChemicals/{id}/kazanDetail");
                if (detailResponse.IsSuccessStatusCode)
                {
                    var detailJson = await detailResponse.Content.ReadAsStringAsync();
                    var details = JsonConvert.DeserializeObject<List<KazanChemicalsDetaiFormDto>>(detailJson);
                    dto.Detail = details?.FirstOrDefault() ?? new KazanChemicalsDetaiFormDto();
                }
                var model = new ModalViewModel<KazanChemicalsFormDto>
                {
                    Entity = dto,
                    IsEdit = true,
                    ModalTitle = "Kazan Kimyasal Analizi Güncelle",
                    FormAction = "Edit"
                };
                return PartialView("_Edit", model);
            }
            else
            {
                var model = new ModalViewModel<KazanChemicalsFormDto>
                {
                    Entity = new KazanChemicalsFormDto
                    {
                        Detail = new KazanChemicalsDetaiFormDto()
                    },
                    IsEdit = false,
                    ModalTitle = "Kazan Kimyasal Analizi Ekle",
                    FormAction = "Edit"
                };
                return PartialView("_Edit", model);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ModalViewModel<KazanChemicalsFormDto> model)
        {
            var dto = model.Entity;
            dto.DepartmentId = int.Parse(User.FindFirst("DepartmentId")?.Value);
            dto.AppUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var client = _httpClientFactory.CreateClient();
            if (dto.RecId > 0)
            {
                if (!_currentUserService.HasPermission("KAZAN.KazanChemicals.Update"))
                {
                    return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
                }
                dto.UpdateDate = DateTime.Now;
                dto.UpdatedBy = dto.AppUserId;
                var headingContent = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
                var headingResult = await client.PutAsync($"{_apiSettings.BaseUrl}/KazanChemicals", headingContent);
                if (!headingResult.IsSuccessStatusCode)
                {
                    var error = await headingResult.Content.ReadAsStringAsync();
                    Console.WriteLine(error);
                    return PartialView("_Edit", model);
                }
                var detailContent = new StringContent(JsonConvert.SerializeObject(dto.Detail), Encoding.UTF8, "application/json");
                var detailResult = await client.PutAsync($"{_apiSettings.BaseUrl}/KazanChemicals/{dto.RecId}/kazanDetail", detailContent);
                if (!detailResult.IsSuccessStatusCode)
                {
                    var error = await detailResult.Content.ReadAsStringAsync();
                    Console.WriteLine(error);
                    return PartialView("_Edit", model);
                }
            }
            else
            {
                if (!_currentUserService.HasPermission("KAZAN.KazanChemicals.Add"))
                {
                    return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
                }
                dto.InsertDate = DateTime.Now;
                var headingContent = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
                var headingResponse = await client.PostAsync($"{_apiSettings.BaseUrl}/KazanChemicals", headingContent);
                if (!headingResponse.IsSuccessStatusCode)
                {
                    var error = await headingResponse.Content.ReadAsStringAsync();
                    return PartialView("_Edit", model);
                }
                var headingResponseJson = await headingResponse.Content.ReadAsStringAsync();
                var createdHeading = JsonConvert.DeserializeObject<KazanChemicalsFormDto>(headingResponseJson);

                if (createdHeading == null)
                    return PartialView("_Edit", model);
                var detailContent = new StringContent(JsonConvert.SerializeObject(dto.Detail), Encoding.UTF8, "application/json");
                var detailResponse = await client.PostAsync($"{_apiSettings.BaseUrl}/KazanChemicals/{createdHeading.RecId}/kazanDetail", detailContent);
                if (!detailResponse.IsSuccessStatusCode)
                {
                    var error = await detailResponse.Content.ReadAsStringAsync();
                    return PartialView("_Edit", model);
                }
            }
            return RedirectToAction("GetKazanChemicalsList");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (!_currentUserService.HasPermission("KAZAN.KazanChemicals.Delete"))
            {
                return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
            }
            var client = _httpClientFactory.CreateClient();
            var detailResponse = await client.GetAsync($"{_apiSettings.BaseUrl}/KazanChemicals/{id}/kazanDetail");
            if (detailResponse.IsSuccessStatusCode)
            {
                var detailJson = await detailResponse.Content.ReadAsStringAsync();
                var details = JsonConvert.DeserializeObject<List<KazanChemicalsDetaiFormDto>>(detailJson);
                if (details != null)
                {
                    foreach (var detail in details)
                    {

                        await client.DeleteAsync($"{_apiSettings.BaseUrl}/KazanChemicals/{id}/kazanDetail/{detail.RecId}");
                    }
                }
            }

            var response = await client.DeleteAsync($"{_apiSettings.BaseUrl}/KazanChemicals/{id}");
            if (response.IsSuccessStatusCode)
                return RedirectToAction("GetKazanChemicalsList");

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
