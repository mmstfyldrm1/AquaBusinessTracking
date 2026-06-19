using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace EntityLayer.Concrete
{
    public class DB_StarchAnalysisHeadingDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RecId { get; set; }

        // Base production fields (from previous)
        public DateTime Date { get; set; }
        public TimeSpan? Time { get; set; }
        public decimal? MachineSpeed { get; set; }
        public string ProductionType { get; set; }
        public decimal? Grammage { get; set; }
        public int? TurnCount { get; set; }
        public decimal? Fau { get; set; }
        public decimal? Ntu { get; set; }

        // Dry Matter / Solid Content Measurements
        public decimal? DryMatterOven { get; set; }           // % KM ETÜV (Column 1)
        public decimal? DryMatterRefractometer { get; set; }   // %KM REFRAKTOMETRE (Column 2)

        // Temperature & Viscosity - Measurement 1
        public decimal? Temperature1 { get; set; }             // SICAKLIK °C (1)
        public decimal? ViscosityCp1 { get; set; }             // VİSKOZİTE (cp) (1)
        public int? ViscosityFord1 { get; set; }               // VİSKOZİTE (Ford) sn (4) (1)

        public int StarchAnalysisHeadingId { get; set; }

        [JsonIgnore]
        public DB_StarchAnalysisHeading StarchAnalysisHeading { get; set; }


    }
}
