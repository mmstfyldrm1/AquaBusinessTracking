using BusinessLayer.Abstract;
using BusinessLayer.Abstract.Integrations;
using DTOLayer.Dtos.SentezIntegrationsDtos;
using DTOLayer.Dtos.SentezProductionDtos;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class SentezInventoryQueryManager : ISentezInventoryQueryService
    {
        private readonly ISentezIntegrationsService _service;

        public SentezInventoryQueryManager(ISentezIntegrationsService service)
        {
            _service = service;
        }

        public async Task<SentezIntegrationsResponsoDto<SentezInventoryResponseDto>?> GetChemicalInventory()
        {
            var query = BuildChemicalInventory();
            return await _service.ExecuteQueryAsync<SentezInventoryResponseDto>(query);
        }

        public async Task<SentezIntegrationsResponsoDto<SentezInventoryResponseDto>?> GetRawMaterielsInventory()
        {
            var query = BuildRawMaterielsInventory();
            return await _service.ExecuteQueryAsync<SentezInventoryResponseDto>(query);
        }

        private string BuildRawMaterielsInventory()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"select ");
            sb.AppendLine($"InventoryCode [Code],");
            sb.AppendLine($"InventoryName [Name]");
            sb.AppendLine($"");
            sb.AppendLine($"");
            sb.AppendLine($"from Erp_Inventory with(nolock) where CompanyId=22 and InventoryCode like'101%' and IsApproved=1 and InUse=1");
            return sb.ToString();
        }

        private string BuildChemicalInventory()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"select ");
            sb.AppendLine($"InventoryCode [Code],");
            sb.AppendLine($"InventoryName [Name]");
            sb.AppendLine($"");
            sb.AppendLine($"");
            sb.AppendLine($"from Erp_Inventory with(nolock) where CompanyId=22 and (InventoryCode like'5%' or InventoryCode like'723%') and IsApproved=1 and InUse=1");
            return sb.ToString();
        }
    }
}
