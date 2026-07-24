using BusinessLayer.Abstract;
using DTOLayer.Dtos.RolePermission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RolesController : ControllerBase
    {
        private readonly IRolePermissionService _service;
        private readonly ILogger<RolesController> _logger;


        public RolesController(
            IRolePermissionService service,
            ILogger<RolesController> logger)
        {
            _service = service;
            _logger = logger;
        }


        [HttpGet("{roleId}/permissions")]
        public async Task<IActionResult> GetPermissions(int roleId)
        {
            _logger.LogInformation(
                "Rol yetkileri getiriliyor. RoleId={RoleId}, Kullanıcı={User}",
                roleId,
                User?.Identity?.Name);


            var result = await _service.GetRolePermissions(roleId);


            _logger.LogInformation(
                "Rol yetkileri başarıyla getirildi. RoleId={RoleId}",
                roleId);


            return Ok(result);
        }


        [HttpPut("{roleId}/permissions")]
        public async Task<IActionResult> Update(
            int roleId,
            [FromBody] RolePermissionDto dto)
        {
            _logger.LogInformation(
                "Rol yetkileri güncelleniyor. RoleId={RoleId}, Kullanıcı={User}",
                roleId,
                User?.Identity?.Name);


            dto.RoleId = roleId;

            await _service.Save(dto);


            _logger.LogInformation(
                "Rol yetkileri başarıyla güncellendi. RoleId={RoleId}",
                roleId);


            return Ok();
        }
    }
}