using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class DB_KazanChemicalsHead : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }

        public string InventoryCode { get; set; }
        public string InventoryName { get; set; }

        public string? Day { get; set; }



        public decimal Incoming { get; set; }

        public decimal Consumption { get; set; }

        public decimal Remaining { get; set; }


    }
}
