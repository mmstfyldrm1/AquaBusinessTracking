using DTOLayer.Dtos.WinderCoilTrackingDto;

namespace BusinessLayer.Abstract
{
    public interface IWinderCoilTrackingService : IGenericService<WinderCoilTrackingDto, CreateWinderCoilTrackingDto, UpdateWinderCoilTrackingDto>
    {
        public Task<List<WinderCoilTrackingDto>> GetWithDetails();
    }
}
