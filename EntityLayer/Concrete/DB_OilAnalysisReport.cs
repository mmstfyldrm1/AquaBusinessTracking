using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class DB_OilAnalysisReport : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }
        public string LocationSampleWasTaken { get; set; }

        public int Hours { get; set; } = DateTime.Now.Hour;

      


    }
}
