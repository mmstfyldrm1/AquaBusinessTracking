using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DataAccsessLayer.Concrete.Repository
{
    public class RolePermissionRepository : IRolePermissionRepository
    {
        private readonly AquaBusinessTrackingContext _context;
        private readonly RoleManager<DB_AppRole> _roleManager;

        public RolePermissionRepository(AquaBusinessTrackingContext context)
        {
            _context = context;
        }

        public async Task<List<DB_Permission>> GetAllPermissions()
        {
            return await _context.Db_Permission.ToListAsync();
        }

        public async Task<List<int>> GetRolePermissionIds(int roleId)
        {
            return await _context.Db_RolePermission
                .Where(x => x.RoleId == roleId)
                .Select(x => x.PermissionId)
                .ToListAsync();
        }

        public async Task AddRange(List<DB_RolePermission> list)
        {
            await _context.Db_RolePermission.AddRangeAsync(list);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByRoleId(int roleId)
        {
            var data = _context.Db_RolePermission
                .Where(x => x.RoleId == roleId);

            _context.Db_RolePermission.RemoveRange(data);
            await _context.SaveChangesAsync();
        }


    }
}
