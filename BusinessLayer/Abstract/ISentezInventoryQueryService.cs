using DTOLayer.Dtos.SentezIntegrationsDtos;
using DTOLayer.Dtos.SentezProductionDtos;

namespace BusinessLayer.Abstract
{
    public interface ISentezInventoryQueryService
    {
        Task<SentezIntegrationsResponsoDto<SentezInventoryResponseDto>?> GetChemicalInventory();

        Task<SentezIntegrationsResponsoDto<SentezInventoryResponseDto>?> GetRawMaterielsInventory();
    }
}
