namespace AIAgent.Models.Production
{
    public class DailyProductionDto
    {
        public DateTime Date { get; set; }
        public decimal Consumable { get; set; }
        public decimal Production { get; set; }
        public decimal Remaning { get; set; }
    }
}
