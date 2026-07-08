using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public class DB_DoughPreparationAnalysisResults : BaseEntity
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }

        public int SampleCollectionTime { get; set; }

        public int SampleResultDeliveryTime { get; set; }

        public string SampleTakenLocation { get; set; }

        public float KM { get; set; }

        public int SR { get; set; }

        public int DryMatter { get; set; }

        public float pH { get; set; }

        public int Conductivity { get; set; }

        public int CaCO3 { get; set; }

        public float Filling { get; set; }

        public int Blur { get; set; }

        public string Explanation { get; set; }


    }
}
