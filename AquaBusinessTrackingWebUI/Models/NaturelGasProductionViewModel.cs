using DTOLayer.Dtos.AdminDashboardDtos;
using DTOLayer.Dtos.NaturelGasMeterMonitoringDtos;

namespace AquaBusinessTrackingWebUI.Models
{
    public class NaturelGasProductionViewModel
    {
        public List<AdminDahboardLast7DaysStock> Production { get; set; } = new();
        public List<NaturelGasMeterMonitoringDto> NaturelGas { get; set; } = new();

        public decimal TotalGas => NaturelGas.Sum(x => x.DailyConsumption);
        public decimal TotalProduction => Production.Sum(x => x.Production);
        public decimal KwhPerTon => TotalProduction > 0
            ? Math.Round(TotalGas / TotalProduction, 2)
            : 0;

        public List<DailyGasDto> DailyStats =>
         NaturelGas
             .GroupBy(x => x.ReceiptDate.Date)
             .Select(g => new DailyGasDto
             {
                 Date = g.Key,
                 NaturelGas = g.Sum(x => x.DailyConsumption),
                 Production = Production.FirstOrDefault(p => p.Date.Date == g.Key)?.Production ?? 0,
                 KwhPerTon = Production.FirstOrDefault(p => p.Date.Date == g.Key)?.Production > 0
                     ? Math.Round(g.Sum(x => x.DailyConsumption) / Production.First(p => p.Date.Date == g.Key).Production, 2)
                     : 0
             })
             .ToList();
    }
    public class DailyGasDto
    {
        public DateTime Date { get; set; }
        public decimal Production { get; set; }
        public decimal NaturelGas { get; set; }
        public decimal KwhPerTon { get; set; }
    }


}

