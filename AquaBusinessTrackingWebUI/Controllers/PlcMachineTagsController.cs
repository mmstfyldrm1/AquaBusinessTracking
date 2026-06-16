using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.PlcDtos.PlcMachineDtos;
using DTOLayer.Dtos.PlcDtos.PlcTagsDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text;

namespace AquaBusinessTrackingWebUI.Controllers
{
    public class PlcMachineTagsController : Controller
    {
        private readonly AuthorizedHttpClientService _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        private readonly CurrentUserService _currentUserService;

        public PlcMachineTagsController(AuthorizedHttpClientService httpClientFactory, IOptions<ApiSettings> apiSettings, CurrentUserService currentUserService)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
            _currentUserService = currentUserService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMachineTagsList()
        {
            if (!_currentUserService.HasPermission("OTOMASYON.PlcTags.View"))
            {
                return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
            }
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync($"{_apiSettings.BaseUrl}/PlcTags/details");
            if (!response.IsSuccessStatusCode)
                return View(new List<PlcMachineTagsDto>());
            var json = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<PlcMachineTagsDto>>(json);
            if (values == null || !values.Any())
                return View(new List<PlcMachineTagsDto>());
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var client = _httpClientFactory.CreateClient();

            var responseMachineList = await client.GetAsync($"{_apiSettings.BaseUrl}/PlcMachine/getall");
            var jsonMachine = await responseMachineList.Content.ReadAsStringAsync();
            var dtomachine = JsonConvert.DeserializeObject<List<PlcMachineDto>>(jsonMachine);

            if (dtomachine == null || !responseMachineList.IsSuccessStatusCode)
            {
                var errorMessage = await responseMachineList.Content.ReadAsStringAsync();
                return RedirectToAction("GetMachineTagsList");
            }
            var machines = dtomachine?
                 .Select(x => new SelectListItem
                 {
                     Value = x.RecId.ToString(),
                     Text = x.Name
                 })
                 .ToList() ?? new();

            ViewBag.Machines = machines;
            if (id.HasValue)
            {
                if (!_currentUserService.HasPermission("OTOMASYON.PlcTags.Update"))
                {
                    return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
                }

                var response = await client.GetAsync($"{_apiSettings.BaseUrl}/PlcTags/getbyid/{id}");
                if (!response.IsSuccessStatusCode)
                    return RedirectToAction("GetMachineTagsList");

                var json = await response.Content.ReadAsStringAsync();
                var dto = JsonConvert.DeserializeObject<PlcMachineTagsDto>(json);

                var model = new ModalViewModel<PlcMachineTagsDto>
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
                if (!_currentUserService.HasPermission("OTO.Add"))
                {
                    return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
                }
                var model = new ModalViewModel<PlcMachineTagsDto>
                {
                    Entity = new PlcMachineTagsDto(),
                    IsEdit = false,
                    ModalTitle = "Kayıt Ekle",
                    FormAction = "Edit"
                };
                return PartialView("_Edit", model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ModalViewModel<PlcMachineTagsDto> model)
        {

            var dto = model.Entity;
            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            if (model.Entity.RecId != null && model.Entity.RecId > 0)
            {

                await client.PutAsync($"{_apiSettings.BaseUrl}/PlcTags/update/{dto.RecId}", content);
            }
            else
            {

                var result = await client.PostAsync($"{_apiSettings.BaseUrl}/PlcTags/add", content);
                if (!result.IsSuccessStatusCode)
                {
                    var errorMessage = result.Content.ReadAsStringAsync();
                    return PartialView("_Edit", model);
                }
            }

            return RedirectToAction("GetMachineTagsList");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (!_currentUserService.HasPermission("OTOMASYON.PlcTags.Delete"))
            {
                return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
            }
            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"{_apiSettings.BaseUrl}/PlcTags/delete/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("GetMachineTagsList");
            }
            else
            {
                return Json(new { success = false, message = "Silme işlemi başarısız oldu." });
            }


        }
    }
}
