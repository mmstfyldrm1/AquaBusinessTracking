using BusinessLayer.Abstract;
using BusinessLayer.Abstract.Integrations;
using DTOLayer.Dtos.SentezIntegrationsDtos.SentezIntegrationsCurrentAccountDtos;
using DTOLayer.Dtos.SentezProductionDtos;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class SentezCurrentAccountQueryService : ISentezCurrentAccountQueryService
    {
        private readonly ISentezIntegrationsService _service;

        public SentezCurrentAccountQueryService(ISentezIntegrationsService service)
        {
            _service = service;
        }

        public async Task<SentezIntegrationsResponsoDto<SentezAddressResponse>?> GetCurrentAccountAddress(int RecId)
        {
            var query = "Select Line1, Line2, Line3 From Erp_Address a where a.CurrentAccountId = " + RecId;
            return await _service.ExecuteQueryAsync<SentezAddressResponse>(query);
        }

        public async Task<SentezIntegrationsResponsoDto<SentezCityResponse>?> GetCurrentAccountCity(int RecId)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"select ");
            sb.AppendLine($"");
            sb.AppendLine($"cu.RecId [CityId]");
            sb.AppendLine($",c.CityName [CityName]");
            sb.AppendLine($"");
            sb.AppendLine($"");
            sb.AppendLine($"from Erp_CurrentAccount cu ");
            sb.AppendLine($"left join Erp_Address a with(nolock) on cu.RecId =  a.CurrentAccountId");
            sb.AppendLine($"left join Meta_City c with(nolock) on c.RecId = a.CityId");
            sb.AppendLine($"where cu.RecId = {RecId}");
            return await _service.ExecuteQueryAsync<SentezCityResponse>(sb.ToString());
        }

        public async Task<SentezIntegrationsResponsoDto<SentezCurrentAccountResponse>?> GetCurrentAccountCodeAndName()
        {
            var query = "Select RecId, CurrentAccountCode, CurrentAccountName From Erp_CurrentAccount where CurrentAccountCode Like  'M%' and  CompanyId=22";
            return await _service.ExecuteQueryAsync<SentezCurrentAccountResponse>(query);
        }

        public async Task<SentezIntegrationsResponsoDto<SentezDistrictResponse>?> GetCurrentAccountDistrict(int RecId)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"select ");
            sb.AppendLine($"");
            sb.AppendLine($"d.RecId [DistrictId]");
            sb.AppendLine($",d.DistrictName [DistrictName]");
            sb.AppendLine($"");
            sb.AppendLine($"");
            sb.AppendLine($"from Erp_CurrentAccount cu ");
            sb.AppendLine($"left join Erp_Address a with(nolock) on cu.RecId =  a.CurrentAccountId");
            sb.AppendLine($"left join Meta_District d with(nolock) on d.RecId= a.DistrictId");
            sb.AppendLine($"where cu.RecId = {RecId}");
            return await _service.ExecuteQueryAsync<SentezDistrictResponse>(sb.ToString());
        }
    }
}
