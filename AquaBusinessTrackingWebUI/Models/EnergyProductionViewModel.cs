using DTOLayer.Dtos.AdminDashboardDtos;
using DTOLayer.Dtos.ElectricDtos.CumulativeElectricityConsumptionDtos;

public class EnergyProductionViewModel
{
    public List<AdminDahboardLast7DaysStock> Production { get; set; } = new();
    public List<CumulativeElectricityConsumptionDto> Electric { get; set; } = new();

    public decimal TotalElectricity => Electric.Sum(x => x.Consumption);
    public decimal TotalProduction => Production.Sum(x => x.Production);
    public decimal KwhPerTon => TotalProduction > 0
        ? Math.Round(TotalElectricity / TotalProduction, 2)
        : 0;

    public List<DailyEnergyDto> DailyStats =>
     Electric
         .GroupBy(x => x.ReceiptDate.Date)
         .Select(g => new DailyEnergyDto
         {
             Date = g.Key,
             Electricity = g.Sum(x => x.Consumption),
             Production = Production.FirstOrDefault(p => p.Date.Date == g.Key)?.Production ?? 0,
             KwhPerTon = Production.FirstOrDefault(p => p.Date.Date == g.Key)?.Production > 0
                 ? Math.Round(g.Sum(x => x.Consumption) / Production.First(p => p.Date.Date == g.Key).Production, 2)
                 : 0
         })
         .ToList();
}

public class DailyEnergyDto
{
    public DateTime Date { get; set; }
    public decimal Production { get; set; }
    public decimal Electricity { get; set; }
    public decimal KwhPerTon { get; set; }
}