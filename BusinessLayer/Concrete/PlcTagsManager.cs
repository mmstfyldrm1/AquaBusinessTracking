using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.PlcDtos.PlcTagsDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class PlcTagsManager : GenericManager<DB_PlcTags, PlcMachineTagsDto, CreatePlcMachineTagsDto, UpdatePlcMachineTagsDto>, IPlcTagsService
    {
        private readonly IPlcTagsRepository _repo;
        public PlcTagsManager(IUnitOfWork uow, IMapper mapper, IPlcTagsRepository repo) : base(uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<PlcMachineTagsDto>> GetByMachineName()
        {
            var entities = await _repo.GetByMachineName();
            var result = _mapper.Map<List<PlcMachineTagsDto>>(entities);
            return result;
        }
    }
}
