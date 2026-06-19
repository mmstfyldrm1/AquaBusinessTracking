using DTOLayer.Dtos.ShiftDtos;

namespace BusinessLayer.Abstract
{
    public interface IShiftService : IGenericService<ShiftDto, CreateShiftDto, UpdateShiftDto>
    {
    }
}
