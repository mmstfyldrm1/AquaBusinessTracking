using System.ComponentModel.DataAnnotations;

namespace EntityLayer.Concrete
{
    public class DB_BoilerOperationandChemicalConsumption : BaseEntity
    {
        [Key]
        public int RecId { get; set; }

        public string? Explanation { get; set; }

        public int ConsumptionPlaceId { get; set; }

        public int ScalePlaceId { get; set; }
        public decimal ConsumptionQuantity { get; set; }
        public virtual DB_KazanEnergyConsumption KazanEnergyConsumption { get; set; }

        public DB_Department? ScalePlace { get; set; }





    }
}
