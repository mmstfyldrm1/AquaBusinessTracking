using DTOLayer.Dtos.SentezNotOrdersDtos;

namespace BusinessLayer.Abstract
{
    public interface ISentezNotOrdersService : IGenericService<SentezNotOrderDto, CreateSentezNotOrdersDto, UpdateSentezNotOrdersDto>
    {
        public Task<List<SentezNotOrderDto>> GetWithDetails();
    }
}
