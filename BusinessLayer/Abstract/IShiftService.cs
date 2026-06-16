using DTOLayer.Dtos.ShiftDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IShiftService:IGenericService<ShiftDto,CreateShiftDto, UpdateShiftDto>    
    {
    }
}
