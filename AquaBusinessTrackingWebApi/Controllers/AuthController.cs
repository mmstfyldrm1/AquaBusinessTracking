using AquaBusinessTrackingWebApi.Services;
using DTOLayer.Dtos.AuthDtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        private readonly UserManager<DB_AppUser> _userManager;
        private readonly SignInManager<DB_AppUser> _signInManager;
        private readonly GenerateTokenService _generateTokenService;

        public AuthController(UserManager<DB_AppUser> userManager, SignInManager<DB_AppUser> signInManager, GenerateTokenService generateTokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _generateTokenService = generateTokenService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var user = new DB_AppUser
            {
                Name = dto.Name,
                SurName = dto.SurName,
                UserName = ConvertToEnglishCharacter($"{dto.Name?.Trim()}{dto.SurName?.Trim()}".Replace(" ", "")),
                DepartmentId = dto.DepartmentId,
                PhoneNumber = dto.Phone,
                CoverImgUrl = dto.CoverImgUrl,
                Email = dto.Email,

            };

            var result = await _userManager.CreateAsync(user, dto.Password);

            if (result.Succeeded)
            {
                var role = await _userManager.AddToRoleAsync(user, "User");
                if (role.Succeeded)
                {
                    return Ok("ok");
                }
            }


            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok("Kayıt başarılı!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.UserName);
            if (user == null)
                return Unauthorized("Kullanıcı bulunamadı");

            var result = await _signInManager.PasswordSignInAsync(user, dto.Password, false, false);
            if (!result.Succeeded)
                return Unauthorized("Geçersiz giriş");
            var roles = await _userManager.GetRolesAsync(user);
            var token = await _generateTokenService.CreateToken(user);
            return Ok(new
            {
                Token = token,
                Id = user.Id,
                FullName = user.Email,
                Email = user.Email,
                UserName = user.UserName,
                Role = roles,
            });

        }

        private string ConvertToEnglishCharacter(string text)
        {
            return text
                .Replace("ç", "c")
                .Replace("Ç", "C")
                .Replace("ğ", "g")
                .Replace("Ğ", "G")
                .Replace("ı", "i")
                .Replace("İ", "I")
                .Replace("ö", "o")
                .Replace("Ö", "O")
                .Replace("ş", "s")
                .Replace("Ş", "S")
                .Replace("ü", "u")
                .Replace("Ü", "U");
        }

    }
}
