using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.VechileFuelLogsDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class VechileFuelLogsManager : GenericManager<DB_VechileFuelLogs, VechileFuelLogsDto, CreateVechileFuelLogsDto, UpdateVechileFuelLogsDto>, IVechileFuelLogsService
    {
        private readonly IVechileFuelLogsRepository _repo;
        public VechileFuelLogsManager(IUnitOfWork uow, IMapper mapper, IVechileFuelLogsRepository repo) : base(uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<VechileFuelLogsDto>> GetWithDetails()
        {
            var entities = await _repo.GetWithDetails();
            var dtos = _mapper.Map<List<VechileFuelLogsDto>>(entities);
            return dtos;
        }
    }
}
