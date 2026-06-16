using DTOLayer.Dtos.PlcDtos.PlcMachineDtos;

namespace BusinessLayer.Abstract
{
    public interface IPlcMachineService : IGenericService<PlcMachineDto, CreatePlcMachineDto, UpdatePlcMachineDto>
    {
    }
}
