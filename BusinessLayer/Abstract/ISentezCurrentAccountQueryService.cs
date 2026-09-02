using DTOLayer.Dtos.SentezIntegrationsDtos.SentezIntegrationsCurrentAccountDtos;
using DTOLayer.Dtos.SentezProductionDtos;

namespace BusinessLayer.Abstract
{
    public interface ISentezCurrentAccountQueryService
    {
        Task<SentezIntegrationsResponsoDto<SentezCurrentAccountResponse>?> GetCurrentAccountCodeAndName();

        Task<SentezIntegrationsResponsoDto<SentezCityResponse>?> GetCurrentAccountCity(int RecId);

        Task<SentezIntegrationsResponsoDto<SentezDistrictResponse>?> GetCurrentAccountDistrict(int RecId);

        Task<SentezIntegrationsResponsoDto<SentezAddressResponse>?> GetCurrentAccountAddress(int RecId);
    }
}
