using DTOLayer.Dtos.BufferGramajProfile;
using DTOLayer.Dtos.BufferGramajProfileDtos;

namespace BusinessLayer.Abstract
{
    public interface IBufferGramajProfileService : IGenericService<BufferGramajProfileDto, CreateBufferGramajProfileDto, UpdateBufferGramajProfileDto>
    {
        public Task<List<BufferGramajProfileDto>> GetWithDetails();
    }
}
