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

        public RolePermissionController(IRolePermissionService service)
        {
            _service = service;
        }
        [HttpGet("{roleId}")]
        public async Task<IActionResult> Edit(int roleId)
        {
            var model = await _service.GetRolePermissions(roleId);
            return Ok(model);
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(RolePermissionDto model)
        {
            await _service.Save(model);
            return Ok();
        }


    }
}
