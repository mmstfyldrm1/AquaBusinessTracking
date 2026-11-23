using DTOLayer.Dtos.AdminDashboardDtos;
using DTOLayer.Dtos.BoilerSteamFeedWaterCondensateDataDtos;

namespace AquaBusinessTrackingWebUI.Models
{
    public class BoilerProductionViewModel
    {
        public List<AdminDahboardDaysStock> Remaning { get; set; } = new();
        public List<BoilerSteamFeedWaterCondensateDataDto> Boiler { get; set; } = new();

        public decimal TotalBoil => Boiler.Sum(x => x.Boil);
        public decimal TotalProduction => Remaning.Sum(x => x.Production);
        public decimal BoilPerkg => TotalProduction > 0
            ? Math.Round(TotalBoil / (TotalProduction), 2)
            : 0;

        public List<DailyBoilDto> DailyStats =>
         Boiler
             .Where(x => x.ReceiptDate.Date >= DateTime.Today.AddDays(-6))
             .GroupBy(x => x.ReceiptDate.Date)
             .Select(g => new DailyBoilDto
             {
                 Date = g.Key,
                 TotalBoiler = Boiler.Sum(x => x.Boil),
                 Production = Remaning.FirstOrDefault(p => p.Date.Date == g.Key)?.Remaning ?? 0,
                 BoilPerTons = Remaning.FirstOrDefault(p => p.Date.Date == g.Key)?.Remaning > 0
                     ? Math.Round(Boiler.Sum(x => x.Boil) / Remaning.First(p => p.Date.Date == g.Key).Remaning, 2)
                     : 0
             })
             .ToList();

        public decimal BoilPerTons =>
        TotalProduction > 0
            ? Math.Round(TotalBoil / (TotalProduction / 1000m), 2)
            : 0;
    }
    public class DailyBoilDto
    {
        public DateTime Date { get; set; }
        public decimal Production { get; set; }
        public decimal TotalBoiler { get; set; }
        public decimal BoilPerTons { get; set; }
    }


}

