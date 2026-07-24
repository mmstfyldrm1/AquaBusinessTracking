using DTOLayer.Dtos.RawMaterialIntakesDtos;

namespace BusinessLayer.Abstract
{
    public interface IRawMaterialIntakeService : IGenericService<RawMaterialIntakesDto, CreateRawMaterialIntakesDto, UpdateRawMaterialIntakesDto>
    {
        public Task<List<RawMaterialIntakesDto>> GetWithDetails();
    }
}
