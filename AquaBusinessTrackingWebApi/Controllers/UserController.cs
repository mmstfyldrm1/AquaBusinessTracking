using DTOLayer.Dtos.UserDtos;
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

        public UserController(UserManager<DB_AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("getusers")]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet("getuser/{id}")]
        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPut("updateuser")]
        public async Task<IActionResult> Edit([FromBody] UpdateUserDto updatedUser)
        {
            var user = await _userManager.FindByIdAsync(updatedUser.Id.ToString());
            if (user == null)
                return NotFound();

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
                return Ok();

            return BadRequest(result.Errors);
        }

        [HttpDelete("deleteuser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
                return NotFound();

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok("User deleted successfully");
        }
    }
}

