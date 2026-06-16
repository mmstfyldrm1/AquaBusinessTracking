using DTOLayer.Dtos.WinderCoilLengthControlDto;

namespace BusinessLayer.Abstract
{
    public interface IWinderCoilLengthControlService : IGenericService<WinderCoilLengthControlDto, CreateWinderLengthControlDto, UpdateWinderCoilLengthControlDto>
    {
        public Task<List<WinderCoilLengthControlDto>> GetWithDetails();
    }
}
