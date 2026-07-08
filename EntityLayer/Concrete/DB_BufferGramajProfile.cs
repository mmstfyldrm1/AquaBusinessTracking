using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class DB_BufferGramajProfile : BaseEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }

        public decimal BufferNo { get; set; }

        public int SampleNo { get; set; }

        public int Gramaj { get; set; }
        public int Thickness { get; set; }

    }
}
