using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EntityLayer.Concrete
{
    public class DB_RetentionAnalysisHead : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }



        public TimeSpan? SampleCollectionTime { get; set; }

        public TimeSpan? SampleResultTime { get; set; }

        public decimal? MachineSpeedRpm { get; set; }

        public decimal? BasisWeightGrM2 { get; set; }

        public string? ProductionType { get; set; }

        public decimal? RetentionPercent { get; set; }

        public decimal? RetentionFeedLtMin { get; set; }

        public decimal? PulpFlowLtMin { get; set; }

        public decimal? UnderScreenCaCO3 { get; set; }

        public decimal? SilicaLtHour { get; set; }

        public decimal? AtcFeedLtHour { get; set; }

        public decimal? PlydacmacFeedLtHour { get; set; }

        public decimal? PacFeedLtHour { get; set; }

        public decimal? DiscFilterPulpFlowLtMin { get; set; }

        public string? Location { get; set; }

        public string Explanation { get; set; }


        [JsonIgnore]
        public ICollection<DB_RetantionAnalysisDetail> RetantionAnalysisDetail { get; set; }

    }
}
