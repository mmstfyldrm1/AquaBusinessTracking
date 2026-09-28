using DTOLayer.Dtos.SentezIntegrationsDtos.SentezIntegrationsCurrentAccountDtos;
using DTOLayer.Dtos.SentezProductionDtos;

namespace BusinessLayer.Abstract
{
    public interface ISentezCurrentAccountQueryService
    {
        Task<SentezIntegrationsResponsoDto<SentezCurrentAccountResponse>?> GetCurrentAccountCodeAndName();

        Task<SentezIntegrationsResponsoDto<SentezCityResponse>?> GetCurrentAccountCity(int RecId);

        Task<SentezIntegrationsResponsoDto<SentezDistrictResponse>?> GetCurrentAccountDistrict(int RecId, int CityId);

        Task<SentezIntegrationsResponsoDto<SentezAddressResponse>?> GetCurrentAccountAddress(int RecId, int CityId);
    }
}
