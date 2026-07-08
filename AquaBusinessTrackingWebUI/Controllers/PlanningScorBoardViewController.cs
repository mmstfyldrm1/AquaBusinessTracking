using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.PlanningScorBoardViewDtos;
using DTOLayer.Dtos.ShiftDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace AquaBusinessTrackingWebUI.Controllers
{
    public class PlanningScorBoardViewController : Controller
    {
        private readonly AuthorizedHttpClientService _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        private readonly CurrentUserService _currentUserService;
        private readonly IWebHostEnvironment _env;

        public PlanningScorBoardViewController(AuthorizedHttpClientService httpClientFactory, IOptions<ApiSettings> apiSettings, CurrentUserService currentUserService, IWebHostEnvironment env)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
            _currentUserService = currentUserService;
            _env = env;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlanList()
        {
            var client = _httpClientFactory.CreateClient();
            if (!_currentUserService.HasPermission("PLANLAMA.PlanningScorBoardView.View"))
            {
                return Json(new { success = false, message = "Bu işlemi gerçekleştirmek için gerekli izniniz bulunmamaktadır." });
            }

            var response = await client.GetAsync($"{_apiSettings.BaseUrl}/PlanningScorBoardView/details");
            if (!response.IsSuccessStatusCode)
                return View(new List<PlanningScorBoardViewDto>());
            var json = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<PlanningScorBoardViewDto>>(json);
            if (values == null || !values.Any())
                return View(new List<PlanningScorBoardViewDto>());
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            await LoadShiftListAsync();
            ViewBag.AppUserName = User.Identity?.Name;



            if (id.HasValue)
            {
                if (!_currentUserService.HasPermission("PLANLAMA.PlanningScorBoardView.Update"))
                {
                    return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
                }
                var client = _httpClientFactory.CreateClient();
                var response = await client.GetAsync($"{_apiSettings.BaseUrl}/PlanningScorBoardView/getbyid/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    var errorMessage = response.Content.ReadAsStringAsync();
                    return RedirectToAction("GetPlanList");
                }


                var json = await response.Content.ReadAsStringAsync();
                var dto = JsonConvert.DeserializeObject<PlanningScorBoardViewDto>(json);

                var model = new ModalViewModel<PlanningScorBoardViewDto>
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
                if (!_currentUserService.HasPermission("PLANLAMA.PlanningScorBoardView.Add"))
                {
                    return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
                }
                var model = new ModalViewModel<PlanningScorBoardViewDto>
                {
                    Entity = new PlanningScorBoardViewDto(),
                    IsEdit = false,
                    ModalTitle = "Kayıt Ekle",
                    FormAction = "Edit"
                };
                return PartialView("_Edit", model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ModalViewModel<PlanningScorBoardViewDto> model)
        {

            if (model.Entity.UploadPdfs != null)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(model.Entity.UploadPdfs.FileName);

                var path = Path.Combine(_env.WebRootPath, "Uploads", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await model.Entity.UploadPdfs.CopyToAsync(stream);
                }

                model.Entity.UploadPdf = fileName;
            }

            var dto = model.Entity;
            dto.DepartmentId = int.Parse(User.FindFirst("DepartmentId")?.Value);
            dto.AppUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var client = _httpClientFactory.CreateClient();
            var json = JsonConvert.SerializeObject(dto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            if (model.Entity.RecId != null && model.Entity.RecId > 0)
            {
                dto.UpdateDate = DateTime.Now;
                var result = await client.PutAsync($"{_apiSettings.BaseUrl}/PlanningScorBoardView/update/{dto.RecId}", content);
                if (!result.IsSuccessStatusCode)
                {
                    var errorMessage = result.Content.ReadAsStringAsync();
                    return PartialView("_Edit", model);
                }
            }
            else
            {
                dto.InsertDate = DateTime.Now;
                var result = await client.PostAsync($"{_apiSettings.BaseUrl}/PlanningScorBoardView/add", content);
                if (!result.IsSuccessStatusCode)
                {
                    var errorMessage = await result.Content.ReadAsStringAsync();
                    return PartialView("_Edit", model);
                }
            }

            return RedirectToAction("GetPlanList");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (!_currentUserService.HasPermission("PLANLAMA.PlanningScorBoardView.Delete"))
            {
                return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
            }

            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"{_apiSettings.BaseUrl}/PlanningScorBoardView/delete/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("GetPlanList");
            }
            else
            {
                return Json(new { success = false, message = "Silme işlemi başarısız oldu." });
            }


        }

        public async Task<IActionResult> ViewPlan(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_apiSettings.BaseUrl}/PlanningScorBoardView/getbyid/{id}");
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = response.Content.ReadAsStringAsync();
                return RedirectToAction("GetPlanList");
            }


            var json = await response.Content.ReadAsStringAsync();
            var dto = JsonConvert.DeserializeObject<PlanningScorBoardViewDto>(json);


            return View(dto);
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
