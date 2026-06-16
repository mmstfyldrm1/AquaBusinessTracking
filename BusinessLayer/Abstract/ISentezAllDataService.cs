using DTOLayer.Dtos.SentezAllDataDtos;

namespace BusinessLayer.Abstract
{
    public interface ISentezAllDataService : IGenericService<SentezAllDataDto, CreateSentezAllDataDto, UpdateSentezAllDataDto>
    {
        public Task<List<SentezAllDataDto>> GetWithDetails();
    }
}
