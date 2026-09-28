using BusinessLayer.Abstract;
using BusinessLayer.Abstract.Integrations;
using DTOLayer.Dtos.AdminDashboardDtos;
using DTOLayer.Dtos.SentezIntegrationsDtos;
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

        public async Task<SentezIntegrationsResponsoDto<SentezProductionDto>?> GetStockWithByDateRange(DateTime startDate, DateTime endDate)
        {
            var query = BuildStockGetbyDateQuery(startDate, endDate);
            return await _service.ExecuteQueryAsync<SentezProductionDto>(query);

        }

        public async Task<SentezIntegrationsResponsoDto<SentezSalesResponseDto>?> GetPreviousDaySalesAsync()
        {
            var query = BuildPreviousDaySalesQuery();
            return await _service.ExecuteQueryAsync<SentezSalesResponseDto>(query);
        }

        public async Task<SentezIntegrationsResponsoDto<SentezSalesResponseDto>?> GetSalesAsync()
        {
            var query = BuildSalesQuery();
            return await _service.ExecuteQueryAsync<SentezSalesResponseDto>(query);
        }

        public async Task<SentezIntegrationsResponsoDto<SentezSalesResponseDto>?> GetSalesGetbyDateAsync(DateTime startDate, DateTime endDate)
        {
            var query = BuildSalesGetbyDateQuery(startDate, endDate);
            return await _service.ExecuteQueryAsync<SentezSalesResponseDto>(query);
        }

        public async Task<SentezIntegrationsResponsoDto<AdminDahboardDaysStock>?> GetLas7DaysProductionAsync(DateTime? startDate, DateTime? endDate)
        {
            if (startDate == null)
            {
                startDate = DateTime.Now.AddDays(-7);
            }
            if (endDate == null)
            {
                endDate = DateTime.Now;
            }
            var query = BuildLast7DaysProductionQuery(startDate.Value, endDate.Value);
            return await _service.ExecuteQueryAsync<AdminDahboardDaysStock>(query);
        }

        public async Task<SentezIntegrationsResponsoDto<AdminDashboardSales>?> GetLas7DaysSalesAsync(DateTime? startDate, DateTime? endDate)
        {
            if (startDate == null)
            {
                startDate = DateTime.Now.AddDays(-7);
            }
            if (endDate == null)
            {
                endDate = DateTime.Now;
            }
            var query = BuildLast7DaysSalesQuery(startDate.Value, endDate.Value);
            return await _service.ExecuteQueryAsync<AdminDashboardSales>(query);
        }

        public async Task<SentezIntegrationsResponsoDto<AdminDahboardDaysStock>?> GetLas7DaysRawMaterilsAsync(DateTime? startDate, DateTime? endDate)
        {
            if (startDate == null)
            {
                startDate = DateTime.Now.AddDays(-7);
            }
            if (endDate == null)
            {
                endDate = DateTime.Now;
            }
            var query = BuildLast7DaysRawMaterielsQuery(startDate.Value, endDate.Value);
            return await _service.ExecuteQueryAsync<AdminDahboardDaysStock>(query);
        }

        public async Task<SentezIntegrationsResponsoDto<AdminDahboardDaysStock>?> GetLas30DaysProductionAsync()
        {
            var query = BuildProductionLast30Query();
            return await _service.ExecuteQueryAsync<AdminDahboardDaysStock>(query);
        }

        public async Task<SentezIntegrationsResponsoDto<SentezIntegrationsGetStockByInventoryCode>?> GetStockByInventoryCode(string inventoryCode)
        {
            var query = BuildStockByInventoryCode(inventoryCode);
            return await _service.ExecuteQueryAsync<SentezIntegrationsGetStockByInventoryCode>(query);
        }

        public async Task<SentezIntegrationsResponsoDto<SentezIntegrationsGetStockByInventoryCode>?> GetStockByInventoryCodeAndWidthCM(string inventoryCode, double WidthCM)
        {
            var query = BuildStockByInventoryCodeAndWidthCM(inventoryCode, WidthCM);
            return await _service.ExecuteQueryAsync<SentezIntegrationsGetStockByInventoryCode>(query);
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
            sb.AppendLine($",CONVERT(VARCHAR, DATEADD(YEAR, DATEDIFF(YEAR, 0, GETDATE()), 0), 104) +' - '+ CONVERT(VARCHAR, GETDATE(), 104) Tarih");
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
            sb.AppendLine($"	where ir.CompanyId = 22 and isnull(ir.IsCancelled,0) = 0 ");
            sb.AppendLine($"	and isnull(iri.IsCancelled,0) = 0");
            sb.AppendLine($"	and ISNULL(ir.IsTransportReceipt,0)=0 and ir.ReceiptType in (1)");
            sb.AppendLine($"	AND ir.ReceiptDate >= '2025-01-01'--DATEADD(YEAR, DATEDIFF(YEAR, 0, GETDATE()), 0)");
            sb.AppendLine($"	AND ir.ReceiptDate < CAST(GETDATE() AS DATE)");
            sb.AppendLine($"	and ir.RecId not in (365137,354647,364242,364243,364874,365112,365336,365342,368546)");
            sb.AppendLine($"	and iss.InventoryCode=i.InventoryCode");
            sb.AppendLine($") YSATİS");
            sb.AppendLine($"");
            sb.AppendLine($"outer apply (select sum(iri.Quantity) Quantity from Erp_InventoryReceiptItem iri with(nolock)");
            sb.AppendLine($"	left join Erp_InventoryReceipt ir with(nolock) on ir.RecId = iri.InventoryReceiptId");
            sb.AppendLine($"	left join Erp_Inventory iss with(nolock) on iss.RecId = iri.InventoryId");
            sb.AppendLine($"	where ir.CompanyId = 22 and isnull(ir.IsCancelled,0) = 0 ");
            sb.AppendLine($"	and isnull(iri.IsCancelled,0) = 0");
            sb.AppendLine($"	and ISNULL(ir.IsTransportReceipt,0)=0 and ir.ReceiptType in (122)");
            sb.AppendLine($"	AND ir.ReceiptDate >= '2025-01-01'--DATEADD(YEAR, DATEDIFF(YEAR, 0, GETDATE()), 0)");
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
            sb.AppendLine($"	where ir.CompanyId = 22 and isnull(ir.IsCancelled,0) = 0 ");
            sb.AppendLine($"	and isnull(iri.IsCancelled,0) = 0 ");
            sb.AppendLine($"	and ISNULL(ir.IsTransportReceipt,0)=0 and ir.ReceiptType in (1)");
            sb.AppendLine($"	AND convert(Date, ir.ReceiptDate)= convert(Date ,GETDATE() - 1)");
            sb.AppendLine($"	and ir.RecId not in (365137,354647,364242,364243,364874,365112,365336,365342,368546)");
            sb.AppendLine($"	and iss.InventoryCode=i.InventoryCode");
            sb.AppendLine($") YSATİS");
            sb.AppendLine($"");
            sb.AppendLine($"outer apply (select sum(iri.Quantity) Quantity from Erp_InventoryReceiptItem iri with(nolock)");
            sb.AppendLine($"	left join Erp_InventoryReceipt ir with(nolock) on ir.RecId = iri.InventoryReceiptId");
            sb.AppendLine($"	left join Erp_Inventory iss with(nolock) on iss.RecId = iri.InventoryId");
            sb.AppendLine($"	where ir.CompanyId = 22 and isnull(ir.IsCancelled,0) = 0 ");
            sb.AppendLine($"	and isnull(iri.IsCancelled,0) = 0 ");
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

        private string BuildLast7DaysRawMaterielsQuery(DateTime startDate, DateTime endDate)
        {
            var sb = new StringBuilder();

            string startDateStr = startDate.ToString("yyyyMMdd");
            string endDateStr = endDate.ToString("yyyyMMdd");

            sb.AppendLine("SELECT");
            sb.AppendLine("    CONVERT(date, a.Tarih) AS Date,");
            sb.AppendLine("    SUM(a.Satis) AS Production,");
            sb.AppendLine("    SUM(a.Iade) AS Consumable,");
            sb.AppendLine("    SUM(a.Stok) AS Remaining");
            sb.AppendLine("FROM");
            sb.AppendLine("(");

            sb.AppendLine("    SELECT");
            sb.AppendLine("        YSATIS.Dates AS Tarih,");
            sb.AppendLine("        ISNULL(YSATIS.Quantity, 0) AS Satis,");
            sb.AppendLine("        ISNULL(YIADE.Quantity, 0) AS Iade,");
            sb.AppendLine("        ISNULL(YSATIS.Quantity, 0) - ISNULL(YIADE.Quantity, 0) AS Stok");

            sb.AppendLine("    FROM Erp_Inventory i WITH(NOLOCK)");

            // Üretim / Giriş
            sb.AppendLine("    OUTER APPLY");
            sb.AppendLine("    (");
            sb.AppendLine("        SELECT");
            sb.AppendLine("            CONVERT(date, ir.ReceiptDate) AS Dates,");
            sb.AppendLine("            SUM(iri.Quantity) AS Quantity");

            sb.AppendLine("        FROM Erp_InventoryReceiptItem iri WITH(NOLOCK)");

            sb.AppendLine("        INNER JOIN Erp_InventoryReceipt ir WITH(NOLOCK)");
            sb.AppendLine("            ON ir.RecId = iri.InventoryReceiptId");

            sb.AppendLine("        INNER JOIN Erp_Inventory iss WITH(NOLOCK)");
            sb.AppendLine("            ON iss.RecId = iri.InventoryId");

            sb.AppendLine("        WHERE ir.CompanyId = 22");
            sb.AppendLine("          AND ISNULL(ir.IsCancelled, 0) = 0");
            sb.AppendLine("          AND ISNULL(iri.IsCancelled, 0) = 0");
            sb.AppendLine("          AND ISNULL(ir.IsTransportReceipt, 0) = 0");
            sb.AppendLine("          AND ir.ReceiptType = 1");

            // Tarih
            sb.AppendLine($"          AND ir.ReceiptDate >= '{startDateStr}'");
            sb.AppendLine($"          AND ir.ReceiptDate < DATEADD(DAY, 1, '{endDateStr}')");

            sb.AppendLine("          AND ir.RecId NOT IN (365137,354647,364242,364243,364874,365112,365336,365342,368546)");
            sb.AppendLine("          AND iss.InventoryCode = i.InventoryCode");

            sb.AppendLine("        GROUP BY CONVERT(date, ir.ReceiptDate)");
            sb.AppendLine("    ) YSATIS");

            // Tüketim / İade
            sb.AppendLine("    OUTER APPLY");
            sb.AppendLine("    (");
            sb.AppendLine("        SELECT");
            sb.AppendLine("            CONVERT(date, ir.ReceiptDate) AS Dates,");
            sb.AppendLine("            SUM(iri.Quantity) AS Quantity");

            sb.AppendLine("        FROM Erp_InventoryReceiptItem iri WITH(NOLOCK)");

            sb.AppendLine("        INNER JOIN Erp_InventoryReceipt ir WITH(NOLOCK)");
            sb.AppendLine("            ON ir.RecId = iri.InventoryReceiptId");

            sb.AppendLine("        INNER JOIN Erp_Inventory iss WITH(NOLOCK)");
            sb.AppendLine("            ON iss.RecId = iri.InventoryId");

            sb.AppendLine("        WHERE ir.CompanyId = 22");
            sb.AppendLine("          AND ISNULL(ir.IsCancelled, 0) = 0");
            sb.AppendLine("          AND ISNULL(iri.IsCancelled, 0) = 0");
            sb.AppendLine("          AND ISNULL(ir.IsTransportReceipt, 0) = 0");
            sb.AppendLine("          AND ir.ReceiptType = 3");

            // Tarih
            sb.AppendLine($"          AND ir.ReceiptDate >= '{startDateStr}'");
            sb.AppendLine($"          AND ir.ReceiptDate < DATEADD(DAY, 1, '{endDateStr}')");

            sb.AppendLine("          AND ir.RecId NOT IN (365137,354647,364242,364243,364874,365112,365336,365342,368546)");
            sb.AppendLine("          AND iss.InventoryCode = i.InventoryCode");

            sb.AppendLine("        GROUP BY CONVERT(date, ir.ReceiptDate)");
            sb.AppendLine("    ) YIADE");

            sb.AppendLine("    WHERE i.CompanyId = 22");
            sb.AppendLine("      AND i.InventoryCode LIKE '101%'");

            sb.AppendLine(") a");

            sb.AppendLine("GROUP BY CONVERT(date, a.Tarih)");
            sb.AppendLine("HAVING SUM(a.Stok) <> 0");
            sb.AppendLine("ORDER BY Date;");

            return sb.ToString();
        }

        private string BuildLast7DaysProductionQuery(DateTime startDate, DateTime endDate)
        {
            var sb = new StringBuilder();

            int DateCount = (endDate - startDate).Days;

            string startDateStr = startDate.ToString("yyyyMMdd");
            string endDateStr = endDate.ToString("yyyyMMdd");

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
            sb.AppendLine($"  AND ir.ReceiptDate >= '{startDateStr}'");
            sb.AppendLine($"  AND ir.ReceiptDate < DATEADD(DAY, 1, '{endDateStr}')");
            sb.AppendLine($"and cast(ir.ReceiptDate as date) >= cast(DATEADD(day,-{DateCount}, GETDATE()) as date) -- tarih");
            sb.AppendLine($"");
            sb.AppendLine($"group by ir.ReceiptDate ");
            sb.AppendLine($"");
            sb.AppendLine($"order by ir.ReceiptDate ");
            return sb.ToString();
        }

        private string BuildLast7DaysSalesQuery(DateTime startDate, DateTime endDate)
        {
            var sb = new StringBuilder();

            string startDateStr = startDate.ToString("yyyyMMdd");
            string endDateStr = endDate.ToString("yyyyMMdd");

            sb.AppendLine("SELECT");
            sb.AppendLine("    CONVERT(date, a.Tarih) AS Date,");
            sb.AppendLine("    SUM(a.Satis) AS Sales,");
            sb.AppendLine("    SUM(a.Iade) AS [Return],");
            sb.AppendLine("    SUM(a.Stok) AS Stock");
            sb.AppendLine("FROM");
            sb.AppendLine("(");

            // SATIŞ
            sb.AppendLine("    SELECT");
            sb.AppendLine("        YSATIS.Dates AS Tarih,");
            sb.AppendLine("        ISNULL(YSATIS.Quantity, 0) AS Satis,");
            sb.AppendLine("        ISNULL(YIADE.Quantity, 0) AS Iade,");
            sb.AppendLine("        ISNULL(YSATIS.Quantity, 0) - ISNULL(YIADE.Quantity, 0) AS Stok");

            sb.AppendLine("    FROM Erp_Inventory i WITH(NOLOCK)");

            sb.AppendLine("    OUTER APPLY");
            sb.AppendLine("    (");
            sb.AppendLine("        SELECT");
            sb.AppendLine("            CONVERT(date, ir.ReceiptDate) AS Dates,");
            sb.AppendLine("            SUM(iri.Quantity) AS Quantity");
            sb.AppendLine("        FROM Erp_InventoryReceiptItem iri WITH(NOLOCK)");

            sb.AppendLine("        INNER JOIN Erp_InventoryReceipt ir WITH(NOLOCK)");
            sb.AppendLine("            ON ir.RecId = iri.InventoryReceiptId");

            sb.AppendLine("        INNER JOIN Erp_Inventory iss WITH(NOLOCK)");
            sb.AppendLine("            ON iss.RecId = iri.InventoryId");

            sb.AppendLine("        WHERE ir.CompanyId = 44");
            sb.AppendLine("          AND ISNULL(ir.IsCancelled, 0) = 0");
            sb.AppendLine("          AND ISNULL(ir.IsApproved, 1) = 1");
            sb.AppendLine("          AND ISNULL(iri.IsCancelled, 0) = 0");
            sb.AppendLine("          AND ISNULL(iri.IsApproved, 1) = 1");
            sb.AppendLine("          AND ISNULL(ir.IsTransportReceipt, 0) = 0");
            sb.AppendLine("          AND ir.ReceiptType = 120");

            // Tarih filtresi
            sb.AppendLine($"          AND ir.ReceiptDate >= '{startDateStr}'");
            sb.AppendLine($"          AND ir.ReceiptDate < DATEADD(DAY, 1, '{endDateStr}')");

            sb.AppendLine("          AND ir.RecId NOT IN (365137,354647,364242,364243,364874,365112,365336,365342,368546)");
            sb.AppendLine("          AND iss.InventoryCode = i.InventoryCode");

            sb.AppendLine("        GROUP BY CONVERT(date, ir.ReceiptDate)");
            sb.AppendLine("    ) YSATIS");

            // İADE
            sb.AppendLine("    OUTER APPLY");
            sb.AppendLine("    (");
            sb.AppendLine("        SELECT");
            sb.AppendLine("            CONVERT(date, ir.ReceiptDate) AS Dates,");
            sb.AppendLine("            SUM(iri.Quantity) AS Quantity");
            sb.AppendLine("        FROM Erp_InventoryReceiptItem iri WITH(NOLOCK)");

            sb.AppendLine("        INNER JOIN Erp_InventoryReceipt ir WITH(NOLOCK)");
            sb.AppendLine("            ON ir.RecId = iri.InventoryReceiptId");

            sb.AppendLine("        INNER JOIN Erp_Inventory iss WITH(NOLOCK)");
            sb.AppendLine("            ON iss.RecId = iri.InventoryId");

            sb.AppendLine("        WHERE ir.CompanyId = 44");
            sb.AppendLine("          AND ISNULL(ir.IsCancelled, 0) = 0");
            sb.AppendLine("          AND ISNULL(ir.IsApproved, 1) = 1");
            sb.AppendLine("          AND ISNULL(iri.IsCancelled, 0) = 0");
            sb.AppendLine("          AND ISNULL(iri.IsApproved, 1) = 1");
            sb.AppendLine("          AND ISNULL(ir.IsTransportReceipt, 0) = 0");
            sb.AppendLine("          AND ir.ReceiptType = 3");

            // Tarih filtresi
            sb.AppendLine($"          AND ir.ReceiptDate >= '{startDateStr}'");
            sb.AppendLine($"          AND ir.ReceiptDate < DATEADD(DAY, 1, '{endDateStr}')");

            sb.AppendLine("          AND ir.RecId NOT IN (365137,354647,364242,364243,364874,365112,365336,365342,368546)");
            sb.AppendLine("          AND iss.InventoryCode = i.InventoryCode");

            sb.AppendLine("        GROUP BY CONVERT(date, ir.ReceiptDate)");
            sb.AppendLine("    ) YIADE");

            // Stok kartı
            sb.AppendLine("    WHERE i.CompanyId = 44");
            sb.AppendLine("      AND i.InventoryCode LIKE '9%'");

            sb.AppendLine(") a");
            sb.AppendLine("WHERE a.Tarih IS NOT NULL");
            sb.AppendLine("GROUP BY CONVERT(date, a.Tarih)");
            sb.AppendLine("HAVING SUM(a.Stok) <> 0");
            sb.AppendLine("ORDER BY Date;");

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
            sb.AppendLine($"AND ir.ReceiptDate >= DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1)");
            sb.AppendLine($"AND ir.ReceiptDate < DATEADD(DAY, 1, CAST(GETDATE() AS DATE))");
            sb.AppendLine($"group by ir.ReceiptDate ");
            sb.AppendLine($"order by ir.ReceiptDate ");
            return sb.ToString();
        }

        private string BuildSalesQuery()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"select ");
            sb.AppendLine($"");
            sb.AppendLine($"a.Explanation as [PapperType]");
            sb.AppendLine($",sum(a.Satıs) as [Sales]");
            sb.AppendLine($",SUM(a.İade) as [Return]");
            sb.AppendLine($",SUM(a.Stok) as [Stock]");
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

        private string BuildSalesGetbyDateQuery(DateTime startDate, DateTime endDate)
        {
            var sb = new StringBuilder();

            string startDateStr = startDate.ToString("yyyyMMdd");
            string endDateStr = endDate.ToString("yyyyMMdd");

            sb.AppendLine($"select ");
            sb.AppendLine($"a.Explanation as [PapperType]");
            sb.AppendLine($",sum(a.Satıs) as [Sales]");
            sb.AppendLine($",SUM(a.İade) as [Return]");
            sb.AppendLine($",SUM(a.Stok) as [Stock]");

            sb.AppendLine($"from (");

            sb.AppendLine($"select");
            sb.AppendLine($"'Yıllık' Tip");
            sb.AppendLine($",4 Type");
            sb.AppendLine($",CONVERT(VARCHAR, '{startDateStr}', 104) +' - '+ CONVERT(VARCHAR, '{endDateStr}', 104) Tarih");
            sb.AppendLine($",grupkodu.Explanation");

            sb.AppendLine($",isnull(YSATİS.Quantity,0) Satıs");
            sb.AppendLine($",isnull(YİADE.Quantity,0) İade");
            sb.AppendLine($",isnull(YSATİS.Quantity,0)-isnull(YİADE.Quantity,0) Stok");

            sb.AppendLine($"from Erp_Inventory i with(nolock)");

            sb.AppendLine($"outer apply (");
            sb.AppendLine($"    select top 1 Explanation");
            sb.AppendLine($"    from Meta_DataFieldValue");
            sb.AppendLine($"    where FieldId = 223");
            sb.AppendLine($"    and isnull(CodeValue,'') = isnull(i.UD_InventoryGroup,'')");
            sb.AppendLine($") grupkodu");

            // SATIŞ
            sb.AppendLine($"outer apply (");
            sb.AppendLine($"    select sum(iri.Quantity) Quantity");
            sb.AppendLine($"    from Erp_InventoryReceiptItem iri with(nolock)");
            sb.AppendLine($"    left join Erp_InventoryReceipt ir with(nolock) on ir.RecId = iri.InventoryReceiptId");
            sb.AppendLine($"    left join Erp_Inventory iss with(nolock) on iss.RecId = iri.InventoryId");

            sb.AppendLine($"    where ir.CompanyId = 44");
            sb.AppendLine($"    and isnull(ir.IsCancelled,0) = 0");
            sb.AppendLine($"    and isnull(ir.IsApproved,1) = 1");
            sb.AppendLine($"    and isnull(iri.IsCancelled,0) = 0");
            sb.AppendLine($"    and isnull(iri.IsApproved,1) = 1");
            sb.AppendLine($"    and ISNULL(ir.IsTransportReceipt,0)=0");
            sb.AppendLine($"    and ir.ReceiptType in (120)");

            // TARİH
            sb.AppendLine($"    and ir.ReceiptDate >= '{startDateStr}'");
            sb.AppendLine($"    and ir.ReceiptDate < DATEADD(DAY, 1, '{endDateStr}')");

            sb.AppendLine($"    and ir.RecId not in (365137,354647,364242,364243,364874,365112,365336,365342,368546)");
            sb.AppendLine($"    and iss.InventoryCode=i.InventoryCode");

            sb.AppendLine($") YSATİS");

            // İADE
            sb.AppendLine($"outer apply (");
            sb.AppendLine($"    select sum(iri.Quantity) Quantity");
            sb.AppendLine($"    from Erp_InventoryReceiptItem iri with(nolock)");
            sb.AppendLine($"    left join Erp_InventoryReceipt ir with(nolock) on ir.RecId = iri.InventoryReceiptId");
            sb.AppendLine($"    left join Erp_Inventory iss with(nolock) on iss.RecId = iri.InventoryId");

            sb.AppendLine($"    where ir.CompanyId = 44");
            sb.AppendLine($"    and isnull(ir.IsCancelled,0) = 0");
            sb.AppendLine($"    and isnull(ir.IsApproved,1) = 1");
            sb.AppendLine($"    and isnull(iri.IsCancelled,0) = 0");
            sb.AppendLine($"    and isnull(iri.IsApproved,1) = 1");
            sb.AppendLine($"    and ISNULL(ir.IsTransportReceipt,0)=0");
            sb.AppendLine($"    and ir.ReceiptType in (3)");

            // TARİH
            sb.AppendLine($"    and ir.ReceiptDate >= '{startDateStr}'");
            sb.AppendLine($"    and ir.ReceiptDate < DATEADD(DAY, 1, '{endDateStr}')");

            sb.AppendLine($"    and ir.RecId not in (365137,354647,364242,364243,364874,365112,365336,365342,368546)");
            sb.AppendLine($"    and iss.InventoryCode=i.InventoryCode");

            sb.AppendLine($") YİADE");

            sb.AppendLine($"where i.CompanyId = 44");
            sb.AppendLine($"and i.InventoryCode like '9%'");

            sb.AppendLine($"group by grupkodu.Explanation");
            sb.AppendLine($",isnull(YSATİS.Quantity,0)");
            sb.AppendLine($",isnull(YİADE.Quantity,0)");
            sb.AppendLine($",isnull(YSATİS.Quantity,0)-isnull(YİADE.Quantity,0)");

            sb.AppendLine($")a");

            sb.AppendLine($"group by a.Explanation");
            sb.AppendLine($"having sum(a.Stok) != 0");

            return sb.ToString();
        }

        private string BuildPreviousDaySalesQuery()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"select ");
            sb.AppendLine($"");
            sb.AppendLine($"a.Explanation as [PapperType]");
            sb.AppendLine($",sum(a.Satıs) as [Sales]");
            sb.AppendLine($",SUM(a.İade) as [Return]");
            sb.AppendLine($",SUM(a.Stok) as [Stock]");
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

            sb.AppendLine($";WITH OpeningCutoff AS (");
            sb.AppendLine($"    SELECT ");
            sb.AppendLine($"        iri.InventoryId,");
            sb.AppendLine($"        iri.InWarehouseId AS WarehouseId,");
            sb.AppendLine($"        MAX(");
            sb.AppendLine($"            DATEADD(SECOND, ");
            sb.AppendLine($"                DATEDIFF(SECOND, CAST(ir.ReceiptTime AS date), ir.ReceiptTime),");
            sb.AppendLine($"                CAST(iri.ReceiptDate AS datetime)");
            sb.AppendLine($"            )");
            sb.AppendLine($"        ) AS CutoffDate");
            sb.AppendLine($"    FROM Erp_InventoryReceiptItem iri WITH (NOLOCK)");
            sb.AppendLine($"    LEFT JOIN Erp_InventoryReceipt ir WITH (NOLOCK) ON ir.RecId = iri.InventoryReceiptId");
            sb.AppendLine($"    WHERE iri.ReceiptType = 100");
            sb.AppendLine($"      AND ISNULL(iri.ReceiptSubType,0) = 0");
            sb.AppendLine($"      AND (iri.IsDeleted = 0 OR iri.IsDeleted IS NULL)");
            sb.AppendLine($"      AND (iri.IsCancelled = 0 OR iri.IsCancelled IS NULL)");
            sb.AppendLine($"    GROUP BY iri.InventoryId, iri.InWarehouseId");
            sb.AppendLine($")");
            sb.AppendLine($"");
            sb.AppendLine($"select ");
            sb.AppendLine($"A.[Kağıt Türü] [PapperType]");
            sb.AppendLine($",sum(isnull(A.InflowNetQuantity,0)) [Production]");
            sb.AppendLine($",sum(isnull(A.OutflowNetQuantity,0)) [Consumable]");
            sb.AppendLine($",isnull(sum(isnull(A.InflowNetQuantity,0))-sum(isnull(A.OutflowNetQuantity,0)),0) [Remaning]");
            sb.AppendLine($"");
            sb.AppendLine($"from( ");
            sb.AppendLine($"");
            sb.AppendLine($"select ");
            sb.AppendLine($"'1' TType");
            sb.AppendLine($",R.InventoryId InventoryId");
            sb.AppendLine($",I.InventoryCode");
            sb.AppendLine($",I.InventoryName");
            sb.AppendLine($",R.CustomerOrderNo");
            sb.AppendLine($",INVG.GroupCode InventoryGroupCode");
            sb.AppendLine($",INVG.GroupName InventoryGroupName");
            sb.AppendLine($",isnull(ST.Quantity,0) InflowNetQuantity");
            sb.AppendLine($",0.0 OutflowNetQuantity ");
            sb.AppendLine($",R.InWarehouseId WarehouseId ");
            sb.AppendLine($",WH.WarehouseCode ");
            sb.AppendLine($",WH.WarehouseName");
            sb.AppendLine($",S.SerialCode SerialCode ");
            sb.AppendLine($",S.Explanation SerialName ");
            sb.AppendLine($",isnull(S.WidthCM,0) SerialWidth");
            sb.AppendLine($",grupkodu.Explanation [Kağıt Türü]");
            sb.AppendLine($",S.UD_Gramaj [Gramaj (gr.)]");
            sb.AppendLine($"");
            sb.AppendLine($"from Erp_InventoryReceipt RC with (nolock) ");
            sb.AppendLine($"inner join Erp_InventoryReceiptItem R with (nolock) on (RC.RecId = R.InventoryReceiptId) ");
            sb.AppendLine($"left join Erp_Inventory I with (nolock) on (R.InventoryId = I.RecId) ");
            sb.AppendLine($"left join Erp_InventoryGroup INVG with (nolock) on INVG.RecId=I.GroupId");
            sb.AppendLine($"left join Erp_Category INVC with (nolock) on INVC.RecId=I.CategoryId");
            sb.AppendLine($"left join Erp_Season INVS with (nolock) on INVS.RecId=I.SeasonId");
            sb.AppendLine($"left join Erp_Mark INVM with (nolock) on INVM.RecId=I.MarkId");
            sb.AppendLine($"inner join Erp_Warehouse WH with (nolock) on (R.InWarehouseId = WH.RecId)  ");
            sb.AppendLine($"left join Erp_InventorySerialTransaction ST with (nolock) on (ST.ReceiptItemId=R.RecId)");
            sb.AppendLine($"left join Erp_InventorySerialCard S with (nolock) on (S.RecId=ST.SerialCardId)");
            sb.AppendLine($"left join OpeningCutoff OC on OC.InventoryId = R.InventoryId and OC.WarehouseId = R.InWarehouseId");
            sb.AppendLine($"");
            sb.AppendLine($"outer apply (select top 1 Explanation from Meta_DataFieldValue where FieldId = 223 and isnull(CodeValue,'') = isnull(I.UD_InventoryGroup,'')) grupkodu");
            sb.AppendLine($"");
            sb.AppendLine($"where");
            sb.AppendLine($"R.ItemType in (1,5,10,11,12,13,65) ");
            sb.AppendLine($"and R.InventoryId is not null ");
            sb.AppendLine($"and isnull(R.NetQuantity,0) <> 0 ");
            sb.AppendLine($"and (RC.ReceiptType < 100 or RC.ReceiptType = 123 or RC.ReceiptType = 200 or RC.ReceiptType = 150 or RC.ReceiptType = 151) ");
            sb.AppendLine($"and (RC.ReceiptType not in (7,28,90,91,92,99)) ");
            sb.AppendLine($"and R.InWarehouseId is not null ");
            sb.AppendLine($"and (RC.IsDeleted = 0 or RC.IsDeleted is null)  ");
            sb.AppendLine($"and (R.IsDeleted = 0 or R.IsDeleted is null) ");
            sb.AppendLine($"and ISNULL(RC.IsCancelled,0)=0 ");
            sb.AppendLine($"and ISNULL(RC.IsApproved,1)=1");
            sb.AppendLine($"and (I.IsDeleted = 0 or I.IsDeleted is null) ");
            sb.AppendLine($"and (I.IsClass = 0 or I.IsClass is null) ");
            sb.AppendLine($"and isnull(RC.ReceiptType,0) in (1 , 2 , 3 , 4 , 5 , 6 , 7 , 8 , 9 , 10 , 11 , 12 , 13 , 15 , 16 , 17 , 18 , 20 , 21 , 22 , 23 , 29 , 40 , 41 , 60 , 70 , 71 , 72 , 73 , 74 , 75 , 76 , 77 , 78 , 79 , 90 , 92 , 99 , 101 , 120 , 121 , 122 , 123 , 124 , 125 , 126 , 127 , 129 , 130 , 131 , 132 , 133 , 134 , 135 , 136 , 137 , 138 , 139 , 140 , 141 , 142 , 150 , 151 , 152 , 160 , 161 , 192 , 170 , 171 , 172 , 173 , 174 , 175 , 176 , 177 , 178 , 179 , 200)  ");
            sb.AppendLine($"and isnull(RC.IsTransportReceipt,0) in (0)  ");
            sb.AppendLine($"and I.InUse <> 0");
            sb.AppendLine($"and WH.InUse <> 0");
            sb.AppendLine($"and S.SerialCode not like 'E%'");
            sb.AppendLine($"and isnull(I.HasSeries,0) = 1");
            sb.AppendLine($"and RC.CompanyId = 22");
            sb.AppendLine($"and InventoryCode like '9%'");
            sb.AppendLine($"and DATEADD(SECOND, DATEDIFF(SECOND, CAST(RC.ReceiptTime AS date), RC.ReceiptTime), CAST(R.ReceiptDate AS datetime)) ");
            sb.AppendLine($"    >= ISNULL(OC.CutoffDate, '1753-01-01')");
            sb.AppendLine($"");
            sb.AppendLine($"");
            sb.AppendLine($"");
            sb.AppendLine($"union all ");
            sb.AppendLine($"");
            sb.AppendLine($"select ");
            sb.AppendLine($"'2' TType");
            sb.AppendLine($",R.InventoryId InventoryId");
            sb.AppendLine($",I.InventoryCode");
            sb.AppendLine($",I.InventoryName");
            sb.AppendLine($",R.CustomerOrderNo");
            sb.AppendLine($",INVG.GroupCode InventoryGroupCode");
            sb.AppendLine($",INVG.GroupName InventoryGroupName");
            sb.AppendLine($",0.0 InflowNetQuantity");
            sb.AppendLine($",isnull(ST.Quantity,0) OutflowNetQuantity ");
            sb.AppendLine($",R.OutWarehouseId WarehouseId ");
            sb.AppendLine($",WH.WarehouseCode ");
            sb.AppendLine($",WH.WarehouseName");
            sb.AppendLine($",S.SerialCode SerialCode ");
            sb.AppendLine($",S.Explanation SerialName ");
            sb.AppendLine($",isnull(S.WidthCM,0) SerialWidth");
            sb.AppendLine($"");
            sb.AppendLine($",grupkodu.Explanation [Kağıt Türü]");
            sb.AppendLine($",S.UD_Gramaj [Gramaj (gr.)]");
            sb.AppendLine($"");
            sb.AppendLine($"");
            sb.AppendLine($"from Erp_InventoryReceipt RC with (nolock) ");
            sb.AppendLine($"inner join Erp_InventoryReceiptItem R with (nolock) on (RC.RecId = R.InventoryReceiptId) ");
            sb.AppendLine($"left join Erp_Inventory I with (nolock) on (R.InventoryId = I.RecId) ");
            sb.AppendLine($"left join Erp_InventoryGroup INVG with (nolock) on INVG.RecId=I.GroupId");
            sb.AppendLine($"left join Erp_Category INVC with (nolock) on INVC.RecId=I.CategoryId");
            sb.AppendLine($"left join Erp_Season INVS with (nolock) on INVS.RecId=I.SeasonId");
            sb.AppendLine($"left join Erp_Mark INVM with (nolock) on INVM.RecId=I.MarkId");
            sb.AppendLine($"inner join Erp_Warehouse WH with (nolock) on (R.OutWarehouseId = WH.RecId) ");
            sb.AppendLine($"left join Erp_InventorySerialTransaction ST with (nolock) on (ST.ReceiptItemId=R.RecId)");
            sb.AppendLine($"left join Erp_InventorySerialCard S with (nolock) on (S.RecId=ST.SerialCardId)");
            sb.AppendLine($"left join OpeningCutoff OC on OC.InventoryId = R.InventoryId and OC.WarehouseId = R.OutWarehouseId");
            sb.AppendLine($"");
            sb.AppendLine($"outer apply (select top 1 Explanation from Meta_DataFieldValue where FieldId = 223 and isnull(CodeValue,'') = isnull(I.UD_InventoryGroup,'')) grupkodu");
            sb.AppendLine($"");
            sb.AppendLine($"where ");
            sb.AppendLine($"R.ItemType in (1,5,10,11,12,13,66) ");
            sb.AppendLine($"and R.InventoryId is not null ");
            sb.AppendLine($"and isnull(R.NetQuantity,0) <> 0 ");
            sb.AppendLine($"and (RC.ReceiptType > 100 or RC.ReceiptType = 4 or RC.ReceiptType = 17  or (RC.ReceiptType = 15 and R.OutWarehouseId is not null)) ");
            sb.AppendLine($"and (RC.ReceiptType not in (126,128,191,192,199,101)) ");
            sb.AppendLine($"and (RC.IsDeleted = 0 or RC.IsDeleted is null)  ");
            sb.AppendLine($"and (R.IsDeleted = 0 or R.IsDeleted is null) ");
            sb.AppendLine($"and ISNULL(RC.IsCancelled,0)=0 ");
            sb.AppendLine($"and ISNULL(RC.IsApproved,1)=1");
            sb.AppendLine($"and (I.IsDeleted = 0 or I.IsDeleted is null) ");
            sb.AppendLine($"and (I.IsClass = 0 or I.IsClass is null) ");
            sb.AppendLine($"and isnull(RC.ReceiptType,0) in (1 , 2 , 3 , 4 , 5 , 6 , 7 , 8 , 9 , 10 , 11 , 12 , 13 , 15 , 16 , 17 , 18 , 20 , 21 , 22 , 23 , 29 , 40 , 41 , 60 , 70 , 71 , 72 , 73 , 74 , 75 , 76 , 77 , 78 , 79 , 90 , 92 , 99 , 101 , 120 , 121 , 122 , 123 , 124 , 125 , 126 , 127 , 129 , 130 , 131 , 132 , 133 , 134 , 135 , 136 , 137 , 138 , 139 , 140 , 141 , 142 , 150 , 151 , 152 , 160 , 161 , 192 , 170 , 171 , 172 , 173 , 174 , 175 , 176 , 177 , 178 , 179 , 200)   ");
            sb.AppendLine($"and isnull(RC.IsTransportReceipt,0) in (0)  ");
            sb.AppendLine($"and I.InUse <> 0");
            sb.AppendLine($"and WH.InUse <> 0");
            sb.AppendLine($"and isnull(I.HasSeries,0) = 1");
            sb.AppendLine($"and S.SerialCode not like 'E%'");
            sb.AppendLine($"and RC.CompanyId = 22");
            sb.AppendLine($"and InventoryCode like '9%'");
            sb.AppendLine($"and DATEADD(SECOND, DATEDIFF(SECOND, CAST(RC.ReceiptTime AS date), RC.ReceiptTime), CAST(R.ReceiptDate AS datetime)) ");
            sb.AppendLine($"	>= ISNULL(OC.CutoffDate, '1753-01-01')");
            sb.AppendLine($"");
            sb.AppendLine($"");
            sb.AppendLine($"");
            sb.AppendLine($" ) A ");
            sb.AppendLine($"");
            sb.AppendLine($"group by");
            sb.AppendLine($"A.[Kağıt Türü]");
            sb.AppendLine($"");
            sb.AppendLine($"order by A.[Kağıt Türü]");
            return sb.ToString();
        }

        private string BuildStockGetbyDateQuery(DateTime startDate, DateTime endDate)
        {
            var sb = new StringBuilder();

            string startDateStr = startDate.ToString("yyyy-MM-dd");
            string endDateExclusiveStr = endDate.Date.AddDays(1).ToString("yyyy-MM-dd");

            sb.AppendLine(";WITH OpeningCutoff AS (");

            sb.AppendLine("    SELECT");
            sb.AppendLine("        iri.InventoryId,");
            sb.AppendLine("        iri.InWarehouseId AS WarehouseId,");
            sb.AppendLine("        MAX(");
            sb.AppendLine("            DATEADD(");
            sb.AppendLine("                SECOND,");
            sb.AppendLine("                DATEDIFF(SECOND, CAST(ir.ReceiptTime AS date), ir.ReceiptTime),");
            sb.AppendLine("                CAST(iri.ReceiptDate AS datetime)");
            sb.AppendLine("            )");
            sb.AppendLine("        ) AS CutoffDate");

            sb.AppendLine("    FROM Erp_InventoryReceiptItem iri WITH (NOLOCK)");

            sb.AppendLine("    LEFT JOIN Erp_InventoryReceipt ir WITH (NOLOCK)");
            sb.AppendLine("        ON ir.RecId = iri.InventoryReceiptId");

            sb.AppendLine("    WHERE iri.ReceiptType = 100");
            sb.AppendLine("      AND ISNULL(iri.ReceiptSubType, 0) = 0");
            sb.AppendLine("      AND (iri.IsDeleted = 0 OR iri.IsDeleted IS NULL)");
            sb.AppendLine("      AND (iri.IsCancelled = 0 OR iri.IsCancelled IS NULL)");

            sb.AppendLine("    GROUP BY");
            sb.AppendLine("        iri.InventoryId,");
            sb.AppendLine("        iri.InWarehouseId");

            sb.AppendLine(")");

            sb.AppendLine("SELECT");
            sb.AppendLine("    A.[Kağıt Türü] AS [PapperType],");
            sb.AppendLine("    SUM(ISNULL(A.InflowNetQuantity, 0)) AS [Production],");
            sb.AppendLine("    SUM(ISNULL(A.OutflowNetQuantity, 0)) AS [Consumable],");
            sb.AppendLine("    SUM(ISNULL(A.InflowNetQuantity, 0))");
            sb.AppendLine("        - SUM(ISNULL(A.OutflowNetQuantity, 0)) AS [Remaning]");

            sb.AppendLine("FROM (");

            sb.AppendLine("    SELECT");
            sb.AppendLine("        R.InventoryId,");
            sb.AppendLine("        ISNULL(ST.Quantity, 0) AS InflowNetQuantity,");
            sb.AppendLine("        0.0 AS OutflowNetQuantity,");
            sb.AppendLine("        grupkodu.Explanation AS [Kağıt Türü]");

            sb.AppendLine("    FROM Erp_InventoryReceipt RC WITH (NOLOCK)");

            sb.AppendLine("    INNER JOIN Erp_InventoryReceiptItem R WITH (NOLOCK)");
            sb.AppendLine("        ON RC.RecId = R.InventoryReceiptId");

            sb.AppendLine("    LEFT JOIN Erp_Inventory I WITH (NOLOCK)");
            sb.AppendLine("        ON R.InventoryId = I.RecId");

            sb.AppendLine("    INNER JOIN Erp_Warehouse WH WITH (NOLOCK)");
            sb.AppendLine("        ON R.InWarehouseId = WH.RecId");

            sb.AppendLine("    LEFT JOIN Erp_InventorySerialTransaction ST WITH (NOLOCK)");
            sb.AppendLine("        ON ST.ReceiptItemId = R.RecId");

            sb.AppendLine("    LEFT JOIN Erp_InventorySerialCard S WITH (NOLOCK)");
            sb.AppendLine("        ON S.RecId = ST.SerialCardId");

            sb.AppendLine("    LEFT JOIN OpeningCutoff OC");
            sb.AppendLine("        ON OC.InventoryId = R.InventoryId");
            sb.AppendLine("       AND OC.WarehouseId = R.InWarehouseId");

            sb.AppendLine("    OUTER APPLY (");
            sb.AppendLine("        SELECT TOP 1 Explanation");
            sb.AppendLine("        FROM Meta_DataFieldValue");
            sb.AppendLine("        WHERE FieldId = 223");
            sb.AppendLine("          AND ISNULL(CodeValue, '') = ISNULL(I.UD_InventoryGroup, '')");
            sb.AppendLine("    ) grupkodu");

            sb.AppendLine("    WHERE R.ItemType IN (1,5,10,11,12,13,65)");
            sb.AppendLine("      AND R.InventoryId IS NOT NULL");
            sb.AppendLine("      AND ISNULL(R.NetQuantity, 0) <> 0");

            sb.AppendLine("      AND (");
            sb.AppendLine("            RC.ReceiptType < 100");
            sb.AppendLine("         OR RC.ReceiptType IN (123,200,150,151)");
            sb.AppendLine("      )");

            sb.AppendLine("      AND RC.ReceiptType NOT IN (7,28,90,91,92,99)");

            sb.AppendLine("      AND R.InWarehouseId IS NOT NULL");

            sb.AppendLine("      AND (RC.IsDeleted = 0 OR RC.IsDeleted IS NULL)");
            sb.AppendLine("      AND (R.IsDeleted = 0 OR R.IsDeleted IS NULL)");

            sb.AppendLine("      AND ISNULL(RC.IsCancelled, 0) = 0");
            sb.AppendLine("      AND ISNULL(RC.IsApproved, 1) = 1");

            sb.AppendLine("      AND (I.IsDeleted = 0 OR I.IsDeleted IS NULL)");
            sb.AppendLine("      AND (I.IsClass = 0 OR I.IsClass IS NULL)");

            sb.AppendLine("      AND ISNULL(RC.IsTransportReceipt, 0) = 0");

            sb.AppendLine("      AND I.InUse <> 0");
            sb.AppendLine("      AND WH.InUse <> 0");

            sb.AppendLine("      AND ISNULL(I.HasSeries, 0) = 1");
            sb.AppendLine("      AND S.SerialCode NOT LIKE 'E%'");

            sb.AppendLine("      AND RC.CompanyId = 22");
            sb.AppendLine("      AND I.InventoryCode LIKE '9%'");


            sb.AppendLine("      AND DATEADD(");
            sb.AppendLine("            SECOND,");
            sb.AppendLine("            DATEDIFF(SECOND, CAST(RC.ReceiptTime AS date), RC.ReceiptTime),");
            sb.AppendLine("            CAST(RC.ReceiptDate AS datetime)");
            sb.AppendLine("      ) >= ISNULL(OC.CutoffDate, '1753-01-01')");

            // TARİH FİLTRESİ
            sb.AppendLine($"      AND RC.ReceiptDate >= '{startDateStr}'");
            sb.AppendLine($"      AND RC.ReceiptDate < '{endDateExclusiveStr}'");


            sb.AppendLine("    UNION ALL");

            sb.AppendLine("    SELECT");
            sb.AppendLine("        R.InventoryId,");
            sb.AppendLine("        0.0 AS InflowNetQuantity,");
            sb.AppendLine("        ISNULL(ST.Quantity, 0) AS OutflowNetQuantity,");
            sb.AppendLine("        grupkodu.Explanation AS [Kağıt Türü]");

            sb.AppendLine("    FROM Erp_InventoryReceipt RC WITH (NOLOCK)");

            sb.AppendLine("    INNER JOIN Erp_InventoryReceiptItem R WITH (NOLOCK)");
            sb.AppendLine("        ON RC.RecId = R.InventoryReceiptId");

            sb.AppendLine("    LEFT JOIN Erp_Inventory I WITH (NOLOCK)");
            sb.AppendLine("        ON R.InventoryId = I.RecId");

            sb.AppendLine("    INNER JOIN Erp_Warehouse WH WITH (NOLOCK)");
            sb.AppendLine("        ON R.OutWarehouseId = WH.RecId");

            sb.AppendLine("    LEFT JOIN Erp_InventorySerialTransaction ST WITH (NOLOCK)");
            sb.AppendLine("        ON ST.ReceiptItemId = R.RecId");

            sb.AppendLine("    LEFT JOIN Erp_InventorySerialCard S WITH (NOLOCK)");
            sb.AppendLine("        ON S.RecId = ST.SerialCardId");

            sb.AppendLine("    LEFT JOIN OpeningCutoff OC");
            sb.AppendLine("        ON OC.InventoryId = R.InventoryId");
            sb.AppendLine("       AND OC.WarehouseId = R.OutWarehouseId");

            sb.AppendLine("    OUTER APPLY (");
            sb.AppendLine("        SELECT TOP 1 Explanation");
            sb.AppendLine("        FROM Meta_DataFieldValue");
            sb.AppendLine("        WHERE FieldId = 223");
            sb.AppendLine("          AND ISNULL(CodeValue, '') = ISNULL(I.UD_InventoryGroup, '')");
            sb.AppendLine("    ) grupkodu");

            sb.AppendLine("    WHERE R.ItemType IN (1,5,10,11,12,13,66)");
            sb.AppendLine("      AND R.InventoryId IS NOT NULL");
            sb.AppendLine("      AND ISNULL(R.NetQuantity, 0) <> 0");

            sb.AppendLine("      AND (");
            sb.AppendLine("            RC.ReceiptType > 100");
            sb.AppendLine("         OR RC.ReceiptType IN (4,17)");
            sb.AppendLine("         OR (RC.ReceiptType = 15 AND R.OutWarehouseId IS NOT NULL)");
            sb.AppendLine("      )");

            sb.AppendLine("      AND RC.ReceiptType NOT IN (126,128,191,192,199,101)");

            sb.AppendLine("      AND (RC.IsDeleted = 0 OR RC.IsDeleted IS NULL)");
            sb.AppendLine("      AND (R.IsDeleted = 0 OR R.IsDeleted IS NULL)");

            sb.AppendLine("      AND ISNULL(RC.IsCancelled, 0) = 0");
            sb.AppendLine("      AND ISNULL(RC.IsApproved, 1) = 1");

            sb.AppendLine("      AND (I.IsDeleted = 0 OR I.IsDeleted IS NULL)");
            sb.AppendLine("      AND (I.IsClass = 0 OR I.IsClass IS NULL)");

            sb.AppendLine("      AND ISNULL(RC.IsTransportReceipt, 0) = 0");

            sb.AppendLine("      AND I.InUse <> 0");
            sb.AppendLine("      AND WH.InUse <> 0");

            sb.AppendLine("      AND ISNULL(I.HasSeries, 0) = 1");
            sb.AppendLine("      AND S.SerialCode NOT LIKE 'E%'");

            sb.AppendLine("      AND RC.CompanyId = 22");
            sb.AppendLine("      AND I.InventoryCode LIKE '9%'");

            // Açılış cutoff
            sb.AppendLine("      AND DATEADD(");
            sb.AppendLine("            SECOND,");
            sb.AppendLine("            DATEDIFF(SECOND, CAST(RC.ReceiptTime AS date), RC.ReceiptTime),");
            sb.AppendLine("            CAST(RC.ReceiptDate AS datetime)");
            sb.AppendLine("      ) >= ISNULL(OC.CutoffDate, '1753-01-01')");

            // TARİH FİLTRESİ
            sb.AppendLine($"      AND RC.ReceiptDate >= '{startDateStr}'");
            sb.AppendLine($"      AND RC.ReceiptDate < '{endDateExclusiveStr}'");

            sb.AppendLine(") A");

            sb.AppendLine("GROUP BY A.[Kağıt Türü]");

            sb.AppendLine("ORDER BY A.[Kağıt Türü]");

            return sb.ToString();
        }

        private string BuildStockByInventoryCode(string InventoryCode)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"select ");
            sb.AppendLine($"i.InventoryCode [InventoryCode]");
            sb.AppendLine($",i.InventoryName [InventoryName]");
            sb.AppendLine($",isc.WidthCM [WidthCM]");
            sb.AppendLine($",SUM(ist.Quantity) [StockQuantity]");
            sb.AppendLine($",w.WarehouseCode [WarehouseCode]");
            sb.AppendLine($",w.WarehouseName [WarehouseName]");

            sb.AppendLine($"from Erp_InventorySerialCard isc with(nolock)");
            sb.AppendLine($"left join Erp_Inventory i with(nolock) on i.RecId = isc.InventoryId");
            sb.AppendLine($"left join Erp_InventorySerialCardTotal ist with(nolock) on isc.RecId = ist.SerialCardId");
            sb.AppendLine($"left join Erp_Warehouse w with(nolock) on w.RecId = ist.WarehouseId");

            sb.AppendLine($"where i.CompanyId = 22");
            sb.AppendLine($"and isc.SerialCode not like 'E%'");
            sb.AppendLine($"and ist.Quantity > 0");
            sb.AppendLine($"and i.InventoryCode = '{InventoryCode}'");

            sb.AppendLine($"group by ");
            sb.AppendLine($"i.InventoryCode");
            sb.AppendLine($",i.InventoryName");
            sb.AppendLine($",isc.WidthCM");
            sb.AppendLine($",w.WarehouseCode");
            sb.AppendLine($",w.WarehouseName");

            return sb.ToString();
        }

        private string BuildStockByInventoryCodeAndWidthCM(string InventoryCode, double WidthCM)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"select ");
            sb.AppendLine($"i.InventoryCode [InventoryCode]");
            sb.AppendLine($",i.InventoryName [InventoryName]");
            sb.AppendLine($",isc.WidthCM [WidthCM]");
            sb.AppendLine($",SUM(ist.Quantity) [StockQuantity]");
            sb.AppendLine($",w.WarehouseCode [WarehouseCode]");
            sb.AppendLine($",w.WarehouseName [WarehouseName]");

            sb.AppendLine($"from Erp_InventorySerialCard isc with(nolock)");
            sb.AppendLine($"left join Erp_Inventory i with(nolock) on i.RecId = isc.InventoryId");
            sb.AppendLine($"left join Erp_InventorySerialCardTotal ist with(nolock) on isc.RecId = ist.SerialCardId");
            sb.AppendLine($"left join Erp_Warehouse w with(nolock) on w.RecId = ist.WarehouseId");

            sb.AppendLine($"where i.CompanyId = 22");
            sb.AppendLine($"and isc.SerialCode not like 'E%'");
            sb.AppendLine($"and ist.Quantity > 0");
            sb.AppendLine($"and i.InventoryCode = '{InventoryCode}'");
            sb.AppendLine($"and isc.WidthCM = {WidthCM}");

            sb.AppendLine($"group by ");
            sb.AppendLine($"i.InventoryCode");
            sb.AppendLine($",i.InventoryName");
            sb.AppendLine($",isc.WidthCM");
            sb.AppendLine($",w.WarehouseCode");
            sb.AppendLine($",w.WarehouseName");

            return sb.ToString();
        }

        private string BuildReceiptQuery()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"select");
            sb.AppendLine($"iri.RecId [RecId]");
            sb.AppendLine($",i.InventoryCode [Code]");
            sb.AppendLine($",i.InventoryName [Name]");
            sb.AppendLine($",orr.DocumentNo [DocumentNo]");
            sb.AppendLine($",orr.ReceiptNo [ReceiptNo]");
            sb.AppendLine($",ir.ReceiptDate");
            sb.AppendLine($",cu.CurrentAccountCode [CurrentAccountCode]");
            sb.AppendLine($",cu.CurrentAccountName [CurrentAccountName]");

            sb.AppendLine($"from Erp_InventoryReceiptItem iri");
            sb.AppendLine($"left join Erp_InventoryReceipt ir with(nolock) on ir.RecId = iri.InventoryReceiptId");
            sb.AppendLine($"left join Erp_OrderReceiptItem ori with(nolock) on ori.RecId = iri.OrderReceiptItemId");
            sb.AppendLine($"left join Erp_OrderReceipt orr with(nolock) on orr.RecId = ori.OrderReceiptId");
            sb.AppendLine($"left join Erp_Inventory i with(nolock) on i.RecId = iri.InventoryId");
            sb.AppendLine($"left join Erp_CurrentAccount cu with(nolock) on cu.RecId = ir.ShipToCurrentAccountId");

            sb.AppendLine($"where ir.CompanyId = 22");
            sb.AppendLine($"and ir.ReceiptType = 199");
            sb.AppendLine($"and orr.DocumentNo not like 'E%'");
            sb.AppendLine($"and ir.ReceiptDate >= CAST(GETDATE() AS DATE)");
            sb.AppendLine($"and ir.ReceiptDate < DATEADD(DAY, 1, CAST(GETDATE() AS DATE))");

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
