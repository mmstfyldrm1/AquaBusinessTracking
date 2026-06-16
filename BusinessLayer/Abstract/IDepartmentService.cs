using DTOLayer.Dtos.DepartmentDtos;
using DTOLayer.Dtos.ElectricDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IDepartmentService:IGenericService<DepartmentDto, CreateDepartmentDto, UpdateDepartmentDto>
    {
       

    }
}
