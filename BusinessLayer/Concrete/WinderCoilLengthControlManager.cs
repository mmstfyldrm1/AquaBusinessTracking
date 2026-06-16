using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.WinderCoilLengthControlDto;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class WinderCoilLengthControlManager : GenericManager<DB_WinderCoilLengthControl, WinderCoilLengthControlDto, CreateWinderLengthControlDto, UpdateWinderCoilLengthControlDto>, IWinderCoilLengthControlService
    {
        private readonly IWinderCoilLengthControlRepository _repo;
        public WinderCoilLengthControlManager(IUnitOfWork uow, IMapper mapper, IWinderCoilLengthControlRepository repo) : base(uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<WinderCoilLengthControlDto>> GetWithDetails()
        {
            var entities = await _repo.GetWithDetails();
            var dtos = _mapper.Map<List<WinderCoilLengthControlDto>>(entities);
            return dtos;
        }
    }
}
