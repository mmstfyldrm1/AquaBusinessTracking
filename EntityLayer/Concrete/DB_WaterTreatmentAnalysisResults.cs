using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class DB_WaterTreatmentAnalysisResults : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }

        public int SampleCollectionTime { get; set; }

        public int SampleResultDeliveryTime { get; set; }

        public string SampleTakenLocation { get; set; }

        public int DryMatter { get; set; }
        public float Filling { get; set; }
        public string Explanation { get; set; }


    }
}
