using DTOLayer.Dtos.RolePermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IRolePermissionService
    {
        Task<RolePermissionDto> GetRolePermissions(int roleId);
        Task Save(RolePermissionDto dto);
    }
}
