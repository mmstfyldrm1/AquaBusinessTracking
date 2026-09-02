using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class DB_KazanEnergyConsumption : BaseEntity
    {
        [Key]
        public int RecId { get; set; }

        public string ConsumptionPlace { get; set; }

        public string? ConsumptionUnit { get; set; }

        public string? Explanation { get; set; }

        public virtual ICollection<DB_BoilerOperationandChemicalConsumption> BoilerOperationandChemicalConsumption { get; set; } = new List<DB_BoilerOperationandChemicalConsumption>();

    }
}
