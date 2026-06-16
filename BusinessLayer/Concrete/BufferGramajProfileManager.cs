using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.BufferGramajProfile;
using DTOLayer.Dtos.BufferGramajProfileDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class BufferGramajProfileManager : GenericManager<DB_BufferGramajProfile, BufferGramajProfileDto, CreateBufferGramajProfileDto, UpdateBufferGramajProfileDto>, IBufferGramajProfileService
    {
        private readonly IBufferGramajProfileRepository _repository;
        public BufferGramajProfileManager(IUnitOfWork uow, IMapper mapper, IBufferGramajProfileRepository repository) : base(uow, mapper)
        {
            _repository = repository;
        }

        public async Task<List<BufferGramajProfileDto>> GetWithDetails()
        {
            var list = await _repository.GetWithDetails();
            var mappedList = _mapper.Map<List<BufferGramajProfileDto>>(list);
            return mappedList;
        }
    }
}
