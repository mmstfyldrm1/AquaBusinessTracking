using DTOLayer.Dtos.ElectricDtos.ElectricMotorTrackingDto;

namespace BusinessLayer.Abstract
{
    public interface IElectricMotorTrackingService : IGenericService<ElectricMotorDto, CreateElectricMotorDto, UpdateElectricMotorDto>
    {
        public Task<List<ElectricMotorDto>> GetWithDetails();
    }
}
