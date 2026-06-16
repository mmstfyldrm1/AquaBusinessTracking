using AquaBusinessTrackingWebUI.Extensions;
using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using DTOLayer.Dtos.ResponseComboBoxDtos;
using DTOLayer.Dtos.RoleDtos;
using DTOLayer.Dtos.RolePermission;
using DTOLayer.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Data;
using System.Text;

namespace AquaBusinessTrackingWebUI.Controllers
{

    public class SettingsController : Controller
    {
        private readonly AuthorizedHttpClientService _httpClientFactory;
        private readonly CurrentUserService _currentUserService;
        private readonly ModalService _modalService;
        private readonly ApiSettings _apiSettings;

        public SettingsController(AuthorizedHttpClientService httpClientFactory, ModalService modalService, IOptions<ApiSettings> apiSettings, CurrentUserService currentUserService)
        {
            _httpClientFactory = httpClientFactory;
            _modalService = modalService;
            _apiSettings = apiSettings.Value;
            _currentUserService = currentUserService;
        }

        [HttpGet]
        public async Task<IActionResult> UserList()
        {

            if (!_currentUserService.HasPermission("AYARLAR.Users.View"))
            {
                return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
            }
            var client = _httpClientFactory.CreateClient();

            // Kullanıcıları getir
            var response = await client.GetAsync($"{_apiSettings.BaseUrl}/User/getusers");

            if (!response.IsSuccessStatusCode)
                return View(new List<GetUserDto>());

            var json = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetUserDto>>(json);

            if (values == null || !values.Any())
                return View(new List<GetUserDto>());

            // Departman Id'lerini tek seferde çek
            var departmentIds = string.Join(",",
                values
                    .Select(x => x.DepartmentId)
                    .Distinct());

            var query = $@" SELECT    RecId AS Id,   DepartmentName AS Name  FROM Db_Department  WHERE RecId IN ({departmentIds})";
            var queryObj = new
            {
                query = query
            };
            var content = new StringContent(JsonConvert.SerializeObject(queryObj), Encoding.UTF8, "application/json");
            var responseDepartment = await client.PostAsync($"{_apiSettings.BaseUrl}/Query/execute", content);
            if (responseDepartment.IsSuccessStatusCode)
            {
                var jsonDepartment = await responseDepartment.Content.ReadAsStringAsync();
                var departments = JsonConvert.DeserializeObject<List<ResponseComboBoxDto>>(jsonDepartment);
                if (departments != null)
                {
                    var departmentDictionary = departments.ToDictionary(x => x.Id, x => x.Name);

                    foreach (var user in values)
                    {
                        if (departmentDictionary.TryGetValue(user.DepartmentId, out var departmentName))
                        {
                            user.DepartmentName = departmentName;
                        }
                    }
                }
            }

            ViewBag.AppUserName = User.Identity?.Name;

            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (!_currentUserService.HasPermission("AYARLAR.Users.Update"))
            {
                return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
            }
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_apiSettings.BaseUrl}/User/getuser/{id}");
            if (!response.IsSuccessStatusCode)
                return View(new List<UpdateUserDto>());
            var json = await response.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<UpdateUserDto>(json);
            if (value == null)
                return View(new List<UpdateUserDto>());

            var sb = new StringBuilder();
            sb.AppendLine($"select s.RecId [Id], s.DepartmentName [Name] from Db_Department s");
            var queyobj = new { query = sb.ToString() };
            var content1 = new StringContent(JsonConvert.SerializeObject(queyobj), Encoding.UTF8, "application/json");
            var response1 = await client.PostAsync($"{_apiSettings.BaseUrl}/Query/execute", content1);
            if (response1.IsSuccessStatusCode)
            {
                var jsonAll = await response1.Content.ReadAsStringAsync();
                var allDepartments = JsonConvert.DeserializeObject<List<ResponseComboBoxDto>>(jsonAll);
                ViewBag.Departments = new SelectList(allDepartments, "Id", "Name");
            }
            ViewBag.AppUserName = User.Identity?.Name;


            var responseRoles = await client.GetAsync($"{_apiSettings.BaseUrl}/Role");

