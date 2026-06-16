using DTOLayer.Dtos.PlcDtos.PlcTagsDtos;

namespace BusinessLayer.Abstract
{
    public interface IPlcTagsService : IGenericService<PlcMachineTagsDto, CreatePlcMachineTagsDto, UpdatePlcMachineTagsDto>
    {
        public Task<List<PlcMachineTagsDto>> GetByMachineName();
    }
}
