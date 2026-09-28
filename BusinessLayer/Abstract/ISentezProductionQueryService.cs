using DTOLayer.Dtos.SentezIntegrationsDtos.SentezIntegrationProductionDtos;
using DTOLayer.Dtos.SentezProductionDtos;

namespace BusinessLayer.Abstract
{
    public interface ISentezProductionQueryService
    {
        Task<SentezIntegrationsResponsoDto<SentezIntegrationsGetCombineDetailsDto>?> GetProductionCombination();

        Task<SentezIntegrationsResponsoDto<SentezIntegrationsGetProductionDetailsDto>?> GetProductionDetails();
    }
}