            if (!responseRoles.IsSuccessStatusCode)
                return View(new List<GetRolesDto>());

            if (responseRoles.IsSuccessStatusCode)
            {
                var jsonRoles = await responseRoles.Content.ReadAsStringAsync();
                var valuesRoles = JsonConvert.DeserializeObject<List<GetRolesDto>>(jsonRoles);
                ViewBag.Roles = valuesRoles.Select(r => new SelectListItem
                {
                    Value = r.Name,
                    Text = r.Name
                }).ToList();
            }

            var responseUserRoles = await client.GetAsync($"{_apiSettings.BaseUrl}/Role/user-roles/{id}");
            if (responseUserRoles.IsSuccessStatusCode)
            {
                var jsonRoles = await responseUserRoles.Content.ReadAsStringAsync();
                value.RoleName = JsonConvert.DeserializeObject<List<string>>(jsonRoles) ?? new List<string>();
            }

            var model = _modalService.BuildEditModel(value);
            return PartialView("_Edit", model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit([FromForm] ModalViewModel<UpdateUserDto> model)
        {
            var client = _httpClientFactory.CreateClient();

            if (model.Entity.ProfileImage != null)
            {
                var file = model.Entity.ProfileImage;
                var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                var savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/ProfilPhotos", fileName);
                using (var stream = new FileStream(savePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                model.Entity.CoverImgUrl = "/img/ProfilPhotos/" + fileName;
            }

            model.Entity.UpdateDate = DateTime.Now;
            var content = new StringContent(JsonConvert.SerializeObject(model.Entity), Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"{_apiSettings.BaseUrl}/User/updateuser", content);

            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                return PartialView("_Edit", model);
            }


            // ✅ 1. Önce mevcut rolleri getir
            var rolesResponse = await client.GetAsync($"{_apiSettings.BaseUrl}/Role/user-roles/{model.Entity.Id}");
            if (rolesResponse.IsSuccessStatusCode)
            {
                var rolesJson = await rolesResponse.Content.ReadAsStringAsync();
                var currentRoles = JsonConvert.DeserializeObject<List<string>>(rolesJson);

                // ✅ 2. Eski rolleri sil
                if (currentRoles != null && currentRoles.Any())
                {
                    var removeDto = new AssignRoleDto
                    {
                        UserId = model.Entity.Id,
                        Name = currentRoles
                    };
                    var removeContent = new StringContent(JsonConvert.SerializeObject(removeDto), Encoding.UTF8, "application/json");
                    await client.PostAsync($"{_apiSettings.BaseUrl}/Role/remove", removeContent);
                }


                // ✅ 3. Yeni rolü ata
                var roleDto = new AssignRoleDto
                {
                    UserId = model.Entity.Id,
                    Name = model.Entity.RoleName
                };
                var roleContent = new StringContent(JsonConvert.SerializeObject(roleDto), Encoding.UTF8, "application/json");
                var result = await client.PostAsync($"{_apiSettings.BaseUrl}/Role/assign", roleContent);

                if (!result.IsSuccessStatusCode)
                {
                    var errorMessage = await result.Content.ReadAsStringAsync();
                    return PartialView("_Edit", model);
                }
            }

            return RedirectToAction("UserList");
            /*
            var client = _httpClientFactory.CreateClient();
            if (model.Entity.ProfileImage != null)
            {
                var file = model.Entity.ProfileImage;
                var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                var savePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/ProfilPhotos", fileName);
                using (var stream = new FileStream(savePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                model.Entity.CoverImgUrl = "/img/ProfilPhotos/" + fileName;

            }
            model.Entity.UpdateDate = DateTime.Now;
            var content = new StringContent(JsonConvert.SerializeObject(model.Entity), Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"{_apiSettings.BaseUrl}/User/updateuser", content);
            if (!response.IsSuccessStatusCode)
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
            }

            if (model.Entity.Name != null && model.Entity.Name.Any())
            {
                var roleDto = new AssignRoleDto
                {
                    UserId = model.Entity.Id,
                    Name = model.Entity.RoleName,
                };

                var roleContent = new StringContent(JsonConvert.SerializeObject(roleDto), Encoding.UTF8, "application/json");
                var result = await client.PostAsync($"{_apiSettings.BaseUrl}/Role/assign", roleContent);
                if (!result.IsSuccessStatusCode)
                {
                    var errorMessage = await result.Content.ReadAsStringAsync();
                }
            }

            if (response.IsSuccessStatusCode)
                return RedirectToAction("UserList");

            return PartialView("_Edit", model);
            */
        }

        [HttpGet]
        public async Task<IActionResult> RolesList()
        {
            if (!_currentUserService.HasPermission("AYARLAR.Roles.View"))
            {
                return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
            }
            var client = _httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{_apiSettings.BaseUrl}/Role");
            if (!response.IsSuccessStatusCode)
                return View(new List<GetRolesDto>());
            var json = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<GetRolesDto>>(json);
            if (values == null || !values.Any())
                return View(new List<GetRolesDto>());
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> AddRoles()
        {
            if (!_currentUserService.HasPermission("AYARLAR.Roles.Add"))
            {
                return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
            }
            var client = _httpClientFactory.CreateClient();
            var permResponse = await client.GetAsync($"{_apiSettings.BaseUrl}/Permission");
            if (permResponse.IsSuccessStatusCode)
            {
                var permJson = await permResponse.Content.ReadAsStringAsync();
                var permissions = JsonConvert.DeserializeObject<List<PermissionDto>>(permJson);
                ViewBag.Permissions = permissions;
            }


            var model = _modalService.BuildAddModel<CreateRoleDto>();
            return PartialView("_AddRoles", model);

        }

        [HttpPost]
        public async Task<IActionResult> AddRoles(ModalViewModel<CreateRoleDto> model)
        {
            var client = _httpClientFactory.CreateClient();

            var content = new StringContent(JsonConvert.SerializeObject(model.Entity), Encoding.UTF8, "application/json");
            var roleResponse = await client.PostAsync($"{_apiSettings.BaseUrl}/Role/create", content);
            var returnData = await roleResponse.Content.ReadAsStringAsync();
            var roleData = JsonConvert.DeserializeObject<CreateRoleResponseDto>(returnData);


            if (!roleResponse.IsSuccessStatusCode)
                return View();


            var permDto = new RolePermissionDto
            {
                RoleId = roleData.Id,
                Permissions = model.Entity.PermissionIds
                    .Select(x => new PermissionItemDto
                    {
                        PermissionId = x,
                        IsSelected = true
                    }).ToList()
            };
            var contentPerm = new StringContent(JsonConvert.SerializeObject(permDto), Encoding.UTF8, "application/json");
            var permResponse = await client.PostAsync($"{_apiSettings.BaseUrl}/RolePermission/Edit", contentPerm);

            if (!permResponse.IsSuccessStatusCode)
                return View();

            TempData.Success("Rol oluşturuldu");
            return RedirectToAction("RolesList");



        }

        [HttpGet]
        public async Task<IActionResult> EditRoles(int id)
        {
            if (!_currentUserService.HasPermission("AYARLAR.Roles.Update"))
            {
                return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
            }
            var client = _httpClientFactory.CreateClient();

            // 1. ROL ADI
            var roleInfoResponse = await client.GetAsync($"{_apiSettings.BaseUrl}/Role/getbyid/{id}");
            var roleInfoJson = await roleInfoResponse.Content.ReadAsStringAsync();
            var roleInfo = JsonConvert.DeserializeObject<UpdateRoleDto>(roleInfoJson);
            if (!roleInfoResponse.IsSuccessStatusCode)
            {
                TempData.Error("Rol bilgisi alınamadı");
                return RedirectToAction("RolesList");
            }

            // 2. TÜM PERMİSSİONLAR - ayrı endpoint'ten çek
            var permResponse = await client.GetAsync($"{_apiSettings.BaseUrl}/Permission");
            var permJson = await permResponse.Content.ReadAsStringAsync();
            var allPermissions = JsonConvert.DeserializeObject<List<PermissionDto>>(permJson);
            if (!permResponse.IsSuccessStatusCode)
            {
                TempData.Error("Rol yetkileri alınamadı");
                return RedirectToAction("RolesList");
            }
            ViewBag.Permissions = allPermissions;

            // 3. ROLE'ün SEÇİLİ PERMİSSİONLARI
            var roleResponse = await client.GetAsync($"{_apiSettings.BaseUrl}/Roles/{id}/permissions");
            var roleJson = await roleResponse.Content.ReadAsStringAsync();
            var rolePermDto = JsonConvert.DeserializeObject<RolePermissionDto>(roleJson);

            var dto = new UpdateRoleDto
            {
                Id = id,
                Name = roleInfo?.Name,
                RoleName = roleInfo?.RoleName,
                PermissionIds = rolePermDto.Permissions
                    .Where(p => p.IsSelected)
                    .Select(p => p.PermissionId)
                    .ToList()
            };

            var model = _modalService.BuildEditModel(dto);
            return PartialView("_EditRoles", model);
        }

        [HttpPost]
        public async Task<IActionResult> EditRoles(ModalViewModel<UpdateRoleDto> model)
        {
            var client = _httpClientFactory.CreateClient();

            // 1. ROLE UPDATE
            var roleContent = new StringContent(
                JsonConvert.SerializeObject(new
                {
                    RoleName = model.Entity.RoleName,
                    Name = model.Entity.Name
                }),
                Encoding.UTF8,
                "application/json"
            );

            var response = await client.PutAsync($"{_apiSettings.BaseUrl}/Role/{model.Entity.Id}", roleContent);
            if (!response.IsSuccessStatusCode)
            {
                TempData.Error("Rol güncellenemedi");
                return RedirectToAction("RolesList");
            }


            var permDto = new RolePermissionDto
            {
                RoleId = model.Entity.Id,
                Permissions = (model.Entity.PermissionIds ?? new List<int>())
                    .Select(p => new PermissionItemDto
                    {
                        PermissionId = p,
                        IsSelected = true
                    }).ToList()
            };

            var permContent = new StringContent(JsonConvert.SerializeObject(permDto), Encoding.UTF8, "application/json");
            var permResponse = await client.PostAsync($"{_apiSettings.BaseUrl}/RolePermission/Edit", permContent);
            if (!permResponse.IsSuccessStatusCode)
            {
                TempData.Error("Rol güncellendi ama yetkiler güncellenemedi");
                return RedirectToAction("RolesList");
            }
            TempData.Success("Rol başarıyla güncellendi");
            return RedirectToAction("RolesList");


        }

        [HttpPost]
        public async Task<IActionResult> DeleteRole(int id)
        {
            if (!_currentUserService.HasPermission("AYARLAR.Roles.Delete"))
            {
                return Json(new { success = false, message = "Bu İşlem için yetkiniz bulunmamaktadır" });
            }
            var client = _httpClientFactory.CreateClient();

            try
            {
                // 1. ROLE PERMISSIONS TEMİZLE
                var permDto = new RolePermissionDto
                {
                    RoleId = id,
                    Permissions = new List<PermissionItemDto>()
                };

                var permContent = new StringContent(JsonConvert.SerializeObject(permDto), Encoding.UTF8, "application/json");
                var permResponse = await client.PostAsync($"{_apiSettings.BaseUrl}/RolePermission/Edit", permContent);
                if (!permResponse.IsSuccessStatusCode)
                {
                    TempData.Error("Rol izinleri temizlenemedi. Silme işlemi iptal edildi.");
                    return RedirectToAction("RolesList");
                }
                var response = await client.DeleteAsync($"{_apiSettings.BaseUrl}/Role/{id}");
                if (!response.IsSuccessStatusCode)
                {
                    TempData.Error("Rol silinemedi.");
                    return RedirectToAction("RolesList");
                }

                TempData.Success("Rol başarıyla silindi.");
            }
            catch (Exception ex)
            {
                TempData.Error("Beklenmeyen hata: " + ex.Message);
            }

            return RedirectToAction("RolesList");
        }
    }



}





