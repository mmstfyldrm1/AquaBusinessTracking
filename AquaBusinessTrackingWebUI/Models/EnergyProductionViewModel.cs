using DTOLayer.Dtos.AdminDashboardDtos;
using DTOLayer.Dtos.ElectricDtos.CumulativeElectricityConsumptionDtos;

public class EnergyProductionViewModel
{
    public List<AdminDahboardDaysStock> Remaning { get; set; } = new();
    public List<CumulativeElectricityConsumptionDto> Electric { get; set; } = new();

    public decimal TotalElectricity => Electric.Sum(x => x.Consumption);
    public decimal TotalProduction => Remaning.Sum(x => x.Production);
    public decimal KwhPerkg => TotalProduction > 0
        ? Math.Round(TotalElectricity / (TotalProduction), 2)
        : 0;

    public List<DailyEnergyDto> DailyStats =>
     Electric
         .Where(x => x.ReceiptDate.Date >= DateTime.Today.AddDays(-6))
         .GroupBy(x => x.ReceiptDate.Date)
         .Select(g => new DailyEnergyDto
         {
             Date = g.Key,
             Electricity = g.Sum(x => x.Consumption),
             Production = Remaning.FirstOrDefault(p => p.Date.Date == g.Key)?.Remaning ?? 0,
             KwhPerTon = Remaning.FirstOrDefault(p => p.Date.Date == g.Key)?.Remaning > 0
                 ? Math.Round(g.Sum(x => x.Consumption) / Remaning.First(p => p.Date.Date == g.Key).Remaning, 2)
                 : 0
         })
         .ToList();

    public decimal KwhPerTons =>
    TotalProduction > 0
        ? Math.Round(TotalElectricity / (TotalProduction / 1000m), 2)
        : 0;
}

public class DailyEnergyDto
{
    public DateTime Date { get; set; }
    public decimal Production { get; set; }
    public decimal Electricity { get; set; }
    public decimal KwhPerTon { get; set; }
}