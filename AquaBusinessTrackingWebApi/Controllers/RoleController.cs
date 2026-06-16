using DTOLayer.Dtos.RoleDtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AquaBusinessTrackingWebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoleController : ControllerBase
    {

        private readonly RoleManager<DB_AppRole> _roleManager;
        private readonly UserManager<DB_AppUser> _userManager;

        public RoleController(RoleManager<DB_AppRole> roleManager, UserManager<DB_AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult GetRoles()
        {
            var roles = _roleManager.Roles.ToList();
            return Ok(roles);
        }

        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetByIdRoles(int id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            if (role == null)
                return NotFound();

            return Ok(new
            {
                id = role.Id,
                name = role.Name,
                roleName = role.RoleName,
                explanation = role.Explanation

            });
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleRequestDto dto)
        {
            if (await _roleManager.RoleExistsAsync(dto.RoleName))
                return BadRequest("Bu rol zaten mevcut.");

            var role = new DB_AppRole
            {
                Name = dto.Name,
                RoleName = dto.RoleName,
                Explanation = dto.Explanation ?? dto.Name.Substring(0, 3).ToUpper()
            };

            var result = await _roleManager.CreateAsync(role);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(new
            {
                role.Id,
                role.Name,
                role.RoleName,
                role.Explanation
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(int id, [FromBody] UpdateRoleRequestDto dto)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            if (role == null)
                return NotFound("Rol bulunamadı.");

            role.RoleName = dto.RoleName;
            role.Name = dto.Name;
            role.Explanation = dto.Explanation ?? dto.Name.Substring(0, 3).ToUpper();
            role.NormalizedName = dto.Name.ToUpper();
            var result = await _roleManager.UpdateAsync(role);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            if (role == null)
                return NotFound("Rol bulunamadı.");

            var result = await _roleManager.DeleteAsync(role);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return NoContent();
        }


        [HttpPost("assign")]
        public async Task<IActionResult> AssignRole([FromBody] AssignRoleDto dto)
        {
            var user = await _userManager.FindByIdAsync(dto.UserId.ToString());
            if (user == null)
                return NotFound("Kullanıcı bulunamadı.");

            foreach (var roleName in dto.Name)
            {
                if (!await _roleManager.RoleExistsAsync(roleName))
                    return NotFound($"{roleName} rolü bulunamadı.");

                var result = await _userManager.AddToRoleAsync(user, roleName);
                if (!result.Succeeded)
                    return BadRequest(result.Errors);
            }

            return Ok("Roller atandı.");
        }

        // Kullanıcıdan rol kaldır
        [HttpPost("remove")]
        public async Task<IActionResult> RemoveRole([FromBody] AssignRoleDto dto)
        {
            var user = await _userManager.FindByIdAsync(dto.UserId.ToString());
            if (user == null)
                return NotFound("Kullanıcı bulunamadı.");

            foreach (var roleName in dto.Name)
            {
                var result = await _userManager.RemoveFromRoleAsync(user, roleName);
                if (!result.Succeeded)
                    return BadRequest(result.Errors);
            }

            return Ok("Roller kaldırıldı.");
        }

        // Kullanıcının rollerini getir
        [HttpGet("user-roles/{userId}")]
        public async Task<IActionResult> GetUserRoles(int userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
                return NotFound("Kullanıcı bulunamadı.");

            var roles = await _userManager.GetRolesAsync(user);
            return Ok(roles);
        }
    }
}