using DTOLayer.Dtos.AdminDashboardDtos;
using DTOLayer.Dtos.NaturelGasMeterMonitoringDtos;

namespace AquaBusinessTrackingWebUI.Models
{
    public class NaturelGasProductionViewModel
    {
        public List<AdminDahboardDaysStock> Remaning { get; set; } = new();
        public List<NaturelGasMeterMonitoringDto> NaturelGas { get; set; } = new();

        public decimal TotalGas => NaturelGas.Sum(x => x.StandartCubicmeter);
        public decimal TotalRemaning => Remaning.Sum(x => x.Production);
        public decimal GasPerKg => TotalRemaning > 0 ? Math.Round(TotalGas / TotalRemaning, 2) : 0;



        public List<DailyGasDto> DailyStats => NaturelGas
             .GroupBy(x => x.ReceiptDate.Date)
             .Select(g => new DailyGasDto
             {
                 Date = g.Key,
                 NaturelGas = g.Sum(x => x.StandartCubicmeter),
                 Production = Remaning.FirstOrDefault(p => p.Date.Date == g.Key)?.Remaning ?? 0,
                 GasPerKg = Remaning.FirstOrDefault(p => p.Date.Date == g.Key)?.Remaning > 0 ? Math.Round(g.Sum(x => x.StandartCubicmeter) / Remaning.First(p => p.Date.Date == g.Key).Remaning, 2) : 0
             }).ToList();
        public decimal GasPerTon => TotalRemaning > 0 ? Math.Round(TotalGas / (TotalRemaning / 1000m), 2) : 0;
    }
    public class DailyGasDto
    {
        public DateTime Date { get; set; }
        public decimal Production { get; set; }
        public decimal NaturelGas { get; set; }
        public decimal GasPerKg { get; set; }
    }


}

