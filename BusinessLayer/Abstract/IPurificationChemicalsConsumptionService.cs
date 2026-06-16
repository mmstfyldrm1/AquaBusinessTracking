using DTOLayer.Dtos.PurificationChemicalsConsumptionDtos;

namespace BusinessLayer.Abstract
{
    public interface IPurificationChemicalsConsumptionService : IGenericService<PurificationChemicalsConsumptionDto, CreatePurificationChemicalsConsumptionDto, UpdatePurificationChemicalsConsumptionDto>
    {
        public Task<List<PurificationChemicalsConsumptionDto>> GetWithDetails();
    }
}
