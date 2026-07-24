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
        private readonly ILogger<RoleController> _logger;


        public RoleController(
            RoleManager<DB_AppRole> roleManager,
            UserManager<DB_AppUser> userManager,
            ILogger<RoleController> logger)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _logger = logger;
        }


        [HttpGet]
        public IActionResult GetRoles()
        {
            _logger.LogInformation("Roller listelendi.");

            var roles = _roleManager.Roles.ToList();

            _logger.LogInformation("{Count} adet rol getirildi.", roles.Count);

            return Ok(roles);
        }


        [HttpGet("getbyid/{id}")]
        public async Task<IActionResult> GetByIdRoles(int id)
        {
            _logger.LogInformation("Rol getiriliyor. Id={Id}", id);

            var role = await _roleManager.FindByIdAsync(id.ToString());

            if (role == null)
            {
                _logger.LogWarning("Rol bulunamadı. Id={Id}", id);
                return NotFound();
            }

            _logger.LogInformation("Rol bulundu. Id={Id}", id);

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
            _logger.LogInformation(
                "Yeni rol oluşturuluyor. Rol Adı={RoleName}",
                dto.Name);

            if (await _roleManager.RoleExistsAsync(dto.Name))
            {
                _logger.LogWarning(
                    "Rol zaten mevcut. Rol Adı={RoleName}",
                    dto.Name);

                return BadRequest("Bu rol zaten mevcut.");
            }


            var role = new DB_AppRole
            {
                Name = dto.Name,
                RoleName = dto.RoleName,
                Explanation = dto.Explanation ?? dto.Name.Substring(0, 3).ToUpper()
            };


            var result = await _roleManager.CreateAsync(role);


            if (!result.Succeeded)
            {
                _logger.LogError(
                    "Rol oluşturulamadı. Rol Adı={RoleName}",
                    dto.Name);

                return BadRequest(result.Errors);
            }


            _logger.LogInformation(
                "Rol başarıyla oluşturuldu. Id={Id}",
                role.Id);


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
            _logger.LogInformation("Rol güncelleniyor. Id={Id}", id);

            var role = await _roleManager.FindByIdAsync(id.ToString());

            if (role == null)
            {
                _logger.LogWarning("Güncellenecek rol bulunamadı. Id={Id}", id);
                return NotFound("Rol bulunamadı.");
            }


            role.RoleName = dto.RoleName;
            role.Name = dto.Name;
            role.Explanation = dto.Explanation ?? dto.Name.Substring(0, 3).ToUpper();
            role.NormalizedName = dto.Name.ToUpper();


            var result = await _roleManager.UpdateAsync(role);


            if (!result.Succeeded)
            {
                _logger.LogError("Rol güncellenemedi. Id={Id}", id);
                return BadRequest(result.Errors);
            }


            _logger.LogInformation("Rol güncellendi. Id={Id}", id);

            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            _logger.LogWarning("Rol silme işlemi başladı. Id={Id}", id);

            var role = await _roleManager.FindByIdAsync(id.ToString());

            if (role == null)
            {
                _logger.LogWarning("Silinecek rol bulunamadı. Id={Id}", id);
                return NotFound("Rol bulunamadı.");
            }


            var result = await _roleManager.DeleteAsync(role);


            if (!result.Succeeded)
            {
                _logger.LogError("Rol silinemedi. Id={Id}", id);
                return BadRequest(result.Errors);
            }


            _logger.LogWarning("Rol silindi. Id={Id}", id);

            return NoContent();
        }


        [HttpPost("assign")]
        public async Task<IActionResult> AssignRole([FromBody] AssignRoleDto dto)
        {
            _logger.LogInformation(
                "Kullanıcıya rol atanıyor. UserId={UserId}",
                dto.UserId);


            var user = await _userManager.FindByIdAsync(dto.UserId.ToString());


            if (user == null)
            {
                _logger.LogWarning(
                    "Kullanıcı bulunamadı. UserId={UserId}",
                    dto.UserId);

                return NotFound("Kullanıcı bulunamadı.");
            }


            foreach (var roleName in dto.Name)
            {
                if (!await _roleManager.RoleExistsAsync(roleName))
                {
                    _logger.LogWarning(
                        "Rol bulunamadı. Rol={RoleName}",
                        roleName);

                    return NotFound($"{roleName} rolü bulunamadı.");
                }


                var result = await _userManager.AddToRoleAsync(user, roleName);


                if (!result.Succeeded)
                {
                    _logger.LogError(
                        "Rol atanamadı. Rol={RoleName}",
                        roleName);

                    return BadRequest(result.Errors);
                }
            }


            _logger.LogInformation(
                "Roller başarıyla atandı. UserId={UserId}",
                dto.UserId);


            return Ok("Roller atandı.");
        }


        [HttpPost("remove")]
        public async Task<IActionResult> RemoveRole([FromBody] AssignRoleDto dto)
        {
            _logger.LogInformation(
                "Kullanıcıdan rol kaldırılıyor. UserId={UserId}",
                dto.UserId);


            var user = await _userManager.FindByIdAsync(dto.UserId.ToString());


            if (user == null)
            {
                _logger.LogWarning(
                    "Kullanıcı bulunamadı. UserId={UserId}",
                    dto.UserId);

                return NotFound("Kullanıcı bulunamadı.");
            }


            foreach (var roleName in dto.Name)
            {
                var result = await _userManager.RemoveFromRoleAsync(user, roleName);


                if (!result.Succeeded)
                {
                    _logger.LogError(
                        "Rol kaldırılamadı. Rol={RoleName}",
                        roleName);

                    return BadRequest(result.Errors);
                }
            }


            _logger.LogInformation(
                "Roller kaldırıldı. UserId={UserId}",
                dto.UserId);


            return Ok("Roller kaldırıldı.");
        }


        [HttpGet("user-roles/{userId}")]
        public async Task<IActionResult> GetUserRoles(int userId)
        {
            _logger.LogInformation(
                "Kullanıcı rolleri getiriliyor. UserId={UserId}",
                userId);


            var user = await _userManager.FindByIdAsync(userId.ToString());


            if (user == null)
            {
                _logger.LogWarning(
                    "Kullanıcı bulunamadı. UserId={UserId}",
                    userId);

                return NotFound("Kullanıcı bulunamadı.");
            }


            var roles = await _userManager.GetRolesAsync(user);


            _logger.LogInformation(
                "{Count} adet kullanıcı rolü getirildi. UserId={UserId}",
                roles.Count,
                userId);


            return Ok(roles);
        }
    }
}