using BusinessLayer.Abstract;
using DTOLayer.Dtos.RolePermission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RolesController : ControllerBase
    {
        private readonly IRolePermissionService _service;

        public RolesController(IRolePermissionService service)
        {
            _service = service;
        }

        [HttpGet("{roleId}/permissions")]
        public async Task<IActionResult> GetPermissions(int roleId)
        {
            var result = await _service.GetRolePermissions(roleId);
            return Ok(result);
        }

        [HttpPut("{roleId}/permissions")]
        public async Task<IActionResult> Update(int roleId, [FromBody] RolePermissionDto dto)
        {
            dto.RoleId = roleId;
            await _service.Save(dto);
            return Ok();
        }
    }
}