using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.ShiftDtos;
using DTOLayer.Dtos.WinderCoilLengthControlDto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace AquaBusinessTrackingWebUI.Controllers
{

    public class WinderCoilLengthController : Controller
    {
        private readonly AuthorizedHttpClientService _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        private readonly CurrentUserService _currentUserService;

        public WinderCoilLengthController(AuthorizedHttpClientService httpClientFactory, IOptions<ApiSettings> apiSettings, CurrentUserService currentUserService)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
            _currentUserService = currentUserService;
        }

        public async Task<IActionResult> GetWinderList()
        {
            if (!_currentUserService.HasPermission("BOBINKESME.WinderCoilLength.View"))
            {
                return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
            }
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_apiSettings.BaseUrl}/WinderCoilLengthControl/details");
            if (!response.IsSuccessStatusCode)
                return View(new List<WinderCoilLengthControlDto>());
            var json = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<WinderCoilLengthControlDto>>(json);
            if (values == null || !values.Any())
                return View(new List<WinderCoilLengthControlDto>());
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            await LoadShiftListAsync();
            ViewBag.AppUserName = User.Identity?.Name;

            if (id.HasValue)
            {
                if (!_currentUserService.HasPermission("BOBINKESME.WinderCoilLength.Update"))
                {
                    return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
                }
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync($"{_apiSettings.BaseUrl}/WinderCoilLengthControl/getbyid?id={id}");
                if (!response.IsSuccessStatusCode)
                    return RedirectToAction("GetMotorList");

                var json = await response.Content.ReadAsStringAsync();
                var dto = JsonConvert.DeserializeObject<WinderCoilLengthControlDto>(json);

                var model = new ModalViewModel<WinderCoilLengthControlDto>
                {
                    Entity = dto,
                    IsEdit = true,
                    ModalTitle = "Bobin Güncelle",
                    FormAction = "Edit"
                };
                return PartialView("_Edit", model);
            }
            else
            {
                if (!_currentUserService.HasPermission("BOBINKESME.WinderCoilLength.Add"))
                {
                    return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
                }
                var model = new ModalViewModel<WinderCoilLengthControlDto>
                {
                    Entity = new WinderCoilLengthControlDto(),
                    IsEdit = false,
                    ModalTitle = "Bobin Ekle",
                    FormAction = "Edit"
                };
                return PartialView("_Edit", model);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Edit(ModalViewModel<WinderCoilLengthControlDto> model)
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
                var result = await client.PutAsync($"{_apiSettings.BaseUrl}/WinderCoilLengthControl/update/{dto.RecId}", content);
                if (!result.IsSuccessStatusCode)
                {
                    var errorMessage = await result.Content.ReadAsStringAsync();
                    return PartialView("_Edit", result);
                }
            }
            else
            {
                dto.InsertDate = DateTime.Now;
                var result = await client.PostAsync($"{_apiSettings.BaseUrl}/WinderCoilLengthControl/add", content);
                if (!result.IsSuccessStatusCode)
                {
                    var errorMessage = await result.Content.ReadAsStringAsync();
                    return PartialView("_Edit", result);
                }
            }

            return RedirectToAction("GetWinderList");
        }


        [HttpPost]
        public async Task<IActionResult> DeleteCoil(int id)
        {
            if (!_currentUserService.HasPermission("BOBINKESME.WinderCoilLength.Delete"))
            {
                return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
            }
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"{_apiSettings.BaseUrl}/WinderCoilLengthControl/delete?id={id}");
            if (response.IsSuccessStatusCode)
                return Redirect("~/WinderCoilLength/GetWinderList");

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
