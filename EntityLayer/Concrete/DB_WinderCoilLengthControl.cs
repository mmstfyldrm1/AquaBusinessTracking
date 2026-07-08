using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class DB_WinderCoilLengthControl : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }

        public decimal CoilWidth { get; set; }

        public decimal WinderCoilLength { get; set; }

        public decimal Gramaj { get; set; }

        public decimal Weight { get; set; }

        public decimal TheoreticCoilLength { get; set; }

        public decimal CoilLengthDifference { get; set; }
        public decimal CoilLengthDeflection { get; set; } // Sapma





    }
}
