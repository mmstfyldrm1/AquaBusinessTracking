using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class DB_SteamConsumption : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }

        public string Location { get; set; }

        public string Day { get; set; }



        public decimal ConsumptionQuantity { get; set; }


    }
}
