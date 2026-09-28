using DTOLayer.Dtos.Integrations;
using DTOLayer.Dtos.SentezIntegrationsDtos.SentezIntegrationProductionDtos;

namespace AquaBusinessTrackingWebUI.Models
{
    public class DetailProductionViewModel
    {
        public List<PlcReadingDto> PlcReading { get; set; }
        public List<SentezIntegrationsGetCombineDetailsDto> SentezIntegrationsGetCombineDetails { get; set; }
        public List<SentezIntegrationsGetProductionDetailsDto> SentezIntegrationsGetProductionDetails { get; set; }

        public ProductionSummaryVm Summary { get; set; }
        public List<TamponCutNodeVm> TamponCutTree { get; set; }
        public List<SentezIntegrationsGetProductionDetailsDto> WaitingTampons { get; set; }


        public List<SentezIntegrationsGetProductionDetailsDto> AllBobinList { get; set; }


        public List<SentezIntegrationsGetProductionDetailsDto> UnmatchedBobinList { get; set; }
    }

    public class ProductionSummaryVm
    {
        public int TotalPlc { get; set; }
        public int TotalCombine { get; set; }
        public int TotalProd { get; set; }
        public decimal TotalCombineQty { get; set; }
        public decimal TotalProdQty { get; set; }
        public int ActiveSets { get; set; }

        public int TamponCount { get; set; }
        public decimal TamponQty { get; set; }
        public int TamponSets { get; set; }
        public decimal StrapCompletionPercent { get; set; }

        public int BobinCount { get; set; }
        public decimal BobinQty { get; set; }
        public int BobinSets { get; set; }
        public decimal WrapCompletionPercent { get; set; }

        public decimal CuttingYieldPercent { get; set; }
        public decimal FireLossQty { get; set; }
        public decimal FireLossPercent { get; set; }
        public decimal WaitingRatioPercent { get; set; }
        public decimal PlanActualPercent { get; set; }
        public double AvgResourceSpeed { get; set; }
        public double AvgCycleMinutes { get; set; }
    }

    public class TamponCutNodeVm
    {
        public SentezIntegrationsGetProductionDetailsDto Tampon { get; set; }
        public List<SentezIntegrationsGetProductionDetailsDto> Bobinler { get; set; }
        public decimal NodeYieldPercent { get; set; }
        public int BobinCount => Bobinler?.Count ?? 0;
        public decimal BobinQtySum => Bobinler?.Sum(b => b.Quantity ?? 0) ?? 0;

    }
}
