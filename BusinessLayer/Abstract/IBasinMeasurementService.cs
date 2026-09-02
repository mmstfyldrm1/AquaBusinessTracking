using DTOLayer.Dtos.BasinDtos.BasinMeasurement;

namespace BusinessLayer.Abstract
{
    public interface IBasinMeasurementService : IGenericService<BasinMeasurementDto, CreateBasinMeasurementDto, UpdateBasinMeasurementDto>
    {
        public Task<List<BasinMeasurementDto>> GetWithDetails();

        public Task<List<BasinMeasurementDto>> GetWithSearchDetails(DateTime StartDate, DateTime EndDate);

    }
}
