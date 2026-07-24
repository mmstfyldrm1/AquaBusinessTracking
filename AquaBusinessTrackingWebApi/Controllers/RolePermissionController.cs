using BusinessLayer.Abstract;
using DTOLayer.Dtos.RolePermission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RolePermissionController : ControllerBase
    {
        private readonly IRolePermissionService _service;
        private readonly ILogger<RolePermissionController> _logger;


        public RolePermissionController(
            IRolePermissionService service,
            ILogger<RolePermissionController> logger)
        {
            _service = service;
            _logger = logger;
        }


        [HttpGet("{roleId}")]
        public async Task<IActionResult> Edit(int roleId)
        {
            _logger.LogInformation(
                "Rol yetkileri getiriliyor. RoleId={RoleId}, Kullanıcı={User}",
                roleId,
                User?.Identity?.Name);


            var model = await _service.GetRolePermissions(roleId);


            _logger.LogInformation(
                "Rol yetkileri başarıyla getirildi. RoleId={RoleId}",
                roleId);


            return Ok(model);
        }


        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(RolePermissionDto model)
        {
            _logger.LogInformation(
                "Rol yetkileri güncelleniyor. RoleId={RoleId}, Kullanıcı={User}",
                model.RoleId,
                User?.Identity?.Name);


            await _service.Save(model);


            _logger.LogInformation(
                "Rol yetkileri başarıyla güncellendi. RoleId={RoleId}",
                model.RoleId);


            return Ok();
        }
    }
}