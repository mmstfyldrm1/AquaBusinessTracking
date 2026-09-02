using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.ShiftDtos;
using DTOLayer.Dtos.ShipmentOrderPlan;
using DTOLayer.Dtos.ShipmentOrderPlanDtos.ShipmentOrderPlanDetailDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace AquaBusinessTrackingWebUI.Controllers
{

    public class ShipmentOrderPlanEditVm
    {
        public ShipmentOrderPlanDto Plan { get; set; } = new ShipmentOrderPlanDto();
        public List<ShipmentOrderPlanDetailDto> Details { get; set; } = new List<ShipmentOrderPlanDetailDto>();


        public List<int> DeletedDetailIds { get; set; } = new List<int>();
    }
    public class ShipmentOrderPlanListItemVm
    {
        public ShipmentOrderPlanDto Plan { get; set; } = new ShipmentOrderPlanDto();
        public List<ShipmentOrderPlanDetailDto> Details { get; set; } = new List<ShipmentOrderPlanDetailDto>();
    }

    public class ShipmentOrderPlanController : Controller
    {
        private readonly AuthorizedHttpClientService _httpClientFactory;
        private readonly ApiSettings _apiSettings;
        private readonly CurrentUserService _currentUserService;

        public ShipmentOrderPlanController(AuthorizedHttpClientService httpClientFactory, IOptions<ApiSettings> apiSettings, CurrentUserService currentUserService)
        {
            _httpClientFactory = httpClientFactory;
            _apiSettings = apiSettings.Value;
            _currentUserService = currentUserService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPlanList()
        {
            if (!_currentUserService.HasPermission("M2KANTAR.ShipmentOrderPlan.View"))
            {
                return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
            }

            var client = _httpClientFactory.CreateClient();


            var planResponse = await client.GetAsync($"{_apiSettings.BaseUrl}/ShipmentOrderPlan/details");
            var plans = new List<ShipmentOrderPlanDto>();
            if (planResponse.IsSuccessStatusCode)
            {
                var planJson = await planResponse.Content.ReadAsStringAsync();
                plans = JsonConvert.DeserializeObject<List<ShipmentOrderPlanDto>>(planJson) ?? new List<ShipmentOrderPlanDto>();
            }

            if (!plans.Any())
                return View(new List<ShipmentOrderPlanListItemVm>());


            var detailTasks = plans.Select(async plan =>
            {
                var detailResponse = await client.GetAsync($"{_apiSettings.BaseUrl}/ShipmentOrderPlanDetail/getbyplanid/{plan.RecId}");
                var details = new List<ShipmentOrderPlanDetailDto>();
                if (detailResponse.IsSuccessStatusCode)
                {
                    var detailJson = await detailResponse.Content.ReadAsStringAsync();
                    details = JsonConvert.DeserializeObject<List<ShipmentOrderPlanDetailDto>>(detailJson) ?? new List<ShipmentOrderPlanDetailDto>();
                }

                return new ShipmentOrderPlanListItemVm
                {
                    Plan = plan,
                    Details = details
                };
            });

            var result = (await Task.WhenAll(detailTasks)).ToList();

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var client = _httpClientFactory.CreateClient();
            var vm = new ShipmentOrderPlanEditVm();
            await LoadShiftListAsync();
            ViewBag.AppUserName = User.Identity?.Name;
            if (id.HasValue)
            {
                if (!_currentUserService.HasPermission("M2KANTAR.ShipmentOrderPlan.Update"))
                {
                    return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
                }


                var planResponse = await client.GetAsync($"{_apiSettings.BaseUrl}/ShipmentOrderPlan/getbyid/{id}");
                if (!planResponse.IsSuccessStatusCode)
                    return RedirectToAction("GetPlanList");

                var planJson = await planResponse.Content.ReadAsStringAsync();
                vm.Plan = JsonConvert.DeserializeObject<ShipmentOrderPlanDto>(planJson) ?? new ShipmentOrderPlanDto();


                var detailResponse = await client.GetAsync($"{_apiSettings.BaseUrl}/ShipmentOrderPlanDetail/getbyplanid/{id}");
                if (detailResponse.IsSuccessStatusCode)
                {
                    var detailJson = await detailResponse.Content.ReadAsStringAsync();
                    vm.Details = JsonConvert.DeserializeObject<List<ShipmentOrderPlanDetailDto>>(detailJson)
                                 ?? new List<ShipmentOrderPlanDetailDto>();
                }

                var model = new ModalViewModel<ShipmentOrderPlanEditVm>
                {
                    Entity = vm,
                    IsEdit = true,
                    ModalTitle = "Kayıt Güncelle",
                    FormAction = "Edit"
                };
                return PartialView("_Edit", model);
            }
            else
            {
                if (!_currentUserService.HasPermission("M2KANTAR.ShipmentOrderPlan.Add"))
                {
                    return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
                }

                var model = new ModalViewModel<ShipmentOrderPlanEditVm>
                {
                    Entity = vm,
                    IsEdit = false,
                    ModalTitle = "Kayıt Ekle",
                    FormAction = "Edit"
                };
                return PartialView("_Edit", model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ModalViewModel<ShipmentOrderPlanEditVm> model)
        {
            var vm = model.Entity;
            var client = _httpClientFactory.CreateClient();
            int planId;

            vm.Plan.DepartmentId = int.Parse(User.FindFirst("DepartmentId")?.Value);
            vm.Plan.AppUserId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);


            var planJson = JsonConvert.SerializeObject(vm.Plan);
            var planContent = new StringContent(planJson, Encoding.UTF8, "application/json");

            if (vm.Plan.RecId != null && vm.Plan.RecId > 0)
            {
                planId = vm.Plan.RecId;
                await client.PutAsync($"{_apiSettings.BaseUrl}/ShipmentOrderPlan/update/{planId}", planContent);
            }
            else
            {
                var planResponse = await client.PostAsync($"{_apiSettings.BaseUrl}/ShipmentOrderPlan/add", planContent);
                var planResultJson = await planResponse.Content.ReadAsStringAsync();
                var createdPlan = JsonConvert.DeserializeObject<ShipmentOrderPlanDto>(planResultJson);
                planId = createdPlan?.RecId ?? 0;

                if (planId == 0)
                {

                    return Json(new { success = false, message = "Plan oluşturuldu fakat RecId alınamadı. API'nin Add metodunu güncelleyin." });
                }
            }


            foreach (var deletedId in vm.DeletedDetailIds)
            {
                await client.DeleteAsync($"{_apiSettings.BaseUrl}/ShipmentOrderPlanDetail/delete/{deletedId}");
            }


            foreach (var detail in vm.Details)
            {
                detail.ShipmentPlanId = planId;

                var detailJson = JsonConvert.SerializeObject(detail);
                var detailContent = new StringContent(detailJson, Encoding.UTF8, "application/json");

                if (detail.RecId != null && detail.RecId > 0)
                {
                    await client.PutAsync($"{_apiSettings.BaseUrl}/ShipmentOrderPlanDetail/update", detailContent);
                }
                else
                {
                    await client.PostAsync($"{_apiSettings.BaseUrl}/ShipmentOrderPlanDetail/add", detailContent);
                }
            }

            return RedirectToAction("GetPlanList");
        }


        [HttpPost]
        public async Task<IActionResult> DeleteDetail(int id)
        {
            if (!_currentUserService.HasPermission("M2KANTAR.ShipmentOrderPlan.Update"))
            {
                return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
            }

            var client = _httpClientFactory.CreateClient();
            var response = await client.DeleteAsync($"{_apiSettings.BaseUrl}/ShipmentOrderPlanDetail/delete/{id}");
            return Json(new { success = response.IsSuccessStatusCode });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteShipmentOrderPlan(int id)
        {
            if (!_currentUserService.HasPermission("ShipmentOrderPlan.Delete"))
            {
                return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
            }

            var client = _httpClientFactory.CreateClient();


            var detailResponse = await client.GetAsync($"{_apiSettings.BaseUrl}/ShipmentOrderPlanDetail/getbyplanid/{id}");
            if (detailResponse.IsSuccessStatusCode)
            {
                var detailJson = await detailResponse.Content.ReadAsStringAsync();
                var relatedDetails = JsonConvert.DeserializeObject<List<ShipmentOrderPlanDetailDto>>(detailJson)
                                      ?? new List<ShipmentOrderPlanDetailDto>();
                foreach (var detail in relatedDetails)
                {
                    await client.DeleteAsync($"{_apiSettings.BaseUrl}/ShipmentOrderPlanDetail/delete/{detail.RecId}");
                }
            }

            var response = await client.DeleteAsync($"{_apiSettings.BaseUrl}/ShipmentOrderPlan/delete/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("GetPlanList");
            }
            else
            {
                return Json(new { success = false, message = "Silme işlemi başarısız oldu." });
            }
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
