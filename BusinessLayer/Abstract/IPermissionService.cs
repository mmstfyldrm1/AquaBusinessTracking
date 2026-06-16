using DTOLayer.Dtos.RolePermission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IPermissionService
    {

        Task<List<PermissionDto>> GetAll();
        Task<PermissionDto> GetById(int id);
        Task Add(AddPermissionsDto dto);
        Task Update(UpdatePermissionsDto dto);
        Task Delete(int id);
    }
}
