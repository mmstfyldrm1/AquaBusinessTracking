using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DTOLayer.Dtos.RolePermission;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class RolePermissionManager : IRolePermissionService
    {
        private readonly IRolePermissionRepository _repo;

        public RolePermissionManager(IRolePermissionRepository repo)
        {
            _repo = repo;
        }

        public async Task<RolePermissionDto> GetRolePermissions(int roleId)
        {
            var allPermissions = await _repo.GetAllPermissions();
            var rolePermIds = await _repo.GetRolePermissionIds(roleId);

            return new RolePermissionDto
            {
                RoleId = roleId,
                Permissions = allPermissions.Select(x => new PermissionItemDto
                {
                    PermissionId = x.RecId,
                    Name = $"{x.Module}.{x.Controller}.{x.Action}",
                    IsSelected = rolePermIds.Contains(x.RecId)
                }).ToList()
            };
        }

        public async Task Save(RolePermissionDto dto)
        {
            await _repo.DeleteByRoleId(dto.RoleId);

            var newData = dto.Permissions
                .Where(x => x.IsSelected)
                .Select(x => new DB_RolePermission
                {
                    RoleId = dto.RoleId,
                    PermissionId = x.PermissionId,

                }).ToList();

            await _repo.AddRange(newData);
        }
    }
}
