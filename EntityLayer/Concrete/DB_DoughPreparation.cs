using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class DB_DoughPreparation : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }



        public string PulperNo { get; set; }

        public string InventoryCode { get; set; }

        public string InventoryName { get; set; }

        public decimal QueueNo { get; set; }

        public decimal Clippings { get; set; }

        public decimal Bale { get; set; }

        public decimal KG { get; set; }


    }
}
