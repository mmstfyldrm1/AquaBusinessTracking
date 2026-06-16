using DTOLayer.Dtos.BasinDtos.BasinDto;

namespace BusinessLayer.Abstract
{
    public interface IBasinService : IGenericService<BasinDto, CreateBasinDto, UpdateBasinDto>
    {
        public Task<List<BasinDto>> GetWithDetails();
    }
}
