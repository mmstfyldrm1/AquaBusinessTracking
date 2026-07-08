using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class DB_CumulativeElectricityConsumption : BaseEntity
    {
        [Key]
        public int RecId { get; set; }
        public int Year { get; set; } = DateTime.Now.Year;
        public int Month { get; set; } = DateTime.Now.Month;

        public decimal Consumption { get; set; }



        public int ElectricMeterLocationId { get; set; }
        public DB_ElectricMeterLocation ElectricMeterLocation { get; set; }

    }
}
