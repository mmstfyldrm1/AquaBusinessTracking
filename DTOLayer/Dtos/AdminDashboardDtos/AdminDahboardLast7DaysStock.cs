namespace DTOLayer.Dtos.AdminDashboardDtos
{
    public class AdminDahboardLast7DaysStock
    {
        public DateTime Date { get; set; }
        public decimal Production { get; set; }
        public decimal Consumable { get; set; }
        public decimal Remaning { get; set; }

    }
}
