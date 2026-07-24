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

        public async Task<SentezIntegrationsResponsoDto<AdminDahboardLast7DaysStock>?> GetLas30DaysProductionAsync()
        {
            var query = BuildProductionLast30Query();
            return await _service.ExecuteQueryAsync<AdminDahboardLast7DaysStock>(query);
        }


        public async Task<SentezIntegrationsResponsoDto<SentezProductionDto>?> GetRawMaterielsPreviousDayStockAsync()
        {
            var query = BuildRawMaterielsPreviousDayStockQuery();
            return await _service.ExecuteQueryAsync<SentezProductionDto>(query);
        }



        public async Task<SentezIntegrationsResponsoDto<SentezProductionDto>?> GetRawMaterielsStockAsync()
        {
            var query = BuildRawMaterielsStockQuery();
            return await _service.ExecuteQueryAsync<SentezProductionDto>(query);
        }

        private string BuildRawMaterielsStockQuery()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"select ");
            sb.AppendLine($"");
            sb.AppendLine($"a.Explanation as [PapperType]");
            sb.AppendLine($",sum(a.Satıs) as [Production]");
            sb.AppendLine($",SUM(a.İade) as [Consumable]");
            sb.AppendLine($",SUM(a.Stok) as [Remaning]");
            sb.AppendLine($"");
            sb.AppendLine($"");
            sb.AppendLine($"from (");
            sb.AppendLine($"");
            sb.AppendLine($"select");
            sb.AppendLine($"'Yıllık' Tip");
            sb.AppendLine($",4 Type");
            sb.AppendLine($",CONVERT(VARCHAR, DATEADD(YEAR, DATEDIFF(YEAR, 0, GETDATE() - 1), 0), 104) +' - '+ CONVERT(VARCHAR, GETDATE() - 1, 104) Tarih");
            sb.AppendLine($",i.InventoryName as Explanation ");
            sb.AppendLine($"");
            sb.AppendLine($",isnull(YSATİS.Quantity,0) Satıs");
            sb.AppendLine($",isnull(YİADE.Quantity,0) İade");
            sb.AppendLine($",isnull(YSATİS.Quantity,0)-isnull(YİADE.Quantity,0) Stok");
            sb.AppendLine($"");
            sb.AppendLine($"from  Erp_Inventory i with(nolock)");
            sb.AppendLine($"outer apply (select top 1 Explanation from Meta_DataFieldValue where FieldId = 223 and isnull(CodeValue,'') = isnull(i.UD_InventoryGroup,'')) grupkodu");
            sb.AppendLine($"outer apply (select sum(iri.Quantity) Quantity from Erp_InventoryReceiptItem iri with(nolock)");
            sb.AppendLine($"	left join Erp_InventoryReceipt ir with(nolock) on ir.RecId = iri.InventoryReceiptId");
            sb.AppendLine($"	left join Erp_Inventory iss with(nolock) on iss.RecId = iri.InventoryId");
            sb.AppendLine($"	where ir.CompanyId = 22 and isnull(ir.IsCancelled,0) = 0 and isnull(ir.IsApproved,1) = 1");
            sb.AppendLine($"	and isnull(iri.IsCancelled,0) = 0 and isnull(iri.IsApproved,1) = 1");
            sb.AppendLine($"	and ISNULL(ir.IsTransportReceipt,0)=0 and ir.ReceiptType in (1)");
            sb.AppendLine($"	AND ir.ReceiptDate >= '2025-01-01'--DATEADD(YEAR, DATEDIFF(YEAR, 0, GETDATE() - 1), 0)");
            sb.AppendLine($"	AND ir.ReceiptDate < CAST(GETDATE() AS DATE)");
            sb.AppendLine($"	and ir.RecId not in (365137,354647,364242,364243,364874,365112,365336,365342,368546)");
            sb.AppendLine($"	and iss.InventoryCode=i.InventoryCode");
            sb.AppendLine($") YSATİS");
            sb.AppendLine($"");
            sb.AppendLine($"outer apply (select sum(iri.Quantity) Quantity from Erp_InventoryReceiptItem iri with(nolock)");
            sb.AppendLine($"	left join Erp_InventoryReceipt ir with(nolock) on ir.RecId = iri.InventoryReceiptId");
            sb.AppendLine($"	left join Erp_Inventory iss with(nolock) on iss.RecId = iri.InventoryId");
            sb.AppendLine($"	where ir.CompanyId = 22 and isnull(ir.IsCancelled,0) = 0 and isnull(ir.IsApproved,1) = 1");
            sb.AppendLine($"	and isnull(iri.IsCancelled,0) = 0 and isnull(iri.IsApproved,1) = 1");
            sb.AppendLine($"	and ISNULL(ir.IsTransportReceipt,0)=0 and ir.ReceiptType in (122)");
            sb.AppendLine($"	AND ir.ReceiptDate >= '2025-01-01'--DATEADD(YEAR, DATEDIFF(YEAR, 0, GETDATE() - 1), 0)");
            sb.AppendLine($"	AND ir.ReceiptDate < CAST(GETDATE() AS DATE)");
            sb.AppendLine($"	and ir.RecId not in (365137,354647,364242,364243,364874,365112,365336,365342,368546)");
            sb.AppendLine($"	and iss.InventoryCode=i.InventoryCode");
            sb.AppendLine($"");
            sb.AppendLine($") YİADE");
            sb.AppendLine($"");
            sb.AppendLine($"");
            sb.AppendLine($"where i.CompanyId = 22 and i.InventoryCode like '101%' --and isc.SerialCode not like 'E%'");
            sb.AppendLine($"group by  grupkodu.Explanation ,isnull(YSATİS.Quantity,0),isnull(YİADE.Quantity,0),isnull(YSATİS.Quantity,0)-isnull(YİADE.Quantity,0),i.InventoryName ");
            sb.AppendLine($"");
            sb.AppendLine($")a");
            sb.AppendLine($"");
            sb.AppendLine($"group by a.Explanation");
            sb.AppendLine($"having sum(a.Stok) != 0");
            sb.AppendLine($"");

            return sb.ToString();
        }

        private string BuildRawMaterielsPreviousDayStockQuery()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"select ");
            sb.AppendLine($"");
            sb.AppendLine($"a.Explanation as [PapperType]");
            sb.AppendLine($",sum(a.Satıs) as [Production]");
            sb.AppendLine($",SUM(a.İade) as [Consumable]");
            sb.AppendLine($",SUM(a.Stok) as [Remaning]");
            sb.AppendLine($"");
            sb.AppendLine($"");
            sb.AppendLine($"from (");
            sb.AppendLine($"");
            sb.AppendLine($"select");
            sb.AppendLine($"'Yıllık' Tip");
            sb.AppendLine($",4 Type");
            sb.AppendLine($",CONVERT(VARCHAR, DATEADD(YEAR, DATEDIFF(YEAR, 0, GETDATE() - 1), 0), 104) +' - '+ CONVERT(VARCHAR, GETDATE() - 1, 104) Tarih");
            sb.AppendLine($",i.InventoryName as Explanation ");
            sb.AppendLine($"");
            sb.AppendLine($",isnull(YSATİS.Quantity,0) Satıs");
            sb.AppendLine($",isnull(YİADE.Quantity,0) İade");
            sb.AppendLine($",isnull(YSATİS.Quantity,0)-isnull(YİADE.Quantity,0) Stok");
            sb.AppendLine($"");
            sb.AppendLine($"from  Erp_Inventory i with(nolock)");
            sb.AppendLine($"outer apply (select top 1 Explanation from Meta_DataFieldValue where FieldId = 223 and isnull(CodeValue,'') = isnull(i.UD_InventoryGroup,'')) grupkodu");
            sb.AppendLine($"outer apply (select sum(iri.Quantity) Quantity from Erp_InventoryReceiptItem iri with(nolock)");
            sb.AppendLine($"	left join Erp_InventoryReceipt ir with(nolock) on ir.RecId = iri.InventoryReceiptId");
            sb.AppendLine($"	left join Erp_Inventory iss with(nolock) on iss.RecId = iri.InventoryId");
            sb.AppendLine($"	where ir.CompanyId = 22 and isnull(ir.IsCancelled,0) = 0 and isnull(ir.IsApproved,1) = 1");
            sb.AppendLine($"	and isnull(iri.IsCancelled,0) = 0 and isnull(iri.IsApproved,1) = 1");
            sb.AppendLine($"	and ISNULL(ir.IsTransportReceipt,0)=0 and ir.ReceiptType in (1)");
            sb.AppendLine($"	AND convert(Date, ir.ReceiptDate)= convert(Date ,GETDATE() - 1)");
            sb.AppendLine($"	and ir.RecId not in (365137,354647,364242,364243,364874,365112,365336,365342,368546)");
            sb.AppendLine($"	and iss.InventoryCode=i.InventoryCode");
            sb.AppendLine($") YSATİS");
            sb.AppendLine($"");
            sb.AppendLine($"outer apply (select sum(iri.Quantity) Quantity from Erp_InventoryReceiptItem iri with(nolock)");
            sb.AppendLine($"	left join Erp_InventoryReceipt ir with(nolock) on ir.RecId = iri.InventoryReceiptId");
            sb.AppendLine($"	left join Erp_Inventory iss with(nolock) on iss.RecId = iri.InventoryId");
            sb.AppendLine($"	where ir.CompanyId = 22 and isnull(ir.IsCancelled,0) = 0 and isnull(ir.IsApproved,1) = 1");
            sb.AppendLine($"	and isnull(iri.IsCancelled,0) = 0 and isnull(iri.IsApproved,1) = 1");
            sb.AppendLine($"	and ISNULL(ir.IsTransportReceipt,0)=0 and ir.ReceiptType in (122)");
            sb.AppendLine($"	AND convert(Date, ir.ReceiptDate) = convert(Date ,GETDATE() - 1)");
            sb.AppendLine($"	and ir.RecId not in (365137,354647,364242,364243,364874,365112,365336,365342,368546)");
            sb.AppendLine($"	and iss.InventoryCode=i.InventoryCode");
            sb.AppendLine($"");
            sb.AppendLine($") YİADE");
            sb.AppendLine($"");
            sb.AppendLine($"");
            sb.AppendLine($"where i.CompanyId = 22 and i.InventoryCode like '101%' --and isc.SerialCode not like 'E%'");
            sb.AppendLine($"group by  grupkodu.Explanation ,isnull(YSATİS.Quantity,0),isnull(YİADE.Quantity,0),isnull(YSATİS.Quantity,0)-isnull(YİADE.Quantity,0),i.InventoryName ");
            sb.AppendLine($"");
            sb.AppendLine($")a");
            sb.AppendLine($"");
            sb.AppendLine($"group by a.Explanation");
            sb.AppendLine($"having sum(a.Stok) != 0");
            sb.AppendLine($"");

            return sb.ToString();
        }
        private string BuildProductionQuery()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"select ");
            sb.AppendLine($"isnull(ir.ReceiptDate,'-') [Date]");
            sb.AppendLine($",sum(case when ir.ReceiptType > 100 then (ist.Quantity) else 0 end) [Consumable]");
            sb.AppendLine($",sum(case When ir.ReceiptType < 100 then (ist.Quantity) else 0 end) [Production]");
            sb.AppendLine($",sum(case When ir.ReceiptType < 100 then (ist.Quantity) else 0 end)-sum(case when ir.ReceiptType > 100 then (ist.Quantity) else 0 end) [Remaning]");
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
            sb.AppendLine($"and isnull(ir.IsCancelled,0 ) = 0 and isnull(ir.IsApproved,1) = 1");
            sb.AppendLine($"and isnull(iri.IsCancelled,0) = 0 and isnull(iri.IsApproved,1) = 1");
            sb.AppendLine($"and ISNULL(ir.IsTransportReceipt,0)=0");
            sb.AppendLine($"and ir.ReceiptType in (10,18,130,132) --and ir.DocumentNo is null");
            sb.AppendLine($"");
            sb.AppendLine($"");
            sb.AppendLine($"and cast(ir.ReceiptDate as date) >= cast(DATEADD(day, -7, GETDATE()) as date) -- tarih");
            sb.AppendLine($"");
            sb.AppendLine($"group by ir.ReceiptDate ");
            sb.AppendLine($"");
            sb.AppendLine($"order by ir.ReceiptDate ");
            return sb.ToString();
        }

        private string BuildProductionLast30Query()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"select ");
            sb.AppendLine($"isnull(ir.ReceiptDate,'-') [Date]");
            sb.AppendLine($",sum(case when ir.ReceiptType > 100 then (ist.Quantity) else 0 end) [Consumable]");
            sb.AppendLine($",sum(case When ir.ReceiptType < 100 then (ist.Quantity) else 0 end) [Production]");
            sb.AppendLine($",sum(case When ir.ReceiptType < 100 then (ist.Quantity) else 0 end)-sum(case when ir.ReceiptType > 100 then (ist.Quantity) else 0 end) [Remaning]");
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
            sb.AppendLine($"and isnull(ir.IsCancelled,0 ) = 0 and isnull(ir.IsApproved,1) = 1");
            sb.AppendLine($"and isnull(iri.IsCancelled,0) = 0 and isnull(iri.IsApproved,1) = 1");
            sb.AppendLine($"and ISNULL(ir.IsTransportReceipt,0)=0");
            sb.AppendLine($"and ir.ReceiptType in (10,18,130,132) --and ir.DocumentNo is null");
            sb.AppendLine($"");
            sb.AppendLine($"");
            sb.AppendLine($"AND ir.ReceiptDate >= DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1) AND ir.ReceiptDate <= CAST(GETDATE() AS DATE)");
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
            sb.AppendLine($"");
            sb.AppendLine($"a.Explanation as [PapperType]");
            sb.AppendLine($",sum(a.Satıs) as [Production]");
            sb.AppendLine($",SUM(a.İade) as [Consumable]");
            sb.AppendLine($",SUM(a.Stok) as [Remaning]");
            sb.AppendLine($"");
            sb.AppendLine($"");
            sb.AppendLine($"from (");
            sb.AppendLine($"");
            sb.AppendLine($"select");
            sb.AppendLine($"'Yıllık' Tip");
            sb.AppendLine($",4 Type");
            sb.AppendLine($",CONVERT(VARCHAR, DATEADD(YEAR, DATEDIFF(YEAR, 0, GETDATE() - 1), 0), 104) +' - '+ CONVERT(VARCHAR, GETDATE() - 1, 104) Tarih");
            sb.AppendLine($",grupkodu.Explanation ");
            sb.AppendLine($"");
            sb.AppendLine($",isnull(YSATİS.Quantity,0) Satıs");
            sb.AppendLine($",isnull(YİADE.Quantity,0) İade");
            sb.AppendLine($",isnull(YSATİS.Quantity,0)-isnull(YİADE.Quantity,0) Stok");
            sb.AppendLine($"");
            sb.AppendLine($"from  Erp_Inventory i with(nolock)");
            sb.AppendLine($"outer apply (select top 1 Explanation from Meta_DataFieldValue where FieldId = 223 and isnull(CodeValue,'') = isnull(i.UD_InventoryGroup,'')) grupkodu");
            sb.AppendLine($"");
            sb.AppendLine($"");
            sb.AppendLine($"outer apply (select sum(iri.Quantity) Quantity from Erp_InventoryReceiptItem iri with(nolock)");
            sb.AppendLine($"	left join Erp_InventoryReceipt ir with(nolock) on ir.RecId = iri.InventoryReceiptId");
            sb.AppendLine($"	left join Erp_Inventory iss with(nolock) on iss.RecId = iri.InventoryId");
            sb.AppendLine($"	--outer apply (select top 1 Explanation from Meta_DataFieldValue where FieldId = 223 and isnull(CodeValue,'') = isnull(iss.UD_InventoryGroup,'')) grupkoduSatıs");
            sb.AppendLine($"	where ir.CompanyId = 44 and isnull(ir.IsCancelled,0) = 0 and isnull(ir.IsApproved,1) = 1");
            sb.AppendLine($"	and isnull(iri.IsCancelled,0) = 0 and isnull(iri.IsApproved,1) = 1");
            sb.AppendLine($"	and ISNULL(ir.IsTransportReceipt,0)=0 and ir.ReceiptType in (120)");
            sb.AppendLine($"	AND ir.ReceiptDate >= '2025-01-01'--DATEADD(YEAR, DATEDIFF(YEAR, 0, GETDATE() - 1), 0)");
            sb.AppendLine($"	AND ir.ReceiptDate < CAST(GETDATE() AS DATE)");
            sb.AppendLine($"	and ir.RecId not in (365137,354647,364242,364243,364874,365112,365336,365342,368546)");
            sb.AppendLine($"	--and isnull(grupkoduSatıs.Explanation,'')=isnull(grupkodu.Explanation,'')");
            sb.AppendLine($"	and iss.InventoryCode=i.InventoryCode");
            sb.AppendLine($") YSATİS");
            sb.AppendLine($"outer apply (select sum(iri.Quantity) Quantity from Erp_InventoryReceiptItem iri with(nolock)");
            sb.AppendLine($"	left join Erp_InventoryReceipt ir with(nolock) on ir.RecId = iri.InventoryReceiptId");
            sb.AppendLine($"	left join Erp_Inventory iss with(nolock) on iss.RecId = iri.InventoryId");
            sb.AppendLine($"	--outer apply (select top 1 Explanation from Meta_DataFieldValue where FieldId = 223 and isnull(CodeValue,'') = isnull(iss.UD_InventoryGroup,'')) grupkoduIade");
            sb.AppendLine($"	where ir.CompanyId = 44 and isnull(ir.IsCancelled,0) = 0 and isnull(ir.IsApproved,1) = 1");
            sb.AppendLine($"	and isnull(iri.IsCancelled,0) = 0 and isnull(iri.IsApproved,1) = 1");
            sb.AppendLine($"	and ISNULL(ir.IsTransportReceipt,0)=0 and ir.ReceiptType in (3)");
            sb.AppendLine($"	AND ir.ReceiptDate >= '2025-01-01'--DATEADD(YEAR, DATEDIFF(YEAR, 0, GETDATE() - 1), 0)");
            sb.AppendLine($"	AND ir.ReceiptDate < CAST(GETDATE() AS DATE)");
            sb.AppendLine($"	and ir.RecId not in (365137,354647,364242,364243,364874,365112,365336,365342,368546)");
            sb.AppendLine($"	--and isnull(grupkoduIade.Explanation,'')=isnull(grupkodu.Explanation,'')");
            sb.AppendLine($"	and iss.InventoryCode=i.InventoryCode");
            sb.AppendLine($"");
            sb.AppendLine($") YİADE");
            sb.AppendLine($"");
            sb.AppendLine($"");
            sb.AppendLine($"where i.CompanyId = 44 and i.InventoryCode like '9%' --and isc.SerialCode not like 'E%'");
            sb.AppendLine($"group by  grupkodu.Explanation ,isnull(YSATİS.Quantity,0),isnull(YİADE.Quantity,0),isnull(YSATİS.Quantity,0)-isnull(YİADE.Quantity,0)");
            sb.AppendLine($"");
            sb.AppendLine($")a");
            sb.AppendLine($"");
            sb.AppendLine($"group by a.Explanation");
            sb.AppendLine($"having sum(a.Stok) != 0");
            sb.AppendLine($"");

            return sb.ToString();
        }

        private string BuildPreviousDaySalesQuery()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"select ");
            sb.AppendLine($"");
            sb.AppendLine($"a.Explanation as [PapperType]");
            sb.AppendLine($",sum(a.Satıs) as [Production]");
            sb.AppendLine($",SUM(a.İade) as [Consumable]");
            sb.AppendLine($",SUM(a.Stok) as [Remaning]");
            sb.AppendLine($"");
            sb.AppendLine($"");
            sb.AppendLine($"from (");
            sb.AppendLine($"");
            sb.AppendLine($"select");
            sb.AppendLine($"'Yıllık' Tip");
            sb.AppendLine($",4 Type");
            sb.AppendLine($",CONVERT(VARCHAR, DATEADD(YEAR, DATEDIFF(YEAR, 0, GETDATE() - 1), 0), 104) +' - '+ CONVERT(VARCHAR, GETDATE() - 1, 104) Tarih");
            sb.AppendLine($",grupkodu.Explanation ");
            sb.AppendLine($"");
            sb.AppendLine($",isnull(YSATİS.Quantity,0) Satıs");
            sb.AppendLine($",isnull(YİADE.Quantity,0) İade");
            sb.AppendLine($",isnull(YSATİS.Quantity,0)-isnull(YİADE.Quantity,0) Stok");
            sb.AppendLine($"");
            sb.AppendLine($"from  Erp_Inventory i with(nolock)");
            sb.AppendLine($"outer apply (select top 1 Explanation from Meta_DataFieldValue where FieldId = 223 and isnull(CodeValue,'') = isnull(i.UD_InventoryGroup,'')) grupkodu");
            sb.AppendLine($"outer apply (select sum(iri.Quantity) Quantity from Erp_InventoryReceiptItem iri with(nolock)");
            sb.AppendLine($"	left join Erp_InventoryReceipt ir with(nolock) on ir.RecId = iri.InventoryReceiptId");
            sb.AppendLine($"	left join Erp_Inventory iss with(nolock) on iss.RecId = iri.InventoryId");
            sb.AppendLine($"	where ir.CompanyId = 44 and isnull(ir.IsCancelled,0) = 0 and isnull(ir.IsApproved,1) = 1");
            sb.AppendLine($"	and isnull(iri.IsCancelled,0) = 0 and isnull(iri.IsApproved,1) = 1");
            sb.AppendLine($"	and ISNULL(ir.IsTransportReceipt,0)=0 and ir.ReceiptType in (120)");
            sb.AppendLine($"	AND convert(Date, ir.ReceiptDate)= convert(Date ,GETDATE() - 1)");
            sb.AppendLine($"	and ir.RecId not in (365137,354647,364242,364243,364874,365112,365336,365342,368546)");
            sb.AppendLine($"	and iss.InventoryCode=i.InventoryCode");
            sb.AppendLine($") YSATİS");
            sb.AppendLine($"");
            sb.AppendLine($"outer apply (select sum(iri.Quantity) Quantity from Erp_InventoryReceiptItem iri with(nolock)");
            sb.AppendLine($"	left join Erp_InventoryReceipt ir with(nolock) on ir.RecId = iri.InventoryReceiptId");
            sb.AppendLine($"	left join Erp_Inventory iss with(nolock) on iss.RecId = iri.InventoryId");
            sb.AppendLine($"	where ir.CompanyId = 44 and isnull(ir.IsCancelled,0) = 0 and isnull(ir.IsApproved,1) = 1");
            sb.AppendLine($"	and isnull(iri.IsCancelled,0) = 0 and isnull(iri.IsApproved,1) = 1");
            sb.AppendLine($"	and ISNULL(ir.IsTransportReceipt,0)=0 and ir.ReceiptType in (3)");
            sb.AppendLine($"	AND convert(Date, ir.ReceiptDate) = convert(Date ,GETDATE() - 1)");
            sb.AppendLine($"	and ir.RecId not in (365137,354647,364242,364243,364874,365112,365336,365342,368546)");
            sb.AppendLine($"	and iss.InventoryCode=i.InventoryCode");
            sb.AppendLine($"");
            sb.AppendLine($") YİADE");
            sb.AppendLine($"");
            sb.AppendLine($"");
            sb.AppendLine($"where i.CompanyId = 44 and i.InventoryCode like '9%' --and isc.SerialCode not like 'E%'");
            sb.AppendLine($"group by  grupkodu.Explanation ,isnull(YSATİS.Quantity,0),isnull(YİADE.Quantity,0),isnull(YSATİS.Quantity,0)-isnull(YİADE.Quantity,0)");
            sb.AppendLine($"");
            sb.AppendLine($")a");
            sb.AppendLine($"");
            sb.AppendLine($"group by a.Explanation");
            sb.AppendLine($"having sum(a.Stok) != 0");

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
            sb.AppendLine($"a.Explanation as [PapperType]");
            sb.AppendLine($",sum(a.Üretim) as [Production]");
            sb.AppendLine($",SUM(a.Sevk) as [Consumable]");
            sb.AppendLine($",SUM(a.Stok) as [Remaning]");
            sb.AppendLine($"");
            sb.AppendLine($"");
            sb.AppendLine($"from (");
            sb.AppendLine($"");
            sb.AppendLine($"select");
            sb.AppendLine($"'Yıllık' Tip");
            sb.AppendLine($",4 Type");
            sb.AppendLine($",CONVERT(VARCHAR, DATEADD(YEAR, DATEDIFF(YEAR, 0, GETDATE() - 1), 0), 104) +' - '+ CONVERT(VARCHAR, GETDATE() - 1, 104) Tarih");
            sb.AppendLine($",grupkodu.Explanation ");
            sb.AppendLine($",sum(isnull(YURETIM.Quantity,0) - isnull(YTUKETIM.Quantity,0)) Üretim");
            sb.AppendLine($",(isnull(YSATİS.Quantity,0)-isnull(YİADE.Quantity,0)) Sevk");
            sb.AppendLine($",sum(isnull(YURETIM.Quantity,0) - isnull(YTUKETIM.Quantity,0))-(isnull(YSATİS.Quantity,0) -  isnull(YİADE.Quantity,0)) Stok");
            sb.AppendLine($"");
            sb.AppendLine($"from Erp_InventorySerialCard isc with(nolock)");
            sb.AppendLine($"left join Erp_Inventory i with(nolock) on i.RecId = isc.InventoryId");
            sb.AppendLine($"outer apply (select top 1 Explanation from Meta_DataFieldValue where FieldId = 223 and isnull(CodeValue,'') = isnull(i.UD_InventoryGroup,'')) grupkodu");
            sb.AppendLine($"outer apply (select sum(ist.Quantity) Quantity from Erp_InventorySerialTransaction ist with(nolock)");
            sb.AppendLine($"	left join Erp_InventoryReceiptItem iri with(nolock) on iri.RecId = ist.ReceiptItemId");
            sb.AppendLine($"	left join Erp_InventoryReceipt ir with(nolock) on ir.RecId = iri.InventoryReceiptId");
            sb.AppendLine($"	where ist.SerialCardId = isc.RecId and isnull(ir.IsCancelled,0) = 0 and isnull(ir.IsApproved,1) = 1");
            sb.AppendLine($"	and isnull(iri.IsCancelled,0) = 0 and isnull(iri.IsApproved,1) = 1");
            sb.AppendLine($"	and ISNULL(ir.IsTransportReceipt,0)=0 and ir.ReceiptType in (10,18)");
            sb.AppendLine($"	AND ir.ReceiptDate >= '2025-01-01'--DATEADD(YEAR, DATEDIFF(YEAR, 0, GETDATE() - 1), 0)");
            sb.AppendLine($"	AND ir.ReceiptDate < CAST(GETDATE() AS DATE)");
            sb.AppendLine($"	and ir.RecId not in (365137,354647,364242,364243,364874,365112,365336,365342,368546)");
            sb.AppendLine($") YURETIM");
            sb.AppendLine($"outer apply (select sum(ist.Quantity) Quantity from Erp_InventorySerialTransaction ist with(nolock)");
            sb.AppendLine($"	left join Erp_InventoryReceiptItem iri with(nolock) on iri.RecId = ist.ReceiptItemId");
            sb.AppendLine($"	left join Erp_InventoryReceipt ir with(nolock) on ir.RecId = iri.InventoryReceiptId");
            sb.AppendLine($"	where ist.SerialCardId = isc.RecId and isnull(ir.IsCancelled,0) = 0 and isnull(ir.IsApproved,1) = 1");
            sb.AppendLine($"	and isnull(iri.IsCancelled,0) = 0 and isnull(iri.IsApproved,1) = 1");
            sb.AppendLine($"	and ISNULL(ir.IsTransportReceipt,0)=0 and ir.ReceiptType in (130,132)");
            sb.AppendLine($"	AND ir.ReceiptDate >='2025-01-01'-- DATEADD(YEAR, DATEDIFF(YEAR, 0, GETDATE() - 1), 0)");
            sb.AppendLine($"	AND ir.ReceiptDate < CAST(GETDATE() AS DATE)");
            sb.AppendLine($"	and ir.RecId not in (365137,354647,364242,364243,364874,365112,365336,365342,368546)");
            sb.AppendLine($") YTUKETIM");
            sb.AppendLine($"outer apply (select sum(iri.Quantity) Quantity from Erp_InventoryReceiptItem iri with(nolock)");
            sb.AppendLine($"	left join Erp_InventoryReceipt ir with(nolock) on ir.RecId = iri.InventoryReceiptId");
            sb.AppendLine($"	left join Erp_Inventory iss with(nolock) on iss.RecId = iri.InventoryId");
            sb.AppendLine($"	--outer apply (select top 1 Explanation from Meta_DataFieldValue where FieldId = 223 and isnull(CodeValue,'') = isnull(iss.UD_InventoryGroup,'')) grupkoduSatıs");
            sb.AppendLine($"	where ir.CompanyId = 44 and isnull(ir.IsCancelled,0) = 0 and isnull(ir.IsApproved,1) = 1");
            sb.AppendLine($"	and isnull(iri.IsCancelled,0) = 0 and isnull(iri.IsApproved,1) = 1");
            sb.AppendLine($"	and ISNULL(ir.IsTransportReceipt,0)=0 and ir.ReceiptType in (120)");
            sb.AppendLine($"	AND ir.ReceiptDate >= '2025-01-01'--DATEADD(YEAR, DATEDIFF(YEAR, 0, GETDATE() - 1), 0)");
            sb.AppendLine($"	AND ir.ReceiptDate < CAST(GETDATE() AS DATE)");
            sb.AppendLine($"	and ir.RecId not in (365137,354647,364242,364243,364874,365112,365336,365342,368546)");
            sb.AppendLine($"	--and isnull(grupkoduSatıs.Explanation,'')=isnull(grupkodu.Explanation,'')");
            sb.AppendLine($"	and iss.InventoryCode=i.InventoryCode");
            sb.AppendLine($") YSATİS");
            sb.AppendLine($"outer apply (select sum(iri.Quantity) Quantity from Erp_InventoryReceiptItem iri with(nolock)");
            sb.AppendLine($"	left join Erp_InventoryReceipt ir with(nolock) on ir.RecId = iri.InventoryReceiptId");
            sb.AppendLine($"	left join Erp_Inventory iss with(nolock) on iss.RecId = iri.InventoryId");
            sb.AppendLine($"	--outer apply (select top 1 Explanation from Meta_DataFieldValue where FieldId = 223 and isnull(CodeValue,'') = isnull(iss.UD_InventoryGroup,'')) grupkoduIade");
            sb.AppendLine($"	where ir.CompanyId = 44 and isnull(ir.IsCancelled,0) = 0 and isnull(ir.IsApproved,1) = 1");
            sb.AppendLine($"	and isnull(iri.IsCancelled,0) = 0 and isnull(iri.IsApproved,1) = 1");
            sb.AppendLine($"	and ISNULL(ir.IsTransportReceipt,0)=0 and ir.ReceiptType in (3)");
            sb.AppendLine($"	AND ir.ReceiptDate >= '2025-01-01'--DATEADD(YEAR, DATEDIFF(YEAR, 0, GETDATE() - 1), 0)");
            sb.AppendLine($"	AND ir.ReceiptDate < CAST(GETDATE() AS DATE)");
            sb.AppendLine($"	and ir.RecId not in (365137,354647,364242,364243,364874,365112,365336,365342,368546)");
            sb.AppendLine($"	--and isnull(grupkoduIade.Explanation,'')=isnull(grupkodu.Explanation,'')");
            sb.AppendLine($"	and iss.InventoryCode=i.InventoryCode");
            sb.AppendLine($"");
            sb.AppendLine($") YİADE");
            sb.AppendLine($"");
            sb.AppendLine($"");
            sb.AppendLine($"where isc.CompanyId = 22 and i.InventoryCode like '9%' --and isc.SerialCode not like 'E%'");
            sb.AppendLine($"group by  grupkodu.Explanation ,");
            sb.AppendLine($"(isnull(YSATİS.Quantity,0)-isnull(YİADE.Quantity,0))  ");
            sb.AppendLine($")a");
            sb.AppendLine($"");
            sb.AppendLine($"group by a.Explanation");

            return sb.ToString();
        }

        public async Task<SentezUpdateResponseDto?> InsertMachineRandoman(double workhours)
        {
            double efficiency = (((workhours * 60) / 1440) * 100);

            var sb = new StringBuilder();
            sb.AppendLine("INSERT INTO Erp_ResourceAttribute");
            sb.AppendLine("(");
            sb.AppendLine("    ResourceId,");
            sb.AppendLine("    UD_Date,");
            sb.AppendLine("    UD_WorkHours,");
            sb.AppendLine("    UD_Efficiency");
            sb.AppendLine(")");
            sb.AppendLine("VALUES");
            sb.AppendLine("(");
            sb.AppendLine("    385,");
            sb.AppendLine("    GETDATE(),");
            sb.AppendLine($"    {workhours},");
            sb.AppendLine($"    {efficiency}");
            sb.AppendLine(");");


            string query = sb.ToString();

            var result = await _service.ExecuteUpdateQueryAsync(query);

            if (result == null || !result.IsOk)
            {
                throw new Exception($"Sentez insert başarısız: {result?.ErrorMessage ?? "Bilinmeyen hata"} (Kod: {result?.ErrorCode})");
            }

            return result;
        }


    }
}
