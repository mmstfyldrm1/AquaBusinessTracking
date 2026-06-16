using DTOLayer.Dtos.DoughPreparationDtos.DoughPreparationHeadDtos;

namespace BusinessLayer.Abstract
{
    public interface IDoughPreparationHeadService : IGenericService<DoughPreparationDto, CreateDoughPreparationDto, UpdateDoughPreparationDto>
    {
        public Task<List<DoughPreparationDto>> GetWithDetails();
    }
}
