using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.BasinDtos.BasinDto;
using DTOLayer.Dtos.ShiftDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace AquaBusinessTrackingWebUI.Controllers
{
    public class BasinController : Controller
    {
        private readonly AuthorizedHttpClientService _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        private readonly CurrentUserService _currentUserService;

        public BasinController(
            AuthorizedHttpClientService httpClientFactory,
            IOptions<ApiSettings> apiSettings,
            CurrentUserService currentUserService)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
            _currentUserService = currentUserService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasinList()
        {
            if (!_currentUserService.HasPermission("ARITMA.Basin.View"))
            {
                return Json(new { success = false, message = "Bu işlemi gerçekleştirmek için gerekli izniniz bulunmamaktadır." });
            }

            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_apiSettings.BaseUrl}/Basin/details");
            if (!response.IsSuccessStatusCode)
                return View(new List<BasinDto>());

            var json = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<BasinDto>>(json);
            if (values == null || !values.Any())
                return View(new List<BasinDto>());

            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            await LoadShiftListAsync();
            ViewBag.AppUserName = User.Identity?.Name;

            if (id.HasValue)
            {
                if (!_currentUserService.HasPermission("ARITMA.Basin.Update"))
                {
                    return Json(new { success = false, message = "Bu işlemi gerçekleştirmek için gerekli izniniz bulunmamaktadır." });
                }

                var client = _httpClientFactory.CreateClient();
                var basinResponse = await client.GetAsync($"{_apiSettings.BaseUrl}/Basin/{id}");
                var basinJson = await basinResponse.Content.ReadAsStringAsync();
                var dto = JsonConvert.DeserializeObject<BasinDto>(basinJson);

                var model = new ModalViewModel<BasinDto>
                {
                    Entity = dto,
                    IsEdit = true,
                    ModalTitle = "Havuz Güncelle",
                    FormAction = "Edit"
                };
                return PartialView("_Edit", model);
            }
            else
            {
                if (!_currentUserService.HasPermission("ARITMA.Basin.Add"))
                {
                    return Json(new { success = false, message = "Bu işlemi gerçekleştirmek için gerekli izniniz bulunmamaktadır." });
                }

                var model = new ModalViewModel<BasinDto>
                {
                    Entity = new BasinDto(),
                    IsEdit = false,
                    ModalTitle = "Havuz Ekle",
                    FormAction = "Edit"
                };
                return PartialView("_Edit", model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ModalViewModel<BasinDto> model)
        {
            var dto = model.Entity;
            dto.DepartmentId = int.Parse(User.FindFirst("DepartmentId")?.Value);
            dto.AppUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var client = _httpClientFactory.CreateClient();

            if (dto.RecId > 0)
            {
                dto.UpdateDate = DateTime.Now;
                var basinJson = JsonConvert.SerializeObject(dto);
                var basinContent = new StringContent(basinJson, Encoding.UTF8, "application/json");
                await client.PutAsync($"{_apiSettings.BaseUrl}/Basin", basinContent);
            }
            else
            {
                dto.InsertDate = DateTime.Now;
                var basinJson = JsonConvert.SerializeObject(dto);
                var basinContent = new StringContent(basinJson, Encoding.UTF8, "application/json");
                await client.PostAsync($"{_apiSettings.BaseUrl}/Basin", basinContent);
            }

            return RedirectToAction("GetBasinList");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBasin(int id)
        {
            if (!_currentUserService.HasPermission("ARITMA.Basin.Delete"))
            {
                return Json(new { success = false, message = "Bu işlemi gerçekleştirmek için gerekli izniniz bulunmamaktadır." });
            }

            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"{_apiSettings.BaseUrl}/Basin/{id}");

            if (response.IsSuccessStatusCode)
                return RedirectToAction("GetBasinList");

            return Json(new { success = false, message = "Silme işlemi başarısız oldu." });
        }

        private async Task LoadShiftListAsync()
        {
            var client = _httpClientFactory.CreateClient();
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