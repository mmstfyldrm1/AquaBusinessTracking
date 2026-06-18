using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.NaturelGasMeterMonitoringDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class NaturelGasMeterMonitoringManager : GenericManager<DB_NaturelGasMeterMonitoring, NaturelGasMeterMonitoringDto, CreateNaturelGasMeterMonitoringDto, UpdateNaturelGasMeterMonitoringDto>, INaturelGasMeterMonitoringService
    {
        private readonly INaturelGasMeterMonitoringRepository _repo;
        public NaturelGasMeterMonitoringManager(IUnitOfWork uow, IMapper mapper, INaturelGasMeterMonitoringRepository repo) : base(uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<NaturelGasMeterMonitoringDto>> GetPreviousDay()
        {
            var entities = await _repo.GetWithDetails();
            var dtos = _mapper.Map<List<NaturelGasMeterMonitoringDto>>(entities);
            return dtos;
        }

        public async Task<List<NaturelGasMeterMonitoringDto>> GetWithDetails()
        {
            var entities = await _repo.GetWithDetails();
            var dtos = _mapper.Map<List<NaturelGasMeterMonitoringDto>>(entities);
            return dtos;
        }
    }
}
