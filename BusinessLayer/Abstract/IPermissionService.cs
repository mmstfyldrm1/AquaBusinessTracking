using DTOLayer.Dtos.RolePermission;

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
