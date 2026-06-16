using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AquaBusinessTrackingWebApi.Services
{
    public class GenerateTokenService
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<DB_AppUser> _userManager;
        private readonly RoleManager<DB_AppRole> _roleManager;
        private readonly IRolePermissionService _service;

        public GenerateTokenService(IConfiguration configuration, UserManager<DB_AppUser> userManager, RoleManager<DB_AppRole> roleManager, IRolePermissionService service)
        {
            _configuration = configuration;
            _userManager = userManager;
            _roleManager = roleManager;
            _service = service;
        }

        public async Task<string> CreateToken(DB_AppUser user)
        {

            var roles = await _userManager.GetRolesAsync(user);
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.UserName ?? user.Email),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("FullName", user.Email ?? ""),
                new Claim("DepartmentId", user.DepartmentId.ToString()),
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            foreach (var role in roles)
            {
                var roleEntity = await _roleManager.FindByNameAsync(role);
                if (roleEntity != null)
                {
                    var rolePermissions = await _service.GetRolePermissions(roleEntity.Id);
                    if (rolePermissions?.Permissions != null)
                    {
                        foreach (var perm in rolePermissions.Permissions.Where(p => p.IsSelected))
                        {
                            claims.Add(new Claim("Permission", perm.Name));
                        }
                    }
                }
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(token);


            return tokenString.ToString();
        }
    }
}
