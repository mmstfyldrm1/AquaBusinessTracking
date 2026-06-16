using EntityLayer.Concrete;

namespace DataAccsessLayer.Abstract
{
    public interface IRolePermissionRepository
    {
        Task<List<DB_Permission>> GetAllPermissions();
        Task<List<int>> GetRolePermissionIds(int roleId);
        Task AddRange(List<DB_RolePermission> list);
        Task DeleteByRoleId(int roleId);


    }
}
