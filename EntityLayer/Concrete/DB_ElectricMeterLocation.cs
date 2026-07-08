using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class DB_ElectricMeterLocation : BaseEntity
    {
        [Key]
        public int RecId { get; set; }

        public string LocationName { get; set; }

        public string? Explanation { get; set; }

        public ICollection<DB_CumulativeElectricityConsumption> CumulativeElectricityConsumption { get; set; }

    }
}
