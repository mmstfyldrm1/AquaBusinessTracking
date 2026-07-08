using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EntityLayer.Concrete
{
    public class DB_StarchAnalysisHeading : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }
        public int SampleCollectionTime { get; set; }

        public int SampleResultDeliveryTime { get; set; }
        public string Explanation { get; set; }

        public string Location { get; set; }



        [JsonIgnore]
        public ICollection<DB_StarchAnalysisHeadingDetail> StarchAnalysisHeadingDetails { get; set; }




    }
}
