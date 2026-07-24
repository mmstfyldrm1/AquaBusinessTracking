using DTOLayer.Dtos.UserDtos;
using DTOLayer.Dtos.UserDtos.UserProfileDtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly UserManager<DB_AppUser> _userManager;
        private readonly ILogger<UserController> _logger;


        public UserController(
            UserManager<DB_AppUser> userManager,
            ILogger<UserController> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }


        [HttpGet("getusers")]
        public async Task<IActionResult> GetUsers()
        {
            _logger.LogInformation(
                "Kullanıcı listesi isteniyor. Kullanıcı={User}",
                User?.Identity?.Name);


            var users = await _userManager.Users.ToListAsync();


            _logger.LogInformation(
                "{Count} adet kullanıcı getirildi.",
                users.Count);


            return Ok(users);
        }


        [HttpGet("getuser/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            _logger.LogInformation(
                "Kullanıcı bilgisi getiriliyor. Id={Id}",
                id);


            var user = await _userManager.FindByIdAsync(id.ToString());


            if (user == null)
            {
                _logger.LogWarning(
                    "Kullanıcı bulunamadı. Id={Id}",
                    id);

                return NotFound();
            }


            _logger.LogInformation(
                "Kullanıcı bulundu. Id={Id}",
                id);


            return Ok(user);
        }


        [HttpPut("changeUserPassword/{id}")]
        public async Task<IActionResult> ChangeUserPassword(
            PasswordDto dto,
            int id)
        {
            _logger.LogInformation(
                "Kullanıcı şifre değiştirme işlemi başlatıldı. Id={Id}",
                id);


            var user = await _userManager.FindByIdAsync(id.ToString());


            if (user == null)
            {
                _logger.LogWarning(
                    "Şifre değiştirilecek kullanıcı bulunamadı. Id={Id}",
                    id);

                return NotFound();
            }


            var result = await _userManager.ChangePasswordAsync(
                user,
                dto.OldPassword,
                dto.NewPassword);


            if (result.Succeeded)
            {
                _logger.LogInformation(
                    "Kullanıcı şifresi başarıyla değiştirildi. Id={Id}",
                    id);
            }
            else
            {
                _logger.LogWarning(
                    "Kullanıcı şifre değiştirme başarısız. Id={Id}",
                    id);
            }


            return Ok(result);
        }


        [HttpPut("updateuser")]
        public async Task<IActionResult> Edit(
            [FromBody] UpdateUserDto updatedUser)
        {
            _logger.LogInformation(
                "Kullanıcı güncelleme işlemi başlatıldı. Id={Id}",
                updatedUser.Id);


            var user = await _userManager.FindByIdAsync(
                updatedUser.Id.ToString());


            if (user == null)
            {
                _logger.LogWarning(
                    "Güncellenecek kullanıcı bulunamadı. Id={Id}",
                    updatedUser.Id);

                return NotFound();
            }


            user.Name = updatedUser.Name;
            user.SurName = updatedUser.SurName;
            user.UserName = updatedUser.UserName;
            user.Email = updatedUser.Email;
            user.PhoneNumber = updatedUser.PhoneNumber;
            user.DepartmentId = updatedUser.DepartmentId;
            user.UpdateDate = DateTime.Now;
            user.CoverImgUrl = updatedUser.CoverImgUrl;


            if (string.IsNullOrEmpty(user.SecurityStamp))
                user.SecurityStamp = Guid.NewGuid().ToString();


            await _userManager.UpdateSecurityStampAsync(user);


            var result = await _userManager.UpdateAsync(user);


            if (result.Succeeded)
            {
                _logger.LogInformation(
                    "Kullanıcı başarıyla güncellendi. Id={Id}",
                    updatedUser.Id);

                return Ok();
            }


            _logger.LogWarning(
                "Kullanıcı güncelleme başarısız. Id={Id}",
                updatedUser.Id);


            return BadRequest(result.Errors);
        }


        [HttpDelete("deleteuser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            _logger.LogWarning(
                "Kullanıcı silme işlemi başlatıldı. Id={Id}, Kullanıcı={User}",
                id,
                User?.Identity?.Name);


            var user = await _userManager.FindByIdAsync(id.ToString());


            if (user == null)
            {
                _logger.LogWarning(
                    "Silinecek kullanıcı bulunamadı. Id={Id}",
                    id);

                return NotFound();
            }


            var result = await _userManager.DeleteAsync(user);


            if (!result.Succeeded)
            {
                _logger.LogWarning(
                    "Kullanıcı silme başarısız. Id={Id}",
                    id);

                return BadRequest(result.Errors);
            }


            _logger.LogWarning(
                "Kullanıcı başarıyla silindi. Id={Id}",
                id);


            return Ok("User deleted successfully");
        }
    }
}