using DTOLayer.Dtos.BoilerRoomDailyShiftMonitoringDtos;

namespace BusinessLayer.Abstract
{
    public interface IBoilerRoomDailyShiftMonitoringService : IGenericService<BoilerRoomDailyShiftMonitoringDto, CreateBoilerRoomDailyShiftMonitoringDto, UpdateBoilerRoomDailyShiftMonitoringDto>
    {
        public Task<List<BoilerRoomDailyShiftMonitoringDto>> GetWithDetails();
    }
}
