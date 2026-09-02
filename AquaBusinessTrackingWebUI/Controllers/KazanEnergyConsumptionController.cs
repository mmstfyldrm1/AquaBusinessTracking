using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.KazanEnergyConsumptionDtos;
using DTOLayer.Dtos.ShiftDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace AquaBusinessTrackingWebUI.Controllers
{
    public class KazanEnergyConsumptionController : Controller
    {
        private readonly AuthorizedHttpClientService _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        private readonly CurrentUserService _currentUserService;
        public KazanEnergyConsumptionController(AuthorizedHttpClientService httpClientFactory, IOptions<ApiSettings> apiSettings, CurrentUserService currentUserService)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
            _currentUserService = currentUserService;
        }

        public async Task<IActionResult> GetKazanEnergyConsumptionList()
        {
            if (!_currentUserService.HasPermission("KAZAN.KazanEnergyConsumption.View"))
            {
                return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
            }
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_apiSettings.BaseUrl}/KazanEnergyConsumption/details");
            if (!response.IsSuccessStatusCode)
                return View(new List<KazanEnergyConsumptionDto>());

            var json = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<KazanEnergyConsumptionDto>>(json);
            if (values == null || !values.Any())
                return View(new List<KazanEnergyConsumptionDto>());
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var client = _httpClientFactory.CreateClient();


            await LoadShiftListAsync();
            ViewBag.AppUserName = User.Identity?.Name;
            if (id.HasValue)
            {

                var headingResponse = await client.GetAsync($"{_apiSettings.BaseUrl}/KazanEnergyConsumption/getbyid/{id}");
                var headingJson = await headingResponse.Content.ReadAsStringAsync();
                var dto = JsonConvert.DeserializeObject<KazanEnergyConsumptionDto>(headingJson);

                var model = new ModalViewModel<KazanEnergyConsumptionDto>
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
                var model = new ModalViewModel<KazanEnergyConsumptionDto>
                {
                    IsEdit = false,
                    ModalTitle = "Kazan Kimyasal Analizi Ekle",
                    FormAction = "Edit"
                };
                return PartialView("_Edit", model);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Edit(ModalViewModel<KazanEnergyConsumptionDto> model)
        {
            var dto = model.Entity;
            dto.DepartmentId = int.Parse(User.FindFirst("DepartmentId")?.Value);
            dto.AppUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var client = _httpClientFactory.CreateClient();
            if (dto.RecId > 0)
            {
                if (!_currentUserService.HasPermission("KAZAN.KazanEnergyConsumption.Update"))
                {
                    return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
                }
                dto.UpdateDate = DateTime.Now;
                dto.UpdatedBy = dto.AppUserId;
                var headingContent = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
                var headingResult = await client.PutAsync($"{_apiSettings.BaseUrl}/KazanEnergyConsumption/update/{model.Entity.RecId}", headingContent);
                if (!headingResult.IsSuccessStatusCode)
                {
                    var error = await headingResult.Content.ReadAsStringAsync();
                    Console.WriteLine(error);
                    return PartialView("_Edit", model);
                }

            }
            else
            {
                if (!_currentUserService.HasPermission("KAZAN.KazanEnergyConsumption.Add"))
                {
                    return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
                }
                dto.InsertDate = DateTime.Now;
                var headingContent = new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
                var headingResponse = await client.PostAsync($"{_apiSettings.BaseUrl}/KazanEnergyConsumption/add", headingContent);
                if (!headingResponse.IsSuccessStatusCode)
                {
                    var error = await headingResponse.Content.ReadAsStringAsync();
                    return PartialView("_Edit", model);
                }

            }
            return RedirectToAction("GetKazanEnergyConsumptionList");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (!_currentUserService.HasPermission("KAZAN.KazanEnergyConsumption.Delete"))
            {
                return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
            }
            var client = _httpClientFactory.CreateClient();

            var response = await client.DeleteAsync($"{_apiSettings.BaseUrl}/KazanEnergyConsumption/delete/{id}");
            if (response.IsSuccessStatusCode)
                return RedirectToAction("GetKazanEnergyConsumptionList");

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
