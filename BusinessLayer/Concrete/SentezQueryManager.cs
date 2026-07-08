using BusinessLayer.Abstract;
using BusinessLayer.Abstract.Integrations;
using DTOLayer.Dtos.AdminDashboardDtos;
using DTOLayer.Dtos.SentezProductionDtos;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class SentezQueryManager : ISentezQueryService
    {
        private readonly ISentezIntegrationsService _service;

        public SentezQueryManager(ISentezIntegrationsService service)
        {
            _service = service;
        }

        public async Task<SentezIntegrationsResponsoDto<SentezProductionDto>?> GetPreviousDayStockAsync()
        {
            var query = BuildPreviousDayQuery();
            return await _service.ExecuteQueryAsync<SentezProductionDto>(query);
        }

        public async Task<SentezIntegrationsResponsoDto<SentezProductionDto>?> GetStockAsync()
        {
            var query = BuildStockQuery();
            return await _service.ExecuteQueryAsync<SentezProductionDto>(query);

        }

        public async Task<SentezIntegrationsResponsoDto<SentezProductionDto>?> GetPreviousDaySalesAsync()
        {
            var query = BuildPreviousDaySalesQuery();
            return await _service.ExecuteQueryAsync<SentezProductionDto>(query);
        }

        public async Task<SentezIntegrationsResponsoDto<SentezProductionDto>?> GetSalesAsync()
        {
            var query = BuildSalesQuery();
            return await _service.ExecuteQueryAsync<SentezProductionDto>(query);
        }

        public async Task<SentezIntegrationsResponsoDto<AdminDahboardLast7DaysStock>?> GetLas7DaysProductionAsync()
        {
            var query = BuildProductionQuery();
            return await _service.ExecuteQueryAsync<AdminDahboardLast7DaysStock>(query);
        }

        private string BuildProductionQuery()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"select ");
            sb.AppendLine($"isnull(ir.ReceiptDate,'-') [Date]");
            sb.AppendLine($",sum(case when ir.ReceiptType > 100 then (ist.Quantity) else 0 end) [Consumable]");
            sb.AppendLine($",sum(case When ir.ReceiptType < 100 then (ist.Quantity) else 0 end) [Production]");
            sb.AppendLine($",sum(case when ir.ReceiptType > 100 then (ist.Quantity) else 0 end)-sum(case When ir.ReceiptType < 100 then (ist.Quantity) else 0 end) [Remaning]");
            sb.AppendLine($"");
            sb.AppendLine($"from Erp_InventorySerialTransaction ist with(nolock)");
            sb.AppendLine($"");
            sb.AppendLine($"left join Erp_InventorySerialCard isc with(nolock) on isc.RecId = ist.SerialCardId");
            sb.AppendLine($"left join Erp_Inventory i with(nolock) on i.RecId = isc.InventoryId");
            sb.AppendLine($"left join Erp_InventoryReceiptItem iri with(nolock) on iri.RecId = ist.ReceiptItemId");
            sb.AppendLine($"left join Erp_InventoryReceipt ir with(nolock) on ir.RecId = iri.InventoryReceiptId");
            sb.AppendLine($"");
            sb.AppendLine($"outer apply (select top 1 Explanation from Meta_DataFieldValue where FieldId = 223 and isnull(CodeValue,'') = isnull(i.UD_InventoryGroup,'')) grupkodu");
            sb.AppendLine($"outer apply (select top 1 Explanation from Meta_DataFieldValue where FieldId = 219 and isnull(CodeValue,'') = isnull(i.UD_Gramaj,'')) gramaj");
            sb.AppendLine($"outer apply (select top 1 Explanation from Meta_DataFieldValue where FieldId = 222 and isnull(CodeValue,'') = isnull(i.UD_Dimensions,'')) en");
            sb.AppendLine($"");
            sb.AppendLine($"");
            sb.AppendLine($"where isc.CompanyId = 22");
            sb.AppendLine($"and i.InventoryCode like '9%'");
            sb.AppendLine($"and isnull(ir.IsCancelled,0) = 0 and isnull(ir.IsApproved,1) = 1");
            sb.AppendLine($"and isnull(iri.IsCancelled,0) = 0 and isnull(iri.IsApproved,1) = 1");
            sb.AppendLine($"and ISNULL(ir.IsTransportReceipt,0)=0");
            sb.AppendLine($"and ir.ReceiptType in (10,130,132)");
            sb.AppendLine($"");
            sb.AppendLine($"");
            sb.AppendLine($"and cast(ir.ReceiptDate as date) >= cast(DATEADD(day, -7, GETDATE()) as date) -- tarih");
            sb.AppendLine($"");
            sb.AppendLine($"group by ir.ReceiptDate ");
            sb.AppendLine($"");
            sb.AppendLine($"order by ir.ReceiptDate ");
            return sb.ToString();
        }

        private string BuildSalesQuery()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"select ");
            sb.AppendLine($"grupkodu.Explanation [PapperType]");
            sb.AppendLine($",sum(case when ir.ReceiptType > 100 then (ist.Quantity) else 0 end) [Production]");
            sb.AppendLine($",sum(case When ir.ReceiptType < 100 then (ist.Quantity) else 0 end) [Consumable]");
            sb.AppendLine($",sum(case when ir.ReceiptType > 100 then (ist.Quantity) else 0 end)-sum(case When ir.ReceiptType < 100 then (ist.Quantity) else 0 end) [Remaning]");
            sb.AppendLine($"");
            sb.AppendLine($"from Erp_InventorySerialTransaction ist with(nolock)");
            sb.AppendLine($"");
            sb.AppendLine($"left join Erp_InventorySerialCard isc with(nolock) on isc.RecId = ist.SerialCardId");
            sb.AppendLine($"left join Erp_Inventory i with(nolock) on i.RecId = isc.InventoryId");
            sb.AppendLine($"left join Erp_InventoryReceiptItem iri with(nolock) on iri.RecId = ist.ReceiptItemId");
            sb.AppendLine($"left join Erp_InventoryReceipt ir with(nolock) on ir.RecId = iri.InventoryReceiptId");
            sb.AppendLine($"");
            sb.AppendLine($"outer apply (select top 1 Explanation from Meta_DataFieldValue where FieldId = 223 and isnull(CodeValue,'') = isnull(i.UD_InventoryGroup,'')) grupkodu");
            sb.AppendLine($"outer apply (select top 1 Explanation from Meta_DataFieldValue where FieldId = 219 and isnull(CodeValue,'') = isnull(i.UD_Gramaj,'')) gramaj");
            sb.AppendLine($"outer apply (select top 1 Explanation from Meta_DataFieldValue where FieldId = 222 and isnull(CodeValue,'') = isnull(i.UD_Dimensions,'')) en");
            sb.AppendLine($"");
            sb.AppendLine($"");
            sb.AppendLine($"where isc.CompanyId = 22");
            sb.AppendLine($"and i.InventoryCode like '9%'");
            sb.AppendLine($"and isnull(ir.IsCancelled,0) = 0 and isnull(ir.IsApproved,1) = 1");
            sb.AppendLine($"and isnull(iri.IsCancelled,0) = 0 and isnull(iri.IsApproved,1) = 1");
            sb.AppendLine($"and ISNULL(ir.IsTransportReceipt,0)=0");
            sb.AppendLine($"and ir.ReceiptType in (3,120)");
            sb.AppendLine($"");
            sb.AppendLine($"");
            sb.AppendLine($"--and cast(ir.ReceiptDate as date) = cast((GETDATE()-1) as date) -- tarih");
            sb.AppendLine($"");
            sb.AppendLine($"group by grupkodu.Explanation ");
            sb.AppendLine($"");
            sb.AppendLine($"order by grupkodu.Explanation");

            return sb.ToString();
        }

        private string BuildPreviousDaySalesQuery()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"select ");
            sb.AppendLine($"grupkodu.Explanation [PapperType]");
            sb.AppendLine($",sum(case when ir.ReceiptType > 100 then (ist.Quantity) else 0 end) [Production]");
            sb.AppendLine($",sum(case When ir.ReceiptType < 100 then (ist.Quantity) else 0 end) [Consumable]");
            sb.AppendLine($",sum(case when ir.ReceiptType > 100 then (ist.Quantity) else 0 end)-sum(case When ir.ReceiptType < 100 then (ist.Quantity) else 0 end) [Remaning]");
            sb.AppendLine($"");
            sb.AppendLine($"from Erp_InventorySerialTransaction ist with(nolock)");
            sb.AppendLine($"");
            sb.AppendLine($"left join Erp_InventorySerialCard isc with(nolock) on isc.RecId = ist.SerialCardId");
            sb.AppendLine($"left join Erp_Inventory i with(nolock) on i.RecId = isc.InventoryId");
            sb.AppendLine($"left join Erp_InventoryReceiptItem iri with(nolock) on iri.RecId = ist.ReceiptItemId");
            sb.AppendLine($"left join Erp_InventoryReceipt ir with(nolock) on ir.RecId = iri.InventoryReceiptId");
            sb.AppendLine($"");
            sb.AppendLine($"outer apply (select top 1 Explanation from Meta_DataFieldValue where FieldId = 223 and isnull(CodeValue,'') = isnull(i.UD_InventoryGroup,'')) grupkodu");
            sb.AppendLine($"outer apply (select top 1 Explanation from Meta_DataFieldValue where FieldId = 219 and isnull(CodeValue,'') = isnull(i.UD_Gramaj,'')) gramaj");
            sb.AppendLine($"outer apply (select top 1 Explanation from Meta_DataFieldValue where FieldId = 222 and isnull(CodeValue,'') = isnull(i.UD_Dimensions,'')) en");
            sb.AppendLine($"");
            sb.AppendLine($"");
            sb.AppendLine($"where isc.CompanyId = 22");
            sb.AppendLine($"and i.InventoryCode like '9%'");
            sb.AppendLine($"and isnull(ir.IsCancelled,0) = 0 and isnull(ir.IsApproved,1) = 1");
            sb.AppendLine($"and isnull(iri.IsCancelled,0) = 0 and isnull(iri.IsApproved,1) = 1");
            sb.AppendLine($"and ISNULL(ir.IsTransportReceipt,0)=0");
            sb.AppendLine($"and ir.ReceiptType in (3,120)");
            sb.AppendLine($"");
            sb.AppendLine($"");
            sb.AppendLine($"and cast(ir.ReceiptDate as date) = cast((GETDATE()-1) as date) -- tarih");
            sb.AppendLine($"");
            sb.AppendLine($"group by grupkodu.Explanation ");
            sb.AppendLine($"");
            sb.AppendLine($"order by grupkodu.Explanation");

            return sb.ToString();
        }

        private string BuildPreviousDayQuery()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"select ");
            sb.AppendLine($"");
            sb.AppendLine($"");
            sb.AppendLine($"grupkodu.Explanation [PapperType]");
            sb.AppendLine($"");
            sb.AppendLine($"--,gramaj.Explanation [Gramaj (gr.)]");
            sb.AppendLine($"--,en.Explanation [Ebat (mm.)]");
            sb.AppendLine($"");
            sb.AppendLine($"");
            sb.AppendLine($",sum(case When ir.ReceiptType < 100 then (ist.Quantity) else 0 end) [production]");
            sb.AppendLine($",sum(case when ir.ReceiptType > 100 then (ist.Quantity-1) else 0 end) [consumable]");
            sb.AppendLine($",SUM(case When ir.ReceiptType < 100 then (ist.Quantity) when ir.ReceiptType > 100 then (ist.Quantity*-1) else 0 end) [remaining]");
            sb.AppendLine($"");
            sb.AppendLine($"from Erp_InventorySerialTransaction ist with(nolock)");
            sb.AppendLine($"");
            sb.AppendLine($"left join Erp_InventorySerialCard isc with(nolock) on isc.RecId = ist.SerialCardId");
            sb.AppendLine($"left join Erp_Inventory i with(nolock) on i.RecId = isc.InventoryId");
            sb.AppendLine($"left join Erp_InventoryReceiptItem iri with(nolock) on iri.RecId = ist.ReceiptItemId");
            sb.AppendLine($"left join Erp_InventoryReceipt ir with(nolock) on ir.RecId = iri.InventoryReceiptId");
            sb.AppendLine($"");
            sb.AppendLine($"outer apply (select top 1 Explanation from Meta_DataFieldValue where FieldId = 223 and isnull(CodeValue,'') = isnull(i.UD_InventoryGroup,'')) grupkodu");
            sb.AppendLine($"outer apply (select top 1 Explanation from Meta_DataFieldValue where FieldId = 219 and isnull(CodeValue,'') = isnull(i.UD_Gramaj,'')) gramaj");
            sb.AppendLine($"outer apply (select top 1 Explanation from Meta_DataFieldValue where FieldId = 222 and isnull(CodeValue,'') = isnull(i.UD_Dimensions,'')) en");
            sb.AppendLine($"");
            sb.AppendLine($"");
            sb.AppendLine($"where isc.CompanyId = 22");
            sb.AppendLine($"and i.InventoryCode like '9%'");
            sb.AppendLine($"and isnull(ir.IsCancelled,0) = 0 and isnull(ir.IsApproved,1) = 1");
            sb.AppendLine($"and isnull(iri.IsCancelled,0) = 0 and isnull(iri.IsApproved,1) = 1");
            sb.AppendLine($"and ISNULL(ir.IsTransportReceipt,0)=0");
            sb.AppendLine($"and ir.ReceiptType in (10,130,132)");
            sb.AppendLine($"");
            sb.AppendLine($"");
            sb.AppendLine($"and cast(ir.ReceiptDate as date) = cast((GETDATE()-1) as date) -- tarih");
            sb.AppendLine($"");
            sb.AppendLine($"group by grupkodu.Explanation ");
            sb.AppendLine($"");
            sb.AppendLine($"order by grupkodu.Explanation");

            return sb.ToString();
        }

        private string BuildStockQuery()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"select ");
            sb.AppendLine($"");
            sb.AppendLine($"");
            sb.AppendLine($"grupkodu.Explanation [PapperType]");
            sb.AppendLine($"");
            sb.AppendLine($"--,gramaj.Explanation [Gramaj (gr.)]");
            sb.AppendLine($"--,en.Explanation [Ebat (mm.)]");
            sb.AppendLine($"");
            sb.AppendLine($"");
            sb.AppendLine($",sum(case When ir.ReceiptType < 100 then (ist.Quantity) else 0 end) [production]");
            sb.AppendLine($",sum(case when ir.ReceiptType > 100 then (ist.Quantity-1) else 0 end) [consumable]");
            sb.AppendLine($",SUM(case When ir.ReceiptType < 100 then (ist.Quantity) when ir.ReceiptType > 100 then (ist.Quantity*-1) else 0 end) [remaining]");
            sb.AppendLine($"");
            sb.AppendLine($"from Erp_InventorySerialTransaction ist with(nolock)");
            sb.AppendLine($"");
            sb.AppendLine($"left join Erp_InventorySerialCard isc with(nolock) on isc.RecId = ist.SerialCardId");
            sb.AppendLine($"left join Erp_Inventory i with(nolock) on i.RecId = isc.InventoryId");
            sb.AppendLine($"left join Erp_InventoryReceiptItem iri with(nolock) on iri.RecId = ist.ReceiptItemId");
            sb.AppendLine($"left join Erp_InventoryReceipt ir with(nolock) on ir.RecId = iri.InventoryReceiptId");
            sb.AppendLine($"");
            sb.AppendLine($"outer apply (select top 1 Explanation from Meta_DataFieldValue where FieldId = 223 and isnull(CodeValue,'') = isnull(i.UD_InventoryGroup,'')) grupkodu");
            sb.AppendLine($"outer apply (select top 1 Explanation from Meta_DataFieldValue where FieldId = 219 and isnull(CodeValue,'') = isnull(i.UD_Gramaj,'')) gramaj");
            sb.AppendLine($"outer apply (select top 1 Explanation from Meta_DataFieldValue where FieldId = 222 and isnull(CodeValue,'') = isnull(i.UD_Dimensions,'')) en");
            sb.AppendLine($"");
            sb.AppendLine($"");
            sb.AppendLine($"where isc.CompanyId = 22");
            sb.AppendLine($"and i.InventoryCode like '9%'");
            sb.AppendLine($"and isnull(ir.IsCancelled,0) = 0 and isnull(ir.IsApproved,1) = 1");
            sb.AppendLine($"and isnull(iri.IsCancelled,0) = 0 and isnull(iri.IsApproved,1) = 1");
            sb.AppendLine($"and ISNULL(ir.IsTransportReceipt,0)=0");
            sb.AppendLine($"and ir.ReceiptType in (10,130,132)");
            sb.AppendLine($"");
            sb.AppendLine($"");
            // sb.AppendLine($"and cast(ir.ReceiptDate as date) = cast((GETDATE()-1) as date) -- tarih");
            sb.AppendLine($"");
            sb.AppendLine($"group by grupkodu.Explanation ");
            sb.AppendLine($"");
            sb.AppendLine($"order by grupkodu.Explanation");

            return sb.ToString();
        }


    }
}
