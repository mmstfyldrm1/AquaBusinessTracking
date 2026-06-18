using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.ElectricDtos.ElectricShiftDtos;
using DTOLayer.Dtos.ResponseComboBoxDtos;
using DTOLayer.Dtos.ShiftDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace AquaBusinessTrackingWebUI.Controllers
{

    public class ElectricShiftWorking : Controller
    {
        private readonly AuthorizedHttpClientService _httpClientService;
        private readonly ApiSettings _apiSettings;
        private readonly CurrentUserService _currentUserService;

        public ElectricShiftWorking(AuthorizedHttpClientService httpClientService, IOptions<ApiSettings> apiSettings, CurrentUserService currentUserService)
        {
            _httpClientService = httpClientService;
            _apiSettings = apiSettings.Value;
            _currentUserService = currentUserService;
        }

        [HttpGet]
        public async Task<IActionResult> GetElectricShiftWorking()
        {
            if (!_currentUserService.HasPermission("ELEKTRIK.ElectricShiftWorking.View"))
            {
                return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });

            }
            var client = _httpClientService.CreateClient();
            var response = await client.GetAsync($"{_apiSettings.BaseUrl}/ElectiricShiftWork/details");
            if (!response.IsSuccessStatusCode)
                return View(new List<ElectricShiftWorkDto>());
            var json = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ElectricShiftWorkDto>>(json);
            if (values == null || !values.Any())
                return View(new List<ElectricShiftWorkDto>());
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            await LoadShiftListAsync();
            var client = _httpClientService.CreateClient();
            var sb = new StringBuilder();
            sb.AppendLine("Select Id [Id] , UserName [Name] from AspNetUsers");
            var queryObjUser = new { query = sb.ToString() };
            var contentUser = new StringContent(JsonConvert.SerializeObject(queryObjUser), Encoding.UTF8, "application/json");
            var responseUser = await client.PostAsync($"{_apiSettings.BaseUrl}/Query/execute", contentUser);

            if (responseUser.IsSuccessStatusCode)
            {
                var jsonDataUser = await responseUser.Content.ReadAsStringAsync();
                var valuesUser = JsonConvert.DeserializeObject<List<ResponseComboBoxDto>>(jsonDataUser);
                if (valuesUser != null)
                {
                    ViewBag.AppUsers = valuesUser.Select(r => new SelectListItem
                    {
                        Value = r.Id.ToString(),
                        Text = r.Name.ToString()
                    }).ToList();
                }
            }

            if (id.HasValue)
            {
                if (!_currentUserService.HasPermission("ELK.ElectricShiftWorking.Update"))
                {
                    return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
                }
                var response = await client.GetAsync($"{_apiSettings.BaseUrl}/ElectiricShiftWork/{id}");
                if (!response.IsSuccessStatusCode)
                    return RedirectToAction("GetElectricShiftWorking");

                var json = await response.Content.ReadAsStringAsync();
                var dto = JsonConvert.DeserializeObject<ElectricShiftWorkDto>(json);

                var model = new ModalViewModel<ElectricShiftWorkDto>
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
                if (!_currentUserService.HasPermission("ELK.ElectricShiftWorking.Add"))
                {
                    return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
                }
                var model = new ModalViewModel<ElectricShiftWorkDto>
                {
                    Entity = new ElectricShiftWorkDto(),
                    IsEdit = false,
                    ModalTitle = "Kayıt Ekle",
                    FormAction = "Edit"
                };
                return PartialView("_Edit", model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ModalViewModel<ElectricShiftWorkDto> model)
        {
            var dto = model.Entity;
            dto.DepartmentId = int.Parse(User.FindFirst("DepartmentId")?.Value);
            //dto.AppUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var client = _httpClientService.CreateClient();
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            if (model.Entity.RecId != null && model.Entity.RecId > 0)
            {
                dto.UpdateDate = DateTime.Now;
                var result = await client.PutAsync($"{_apiSettings.BaseUrl}/ElectiricShiftWork/{dto.RecId}", content);
                if (!result.IsSuccessStatusCode)
                {
                    var errorMessage = await result.Content.ReadAsStringAsync();
                    return PartialView("_Edit", model);
                }
            }
            else
            {
                dto.InsertDate = DateTime.Now;
                var result = await client.PostAsync($"{_apiSettings.BaseUrl}/ElectiricShiftWork", content);
                if (!result.IsSuccessStatusCode)
                {
                    var errorMessage = await result.Content.ReadAsStringAsync();
                    return PartialView("_Edit", model);
                }
            }

            return RedirectToAction("GetElectricShiftWorking");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteShiftWork(int id)
        {
            if (!_currentUserService.HasPermission("ELK.ElectricShiftWorking.Delete"))
            {
                return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
            }
            var client = _httpClientService.CreateClient();
            var response = await client.DeleteAsync($"{_apiSettings.BaseUrl}/ElectiricShiftWork/{id}");
            if (response.IsSuccessStatusCode)
                return Redirect("~/ElectricShiftWorking/GetElectricShiftWorking");

            return Json(new { success = false, message = "Silme işlemi başarısız oldu." });
        }




        private async Task LoadShiftListAsync()
        {
            var client = _httpClientService.CreateClient();
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
