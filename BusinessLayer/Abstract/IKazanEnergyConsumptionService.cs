using DTOLayer.Dtos.KazanEnergyConsumptionDtos;

namespace BusinessLayer.Abstract
{
    public interface IKazanEnergyConsumptionService : IGenericService<KazanEnergyConsumptionDto, CreateKazanEnergyConsumptionDto, UpdateKazanEnergyConsumptionDto>
    {
        public Task<List<KazanEnergyConsumptionDto>> GetWithDetails();
    }
}
