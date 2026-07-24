using DTOLayer.Dtos.AdminDashboardDtos;
using DTOLayer.Dtos.NaturelGasMeterMonitoringDtos;

namespace AquaBusinessTrackingWebUI.Models
{
    public class NaturelGasProductionViewModel
    {
        public List<AdminDahboardLast7DaysStock> Remaning { get; set; } = new();
        public List<NaturelGasMeterMonitoringDto> NaturelGas { get; set; } = new();

        public decimal TotalGas => NaturelGas.Sum(x => x.DailyConsumption);
        public decimal TotalRemaning => Remaning.Sum(x => x.Remaning);
        public decimal KwhPerTon => TotalRemaning > 0
            ? Math.Round(TotalGas / TotalRemaning, 2)
            : 0;

        public List<DailyGasDto> DailyStats =>
         NaturelGas
             .GroupBy(x => x.ReceiptDate.Date)
             .Select(g => new DailyGasDto
             {
                 Date = g.Key,
                 NaturelGas = g.Sum(x => x.DailyConsumption),
                 Production = Remaning.FirstOrDefault(p => p.Date.Date == g.Key)?.Remaning ?? 0,
                 KwhPerTon = Remaning.FirstOrDefault(p => p.Date.Date == g.Key)?.Remaning > 0
                     ? Math.Round(g.Sum(x => x.DailyConsumption) / Remaning.First(p => p.Date.Date == g.Key).Remaning, 2)
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

