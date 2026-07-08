using AutoMapper;
using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete.UoW;
using DTOLayer.Dtos.BoilerRoomDailyShiftMonitoringDtos;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class BoilerRoomDailyShiftMonitoringManager : GenericManager<DB_BoilerRoomDailyShiftMonitoring, BoilerRoomDailyShiftMonitoringDto, CreateBoilerRoomDailyShiftMonitoringDto, UpdateBoilerRoomDailyShiftMonitoringDto>, IBoilerRoomDailyShiftMonitoringService
    {
        private readonly IBoilerRoomDailyShiftMonitoringRepository _repo;
        public BoilerRoomDailyShiftMonitoringManager(IUnitOfWork uow, IMapper mapper, IBoilerRoomDailyShiftMonitoringRepository repo) : base(uow, mapper)
        {
            _repo = repo;
        }

        public async Task<List<BoilerRoomDailyShiftMonitoringDto>> GetWithDetails()
        {
            var data = await _repo.GetWithDetails();
            return _mapper.Map<List<BoilerRoomDailyShiftMonitoringDto>>(data);
        }
    }
}
