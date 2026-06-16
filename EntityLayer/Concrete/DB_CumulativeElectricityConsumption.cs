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
        public DateTime Date { get; set; } = DateTime.Now;

        public DateTime? InsertedDate { get; set; }

        public DateTime? DeleteDate { get; set; }

        public DateTime? UpdateDate { get; set; }
        public int ElectricMeterLocationId { get; set; }
        public DB_ElectricMeterLocation ElectricMeterLocation { get; set; }

        public int DepartmanId { get; set; }

        public DB_Department Department { get; set; }


    }
}
