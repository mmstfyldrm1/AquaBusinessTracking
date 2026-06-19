using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.BasinDtos.BasinDto;
using DTOLayer.Dtos.ResponseComboBoxDtos;
using DTOLayer.Dtos.ShiftDtos;
using DTOLayer.Dtos.TestDtos.TestHeadDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace AquaBusinessTrackingWebUI.Controllers
{

    public class TestController : Controller
    {
        private readonly AuthorizedHttpClientService _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        private readonly CurrentUserService _currentUserService;

        public TestController(AuthorizedHttpClientService httpClientFactory, IOptions<ApiSettings> apiSettings, CurrentUserService currentUserService)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
            _currentUserService = currentUserService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTestList()
        {
            if (!_currentUserService.HasPermission("ARITMA.IndustrialTest.View"))
            {
                return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
            }
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_apiSettings.BaseUrl}/Test/details");
            if (!response.IsSuccessStatusCode)
                return View(new List<TestHeadDto>());
            var json = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<TestHeadDto>>(json);
            if (values == null || !values.Any())
                return View(new List<TestHeadDto>());
            var sb = new StringBuilder();
            return View(values);
        }


        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            await LoadShiftListAsync();
            ViewBag.AppUserName = User.Identity?.Name;

            if (id.HasValue)
            {
                if (!_currentUserService.HasPermission("ARITMA.IndustrialTest.Update"))
                {
                    return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
                }
                var client = _httpClientFactory.CreateClient();
                var testResponse = await client.GetAsync($"{_apiSettings.BaseUrl}/Test/{id}");
                var testJson = await testResponse.Content.ReadAsStringAsync();
                var dto = JsonConvert.DeserializeObject<TestFormDto>(testJson);


                var detailResponse = await client.GetAsync($"{_apiSettings.BaseUrl}/Test/{id}/testDetail");
                if (detailResponse.IsSuccessStatusCode)
                {
                    var ResponseJson = await detailResponse.Content.ReadAsStringAsync();
                    var detail = JsonConvert.DeserializeObject<List<TestDetailFormDto>>(ResponseJson);
                    dto.Detail = detail?.FirstOrDefault() ?? new TestDetailFormDto();
                }

                var model = new ModalViewModel<TestFormDto>
                {
                    Entity = dto,
                    IsEdit = true,
                    ModalTitle = "Test Güncelle",
                    FormAction = "Edit"
                };
                return PartialView("_Edit", model);
            }
            else
            {
                if (!_currentUserService.HasPermission("ARITMA.IndustrialTest.Add"))
                {
                    return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
                }
                var model = new ModalViewModel<TestFormDto>
                {
                    Entity = new TestFormDto(),
                    IsEdit = false,
                    ModalTitle = "Test Ekle",
                    FormAction = "Edit"
                };
                return PartialView("_Edit", model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ModalViewModel<TestFormDto> model)
        {
            var dto = model.Entity;
            dto.DepartmentId = int.Parse(User.FindFirst("DepartmentId")?.Value);
            dto.AppUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var client = _httpClientFactory.CreateClient();

            if (model.Entity.RecId != null && model.Entity.RecId > 0)
            {

                dto.UpdateDate = DateTime.Now;
                var testJson = JsonConvert.SerializeObject(dto);
                var testContent = new StringContent(testJson, Encoding.UTF8, "application/json");
                await client.PutAsync($"{_apiSettings.BaseUrl}/Test", testContent);


                var detailJson = JsonConvert.SerializeObject(dto.Detail);
                var detailContent = new StringContent(detailJson, Encoding.UTF8, "application/json");
                var result = await client.PutAsync($"{_apiSettings.BaseUrl}/Test/{dto.RecId}/testDetail", detailContent);
                if (!result.IsSuccessStatusCode)
                {
                    var errormessage = result.Content.ReadAsStringAsync();
                }
            }
            else
            {

                dto.InsertDate = DateTime.Now;
                var testJson = JsonConvert.SerializeObject(dto);
                var testContent = new StringContent(testJson, Encoding.UTF8, "application/json");
                var testResponse = await client.PostAsync($"{_apiSettings.BaseUrl}/Test", testContent);

                if (testResponse.IsSuccessStatusCode)
                {
                    var testResponseJson = await testResponse.Content.ReadAsStringAsync();
                    var createdTest = JsonConvert.DeserializeObject<TestFormDto>(testResponseJson);

                    if (createdTest != null)
                    {
                        var detailJson = JsonConvert.SerializeObject(dto.Detail);
                        var detailContent = new StringContent(detailJson, Encoding.UTF8, "application/json");
                        await client.PostAsync($"{_apiSettings.BaseUrl}/Test/{createdTest.RecId}/testDetail", detailContent);
                    }
                }


            }

            return RedirectToAction("GetTestList");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (!_currentUserService.HasPermission("ARITMA.IndustrialTest.Delete"))
            {
                return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
            }

            var client = _httpClientFactory.CreateClient();
            var detailResponse = await client.GetAsync($"{_apiSettings.BaseUrl}/Test/{id}/testDetail");
            if (detailResponse.IsSuccessStatusCode)
            {
                var detailJson = await detailResponse.Content.ReadAsStringAsync();
                var details = JsonConvert.DeserializeObject<List<TestDetailFormDto>>(detailJson);

                if (details != null)
                {
                    foreach (var detail in details)
                    {
                        await client.DeleteAsync($"{_apiSettings.BaseUrl}/Test/{id}/testDetail/{detail.RecId}");
                    }
                }
            }
            var response = await client.DeleteAsync($"{_apiSettings.BaseUrl}/Test/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("GetTestList");
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
