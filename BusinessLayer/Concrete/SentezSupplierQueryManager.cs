using BusinessLayer.Abstract;
using BusinessLayer.Abstract.Integrations;
using DTOLayer.Dtos.SentezProductionDtos;
using DTOLayer.Dtos.SupplierDashboardDtos;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class SentezSupplierQueryManager : ISentezSupplierQueryService
    {
        private readonly ISentezIntegrationsService _sentez;

        public SentezSupplierQueryManager(ISentezIntegrationsService sentez)
        {
            _sentez = sentez;
        }

        public async Task<SentezIntegrationsResponsoDto<SupplierDashboardBySupplierDto>> GetSupplierDashboardBySupplier(DateTime startDate, DateTime endDate)
        {
            var result = GetSupplierDashboardBySupplierQuery(startDate, endDate);
            return await _sentez.ExecuteQueryAsync<SupplierDashboardBySupplierDto>(result);
        }

        private string GetSupplierDashboardBySupplierQuery(DateTime startDate, DateTime endDate)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"SELECT");
            sb.AppendLine($"    cu.CurrentAccountName AS SupplierName,");
            sb.AppendLine($"");
            sb.AppendLine($"    SUM(ISNULL(iri.Quantity, 0)) AS TotalQuantity,");
            sb.AppendLine($"");
            sb.AppendLine($"    SUM(ISNULL(qc.ApprovedQuantity, 0)) AS ApprovedQuantity,");
            sb.AppendLine($"");
            sb.AppendLine($"    SUM(ISNULL(qc.RejectedQuantity, 0)) AS RejectedQuantity,");
            sb.AppendLine($"");
            sb.AppendLine($"    SUM(");
            sb.AppendLine($"        ISNULL(qc.UD_MoistureWaste, 0) +");
            sb.AppendLine($"        ISNULL(qc.UD_GarbageWaste, 0)");
            sb.AppendLine($"    ) AS TotalDeduction,");
            sb.AppendLine($"");
            sb.AppendLine($"    (");
            sb.AppendLine($"        SUM(");
            sb.AppendLine($"            ISNULL(qc.UD_MoistureWaste, 0) +");
            sb.AppendLine($"            ISNULL(qc.UD_GarbageWaste, 0)");
            sb.AppendLine($"        )");
            sb.AppendLine($"        / NULLIF(SUM(ISNULL(iri.Quantity, 0)), 0)");
            sb.AppendLine($"    ) * 100 AS DeductionRate,");
            sb.AppendLine($"");
            sb.AppendLine($"    AVG(ISNULL(qc.UD_WetScale, 0)) AS AverageMoisture,");
            sb.AppendLine($"");
            sb.AppendLine($"    AVG(ISNULL(qc.UD_UnknowMaterialScale, 0)) AS AverageForeignMaterial");
            sb.AppendLine($"");
            sb.AppendLine($"FROM Erp_InventoryReceiptItem iri WITH(NOLOCK)");
            sb.AppendLine($"");
            sb.AppendLine($"LEFT JOIN Erp_QualityControl qc WITH(NOLOCK)");
            sb.AppendLine($"    ON qc.InventoryReceiptItemId = iri.RecId");
            sb.AppendLine($"");
            sb.AppendLine($"LEFT JOIN Erp_InventoryReceipt ir WITH(NOLOCK)");
            sb.AppendLine($"    ON ir.RecId = iri.InventoryReceiptId");
            sb.AppendLine($"");
            sb.AppendLine($"LEFT JOIN Erp_Inventory i WITH(NOLOCK)");
            sb.AppendLine($"    ON i.RecId = iri.InventoryId");
            sb.AppendLine($"");
            sb.AppendLine($"LEFT JOIN Erp_CurrentAccount cu WITH(NOLOCK)");
            sb.AppendLine($"    ON cu.RecId = ir.CurrentAccountId");
            sb.AppendLine($"");
            sb.AppendLine($"WHERE ir.CompanyId = 22");
            sb.AppendLine($"AND i.InventoryCode LIKE '1010%'");
            sb.AppendLine($"AND ir.ReceiptDate BETWEEN '{startDate}' AND '{endDate}'");
            sb.AppendLine($"AND ir.ReceiptType = 1");
            sb.AppendLine($"AND ir.IsCancelled = 0");
            sb.AppendLine($"AND (i.InventoryName LIKE 'A%' or i.InventoryName LIKE 'H%')");
            sb.AppendLine($"");
            sb.AppendLine($"GROUP BY");
            sb.AppendLine($"    cu.CurrentAccountName");
            sb.AppendLine($"");
            sb.AppendLine($"ORDER BY");
            sb.AppendLine($"    TotalQuantity DESC;");
            return sb.ToString();
        }

        public async Task<SentezIntegrationsResponsoDto<SupplierDashboardSummaryDto>> GetSupplierDashboardSummary(DateTime startDate, DateTime endDate)
        {
            var result = GetSupplierDashboardSummaryQuery(startDate, endDate);
            return await _sentez.ExecuteQueryAsync<SupplierDashboardSummaryDto>(result);

        }

        private string GetSupplierDashboardSummaryQuery(DateTime startDate, DateTime endDate)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"SELECT");
            sb.AppendLine($"    SUM(ISNULL(iri.Quantity, 0)) AS TotalQuantity,");
            sb.AppendLine($"");
            sb.AppendLine($"    SUM(ISNULL(qc.UD_InvoiceQuantity, 0)) AS NetQuantity,");
            sb.AppendLine($"");
            sb.AppendLine($"    SUM(ISNULL(qc.ApprovedQuantity, 0)) AS ApprovedQuantity,");
            sb.AppendLine($"");
            sb.AppendLine($"    SUM(ISNULL(qc.RejectedQuantity, 0)) AS RejectedQuantity,");
            sb.AppendLine($"");
            sb.AppendLine($"    SUM(ISNULL(iri.ReturnedQuantity, 0)) AS ReturnedQuantity,");
            sb.AppendLine($"");
            sb.AppendLine($"    SUM(");
            sb.AppendLine($"        ISNULL(qc.UD_MoistureWaste, 0) +");
            sb.AppendLine($"        ISNULL(qc.UD_GarbageWaste, 0)");
            sb.AppendLine($"    ) AS TotalDeduction,");
            sb.AppendLine($"");
            sb.AppendLine($"    (");
            sb.AppendLine($"        SUM(");
            sb.AppendLine($"            ISNULL(qc.UD_MoistureWaste, 0) +");
            sb.AppendLine($"            ISNULL(qc.UD_GarbageWaste, 0)");
            sb.AppendLine($"        )");
            sb.AppendLine($"        / NULLIF(SUM(ISNULL(iri.Quantity, 0)), 0)");
            sb.AppendLine($"    ) * 100 AS DeductionRate");
            sb.AppendLine($"");
            sb.AppendLine($"FROM Erp_InventoryReceiptItem iri WITH(NOLOCK)");
            sb.AppendLine($"");
            sb.AppendLine($"LEFT JOIN Erp_QualityControl qc WITH(NOLOCK)");
            sb.AppendLine($"    ON qc.InventoryReceiptItemId = iri.RecId");
            sb.AppendLine($"");
            sb.AppendLine($"LEFT JOIN Erp_InventoryReceipt ir WITH(NOLOCK)");
            sb.AppendLine($"    ON ir.RecId = iri.InventoryReceiptId");
            sb.AppendLine($"");
            sb.AppendLine($"LEFT JOIN Erp_Inventory i WITH(NOLOCK)");
            sb.AppendLine($"    ON i.RecId = iri.InventoryId");
            sb.AppendLine($"");
            sb.AppendLine($"LEFT JOIN Erp_CurrentAccount cu WITH(NOLOCK)");
            sb.AppendLine($"    ON cu.RecId = ir.CurrentAccountId");
            sb.AppendLine($"");
            sb.AppendLine($"WHERE ir.CompanyId = 22");
            sb.AppendLine($"AND i.InventoryCode LIKE '1010%'");
            sb.AppendLine($"AND ir.ReceiptDate BETWEEN '{startDate}' AND '{endDate}'");
            sb.AppendLine($"AND ir.ReceiptType = 1");
            sb.AppendLine($"AND ir.IsCancelled = 0");
            sb.AppendLine($"AND (i.InventoryName LIKE 'A%' OR i.InventoryName LIKE 'H%');");
            return sb.ToString();
        }

        public async Task<SentezIntegrationsResponsoDto<SupplierDashboardByDateDto>> GetSupplierDashboardByDate(DateTime startDate, DateTime endDate)
        {
            var result = GetSupplierDashboardByDateQuery(startDate, endDate);
            return await _sentez.ExecuteQueryAsync<SupplierDashboardByDateDto>(result);
        }

        private string GetSupplierDashboardByDateQuery(DateTime startDate, DateTime endDate)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"SELECT");
            sb.AppendLine($"    CAST(ir.ReceiptDate AS DATE) AS [Date],");
            sb.AppendLine($"");
            sb.AppendLine($"    SUM(ISNULL(iri.Quantity, 0)) AS TotalQuantity,");
            sb.AppendLine($"");
            sb.AppendLine($"    SUM(ISNULL(qc.UD_InvoiceQuantity, 0)) AS NetQuantity,");
            sb.AppendLine($"");
            sb.AppendLine($"    SUM(ISNULL(qc.ApprovedQuantity, 0)) AS ApprovedQuantity,");
            sb.AppendLine($"");
            sb.AppendLine($"    SUM(ISNULL(qc.RejectedQuantity, 0)) AS RejectedQuantity,");
            sb.AppendLine($"");
            sb.AppendLine($"    SUM(ISNULL(iri.ReturnedQuantity, 0)) AS ReturnedQuantity,");
            sb.AppendLine($"");
            sb.AppendLine($"    SUM(");
            sb.AppendLine($"        ISNULL(qc.UD_MoistureWaste, 0) +");
            sb.AppendLine($"        ISNULL(qc.UD_GarbageWaste, 0)");
            sb.AppendLine($"    ) AS TotalDeduction,");
            sb.AppendLine($"");
            sb.AppendLine($"    (");
            sb.AppendLine($"        SUM(");
            sb.AppendLine($"            ISNULL(qc.UD_MoistureWaste, 0) +");
            sb.AppendLine($"            ISNULL(qc.UD_GarbageWaste, 0)");
            sb.AppendLine($"        )");
            sb.AppendLine($"        /");
            sb.AppendLine($"        NULLIF(SUM(ISNULL(iri.Quantity, 0)), 0)");
            sb.AppendLine($"    ) * 100 AS DeductionRate");
            sb.AppendLine($"");
            sb.AppendLine($"FROM Erp_InventoryReceiptItem iri WITH(NOLOCK)");
            sb.AppendLine($"");
            sb.AppendLine($"LEFT JOIN Erp_QualityControl qc WITH(NOLOCK)");
            sb.AppendLine($"    ON qc.InventoryReceiptItemId = iri.RecId");
            sb.AppendLine($"");
            sb.AppendLine($"LEFT JOIN Erp_InventoryReceipt ir WITH(NOLOCK)");
            sb.AppendLine($"    ON ir.RecId = iri.InventoryReceiptId");
            sb.AppendLine($"");
            sb.AppendLine($"LEFT JOIN Erp_Inventory i WITH(NOLOCK)");
            sb.AppendLine($"    ON i.RecId = iri.InventoryId");
            sb.AppendLine($"");
            sb.AppendLine($"LEFT JOIN Erp_CurrentAccount cu WITH(NOLOCK)");
            sb.AppendLine($"    ON cu.RecId = ir.CurrentAccountId");
            sb.AppendLine($"");
            sb.AppendLine($"WHERE ir.CompanyId = 22");
            sb.AppendLine($"AND i.InventoryCode LIKE '1010%'");
            sb.AppendLine($"AND ir.ReceiptDate BETWEEN '{startDate}' AND '{endDate}'");
            sb.AppendLine($"AND ir.ReceiptType = 1");
            sb.AppendLine($"AND ir.IsCancelled = 0");
            sb.AppendLine($"AND (i.InventoryName LIKE 'A%' OR i.InventoryName LIKE 'H%')");
            sb.AppendLine($"");
            sb.AppendLine($"GROUP BY");
            sb.AppendLine($"    CAST(ir.ReceiptDate AS DATE)");
            sb.AppendLine($"");
            sb.AppendLine($"ORDER BY");
            sb.AppendLine($"    [Date];");
            return sb.ToString();
        }

        public Task<SentezIntegrationsResponsoDto<SupplierDashboardQualityDto>> GetSupplierQuality(DateTime startDate, DateTime endDate)
        {
            var result = GetSupplierQualityQuery(startDate, endDate);
            return _sentez.ExecuteQueryAsync<SupplierDashboardQualityDto>(result);
        }

        private string GetSupplierQualityQuery(DateTime startDate, DateTime endDate)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"");
            sb.AppendLine($"        SELECT");
            sb.AppendLine($"            ISNULL(cu.CurrentAccountName, 'Bilinmeyen') AS SupplierName,");
            sb.AppendLine($"");
            sb.AppendLine($"            AVG(ISNULL(qc.UD_WetScale, 0)) AS AverageMoisture,");
            sb.AppendLine($"");
            sb.AppendLine($"            AVG(ISNULL(qc.UD_UnknowMaterialScale, 0)) AS AverageForeignMaterial,");
            sb.AppendLine($"");
            sb.AppendLine($"            SUM(");
            sb.AppendLine($"                ISNULL(qc.UD_MoistureWaste, 0)");
            sb.AppendLine($"                + ISNULL(qc.UD_GarbageWaste, 0)");
            sb.AppendLine($"            ) AS TotalDeduction,");
            sb.AppendLine($"");
            sb.AppendLine($"            (");
            sb.AppendLine($"                SUM(");
            sb.AppendLine($"                    ISNULL(qc.UD_MoistureWaste, 0)");
            sb.AppendLine($"                    + ISNULL(qc.UD_GarbageWaste, 0)");
            sb.AppendLine($"                )");
            sb.AppendLine($"                / NULLIF(");
            sb.AppendLine($"                    SUM(ISNULL(iri.Quantity, 0)),");
            sb.AppendLine($"                    0");
            sb.AppendLine($"                )");
            sb.AppendLine($"            ) * 100 AS DeductionRate,");
            sb.AppendLine($"");
            sb.AppendLine($"            SUM(ISNULL(qc.ApprovedQuantity, 0)) AS ApprovedQuantity,");
            sb.AppendLine($"");
            sb.AppendLine($"            SUM(ISNULL(qc.RejectedQuantity, 0)) AS RejectedQuantity,");
            sb.AppendLine($"");
            sb.AppendLine($"            (");
            sb.AppendLine($"                SUM(ISNULL(qc.RejectedQuantity, 0))");
            sb.AppendLine($"                / NULLIF(");
            sb.AppendLine($"                    SUM(ISNULL(qc.ApprovedQuantity, 0))");
            sb.AppendLine($"                    + SUM(ISNULL(qc.RejectedQuantity, 0)),");
            sb.AppendLine($"                    0");
            sb.AppendLine($"                )");
            sb.AppendLine($"            ) * 100 AS RejectionRate");
            sb.AppendLine($"");
            sb.AppendLine($"        FROM Erp_InventoryReceiptItem iri WITH(NOLOCK)");
            sb.AppendLine($"");
            sb.AppendLine($"        LEFT JOIN Erp_QualityControl qc WITH(NOLOCK)");
            sb.AppendLine($"            ON qc.InventoryReceiptItemId = iri.RecId");
            sb.AppendLine($"");
            sb.AppendLine($"        LEFT JOIN Erp_InventoryReceipt ir WITH(NOLOCK)");
            sb.AppendLine($"            ON ir.RecId = iri.InventoryReceiptId");
            sb.AppendLine($"");
            sb.AppendLine($"        LEFT JOIN Erp_Inventory i WITH(NOLOCK)");
            sb.AppendLine($"            ON i.RecId = iri.InventoryId");
            sb.AppendLine($"");
            sb.AppendLine($"        LEFT JOIN Erp_CurrentAccount cu WITH(NOLOCK)");
            sb.AppendLine($"            ON cu.RecId = ir.CurrentAccountId");
            sb.AppendLine($"");
            sb.AppendLine($"        WHERE ir.CompanyId = 22");
            sb.AppendLine($"          AND i.InventoryCode LIKE '1010%'");
            sb.AppendLine($"          AND ir.ReceiptDate >= '{startDate}'");
            sb.AppendLine($"          AND ir.ReceiptDate < DATEADD(DAY, 1, '{endDate}')");
            sb.AppendLine($"          AND ir.ReceiptType = 1");
            sb.AppendLine($"          AND ir.IsCancelled = 0");
            sb.AppendLine($"          AND (i.InventoryName LIKE 'A%' OR i.InventoryName LIKE 'H%')");
            sb.AppendLine($"");
            sb.AppendLine($"        GROUP BY");
            sb.AppendLine($"            cu.CurrentAccountName");
            sb.AppendLine($"");
            sb.AppendLine($"        ORDER BY");
            sb.AppendLine($"            DeductionRate ASC;");
            sb.AppendLine($" ");
            return sb.ToString();
        }

        public Task<SentezIntegrationsResponsoDto<SupplierDashboardMaterialDistributionDto>> GetSupplierMaterialDistribution(DateTime startDate, DateTime endDate)
        {
            var result = GetSupplierMaterialDistributionQuery(startDate, endDate);
            return _sentez.ExecuteQueryAsync<SupplierDashboardMaterialDistributionDto>(result);
        }

        private string GetSupplierMaterialDistributionQuery(DateTime startDate, DateTime endDate)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"SELECT");
            sb.AppendLine($"            ISNULL(cu.CurrentAccountName, 'Bilinmeyen') AS SupplierName,");
            sb.AppendLine($"");
            sb.AppendLine($"            ISNULL(i.InventoryCode, '') AS InventoryCode,");
            sb.AppendLine($"");
            sb.AppendLine($"            ISNULL(i.InventoryName, '') AS InventoryName,");
            sb.AppendLine($"");
            sb.AppendLine($"            SUM(ISNULL(iri.Quantity, 0)) AS TotalQuantity,");
            sb.AppendLine($"");
            sb.AppendLine($"            SUM(ISNULL(qc.UD_InvoiceQuantity, 0)) AS NetQuantity,");
            sb.AppendLine($"");
            sb.AppendLine($"            SUM(ISNULL(qc.ApprovedQuantity, 0)) AS ApprovedQuantity,");
            sb.AppendLine($"");
            sb.AppendLine($"            SUM(ISNULL(qc.RejectedQuantity, 0)) AS RejectedQuantity,");
            sb.AppendLine($"");
            sb.AppendLine($"            (");
            sb.AppendLine($"                SUM(ISNULL(iri.Quantity, 0))");
            sb.AppendLine($"                /");
            sb.AppendLine($"                NULLIF(");
            sb.AppendLine($"                    SUM(SUM(ISNULL(iri.Quantity, 0))) OVER(),");
            sb.AppendLine($"                    0");
            sb.AppendLine($"                )");
            sb.AppendLine($"            ) * 100 AS Percentage");
            sb.AppendLine($"");
            sb.AppendLine($"        FROM Erp_InventoryReceiptItem iri WITH(NOLOCK)");
            sb.AppendLine($"");
            sb.AppendLine($"        LEFT JOIN Erp_QualityControl qc WITH(NOLOCK)");
            sb.AppendLine($"            ON qc.InventoryReceiptItemId = iri.RecId");
            sb.AppendLine($"");
            sb.AppendLine($"        LEFT JOIN Erp_InventoryReceipt ir WITH(NOLOCK)");
            sb.AppendLine($"            ON ir.RecId = iri.InventoryReceiptId");
            sb.AppendLine($"");
            sb.AppendLine($"        LEFT JOIN Erp_Inventory i WITH(NOLOCK)");
            sb.AppendLine($"            ON i.RecId = iri.InventoryId");
            sb.AppendLine($"");
            sb.AppendLine($"        LEFT JOIN Erp_CurrentAccount cu WITH(NOLOCK)");
            sb.AppendLine($"            ON cu.RecId = ir.CurrentAccountId");
            sb.AppendLine($"");
            sb.AppendLine($"        WHERE ir.CompanyId = 22");
            sb.AppendLine($"          AND i.InventoryCode LIKE '1010%'");
            sb.AppendLine($"          AND ir.ReceiptDate >= '{startDate}'");
            sb.AppendLine($"          AND ir.ReceiptDate < DATEADD(DAY, 1, '{endDate}')");
            sb.AppendLine($"          AND ir.ReceiptType = 1");
            sb.AppendLine($"          AND ir.IsCancelled = 0");
            sb.AppendLine($"          AND (i.InventoryName LIKE 'A%' OR i.InventoryName LIKE 'H%')");
            sb.AppendLine($"");
            sb.AppendLine($"        GROUP BY");
            sb.AppendLine($"            cu.CurrentAccountName,");
            sb.AppendLine($"            i.InventoryCode,");
            sb.AppendLine($"            i.InventoryName");
            sb.AppendLine($"");
            sb.AppendLine($"        ORDER BY");
            sb.AppendLine($"            TotalQuantity DESC;");
            return sb.ToString();
        }

        public Task<SentezIntegrationsResponsoDto<SupplierDashboardTrendDto>> GetSupplierTrend(DateTime startDate, DateTime endDate)
        {
            var result = GetSupplierTrendQuery(startDate, endDate);
            return _sentez.ExecuteQueryAsync<SupplierDashboardTrendDto>(result);
        }

        private string GetSupplierTrendQuery(DateTime startDate, DateTime endDate)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"SELECT");
            sb.AppendLine($"            CAST(ir.ReceiptDate AS DATE) AS [Date],");
            sb.AppendLine($"");
            sb.AppendLine($"            ISNULL(cu.CurrentAccountName, 'Bilinmeyen') AS SupplierName,");
            sb.AppendLine($"");
            sb.AppendLine($"            SUM(ISNULL(iri.Quantity, 0)) AS TotalQuantity,");
            sb.AppendLine($"");
            sb.AppendLine($"            SUM(ISNULL(qc.UD_InvoiceQuantity, 0)) AS NetQuantity,");
            sb.AppendLine($"");
            sb.AppendLine($"            SUM(ISNULL(qc.ApprovedQuantity, 0)) AS ApprovedQuantity,");
            sb.AppendLine($"");
            sb.AppendLine($"            SUM(ISNULL(qc.RejectedQuantity, 0)) AS RejectedQuantity,");
            sb.AppendLine($"");
            sb.AppendLine($"            SUM(ISNULL(iri.ReturnedQuantity, 0)) AS ReturnedQuantity,");
            sb.AppendLine($"");
            sb.AppendLine($"            SUM(");
            sb.AppendLine($"                ISNULL(qc.UD_MoistureWaste, 0)");
            sb.AppendLine($"                + ISNULL(qc.UD_GarbageWaste, 0)");
            sb.AppendLine($"            ) AS TotalDeduction,");
            sb.AppendLine($"");
            sb.AppendLine($"            (");
            sb.AppendLine($"                SUM(");
            sb.AppendLine($"                    ISNULL(qc.UD_MoistureWaste, 0)");
            sb.AppendLine($"                    + ISNULL(qc.UD_GarbageWaste, 0)");
            sb.AppendLine($"                )");
            sb.AppendLine($"                /");
            sb.AppendLine($"                NULLIF(");
            sb.AppendLine($"                    SUM(ISNULL(iri.Quantity, 0)),");
            sb.AppendLine($"                    0");
            sb.AppendLine($"                )");
            sb.AppendLine($"            ) * 100 AS DeductionRate");
            sb.AppendLine($"");
            sb.AppendLine($"        FROM Erp_InventoryReceiptItem iri WITH(NOLOCK)");
            sb.AppendLine($"");
            sb.AppendLine($"        LEFT JOIN Erp_QualityControl qc WITH(NOLOCK)");
            sb.AppendLine($"            ON qc.InventoryReceiptItemId = iri.RecId");
            sb.AppendLine($"");
            sb.AppendLine($"        LEFT JOIN Erp_InventoryReceipt ir WITH(NOLOCK)");
            sb.AppendLine($"            ON ir.RecId = iri.InventoryReceiptId");
            sb.AppendLine($"");
            sb.AppendLine($"        LEFT JOIN Erp_Inventory i WITH(NOLOCK)");
            sb.AppendLine($"            ON i.RecId = iri.InventoryId");
            sb.AppendLine($"");
            sb.AppendLine($"        LEFT JOIN Erp_CurrentAccount cu WITH(NOLOCK)");
            sb.AppendLine($"            ON cu.RecId = ir.CurrentAccountId");
            sb.AppendLine($"");
            sb.AppendLine($"        WHERE ir.CompanyId = 22");
            sb.AppendLine($"          AND i.InventoryCode LIKE '1010%'");
            sb.AppendLine($"          AND ir.ReceiptDate >= '{startDate}'");
            sb.AppendLine($"          AND ir.ReceiptDate < DATEADD(DAY, 1, '{endDate}')");
            sb.AppendLine($"          AND ir.ReceiptType = 1");
            sb.AppendLine($"          AND ir.IsCancelled = 0");
            sb.AppendLine($"          AND (i.InventoryName LIKE 'A%' OR i.InventoryName LIKE 'H%')");
            sb.AppendLine($"");
            sb.AppendLine($"        GROUP BY");
            sb.AppendLine($"            CAST(ir.ReceiptDate AS DATE),");
            sb.AppendLine($"            cu.CurrentAccountName");
            sb.AppendLine($"");
            sb.AppendLine($"        ORDER BY");
            sb.AppendLine($"            [Date],");
            sb.AppendLine($"            SupplierName;");
            return sb.ToString();

        }
    }
}
