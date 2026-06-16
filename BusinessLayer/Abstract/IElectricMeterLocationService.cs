using DTOLayer.Dtos.ElectricDtos.ElectricMeterLocationDtos;

namespace BusinessLayer.Abstract
{
    public interface IElectricMeterLocationService : IGenericService<ElectricMeterLocationDto, CreateElectricMeterLocationDto, UpdateElectricMeterLocationDto>
    {
        public Task<List<ElectricMeterLocationDto>> GetWithDetails();
    }
}
