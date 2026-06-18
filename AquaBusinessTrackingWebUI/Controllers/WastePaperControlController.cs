using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.ShiftDtos;
using DTOLayer.Dtos.WastePaperControlDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace AquaBusinessTrackingWebUI.Controllers
{

    public class WastePaperControlController : Controller
    {
        private readonly AuthorizedHttpClientService _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        private readonly CurrentUserService _currentUserService;

        public WastePaperControlController(AuthorizedHttpClientService httpClientFactory, IOptions<ApiSettings> apiSettings, CurrentUserService currentUserService)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
            _currentUserService = currentUserService;
        }

        [HttpGet]
        public async Task<IActionResult> GetWastePaperControlList()
        {
            if (!_currentUserService.HasPermission("KAGITSATINALMA.WastePaperControl.View"))
            {
                return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
            }
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_apiSettings.BaseUrl}/WastePaperControl/details");
            if (!response.IsSuccessStatusCode)
                return View(new List<WastePaperControlDto>());
            var json = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<WastePaperControlDto>>(json);
            if (values == null || !values.Any())
                return View(new List<WastePaperControlDto>());
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            await LoadShiftListAsync();
            ViewBag.AppUserName = User.Identity?.Name;

            if (id.HasValue)
            {
                if (!_currentUserService.HasPermission("KAGITSATINALMA.WastePaperControl.Update"))
                {
                    return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
                }
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync($"{_apiSettings.BaseUrl}/WastePaperControl/getbyid/{id}");
                if (!response.IsSuccessStatusCode)
                    return RedirectToAction("GetWastePaperControlList");

                var json = await response.Content.ReadAsStringAsync();
                var dto = JsonConvert.DeserializeObject<WastePaperControlDto>(json);

                var model = new ModalViewModel<WastePaperControlDto>
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
                if (!_currentUserService.HasPermission("KAGITSATINALMA.WastePaperControl.Add"))
                {
                    return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
                }
                var model = new ModalViewModel<WastePaperControlDto>
                {
                    Entity = new WastePaperControlDto(),
                    IsEdit = false,
                    ModalTitle = "Kağıt Kontrol Ekle",
                    FormAction = "Edit"
                };
                return PartialView("_Edit", model);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Edit(ModalViewModel<WastePaperControlDto> model)
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
                var result = await client.PutAsync($"{_apiSettings.BaseUrl}/WastePaperControl/update/{dto.RecId}", content);
                if (!result.IsSuccessStatusCode)
                {
                    var errorMessage = await result.Content.ReadAsStringAsync();
                    return PartialView("_Edit", result);
                }
            }
            else
            {
                dto.InsertDate = DateTime.Now;
                var result = await client.PostAsync($"{_apiSettings.BaseUrl}/WastePaperControl/add", content);
                if (!result.IsSuccessStatusCode)
                {
                    var errorMessage = await result.Content.ReadAsStringAsync();
                    return PartialView("_Edit", result);
                }
            }

            return RedirectToAction("GetWastePaperControlList");
        }


        [HttpPost]
        public async Task<IActionResult> DeletePaperControl(int id)
        {
            if (!_currentUserService.HasPermission("KAGITSATINALMA.WastePaperControl.Delete"))
            {
                return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
            }
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"{_apiSettings.BaseUrl}/WastePaperControl/delete/{id}");
            if (response.IsSuccessStatusCode)
                return Redirect("~/WastePaperControl/GetWastePaperControlList");

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
