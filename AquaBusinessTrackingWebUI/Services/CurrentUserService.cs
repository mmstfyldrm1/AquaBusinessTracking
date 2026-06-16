using System.Security.Claims;

namespace AquaBusinessTrackingWebUI.Services
{
    public class CurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetUserId()
        {
            return _httpContextAccessor.HttpContext?.User
                .FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "";
        }

        public string GetUserName()
        {
            return _httpContextAccessor.HttpContext?.User
                .FindFirst(ClaimTypes.Name)?.Value ?? "";
        }

        public string GetEmail()
        {
            return _httpContextAccessor.HttpContext?.User
                .FindFirst(ClaimTypes.Email)?.Value ?? "";
        }

        public string GetDepartmentId()
        {
            return _httpContextAccessor.HttpContext?.User
                .FindFirst("DepartmentId")?.Value ?? "";
        }

        public List<string> GetRoles()
        {
            return _httpContextAccessor.HttpContext?.User
                .Claims
                .Where(c => c.Type == ClaimTypes.Role)
                .Select(c => c.Value)
                .ToList() ?? new List<string>();
        }

        public bool HasRole(string role)
        {
            return GetRoles().Contains(role, StringComparer.OrdinalIgnoreCase);
        }

        public List<string> GetPermissions()
        {
            return _httpContextAccessor.HttpContext?.User
                .Claims
                .Where(c => c.Type == "Permission")
                .Select(c => c.Value)
                .ToList() ?? new List<string>();
        }

        public bool HasPermission(string permission)
        {
            if (HasRole("Admin")) return true;
            return GetPermissions().Contains(permission, StringComparer.OrdinalIgnoreCase);

        }

        public bool HasModulePermission(string module)
        {
            if (HasRole("Admin")) return true;
            return GetPermissions().Any(p => p.StartsWith(module + ".", StringComparison.OrdinalIgnoreCase));
        }

        public bool IsAuthenticated()
        {
            return _httpContextAccessor.HttpContext?.User?.Identity?.IsAuthenticated ?? false;
        }
    }
}