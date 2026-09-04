using DTOLayer.Dtos.RawMaterialIntakesDtos;

namespace AIAgent.Services.Abstract.RawMaterials
{
    public interface IRawMaterialsApiService
    {
        public Task<List<RawMaterialIntakesDto>> GetWithSearchDetails(DateTime StartDate, DateTime EndDate);
    }
}
