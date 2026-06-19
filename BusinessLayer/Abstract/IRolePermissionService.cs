using DTOLayer.Dtos.RolePermission;

namespace BusinessLayer.Abstract
{
    public interface IRolePermissionService
    {
        Task<RolePermissionDto> GetRolePermissions(int roleId);
        Task Save(RolePermissionDto dto);
    }
}
