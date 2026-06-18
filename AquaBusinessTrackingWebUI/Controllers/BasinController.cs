using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.BasinDtos.BasinDto;
using DTOLayer.Dtos.ResponseComboBoxDtos;
using DTOLayer.Dtos.ShiftDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;
using static DTOLayer.Dtos.BasinDtos.BasinDto.BasinFormDto;

namespace AquaBusinessTrackingWebUI.Controllers
{


    public class BasinController : Controller
    {
        private readonly AuthorizedHttpClientService _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        private readonly CurrentUserService _currentUserService;

        public BasinController(AuthorizedHttpClientService httpClientFactory, IOptions<ApiSettings> apiSettings, CurrentUserService currentUserService)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
            _currentUserService = currentUserService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBasinList()
        {
            var client = _httpClientFactory.CreateClient();
            if (!_currentUserService.HasPermission("ARITMA.AATLabAnalysis.View"))
            {
                return Json(new { success = false, message = "Bu işlemi gerçekleştirmek için gerekli izniniz bulunmamaktadır." });
            }

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
                if (!_currentUserService.HasPermission("ARITMA.AATLabAnalysis.Update"))
                {
                    return Json(new { success = false, message = "Bu işlemi gerçekleştirmek için gerekli izniniz bulunmamaktadır." });
                }
                var client = _httpClientFactory.CreateClient();


                var basinResponse = await client.GetAsync($"{_apiSettings.BaseUrl}/Basin/{id}");
                var basinJson = await basinResponse.Content.ReadAsStringAsync();
                var dto = JsonConvert.DeserializeObject<BasinFormDto>(basinJson);


                var measurementResponse = await client.GetAsync($"{_apiSettings.BaseUrl}/Basin/{id}/measurements");
                if (measurementResponse.IsSuccessStatusCode)
                {
                    var measurementJson = await measurementResponse.Content.ReadAsStringAsync();
                    var measurements = JsonConvert.DeserializeObject<List<BasinMeasurementFormDto>>(measurementJson);
                    dto.Measurement = measurements?.FirstOrDefault() ?? new BasinMeasurementFormDto();
                }

                var model = new ModalViewModel<BasinFormDto>
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
                if (!_currentUserService.HasPermission("ARITMA.AATLabAnalysis.Add"))
                {
                    return Json(new { success = false, message = "Bu işlemi gerçekleştirmek için gerekli izniniz bulunmamaktadır." });
                }
                var model = new ModalViewModel<BasinFormDto>
                {
                    Entity = new BasinFormDto(),
                    IsEdit = false,
                    ModalTitle = "Havuz Ekle",
                    FormAction = "Edit"
                };

                return PartialView("_Edit", model);

            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ModalViewModel<BasinFormDto> model)
        {
            var dto = model.Entity;
            dto.DepartmentId = int.Parse(User.FindFirst("DepartmentId")?.Value);
            dto.AppUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var client = _httpClientFactory.CreateClient();

            if (model.Entity.RecId != null && model.Entity.RecId > 0)
            {

                dto.UpdateDate = DateTime.Now;
                var basinJson = JsonConvert.SerializeObject(dto);
                var basinContent = new StringContent(basinJson, Encoding.UTF8, "application/json");
                await client.PutAsync($"{_apiSettings.BaseUrl}/Basin", basinContent);


                var measurementJson = JsonConvert.SerializeObject(dto.Measurement);
                var measurementContent = new StringContent(measurementJson, Encoding.UTF8, "application/json");
                var result = await client.PutAsync($"{_apiSettings.BaseUrl}/Basin/{dto.RecId}/measurement", measurementContent);
                if (!result.IsSuccessStatusCode)
                {
                    var errormessage = result.Content.ReadAsStringAsync();
                }
            }
            else
            {

                dto.InsertDate = DateTime.Now;
                var basinJson = JsonConvert.SerializeObject(dto);
                var basinContent = new StringContent(basinJson, Encoding.UTF8, "application/json");
                var basinResponse = await client.PostAsync($"{_apiSettings.BaseUrl}/Basin", basinContent);

                if (basinResponse.IsSuccessStatusCode)
                {
                    var basinResponseJson = await basinResponse.Content.ReadAsStringAsync();
                    var createdBasin = JsonConvert.DeserializeObject<BasinDto>(basinResponseJson);

                    if (createdBasin != null)
                    {
                        var measurementJson = JsonConvert.SerializeObject(dto.Measurement);
                        var measurementContent = new StringContent(measurementJson, Encoding.UTF8, "application/json");
                        await client.PostAsync($"{_apiSettings.BaseUrl}/Basin/{createdBasin.RecId}/measurement", measurementContent);
                    }
                }


            }

            return RedirectToAction("GetBasinList");
        }


        [HttpPost]
        public async Task<IActionResult> DeleteBasin(int id)
        {

            var client = _httpClientFactory.CreateClient();

            if (_currentUserService.HasPermission("ARITMA.AATLabAnalysis.Delete"))
            {

                var measurementResponse = await client.GetAsync($"{_apiSettings.BaseUrl}/Basin/{id}/measurements");
                if (measurementResponse.IsSuccessStatusCode)
                {
                    var measurementJson = await measurementResponse.Content.ReadAsStringAsync();
                    var measurements = JsonConvert.DeserializeObject<List<BasinMeasurementFormDto>>(measurementJson);

                    if (measurements != null)
                    {
                        foreach (var measurement in measurements)
                        {
                            await client.DeleteAsync($"{_apiSettings.BaseUrl}/Basin/{id}/measurement/{measurement.Id}");
                        }
                    }
                }
                var response = await client.DeleteAsync($"{_apiSettings.BaseUrl}/Basin/{id}");
                if (response.IsSuccessStatusCode)
                    return RedirectToAction("GetBasinList");

            }
            else
            {
                return Json(new { success = false, message = "Bu işlemi gerçekleştirmek için gerekli izniniz bulunmamaktadır." });
            }

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

        [HttpGet]
        public async Task<IActionResult> GetBasinDetailPage()
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetAsync($"{_apiSettings.BaseUrl}/Basin");
            if (!response.IsSuccessStatusCode)
                return View(new List<BasinDto>());
            var json = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<BasinDto>>(json);
            if (values == null || !values.Any())
                return View(new List<BasinDto>());
            var sb = new StringBuilder();
            sb.AppendLine($"select s.RecId [Id], s.ShiftName [Name] from Db_Basin b left join Db_Shift s with(nolock) on s.RecId= b.ShiftId where b.RecId={values[0].RecId}");
            var queyobj = new { query = sb.ToString() };
            var content1 = new StringContent(JsonConvert.SerializeObject(queyobj), Encoding.UTF8, "application/json");
            var response1 = await client.PostAsync($"{_apiSettings.BaseUrl}/Query/execute", content1);
            if (response1.IsSuccessStatusCode)
            {
                var jsonData1 = await response1.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<List<ResponseComboBoxDto>>(jsonData1);

                ViewBag.ShiftName = values2?.FirstOrDefault()?.Name;
            }
            ViewBag.AppUserName = User.Identity?.Name;


            return View(values);
        }


    }
}
