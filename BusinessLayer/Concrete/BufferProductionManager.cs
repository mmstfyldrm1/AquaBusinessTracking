using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.BufferProductionDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class BufferProductionManager : GenericManager<DB_BufferProduction, BufferProductionDto, CreateBufferProductionDto, UpdateBufferProductionDto>, IBufferProductionService
    {
        private readonly IBufferProductionRepository _repo;
        public BufferProductionManager(IUnitOfWork uow, IMapper mapper, IBufferProductionRepository repo) : base(uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<BufferProductionDto>> GetWithDetails()
        {
            var data = await _repo.GetWithDetails();
            return _mapper.Map<List<BufferProductionDto>>(data);
        }
    }
}
