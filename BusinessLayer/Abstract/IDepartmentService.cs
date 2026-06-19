using DTOLayer.Dtos.DepartmentDtos;

namespace BusinessLayer.Abstract
{
    public interface IDepartmentService : IGenericService<DepartmentDto, CreateDepartmentDto, UpdateDepartmentDto>
    {


    }
}
