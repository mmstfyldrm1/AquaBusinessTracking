using DTOLayer.Dtos.KazanDtos.KazanHeadDtos;

namespace BusinessLayer.Abstract
{
    public interface IKazanChemicalsHeadService : IGenericService<KazanChemicalsHeadDto, CreateKazanChemicalsHeadDto, UpdateKazanChemicalsHeadDto>
    {
        public Task<List<KazanChemicalsHeadDto>> GetWithDetails();
    }
}
