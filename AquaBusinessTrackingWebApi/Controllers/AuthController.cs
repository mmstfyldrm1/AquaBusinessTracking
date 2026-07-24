using AquaBusinessTrackingWebApi.Services;
using DTOLayer.Dtos.AuthDtos;
using DTOLayer.Dtos.UserDtos;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AquaBusinessTrackingWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        private readonly UserManager<DB_AppUser> _userManager;
        private readonly SignInManager<DB_AppUser> _signInManager;
        private readonly GenerateTokenService _generateTokenService;
        private readonly ILogger<AuthController> _logger;

        public AuthController(UserManager<DB_AppUser> userManager, SignInManager<DB_AppUser> signInManager, GenerateTokenService generateTokenService, ILogger<AuthController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _generateTokenService = generateTokenService;
            _logger = logger;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            _logger.LogInformation("Yeni kullanıcı kayıt isteği. Email={Email}", dto.Email);
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
                _logger.LogInformation("Kullanıcı oluşturuldu. Id={UserId}, Email={Email}", user.Id, user.Email);
                var role = await _userManager.AddToRoleAsync(user, "User");
                if (role.Succeeded)
                {
                    _logger.LogInformation("Kullanıcıya 'User' rolü atandı. Id={UserId}, Email={Email}", user.Id, user.Email);
                    return Ok("ok");
                }
            }


            if (!result.Succeeded)
            {
                _logger.LogWarning("Kullanıcı oluşturulamadı. Hatalar: {Errors}", string.Join(", ", result.Errors.Select(e => e.Description)));
                return BadRequest(result.Errors);
            }


            return Ok("Kayıt başarılı!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            _logger.LogInformation("Kullanıcı giriş isteği. Email={Email}", dto.UserName);
            var user = await _userManager.FindByEmailAsync(dto.UserName);
            if (user == null)
            {
                _logger.LogWarning("Kullanıcı bulunamadı. Email={Email}", dto.UserName);
                return Unauthorized("Kullanıcı bulunamadı");
            }


            var ip = HttpContext.Connection.RemoteIpAddress?.ToString();
            var result = await _signInManager.PasswordSignInAsync(user, dto.Password, false, false);
            if (!result.Succeeded)
            {
                _logger.LogWarning("Geçersiz giriş. Email={Email}", dto.UserName);
                return Unauthorized("Geçersiz giriş");
            }

            else
                _logger.LogInformation("Başarılı giriş. UserId={UserId}, UserName={UserName}, IP={IP}", user.Id, user.UserName, ip);


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

        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            _logger.LogInformation("Tüm kullanıcılar listeleniyor.");
            var users = await _userManager.Users
                .Select(x => new GetListUserDto
                {
                    Id = x.Id,
                    UserName = x.UserName

                })
                .ToListAsync();

            return Ok(users);
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
