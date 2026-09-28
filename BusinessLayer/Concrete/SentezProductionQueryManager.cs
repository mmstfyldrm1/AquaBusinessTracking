using BusinessLayer.Abstract;
using BusinessLayer.Abstract.Integrations;
using DTOLayer.Dtos.SentezIntegrationsDtos.SentezIntegrationProductionDtos;
using DTOLayer.Dtos.SentezProductionDtos;
using System.Text;

namespace BusinessLayer.Concrete
{
    public class SentezProductionQueryManager : ISentezProductionQueryService
    {
        private readonly ISentezIntegrationsService _service;

        public SentezProductionQueryManager(ISentezIntegrationsService service)
        {
            _service = service;
        }

        public async Task<SentezIntegrationsResponsoDto<SentezIntegrationsGetCombineDetailsDto>?> GetProductionCombination()
        {
            var query = BuildGetProductionCombinationQuery();
            return await _service.ExecuteQueryAsync<SentezIntegrationsGetCombineDetailsDto>(query);

        }

        public async Task<SentezIntegrationsResponsoDto<SentezIntegrationsGetProductionDetailsDto>?> GetProductionDetails()
        {
            var query = BuildGetProductionDetailsQuery();
            return await _service.ExecuteQueryAsync<SentezIntegrationsGetProductionDetailsDto>(query);
        }

        private string BuildGetProductionDetailsQuery()
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");

            var sb = new StringBuilder();
            sb.AppendLine($"select");
            sb.AppendLine($"cr.RecId [RecId]");
            sb.AppendLine($",cr.ParentId [ParentId]");
            sb.AppendLine($",cr.ReceiptDate [ReceiptDate]");
            sb.AppendLine($",cr.StartTime [StartTime]");
            sb.AppendLine($",cr.EndTime [EndTime]");
            sb.AppendLine($",isc.SerialCode [SerialCode]");
            sb.AppendLine($",isc.Quantity [Quantity]");
            sb.AppendLine($",i.InventoryCode [InventoryCode]");
            sb.AppendLine($",i.InventoryName [InventoryName]");
            sb.AppendLine($",isc.WidthCM [WidthCM]");
            sb.AppendLine($",cr.CombinationNo [CombinationNo]");
            sb.AppendLine($",cr.Explanation [Explanation]");
            sb.AppendLine($",e.EmployeeName [EmployeeName]");
            sb.AppendLine($",cr.ResourceSpeed [ResourceSpeed]");
            sb.AppendLine($"--,cr.UD_Vardiya [UD_Vardiya]");
            sb.AppendLine($",wo.WorkOrderNo [WorkOrderNo]");
            sb.AppendLine($",wo.DeliveryDate [DeliveryDate]");
            sb.AppendLine($",isc.IsStrapping [IsStrapping]");
            sb.AppendLine($",isc.IsWrapping [IsWrapping]");
            sb.AppendLine($",isc.[StopperAt]");
            sb.AppendLine($",isc.LabelAt [LabelAt]");
            sb.AppendLine($",isc.WarehouseAt [WarehouseAt]");
            sb.AppendLine($",isc.ManufactureReceiptId [ManufactureReceiptId]");
            sb.AppendLine($",isc.ConsumptionReceiptId [ConsumptionReceiptId]");
            sb.AppendLine($",isc.SetNumber [SetNumber]");
            sb.AppendLine($",isc.SetPosition [SetPosition]");
            sb.AppendLine($"");
            sb.AppendLine($"from Erp_InventorySerialCard isc with(nolock) ");
            sb.AppendLine($"left join Erp_CombinationReceipt cr with(nolock) on cr.RecId = isc.CombinationReceiptId");
            sb.AppendLine($"left join Erp_Inventory i with(nolock) on i.RecId = isc.InventoryId");
            sb.AppendLine($"left join Erp_Employee e with(nolock) on e.RecId = cr.EmployeeId");
            sb.AppendLine($"left join Erp_WorkOrder wo with(nolock) on wo.RecId = isc.WorkOrderId");
            sb.AppendLine($"where (i.InventoryCode like '8%' or i.InventoryCode like '9%') and isc.CompanyId=22 and isc.SerialCode not like'E%' and cr.ReceiptDate='{date}'");
            sb.AppendLine($"");
            sb.AppendLine($"order by isc.RecId desc");
            sb.AppendLine($"");
            sb.AppendLine($" ");
            return sb.ToString();
        }

        private string BuildGetProductionCombinationQuery()
        {
            var dateTime = DateTime.Now.ToString("yyyy-MM-dd");
            var sb = new StringBuilder();
            sb.AppendLine($"Select ");
            sb.AppendLine($"cr.ReceiptDate [ReceiptDate],");
            sb.AppendLine($"p.CombinationNo [CombinationNo],");
            sb.AppendLine($"p.AssignedResources [AssignedResources],");
            sb.AppendLine($"i.InventoryName [InventoryName],");
            sb.AppendLine($"p.Quantity [Quantity],");
            sb.AppendLine($"p.FinishDailyQuantity [FinishDailyQuantity]");
            sb.AppendLine($"");
            sb.AppendLine($"");
            sb.AppendLine($"");
            sb.AppendLine($"from Erp_Planning p with(nolock)");
            sb.AppendLine($"left join Erp_CombinationReceipt cr with(nolock) on cr.RecId = p.CombinationReceiptId");
            sb.AppendLine($"left join Erp_Inventory i with(nolock) on i.RecId = p.InventoryId");
            sb.AppendLine($"left join Erp_WorkOrder wo with(nolock) on wo.RecId = p.WorkOrderId");
            sb.AppendLine($"where FinishDailyQuantity is not null and i.CompanyId=22 and cr.ReceiptDate ='{dateTime}'");
            sb.AppendLine($"");
            sb.AppendLine($"order by p.RecId desc");
            sb.AppendLine($"");

            return sb.ToString();
        }
    }
}
