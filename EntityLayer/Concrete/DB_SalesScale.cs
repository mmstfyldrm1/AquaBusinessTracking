using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class DB_SalesScale : BaseEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }

        public DateTime ScaleDate { get; set; } = DateTime.Now;

        public DateTime ScaleHours { get; set; } = DateTime.Now;

        public decimal ScaleNo { get; set; }

        public string DeliveryNumber { get; set; }

        public string CurrentAccountName { get; set; }

        public string TruckPlate { get; set; }



        public decimal DeliveryQuantity { get; set; }

        public decimal ScaleQuantity { get; set; }

        public int? ScaleGap { get; set; } // Fark

        public string GapSuperVisior { get; set; }

        public string GapDesicion { get; set; }


    }
}
