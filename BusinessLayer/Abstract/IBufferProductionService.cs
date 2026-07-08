using DTOLayer.Dtos.BufferProductionDtos;

namespace BusinessLayer.Abstract
{
    public interface IBufferProductionService : IGenericService<BufferProductionDto, CreateBufferProductionDto, UpdateBufferProductionDto>
    {
        public Task<List<BufferProductionDto>> GetWithDetails();
    }
}
