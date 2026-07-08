using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class DB_PapperMachineChemical : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }

        public string InventoryCode { get; set; }

        public string InventoryName { get; set; }

        public decimal IncomingQuantity { get; set; }

        public decimal ConsumedQuantity { get; set; }

        public decimal RemainingQuantity { get; set; }



    }
}
